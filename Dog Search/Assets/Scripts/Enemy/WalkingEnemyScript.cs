using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{

    Vector2 Direction = Vector2.left;
    [SerializeField] float speed;
    [SerializeField] bool startRight;

    // Start is called before the first frame update
    void Start()
    {
        if (startRight)
            Direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Ground")
        {
            Direction = -Direction;
        }
    }
}
