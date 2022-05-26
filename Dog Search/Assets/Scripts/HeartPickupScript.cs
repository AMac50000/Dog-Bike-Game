using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if((col.gameObject.tag == "Player")&&(GameManagerScript.Instance.GetLives()<3))
        {
            GameManagerScript.Instance.AddLives(1);
            GameObject.Destroy(gameObject);
        }
    }
}
