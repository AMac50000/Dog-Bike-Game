using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    [SerializeField] float speed = 5;
    //[SerializeField] bool right = false, down = false, left = false;
    //Vector2 direction;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimer();
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime,Space.Self);
    }

    void CheckTimer()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.gameObject.tag == "Player")||(col.gameObject.tag == "Boy") ||(col.gameObject.tag == "Bike") ||(col.gameObject.tag == "Wheel"))
        {
            GameManagerScript.Instance.LooseLife();
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Enemy")
        {
            //Do Nothing
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
