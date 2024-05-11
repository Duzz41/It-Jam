using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public SoldierAI[] AIList;
    public void PushSoldiers()
    {
        for (int i = 0; i < AIList.Length; i++)
        {
            AIList[i].startAttack = true;
        }
    }
}
