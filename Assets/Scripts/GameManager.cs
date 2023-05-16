

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Wave[] wavess;
    [SerializeField] Transform spawnpoints;
    [SerializeField] Text text;
    [SerializeField] Text wavenum;
    [SerializeField] Text enemies;

    [SerializeField] public GameObject gameOverui;
    

    [SerializeField] GameObject winUI;
    

    public float timeBetweenWaves = 5f;
    public float countdown = 3f;

    public static int waveNumber = 0;

    public static bool isgameDone;

    public static int remainingEnemy = 0;
    public Text message;


    void Awake()
    {
        isgameDone = false;
        winUI.SetActive(false);
        countdown = 3f;
        waveNumber = 0;
        remainingEnemy = 0;

    }

    void Update()
    {       
        Debug.Log(remainingEnemy);
        if(remainingEnemy<=0)
        {
            message.text = "Press g to start wave";
            message.color = Color.green;
            Invoke("remove",3f);
            if(Input.GetKeyDown(KeyCode.G))
            {
                StartCoroutine(SpawnWave());
            }
        }
        
        if(GameStats.Health <= 0 && isgameDone == false)
        {
            EndGame();
            return;
        }
        if(waveNumber == wavess.Length)
        {   
            youwon();
            this.enabled = false;
            return;
        }
        enemies.text = remainingEnemy.ToString();
        wavenum.text = "Wave "+waveNumber;
    }       
    IEnumerator SpawnWave()
    {   
        
        GameStats.waves++;
        Wave wave = wavess[waveNumber];
        remainingEnemy = wave.count;

        for(int i = 0; i<wave.count;i++)
        {   
            SpawnEnemy(wave.enemy,wave.count);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        ;
        waveNumber++;

        
    }
    private void SpawnEnemy(GameObject enemy,int count)
    {
        Instantiate(enemy,spawnpoints.position,spawnpoints.rotation);
        
    }
    void EndGame()
    {   
        isgameDone = true;
        gameOverui.SetActive(true);
    }
    public void youwon()
    {   
        PlayerPrefs.SetInt("levelreached",2);
        winUI.SetActive(true);
    }

    public void Retry(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("Retry() method called.");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void remove()
    {
        message.text = "";
    }
    
    

    
}
