using System;
using UnityEngine;
using UnityEngine.AI;


public class EnemyWayPoint : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    private Transform target;
    public Transform[] wayPoint;
    private int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        MoveToWayPoint();
    }

    private void MoveToWayPoint()
    {
        target = wayPoint[index];

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if ((transform.position - playerTransform.position).magnitude < 3)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            navMeshAgent.SetDestination(target.position);

            if ((transform.position - target.position).magnitude < 0.1f)
            {
                index++;
                if (index >= wayPoint.Length)
                {
                    index = 0;
                    MoveToWayPoint();
                }
                else
                {
                    MoveToWayPoint();
                }
            }
        }
    }




void Update()
    {
        
    }
}
