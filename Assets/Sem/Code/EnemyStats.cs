using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] int prizeAmount;
    public int currentHealth;
    private AnimChars _animScript;
    private EnemyAI _enemyAI;
    private void Start()
    {
        _animScript = GetComponentInChildren<AnimChars>();
        _enemyAI = GetComponent<EnemyAI>();
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
        _animScript.DeathParticle();

        Invoke(nameof(Die), 1f);
    }


    void Die()
    {
        GameManager.instance.killCount++;
        _enemyAI.DieSoundPlay();
        Destroy(gameObject);
    }

}
