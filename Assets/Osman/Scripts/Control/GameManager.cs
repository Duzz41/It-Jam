using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentSoldierCount = 0;
    [SerializeField]
    private Transform[] _spawnPos;
    public GameObject enemy;
    public SoldierInstante soldierList;
    public CameraMovement cameraMovement;
    private List<GameObject> enemies = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        if (currentSoldierCount == 0 && cameraMovement._isFighting == true)
        {
            soldierList.i = 0;
            soldierList.soldierList.Clear();
            GameObject newSoldier = Instantiate(soldierList.soldier, soldierList.spawPos[soldierList.i].position, Quaternion.identity);
            soldierList.soldierList.Add(newSoldier);
            soldierList.i++;
            currentSoldierCount++;
            EvntManager.TriggerEvent("CameraMoveBack");
        }
    }

    public void SpawnAllEnemies()
    {

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear(); // Listeyi temizle

        // Yeni düşmanları oluştur
        for (int i = 0; i < _spawnPos.Length; i++) // Örnek olarak 5 düşman oluştur
        {
            GameObject newEnemy = Instantiate(enemy, _spawnPos[i].position, Quaternion.identity);
            enemies.Add(newEnemy); // Oluşturulan düşmanı listeye ekle
        }
    }

}
