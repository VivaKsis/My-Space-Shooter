using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public int scoreValue;

    public GameObject explosion;

    public HealthBarManager healthBar;

    public AudioSource dieSound;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            Done_GameController gameController;
            gameController = gameControllerObject.GetComponent<Done_GameController>();
            gameController.AddScore(scoreValue);
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (dieSound != null)
        {
            dieSound.Play();
        }
        Destroy(gameObject);
    }
}
