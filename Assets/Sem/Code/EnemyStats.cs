using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] int prizeAmount;
    public int currentHealth;
    private bool isDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {

        MoneyManager.instance.AddMoney(prizeAmount);
        isDead = false;
        Invoke(nameof(Die), 1f);
    }


    void Die()
    {
        GameManager.instance.killCount++;
        EvntManager.TriggerEvent("DeathParticle");
        EvntManager.TriggerEvent("DeathSoud");
        Destroy(gameObject);
    }

}
