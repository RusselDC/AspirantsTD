using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;
    [SerializeField] private AudioSource seffect;
    public float explosion = 0f;
    public float speed = 30f;

    [SerializeField]public float damage;


    public void Seek(Transform TARGET)
    {
        target = TARGET;
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceframe = speed * Time.fixedDeltaTime;

        if(dir.magnitude<=distanceframe)
        {
            HitTarget();
            Destroy(gameObject);
        }
        transform.Translate(dir.normalized * distanceframe, Space.World);

        transform.LookAt(target);
    }

    void HitTarget(){
        
        GameObject effect = (GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(effect, .5f);
        seffect.Play();
        if(explosion > 0f)
        {
            Explode();
        }else{
            Damage(target);
        }

        
    }

    
    void Explode()
    {
        Collider[] affected = Physics.OverlapSphere(transform.position, explosion);
        foreach(Collider collider in affected)
        {
            if(collider.tag == "Enemy")
            {   
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        EnemyHealth e = enemy.GetComponent<EnemyHealth>();
        if(e!=null)
        {
            e.TakeDamage(damage);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion);
    }

}
