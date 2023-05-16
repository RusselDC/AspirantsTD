using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Text health;
    void Start()
    {
        health.text = "Health"+GameStats.Health;
    }
    void Update()
    {
        health.text = "Health: "+GameStats.Health; 
    }
}
