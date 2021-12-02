using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
   public float hitPoints;

    public float hitPointsCurrent;

    public object HitPoints { get; internal set; }
    public object HitPointsCurrent { get; internal set; }

    public void Hit(float damage)
    {
        hitPointsCurrent -= damage;

        if (hitPointsCurrent <= 0)
        {
            Die();//ошибка
        }

    }
    public void Die()
    {
        BroadcastMessage("Destroyed");//ошибка 

        Destroy(gameObject);
    }

    void Start()
    {

        hitPointsCurrent = hitPoints;

    }

}