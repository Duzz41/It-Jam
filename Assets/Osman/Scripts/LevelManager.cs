using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OpenScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
