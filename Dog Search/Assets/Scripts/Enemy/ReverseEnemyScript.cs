using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseEnemyScript : MonoBehaviour
{
    Vector2 Direction = Vector2.left;
    [SerializeField] float lungeSpeed, fleeSpeed, range;
    bool shouldLunge = false, shouldFlee = false;
    GameObject raycastPoint;

    private void Start()
    {
        raycastPoint = transform.Find("Raycast Point").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();
        Lunge();
        Flee();
    }

    void CheckForPlayer()
    {
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
        if(shouldLunge == true)
        {
            transform.Translate(Direction * lungeSpeed * Time.deltaTime);
        }
    }

    void Flee()
    {
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

        if((col.gameObject.tag != "Enemy")&&(col.gameObject.tag != "Player") &&
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
}
