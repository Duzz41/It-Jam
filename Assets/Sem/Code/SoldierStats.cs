using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isDead = false;
    //Tüm askerlerimiz öldüğünde CameraShake eventmanagerı çağırılması.
    private void Start()
    {
        currentHealth = maxHealth;
        EvntManager.StartListening<int>("IncrHealth", IncreaseHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EvntManager.TriggerEvent("DeathSoud");
            EvntManager.TriggerEvent("CameraShake");
            isDead = true;
            Invoke(nameof(Die), 0.5f);
        }
    }

    void Die()
    {
        if (isDead == true)
        {
            isDead = false;
            GameManager.instance.currentSoldierCount--;
            Destroy(gameObject);
        }
    }
    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth;
    }
}
