using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCol : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(GameManagerScript.Instance.GetPlayerInvulnerable() == false)
        {
            if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "Wheel") || (col.gameObject.tag == "Bike") || (col.gameObject.tag == "Boy"))
            {
                GameObject.Destroy(transform.parent.gameObject);
                GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x, 0);
                GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * GameObject.Find("Player").GetComponent<PlayerMovementScript>().GetStompDistance());
            }
                
        }
    }
}
