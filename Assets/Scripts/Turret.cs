using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{   
    [Header("Shooting")]
    public float firerate = 1f;
    
    public float fireCountdown = 0f;
    public float Range = 15f;

    public int damage = 50;

    [Header("Aim")]
    public Transform target;
    
    public Transform rotator;
    public float rotationSpeed = 10f;

    private EnemyHealth enemyTargetHealth;
    private EnemyMovement enemyTargetMovement;

    public GameObject bulletfab;
    public Transform targetpoint;

    [Header("LASER")]
    [SerializeField] public bool isLaser = false;
    public LineRenderer lr;

    [SerializeField] public float damagetime;

    public float slower = 0.10f;
    [SerializeField] AudioSource laser;
    

    void Start()
    {
        InvokeRepeating("SearchTarget",0f,0.25f);

    }
    void SearchTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float SHORT_DISTANCE = Mathf.Infinity;
        GameObject NEAREST_ENEMY =  null;
        foreach(GameObject enemy in enemys)
        {
            float enemydistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(enemydistance < SHORT_DISTANCE )
            {
                SHORT_DISTANCE = enemydistance;
                NEAREST_ENEMY = enemy;
            }
        }
        if(NEAREST_ENEMY != null && SHORT_DISTANCE <= Range )
        {
            target = NEAREST_ENEMY.transform;
            enemyTargetHealth = NEAREST_ENEMY.GetComponent<EnemyHealth>();
            enemyTargetMovement = NEAREST_ENEMY.GetComponent<EnemyMovement>();
        }else{
            target = null;
        }
    }
    void Update()
    {
        if(target==null) 
        {   
            if(isLaser)
            {
                if(lr.enabled)
                {
                    lr.enabled = false;
                    laser.Stop();
                    
                }
            }
            return;
        }
        
        


        //target locker
        lockaim();

        if(isLaser)
        {
            goLaser();
        }else{

            if(fireCountdown<=0f)
            {
                Shoot();
                fireCountdown = 1f/firerate;
            }
            fireCountdown -= Time.fixedDeltaTime;
        }

        
        
    }

    void lockaim()
    {
        Vector3 dir = target.position - transform.position;

        Quaternion ViewRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation,ViewRotation,Time.fixedDeltaTime * rotationSpeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void goLaser()
    {   

        enemyTargetHealth.TakeDamage(damagetime * Time.deltaTime);
        enemyTargetMovement.Slow(slower);
        if(!lr.enabled)
        {
            lr.enabled = true;
        }
        lr.SetPosition(0, targetpoint.position);
        lr.SetPosition(1, target.position);
        laser.Play();
        



        Vector3 laserdir = targetpoint.position - target.position;
    }

    void Shoot()
    {
        GameObject BULLET =(GameObject)Instantiate(bulletfab, targetpoint.position, targetpoint.rotation);
        Bullet bullet = BULLET.GetComponent<Bullet>();

        if(bullet!=null)
        {
            bullet.Seek(target);
        }
    }
    void OnDrawGizmosSelected()
    {   
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, Range);
        
    }
}
