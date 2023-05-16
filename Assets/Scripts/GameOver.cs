
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{
    public Text waveText;
    void OnEnable()
    {
        waveText.text = GameStats.waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Debug.Log("You went to menu!");
    }
}
 