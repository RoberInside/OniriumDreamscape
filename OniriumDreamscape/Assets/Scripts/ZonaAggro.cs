using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAggro : MonoBehaviour
{    
    [SerializeField]
    private float minDistSpeed;
    [SerializeField]
    private List<EnemyBehaviour> enemyBSC;

    public Transform enemiesTF;
    

    // Start is called before the first frame update
    void Start()
    {
        enemiesTF = GameObject.Find("Enemigos").transform;
        InitializeZoneEneimes();        
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < enemyBSC.Count; i++)
        {
            if (other.GetComponent<PlayerController>())
            {
                enemyBSC[i].agent.SetDestination(enemyBSC[i].playerTF.position);
                if (enemyBSC[i].agent.remainingDistance > minDistSpeed)
                {
                    enemyBSC[i].agent.speed = 10.0f;
                }
                else if (enemyBSC[i].agent.remainingDistance < minDistSpeed)
                {
                    enemyBSC[i].agent.speed = enemyBSC[i].defaultSpeed;
                }
                //Debug.Log("detectado");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            for (int i = 0; i < enemyBSC.Count; i++)
            {
                enemyBSC[i].MoveNextWp();
                enemyBSC[i].agent.speed = enemyBSC[i].defaultSpeed;
            }

        }
    }
    void InitializeZoneEneimes()
    {
        foreach (Transform en in enemiesTF)
        {
            enemyBSC.Add(en.GetComponent<EnemyBehaviour>());
        }
    }
}
