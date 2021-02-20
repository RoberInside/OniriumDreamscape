using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAggro : MonoBehaviour
{    
    [SerializeField]
    private float minDistSpeed;
    [SerializeField]
    private EnemyBehaviour enemyBSC;
    

    // Start is called before the first frame update
    void Start()
    {        
        enemyBSC = FindObjectOfType<EnemyBehaviour>();        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            enemyBSC.agent.SetDestination(enemyBSC.playerTF.position);
            if (enemyBSC.agent.remainingDistance > minDistSpeed)
            {
                enemyBSC.agent.speed = 10.0f;
            }
            else if (enemyBSC.agent.remainingDistance < minDistSpeed)
            {
                enemyBSC.agent.speed = enemyBSC.defaultSpeed;
            }
            //Debug.Log("detectado");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            enemyBSC.MoveNextWp();
            enemyBSC.agent.speed = enemyBSC.defaultSpeed;          
            
        }
    }
}
