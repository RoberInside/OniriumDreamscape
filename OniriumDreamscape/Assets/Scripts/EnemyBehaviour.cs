using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float maxDelay = 0.5f;
    public Transform playerTF;
    public Transform patrolTF;
    public NavMeshAgent agent;
    public float defaultSpeed;
    

    public List<Transform> waypoints;

    [SerializeField]
    private float currentDelay = 0;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTF = GameObject.FindGameObjectWithTag("Player").transform;
        defaultSpeed = 3.5f;

        InitializeWp();
        MoveNextWp();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            currentDelay += Time.deltaTime;
            if (currentDelay > maxDelay)
            {
                currentDelay = 0;
                MoveNextWp();                
            }
        }
    }
    void InitializeWp()
    {
        foreach (Transform wp in patrolTF)
        {
            waypoints.Add(wp);
        }
    }
    public void MoveNextWp()
    {
        if (waypoints.Count == 0)
        {
            return;
        }
        agent.SetDestination(waypoints[index].position);
        index = Random.Range(0, waypoints.Count);
    }
}
