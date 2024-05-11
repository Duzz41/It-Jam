using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("AH UH AH");

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Dead sold");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
