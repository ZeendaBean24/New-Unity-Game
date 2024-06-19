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

    private Coroutine damageCoroutine;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
            Debug.Log("Health Bar Updated: " + healthBarFill.fillAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ", current health: " + currentHealth);
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
        Debug.Log("Game Over");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DamageOverTime(other));
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    IEnumerator DamageOverTime(Collider2D enemy)
    {
        while (true)
        {
            TakeDamage(10); // Adjust the damage value as needed
            yield return new WaitForSeconds(damageCooldown);
        }
    }
}
