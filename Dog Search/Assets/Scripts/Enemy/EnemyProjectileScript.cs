using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] bool right = false;
    Vector2 direction;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (right)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.gameObject.tag == "Player")||(col.gameObject.tag == "Boy") ||(col.gameObject.tag == "Bike") ||(col.gameObject.tag == "Wheel"))
        {
            GameManagerScript.Instance.LooseLife();
        }else if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }

        Destroy(gameObject);
    }
}
