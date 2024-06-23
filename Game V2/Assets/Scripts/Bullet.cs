using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifespan = 5f; // Time in seconds before the bullet is destroyed

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.EnemyTakeDamage(damage);
            }

            PlayerXP playerXP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXP>();
            if (playerXP != null)
            {
                playerXP.AddXP(10);
            }

            Destroy(gameObject);
        }
    }
}

