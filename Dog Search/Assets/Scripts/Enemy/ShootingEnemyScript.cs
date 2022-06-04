using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : MonoBehaviour
{
    [SerializeField] float shootTime = 5, shootDelay = 0f;
    [SerializeField] GameObject projectile;

    float timer = 0;
    Vector3 firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = shootDelay;
        firePoint = transform.Find("Fire Point").position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckToFire();
    }

    void Fire()
    {
        Instantiate(projectile, firePoint, Quaternion.identity);
    }

    void CheckToFire()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Fire();
            timer = shootTime;
        }
    }
}
