using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform playerTF;
    public Transform patrolTF;

    public List<Transform> _waypointsDest;

    [SerializeField]
    public NavMeshAgent _agent;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTF = GameObject.Find("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();        
        InitializeWp();
        MoveNextWp();
    }

    // Update is called once per frame
    void Update()
    {
        MoveNextWp();
    }
    void InitializeWp()
    {
        foreach (Transform transform in _waypointsDest)
        {
            _waypointsDest.Add(transform);
        }
    }
    void MoveNextWp()
    {
        _agent.SetDestination(_waypointsDest[index].position);
        index = Random.Range(0, _waypointsDest.Count);
    }
}
