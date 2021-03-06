using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float maxDelay = 0.5f;          //delay maximo del enemigo en empezar a perseguirte
    [SerializeField]
    public float defaultSpeed;              //velocidad por defecto en la persecucion
    [SerializeField]
    private List<Transform> waypoints;      //lista de waypoints de la patrulla
    [SerializeField]
    private Transform patrolTF;             //contenedor de los puntos de patrulla
    
    public Transform playerTF;              //transform del jugador
    public NavMeshAgent agent;              //agente del enemigo
        
    private float currentDelay = 0;     
    private int index = 0;                  //inicio de indice para al patrulla aleatoria

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
        if (agent.remainingDistance < 0.5f && !agent.pathPending)   //si el agente esta a menos de dicha distancia de su objetivo y no tiene un objetivo pendiente
        {
            currentDelay += Time.deltaTime;     //delay con el tiempo de juego
            if (currentDelay > maxDelay)        //se resetea cada vez que llega a un destino y procede al siguiente
            {
                currentDelay = 0;
                MoveNextWp();                
            }
        }
    }
    /// <summary>
    /// Inicializa la lista de waypoints en el transform donde se ecuentran en la jerarquia.
    /// </summary>
    void InitializeWp()
    {
        foreach (Transform wp in patrolTF)
        {
            waypoints.Add(wp);
        }
    }
    /// <summary>
    /// Se mueve al siguiente waypoint, dicho waypoint se elige de manera aleatoria.
    /// </summary>
    public void MoveNextWp()
    {
        if (waypoints.Count == 0)
        {
            return;
        }
        agent.SetDestination(waypoints[index].position);    
        index = Random.Range(0, waypoints.Count);   //random del waypoint de la lista de la patrulla correspondiente
    }
}
