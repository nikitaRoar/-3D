using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private GameObject owner;
    [SerializeField] private float radius;
    public GameObject Owner { get => owner; set => owner = value; }

    [SerializeField] private GameObject explosionPrefab;


    [SerializeField] private float damage;


    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!GameObject.Equals(collision.gameObject, Owner))
        {

            if (radius > 0)
            {
                CauseExplosionDamage();
            }
            else
            {
                Destructable target = collision.gameObject.GetComponent<Destructable>();
                if (target != null)
                {
                    target.Hit(Damage);

                }
                if (explosionPrefab != null)
                {
                    Explosion.Create(transform.position, explosionPrefab);
                }
                ParticleSystem trail = gameObject.GetComponentInChildren<ParticleSystem>();

                if (trail != null)
                {
                    Destroy(trail.gameObject, trail.startLifetime);

                    trail.Stop();

                    trail.transform.SetParent(null);
                }
                //if (radius == 0.0f)
                //{
                //    target.Hit(Damage);
                //}


                Destroy(gameObject);
            }
        }
    }
    private void CauseExplosionDamage()
    {
        Collider[] explosionVictims = Physics.OverlapSphere(transform.position, radius);


        int i = 0;
        Vector3 vectorToVictim = explosionVictims[i].transform.position - transform.position;

        float decay = 1 - (vectorToVictim.magnitude / radius);
        Destructable currentVictim = explosionVictims[i].gameObject.GetComponent<Destructable>();
        if (currentVictim != null)
        {
            currentVictim.Hit(damage * decay);
        }
        Rigidbody victimRigidbody = explosionVictims[i].gameObject.GetComponent<Rigidbody>();
        if (victimRigidbody != null)
        {
            victimRigidbody.AddForce(vectorToVictim.normalized * decay * 1000);
        }

    }

}

    


