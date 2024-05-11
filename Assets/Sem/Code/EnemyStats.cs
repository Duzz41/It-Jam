using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] int prizeAmount;
    public int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EvntManager.TriggerEvent("DeathSoud");
            MoneyManager.instance.AddMoney(prizeAmount);
            Invoke(nameof(Die), 0.5f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
