using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isDead = false;
    private AnimChars _animScript;
    //Tüm askerlerimiz öldüğünde CameraShake eventmanagerı çağırılması.
    private void Start()
    {
        currentHealth = maxHealth;
        _animScript = GetComponent<AnimChars>();
        EvntManager.StartListening<int>("IncrHealth", IncreaseHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EvntManager.TriggerEvent("DeathSoud");
            EvntManager.TriggerEvent("CameraShake");
            _animScript.DeathParticle();
            isDead = true;
            Invoke(nameof(Die), 2f);
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
