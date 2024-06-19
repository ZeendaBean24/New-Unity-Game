using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBarFill;
    public GameOverManager gameOverManager;
    public float damageCooldown = 2f; // Time in seconds between consecutive damages
    private float lastDamageTime;

    CapsuleCollider2D playerCollider;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        playerCollider=GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // Check if enough time has passed since the last damage
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            // Reset lastDamageTime to allow taking damage again
            lastDamageTime = Time.time;
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
            // Debug.Log("Health Bar Updated: " + healthBarFill.fillAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        lastDamageTime = Time.time; // Update the last damage time
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver();
        }
        UpdateHealthBar();
    }

    void GameOver()
    {
        gameOverManager.ShowGameOverScreen();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Enemy") && Time.time - lastDamageTime >= damageCooldown)
        {
            TakeDamage(10); // Adjust the damage value as needed
        }
    }
}
