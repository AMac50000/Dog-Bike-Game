using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : MonoBehaviour
{
    [SerializeField] float shootTime = 5, shootDelay = 0f;
    [SerializeField] GameObject projectile;
    [SerializeField] bool right;
    float timer = 0;
    Transform firePoint;
    bool seen = false;
    Renderer mRenderer;



    // Start is called before the first frame update
    void Start()
    {
        timer = shootDelay;

        mRenderer = GetComponent<Renderer>();

        if (right)
        {
            firePoint = transform.Find("Right Fire Point");
        }
        else
        {
            firePoint = transform.Find("Left Fire Point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSeen();
        if (seen)
        {
            CheckToFire();
        }
    }

    void Fire()
    {        
        Instantiate(projectile, firePoint.position, firePoint.rotation);
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

    void CheckIfSeen()
    {
        if (mRenderer.isVisible)
        {
            seen = true;
        }
    }
}
