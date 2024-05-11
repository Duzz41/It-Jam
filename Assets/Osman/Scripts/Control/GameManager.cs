using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int currentSoldierCount = 0;
    public SoldierInstante soldierList;
    public CameraMovement cameraMovement;
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
            soldierList.soldierList.Clear();
            EvntManager.TriggerEvent("CameraMoveBack");
        }
    }

}
