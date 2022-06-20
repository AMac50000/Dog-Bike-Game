using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float speed, maxSpeed, maxRotation, jumpForce, jumpDistance, stompDistance;
    float xMove = 0, yMove = 0;
    Rigidbody2D rb;
    Vector2 Movement;
    [SerializeField] Joystick joystick;
    Transform rayOrigin1, rayOrigin2, rayOrigin3, rayOrigin4, rayOrigin5, rayOrigin6, rayOrigin7, rayOrigin8, rayOrigin9;
    SpriteRenderer sprite;


    //[SerializeField] Rigidbody2D frontTire, backTire;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rayOrigin1 = transform.Find("RaycastPoint1");
        rayOrigin2 = transform.Find("RaycastPoint2");
        rayOrigin3 = transform.Find("RaycastPoint3");
        rayOrigin4 = transform.Find("RaycastPoint4");
        rayOrigin5 = transform.Find("RaycastPoint5");
        rayOrigin6 = transform.Find("RaycastPoint6");
        rayOrigin7 = transform.Find("RaycastPoint7");
        rayOrigin8 = transform.Find("RaycastPoint8");
        rayOrigin9 = transform.Find("RaycastPoint9");
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        ConstrainRotation();
        CheckInput();
        Debug.DrawRay(new Vector3(rayOrigin1.position.x, rayOrigin1.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin2.position.x, rayOrigin2.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin3.position.x, rayOrigin3.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin4.position.x, rayOrigin4.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin5.position.x, rayOrigin5.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin6.position.x, rayOrigin6.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin7.position.x, rayOrigin7.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin8.position.x, rayOrigin8.position.y), Vector3.down * jumpDistance, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin9.position.x, rayOrigin9.position.y), Vector3.down * jumpDistance, Color.red);
        //Debug.Log("Joystick X is: " + joystick.Direction);
    }

    void CheckInput()
    {
        xMove = joystick.Horizontal * speed;

        if (!IsGrounded())
        {
            xMove /= 2;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    bool IsGrounded()
    {
        //Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0), -Vector3.up, Color.red, 1f);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rayOrigin1.position.x, rayOrigin1.position.y), Vector2.down,jumpDistance,  1);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(rayOrigin2.position.x, rayOrigin2.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(rayOrigin3.position.x, rayOrigin3.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(rayOrigin4.position.x, rayOrigin4.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit5 = Physics2D.Raycast(new Vector2(rayOrigin5.position.x, rayOrigin5.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit6 = Physics2D.Raycast(new Vector2(rayOrigin6.position.x, rayOrigin6.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit7 = Physics2D.Raycast(new Vector2(rayOrigin7.position.x, rayOrigin7.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit8 = Physics2D.Raycast(new Vector2(rayOrigin8.position.x, rayOrigin8.position.y), Vector2.down, jumpDistance, 1);
        RaycastHit2D hit9 = Physics2D.Raycast(new Vector2(rayOrigin9.position.x, rayOrigin9.position.y), Vector2.down, jumpDistance, 1);

        if ((hit == true)||(hit2 == true)||(hit3 == true)||
            (hit4 == true) || (hit5 == true) || (hit6 == true)||
            (hit7 == true) || (hit8 == true) || (hit9 == true))
        {
            //Debug.Log("Raycast Hit " + hit.transform.gameObject.name);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Jump()
    {
        //Debug.Log("Jump Function Called");

        if (IsGrounded() == true)
        {
            //Debug.Log("Jumping");
            yMove = jumpForce * 10;
        }
    }

    public void MakeSpritTransparent()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
    }

    public void MakeSpritOpaque()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
    }

    void Move()
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            //frontTire.AddTorque(xMove);
            //backTire.AddTorque(xMove);

            rb.AddForce(new Vector2(xMove, yMove));
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        /*
        else
        {
            rb.velocity = rb.velocity;
        }
        */
        //Debug.Log("X velocity is " + rb.velocity.x);
        xMove = 0;
        yMove = 0;
    }

    public float GetStompDistance()
    {
        return stompDistance;
    }

    public int IsRightFacing()
    {
        if(joystick.Direction.x != 0f)
        {
            if (joystick.Direction.x > 0f)
            {
                return 1;
            }
            else if (joystick.Direction.x < 0f)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        else return 0;

    }

    void ConstrainRotation()
    {


        Vector3 rot = transform.eulerAngles;
        Vector3 tempRot = rot;
        if (rot.x < 0)
        {
            Debug.Log("Rotation is negative");
        }
        if((rot.z>maxRotation)&&(rot.z < (360 - maxRotation)))
        {
            Debug.Log("Invalid Angel: " + rot.z);
            if(rot.z > 180f)
            {
                rot.z = (360f - maxRotation);
            }
            else
            {
                rot.z = maxRotation;
            }
            transform.eulerAngles = rot;
        }
        /*
        if (rot.z < maxRotation)
        {
            tempRot.z = Mathf.Clamp(rot.z, 0, maxRotation);
            Debug.Log("rot.z = " + rot.z);

            transform.eulerAngles = tempRot;

        }
        else if (rot.z < (360 - maxRotation))
        {
            tempRot.z = Mathf.Clamp(rot.z, 360f - maxRotation, 360f);
            Debug.Log("rot.z = " + rot.z);

            transform.eulerAngles = tempRot;
        }
        */



        /*
        if(transform.eulerAngles.z >= maxRotation)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, maxRotation);
        }

        if(transform.eulerAngles.z <= -maxRotation)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (-maxRotation));
        }
        */

    }

}
