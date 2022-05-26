using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{

    Vector2 Direction = Vector2.left;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "Ground")
        {
            Direction = -Direction;
        }
    }
}
