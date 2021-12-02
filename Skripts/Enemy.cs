using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : Character
{
   private NavMeshAgent _navMeshAgent;

   [SerializeField] private float shootDelay = 1f;

    [SerializeField] private GameObject explosionPrefab;
    private void Awake()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        InvokeRepeating("ShootEnemy", 0.0f, shootDelay);
    }

    private void Update()
    {
        ShootEnemy(); 
        if (target != null)
        {
            _navMeshAgent.SetDestination(target.position);
            CheckTargetVisibility();
        }
    }

    private void CheckTargetVisibility()
    {

        Vector3 targetDirection = target.position - gun.transform.position;

        Ray ray = new Ray(gun.transform.position, targetDirection);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == target)
            {
                seeTarget = true;
                return;
            }
        }

        seeTarget = false;

    }

    public void Destroyed()
    {
        if (explosionPrefab != null)
        {
            Explosion.Create(transform.position, explosionPrefab);
        }
        HealthBonus.Create(transform.position);
       
        if (UnityEngine.Random.Range(0, 100) < 50)
        {
            HealthBonus.Create(transform.position);
	    }
        ScoreLabel.score += 25;
    }

}
