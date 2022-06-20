using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallPickUpScript : MonoBehaviour
{
    GameObject player;
    PlayerFireScript pf;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pf = player.GetComponent<PlayerFireScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.gameObject.tag == "Player") || (col.gameObject.tag == "Wheel") || (col.gameObject.tag == "Bike"))
        {
            pf.AddPowerUp();
            GameObject.Destroy(gameObject);
        }
    }
}
