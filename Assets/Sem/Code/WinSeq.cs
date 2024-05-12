using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSeq : MonoBehaviour
{
    private void Start() {
        EvntManager.StartListening("Win", Win);

    }
    private void Win() {
        
    }
}
