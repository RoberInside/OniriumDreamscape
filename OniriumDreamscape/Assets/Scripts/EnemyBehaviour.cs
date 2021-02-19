using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public float maxDelay = 0.5f;
    public Transform playerTF;
    public Transform patrolTF;
    //public Collider zonaggro;

    public List<Transform> waypoints;

    [SerializeField]
    public NavMeshAgent _agent;
    private float currentDelay = 0;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        playerTF = GameObject.FindGameObjectWithTag("Player").transform;
        //zonaggro = GameObject.Find("ZonaAggro").GetComponent<Collider>();
        InitializeWp();
        MoveNextWp();
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent.remainingDistance < 0.5f && !_agent.pathPending)
        {
            currentDelay += Time.deltaTime;
            if (currentDelay > maxDelay)
            {
                currentDelay = 0;
                MoveNextWp();                
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        //other = zonaggro;
        if (other.CompareTag("Player"))
        {
            _agent.SetDestination(playerTF.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            MoveNextWp();
            Debug.Log("Jugador perdido");
        }
    }
    void InitializeWp()
    {
        foreach (Transform wp in patrolTF)
        {
            waypoints.Add(wp);
        }
    }
    void MoveNextWp()
    {
        if (waypoints.Count == 0)
        {
            return;
        }
        _agent.SetDestination(waypoints[index].position);
        index = Random.Range(0, waypoints.Count);
    }
}
