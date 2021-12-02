using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform gun;

    public Transform gunRocket;

    public GameObject RocketPrefab;

    public float shootPower;

    public float bulletDamage;

    public float RocketDamage;

    public bool seeTarget;

    public Transform target;

    [SerializeField] private float rocketDelay;
    private float rocketDelayCurrent;


    public void ShootBullet(Vector3 direction)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab, gun.position, gun.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().AddForce(direction * shootPower);
            Damager bulletBehaviour = newBullet.GetComponent<Damager>();
            bulletBehaviour.Damage = bulletDamage;
            bulletBehaviour.Owner = gameObject;
            Destroy(newBullet.gameObject, 5);

        }
    }

    protected void UpdateTimer()
    {
        if (rocketDelayCurrent > 0)
        {
            rocketDelayCurrent -= Time.deltaTime;
        }
    }


    public void ShootRocket(Vector3 direction)
    {
        if (rocketDelayCurrent <= 0)
        {
            rocketDelayCurrent = rocketDelay;
    	}

        if (Input.GetButtonDown("Fire2"))
        {
            GameObject newBullet = Instantiate(RocketPrefab, gunRocket.position, gunRocket.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().AddForce(direction * shootPower);
            Damager bulletBehaviour = newBullet.GetComponent<Damager>();
            bulletBehaviour.Damage = RocketDamage; bulletBehaviour.Owner = gameObject;
            Destroy(newBullet.gameObject, 5);
        }
    }


    public void ShootEnemy()
    {
        Vector3 targetDirection = target.position - gun.transform.position;

        targetDirection.Normalize();


        if (seeTarget == true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, gun.position, gun.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().AddForce(targetDirection * shootPower);
            Damager bulletBehaviour = newBullet.GetComponent<Damager>();
            bulletBehaviour.Damage = bulletDamage;
            bulletBehaviour.Owner = gameObject;
            Destroy(newBullet.gameObject, 5);

        }
    }
}

