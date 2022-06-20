using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudEnemyScript : MonoBehaviour
{
    [SerializeField] float speed, shootTime;
    Transform firePoint1, firePoint2, firePoint3, startPoint, endPoint, targetPoint;
    [SerializeField] GameObject Projectile;

    float timer = 0;

    Transform[] ProjectileArary = new Transform[3];
    // Start is called before the first frame update
    void Start()
    {
        GetPoints();
        targetPoint = endPoint;
    }

    // Update is called once per frame
    void Update()
    {
        CheckToFire();
        CheckPosition();
        MoveToTargetPoint();
    }

    void GetPoints()
    {
        //Debug.Log("Get Points Called");
        firePoint1 = transform.Find("Fire Point 1");
        firePoint2 = transform.Find("Fire Point 2");
        firePoint3 = transform.Find("Fire Point 3");

        ProjectileArary[0] = firePoint1;
        ProjectileArary[1] = firePoint2;
        ProjectileArary[2] = firePoint3;


        startPoint = transform.parent.Find("Start Point");
        endPoint = transform.parent.Find("End Point");
    }

    void CheckPosition()
    {
        //Debug.Log("Check Position Called");
        if (transform.position == targetPoint.position)
        {
            if(targetPoint == endPoint)
            {
                targetPoint = startPoint;
            }else if(targetPoint == startPoint)
            {
                targetPoint = endPoint;
            }
        }
    }

    private void MoveToTargetPoint()
    {
        //Debug.Log("MoveToTargetPoint Called");
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, step);
    }

    void Fire()
    {
        for(int i = 0; i<=2; i++)
        {
            GameObject temp = Projectile;
            Projectile.transform.rotation = ProjectileArary[i].rotation;
            Instantiate(temp, ProjectileArary[i].position, ProjectileArary[i].rotation);
        }
    }

    void CheckToFire()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Fire();
            timer = shootTime;
        }
    }
}
