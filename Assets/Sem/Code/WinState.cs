using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public List<EnemyStats> enemies = new List<EnemyStats>();

    public EnemyStats[] enemy;

    private void Start()
    {
        FindAllEnemies();
        EvntManager.StartListening<EnemyStats>("Score", CheckWinState);
    }
    public void FindAllEnemies()
    {
        enemy = GameObject.FindObjectsOfType<EnemyStats>();
        foreach (EnemyStats item in enemy)
        {
            enemies.Add(item);
        }
    }
    public void CheckWinState(EnemyStats stat)
    {
        enemies.Remove(stat);
        if (enemies.Count == 0)
        {
           //oyunu burada kazanıyorsun
        }
    }
}
