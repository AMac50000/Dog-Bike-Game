using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTestScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered trigger");
        }

    }
}
