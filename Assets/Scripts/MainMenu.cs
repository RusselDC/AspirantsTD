using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{       

    [SerializeField] string scenetolaod;
    public void Play()
    {
        SceneManager.LoadScene(scenetolaod);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void how(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
