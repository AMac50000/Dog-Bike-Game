using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickupScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.gameObject.tag == "Player")&&(GameManagerScript.Instance.GetLives()<3))
        {
            GameManagerScript.Instance.AddLives(1);
            GameObject.Destroy(gameObject);
        }
    }
}
