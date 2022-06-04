using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "Wheel") || (col.gameObject.tag == "Bike"))
        {
            GameManagerScript.Instance.LooseLife();
        }

        if(col.gameObject.tag == "Cat")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
