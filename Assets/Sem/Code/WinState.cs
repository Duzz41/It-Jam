using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinState : MonoBehaviour
{
    public GameObject winPanel;
    private void Start()
    {
        winPanel.SetActive(false);
        EvntManager.StartListening("Win", Winn);
    }
    private void Winn()
    {
        winPanel.SetActive(true);
    }
}
