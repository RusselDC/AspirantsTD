using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
    private float health;
    public float startHealth;
    public static int damage;
    [SerializeField]public int enemydamage;

    [SerializeField]public int rewardvalue;
    public GameObject deathEffect;

    [SerializeField]public Image hBar;
    
    void Start()
    {
        damage = enemydamage;
        health = startHealth;
 
    } 
    public void TakeDamage(float dmg)
    {

        health -= dmg;
        hBar.fillAmount = health/startHealth;
        if(health<=0)
        {
            EnemyDie();
        }
    }
    private void EnemyDie()
    {   
     
        GameStats.Money += rewardvalue;
        Destroy(gameObject);
        GameObject death = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(death, 0.5f);
        GameManager.remainingEnemy--;
    }
    
}
