using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickupScript : MonoBehaviour
{
    GameManagerScript gm;

    private void Start()
    {
        gm = GameManagerScript.Instance;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(((col.gameObject.tag == "Player") || (col.gameObject.tag == "Wheel") || (col.gameObject.tag == "Bike")) &&(gm.GetLives()<3))
        {
            gm.AddLives(1);
            GameObject.Destroy(gameObject);
        }
    }
}
