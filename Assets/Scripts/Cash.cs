using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cash : MonoBehaviour
{
    public Text cash;
    void Update()
    {
        cash.text = "Gold: "+GameStats.Money.ToString();
    }
}
