using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireScript : MonoBehaviour
{
    bool fireActive;

    [SerializeField] GameObject powerUpButton, projectile;
    GameObject projectilePoint;
    // Start is called before the first frame update
    void Start()
    {
        //powerUpButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPowerUp()
    {
        powerUpButton.SetActive(true);
        bool fireActive = true;
    }

    public void Fire()
    {
        if (fireActive)
        {
            Instantiate(projectile, projectilePoint.transform);
        }
    }
}
