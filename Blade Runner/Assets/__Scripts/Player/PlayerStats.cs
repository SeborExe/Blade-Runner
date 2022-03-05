using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth, currentHealth;

    private GameManager GM;

    [SerializeField]
    private GameObject deathChunkParticles, deathBloodParticles;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathChunkParticles, transform.position, deathChunkParticles.transform.rotation);
        Instantiate(deathBloodParticles, transform.position, deathBloodParticles.transform.rotation);

        GM.Respawn();
        Destroy(gameObject);
    }
}
