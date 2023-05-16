using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePause : MonoBehaviour
{   
    public GameObject pause;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        pause.SetActive(!pause.activeSelf);

        if(pause.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    } 

    public void Retry(string scenename)
    {
        Toggle();
        SceneManager.LoadScene(scenename);
    }
    public void Menu(string scene)
    {
       SceneManager.LoadScene(scene);
    }
    public void Continue()
    {
        Toggle();
    }   
}
