using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            other.GetComponent<EnemyScript>().TakeDamage (damage);
        }
    }
}