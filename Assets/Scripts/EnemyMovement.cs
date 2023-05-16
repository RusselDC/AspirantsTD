using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    private float startspeed;



    void Start()
    {
        target = Waypoints.waypoints[0];
        startspeed = speed;
        
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.fixedDeltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<=0.4f)
        {
            NextwayPoint();
        }
        resetSpeed();
    }

    private void NextwayPoint()
    {   
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        GameStats.Health -= EnemyHealth.damage;
        GameManager.remainingEnemy--;
        Destroy(gameObject);
    }

    public void Slow(float slower)
    {
        speed = speed * (1f - slower);
    }
    public void resetSpeed()
    {
        speed = startspeed;
    }
}
