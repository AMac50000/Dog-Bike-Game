using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyScript : MonoBehaviour
{
    Vector3 startPosition;

    [SerializeField] float jumpForce, jumpTime, jumpDelay = 0f;
    Rigidbody2D rb;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = jumpDelay;
        startPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeepSameY();
        CheckTimer();
    }


    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        timer = jumpTime;
    }

    void CheckTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Jump();
        }
    }

    void KeepSameY()
    {
        if (gameObject.transform.position.y<= startPosition.y)
        {
            rb.velocity = Vector3.zero;
            gameObject.transform.position = new Vector3 (transform.position.x, startPosition.y, startPosition.z);
        }
    }
}
