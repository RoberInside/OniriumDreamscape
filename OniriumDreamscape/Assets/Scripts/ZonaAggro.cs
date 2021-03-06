using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase hace que la lista de enemigos asociados que puedan llegar al jugador
/// mediante el agente en el trigger de la zona aggro le persigan hasta que salga de dicha zona
/// </summary>
public class ZonaAggro : MonoBehaviour
{   
    /// <summary>
    /// Distancia minima a la que reduce la velocidad a la velocidad base para que no sea imposible de esquivar.
    /// </summary>
    [SerializeField]
    private float minDistSpeed;
    /// <summary>
    /// Lista de enemigos que hay en la escena y que persiguen al jugador.
    /// </summary>
    [SerializeField]
    private List<EnemyBehaviour> enemyBSC;

    /// <summary>
    /// Transform del objeto en la jerarquia que contiene a los enemigos
    /// </summary>
    public Transform enemiesTF;
    
    void Start()
    {
        enemiesTF = GameObject.Find("Enemigos").transform;
        InitializeZoneEneimes();        
    }
    /// <summary>
    /// Si el jugador Se queda en dicho trigger, lo enemigos iran a por el hasat que salga y reanudaran la patrulla aleatoria.
    /// </summary>    
    private void OnTriggerStay(Collider other)          
    {
        for (int i = 0; i < enemyBSC.Count; i++)
        {
            if (other.GetComponent<PlayerController>())
            {
                enemyBSC[i].agent.SetDestination(enemyBSC[i].playerTF.position);
                if (enemyBSC[i].agent.remainingDistance > minDistSpeed)             //si el jugador esta a mas disancia que la minima el enemigo 
                                                                                    //ira mas rapido hasta acortar dicha distancia
                {
                    enemyBSC[i].agent.speed = 10.0f;
                }
                else if (enemyBSC[i].agent.remainingDistance < minDistSpeed)        //si esta a menos distancia vuelve a la velocidad normal
                {
                    enemyBSC[i].agent.speed = enemyBSC[i].defaultSpeed;
                }
               
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())             //si sale del aggro los enemigos dejan de perseguir
        {
            for (int i = 0; i < enemyBSC.Count; i++)
            {
                enemyBSC[i].MoveNextWp();
                enemyBSC[i].agent.speed = enemyBSC[i].defaultSpeed;
            }
        }
    }
    void InitializeZoneEneimes()                            //inicializa la zona encontrando a los enemigos y añadiendolos a 
                                                            //la lista de enemigos para que detecten si el jugador ha entrado en la zona
    {
        foreach (Transform en in enemiesTF)
        {
            enemyBSC.Add(en.GetComponent<EnemyBehaviour>());
        }
    }
}
