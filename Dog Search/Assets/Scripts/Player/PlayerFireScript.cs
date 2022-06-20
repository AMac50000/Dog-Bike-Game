using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireScript : MonoBehaviour
{
    bool fireActive;

    [SerializeField] GameObject powerUpButton, rightProjectile, leftProjectile;
    GameObject rightProjectilePoint, leftProjectilePoint;
    PlayerMovementScript pmScript;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(leftProjectile == null)
        {
            Debug.Log("leftProjectile null");
        }

        if (rightProjectile == null)
        {
            Debug.Log("rightProjectile null");
        }

        if(StatsManagerScript.Instance != null)
        {
            if (StatsManagerScript.Instance.GetTenisBallPowerUp() == true)
            {
                AddPowerUp();
            }
        }

        rightProjectilePoint = transform.Find("RightProjectilePoint").gameObject;
        leftProjectilePoint = transform.Find("LeftProjectilePoint").gameObject;
        //powerUpButton.SetActive(false);
    }

    private void Update()
    {
        CheckDirection();
    }

    public void AddPowerUp()
    {
        powerUpButton.SetActive(true);
        fireActive = true;
        Debug.Log("Power up obtained");
    }

    public void RemovePowerUp()
    {
        powerUpButton.SetActive(false);
        fireActive = false;
    }

    void CheckDirection()
    {
        /*
        if (direction == 1)
        {
            Debug.Log("Facing Right");
        }
        else if (direction == 2)
        {
            Debug.Log("Facing Left");
            Instantiate(leftProjectile, leftProjectilePoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("INVALID DIRECTION: " + direction);
        }
        */
        if (gameObject.GetComponent<PlayerMovementScript>().IsRightFacing() == 1)
        {
            direction = 1;
        }
        if (gameObject.GetComponent<PlayerMovementScript>().IsRightFacing() == 2)
        {
            direction = 2;
        }
    }

    public void Fire()
    {
        //Debug.Log("Fire Called");
        if (fireActive)
        {
            //Debug.Log("Fire Active");
            if (direction == 1)
            {
                if (leftProjectile == null)
                {
                    Debug.Log("leftProjectile null");
                }

                if (rightProjectile == null)
                {
                    Debug.Log("rightProjectile null");
                }
                GameObject temp = rightProjectilePoint;
                if (temp == null)
                {
                    Debug.Log("temp null");
                }
                //Debug.Log("Fire Right");
                Instantiate(rightProjectile, rightProjectilePoint.transform.position, Quaternion.identity);
            }
            else if(direction == 2)
            {
                if (leftProjectile == null)
                {
                    Debug.Log("leftProjectile null");
                }

                if (rightProjectile == null)
                {
                    Debug.Log("rightProjectile null");
                }
                GameObject temp = leftProjectile;
                if (temp == null)
                {
                    Debug.Log("temp null");
                }
                //Debug.Log("Fire Left");
                Instantiate(temp, 
                    leftProjectilePoint.transform.position, 
                    Quaternion.identity);
            }
            else
            {
                while (true)
                {
                    Debug.Log("Error Invalid Direction");
                }
            }
        }
    }
}
