using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    public GameObject anykey;
    public float KeyShowDelay = 3f;
    public bool CanContinue = false;
    private void Start()
    {
        anykey.SetActive(false);
        Invoke(nameof(KeyShow), KeyShowDelay);
    }
    private void KeyShow()
    {
        anykey.SetActive(true);
        CanContinue = true;
    }
    private void FixedUpdate()
    {
        if(CanContinue)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
