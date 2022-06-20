using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseEnemyScript : MonoBehaviour
{
    Vector2 Direction = Vector2.left;
    [SerializeField] float lungeSpeed, fleeSpeed, range, groundCheck;
    [SerializeField] bool right;
    bool shouldLunge = false, shouldFlee = false;
    GameObject raycastPoint;
    Transform rayOrigin1, rayOrigin2, rayOrigin3, rayOrigin4, rayOrigin5, rayOrigin6, rayOrigin7, rayOrigin8, rayOrigin9;
    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rayOrigin1 = transform.Find("Raycast Point 1");
        rayOrigin2 = transform.Find("Raycast Point 2");
        rayOrigin3 = transform.Find("Raycast Point 3");
        rayOrigin4 = transform.Find("Raycast Point 4");
        rayOrigin5 = transform.Find("Raycast Point 5");
        rayOrigin6 = transform.Find("Raycast Point 6");
        rayOrigin7 = transform.Find("Raycast Point 7");
        rayOrigin8 = transform.Find("Raycast Point 8");
        rayOrigin9 = transform.Find("Raycast Point 9");

        

        if(right == true)
        {
            raycastPoint = transform.Find("Right Raycast Point").gameObject;
            Direction = Vector2.right;
        }
        else
        {
            raycastPoint = transform.Find("Left Raycast Point").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        Lunge();
        Flee();
        SetPositionLock();
    }

    void CheckForPlayer()
    {
        //Debug.Log("Check For Player Called");
        //int layerMask = 1 << 6;
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.transform.position, Direction, range);
        Debug.DrawRay(new Vector3(raycastPoint.transform.position.x, raycastPoint.transform.position.y), Direction *range , Color.red);
        if (hit == true)
        {
            //Debug.Log("Rayacast hitting: " + hit.collider.gameObject.name + " of " + hit.collider.gameObject.transform.parent.name);
            //Debug.Log("Raycast Hit");
            if (shouldFlee == false)
            {
                if(shouldLunge == false)
                {
                    //Debug.Log("Raycast Flee False");
                    if ((hit.collider.gameObject.tag == "Player") || (hit.collider.gameObject.tag == "Wheel") || (hit.collider.gameObject.tag == "Bike"))
                    {
                        shouldLunge = true;
                        //Debug.Log("Player Sighted");
                    }
                    else
                    {
                        shouldLunge = false;
                    }
                }
            }
        }
    }

    void Lunge()
    {
        //Debug.Log("Lunge Called");

        if (shouldLunge == true)
        {
            transform.Translate(Direction * lungeSpeed * Time.deltaTime);
        }
    }

    void Flee()
    {
        //Debug.Log("Flee Called");

        if (shouldFlee == true)
        {
            transform.Translate(-Direction * fleeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((shouldFlee == true)||(shouldLunge == true))
        {
            if (col.gameObject.tag == "Enemy")
            {
                GameObject.Destroy(col.transform.parent.gameObject);
            }
        }
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
        }else if ((col.gameObject.tag != "Enemy")&&(col.gameObject.tag != "Player") &&
        (col.gameObject.tag != "Wheel")&& (col.gameObject.tag != "Bike") && 
        (col.gameObject.tag != "Ground") && (col.gameObject.tag != "Boy")&& (col.gameObject.tag != "Heart"))
        {
            if(shouldFlee == true)
            {
                Destroy(gameObject);
            }
            shouldLunge = false;
            shouldFlee = false;
        }


    }

    public void SetShouldFlee()
    {
        shouldFlee = true;
        shouldLunge = false;
    }

    public void SetShouldFlee(bool temp)
    {
        shouldFlee = temp;
        if(temp == true)
        {
            shouldLunge = false;
        }
    }
    bool IsGrounded()
    {
        //Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0), -Vector3.up, Color.red, 1f);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rayOrigin1.position.x, rayOrigin1.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(rayOrigin2.position.x, rayOrigin2.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(rayOrigin3.position.x, rayOrigin3.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(rayOrigin4.position.x, rayOrigin4.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit5 = Physics2D.Raycast(new Vector2(rayOrigin5.position.x, rayOrigin5.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit6 = Physics2D.Raycast(new Vector2(rayOrigin6.position.x, rayOrigin6.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit7 = Physics2D.Raycast(new Vector2(rayOrigin7.position.x, rayOrigin7.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit8 = Physics2D.Raycast(new Vector2(rayOrigin8.position.x, rayOrigin8.position.y), Vector2.down, groundCheck, 1);
        RaycastHit2D hit9 = Physics2D.Raycast(new Vector2(rayOrigin9.position.x, rayOrigin9.position.y), Vector2.down, groundCheck, 1);

        if ((hit == true) || (hit2 == true) || (hit3 == true) ||
            (hit4 == true) || (hit5 == true) || (hit6 == true) ||
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
    private void SetPositionLock()
    {
        //Debug.Log("Set Position Lock Called");

        if (IsGrounded())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }

        Debug.DrawRay(new Vector3(rayOrigin1.position.x, rayOrigin1.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin2.position.x, rayOrigin2.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin3.position.x, rayOrigin3.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin4.position.x, rayOrigin4.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin5.position.x, rayOrigin5.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin6.position.x, rayOrigin6.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin7.position.x, rayOrigin7.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin8.position.x, rayOrigin8.position.y), Vector3.down * groundCheck, Color.red);
        Debug.DrawRay(new Vector3(rayOrigin9.position.x, rayOrigin9.position.y), Vector3.down * groundCheck, Color.red);
    }
}
