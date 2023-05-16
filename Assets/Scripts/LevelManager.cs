using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{   
    public Button[] levels;

    void Start()
    {
        int levelreached = PlayerPrefs.GetInt("levelreached",1);
       for(int i = 0; i<levels.Length;i++)
       {
        if(i + 1 > levelreached)
        {
            levels[i].interactable = false;
        }
        
       }
    }
    public void Select(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
