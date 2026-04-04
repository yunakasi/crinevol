using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDamage : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}