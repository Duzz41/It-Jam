using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int killCount = 0;
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
            killCount = 0;
            soldierList.i = 0;
            soldierList.soldierList.Clear();
            GameObject newSoldier = Instantiate(soldierList.soldier, soldierList.spawPos[soldierList.i].position, Quaternion.identity);
            soldierList.soldierList.Add(newSoldier);
            soldierList.i++;
            currentSoldierCount++;
            EvntManager.TriggerEvent("CameraMoveBack");
        }
        else if (killCount == 15 && cameraMovement._isFighting == true)
        {
            EvntManager.TriggerEvent("MoveThirdLocation");
        }
        else if (killCount == 26 && cameraMovement._isFighting == true)
        {
            EvntManager.TriggerEvent("MoveFourthLocation");
        }
        else if (killCount == 44 && cameraMovement._isFighting == true)
        {
            EvntManager.TriggerEvent("MoveFifthLocation");
        }
        else if (killCount == 60 && cameraMovement._isFighting == true)
        {
            EvntManager.TriggerEvent("MoveSixthLocation");
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

    public void CheckWin()
    {
        if (killCount == 66)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
