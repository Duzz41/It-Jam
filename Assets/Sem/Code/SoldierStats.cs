using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //Tüm askerlerimiz öldüğünde CameraShake eventmanagerı çağırılması.
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
            EvntManager.TriggerEvent("CameraShake");
            Invoke(nameof(Die), 0.5f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
