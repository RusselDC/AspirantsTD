using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{   
    [SerializeField] Text text;
    public static int Money;
    public int StartMoney = 100;


    public static int Health;
    public int startHealth = 100;


    public static int waves;

    void Start()
    {
        Money = StartMoney;
        Health = startHealth;
        waves = 0;
    }

    void Update()
    {
        text.text = Health.ToString();
    }
    
}
