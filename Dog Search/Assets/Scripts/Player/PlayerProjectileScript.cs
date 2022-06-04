using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] bool left = false;
    Vector2 direction = Vector2.right;
    float timer = 0f;

    private void Start()
    {
        if(left == true)
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
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    PlayerProjectileScript()
    {

    }
}
