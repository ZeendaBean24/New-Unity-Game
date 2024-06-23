using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    private PlayerXP playerXP;

    void Start()
    {
        // Find the player GameObject and get the PlayerXP component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerXP = player.GetComponent<PlayerXP>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Damage the enemy
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.EnemyTakeDamage(damage);
            }

            // Award XP to the player
            if (playerXP != null)
            {
                playerXP.AddXP(10);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}

