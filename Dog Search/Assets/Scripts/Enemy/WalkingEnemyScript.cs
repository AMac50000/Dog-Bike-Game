using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyScript : MonoBehaviour
{
    Vector2 Direction = Vector2.left;
    [SerializeField] float speed, rayDistance;
    [SerializeField] bool startRight;

    bool seen = false;
 
    Renderer mRenderer;
    
    Rigidbody2D rb;

    Transform rayOrigin1, rayOrigin2, rayOrigin3, rayOrigin4, rayOrigin5, rayOrigin6, rayOrigin7, rayOrigin8, rayOrigin9;

   

    // Start is called before the first frame update
    void Start()
    {
        if (startRight)
            Direction = Vector2.right;

        rb = gameObject.GetComponent<Rigidbody2D>();
        mRenderer = GetComponent<Renderer>();

        rayOrigin1 = transform.Find("Raycast Point 1");
        rayOrigin2 = transform.Find("Raycast Point 2");
        rayOrigin3 = transform.Find("Raycast Point 3");
        rayOrigin4 = transform.Find("Raycast Point 4");
        rayOrigin5 = transform.Find("Raycast Point 5");
        rayOrigin6 = transform.Find("Raycast Point 6");
        rayOrigin7 = transform.Find("Raycast Point 7");
        rayOrigin8 = transform.Find("Raycast Point 8");
        rayOrigin9 = transform.Find("Raycast Point 9");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfSeen();
        if (seen)
        {
        transform.Translate(Direction * speed * Time.deltaTime);
        CheckPlatform();
        }
    }

    bool OnPlatform()
    {
        //Debug.DrawRay(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0), -Vector3.up, Color.red, 1f);
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rayOrigin1.position.x, rayOrigin1.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(rayOrigin2.position.x, rayOrigin2.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(rayOrigin3.position.x, rayOrigin3.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit4 = Physics2D.Raycast(new Vector2(rayOrigin4.position.x, rayOrigin4.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit5 = Physics2D.Raycast(new Vector2(rayOrigin5.position.x, rayOrigin5.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit6 = Physics2D.Raycast(new Vector2(rayOrigin6.position.x, rayOrigin6.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit7 = Physics2D.Raycast(new Vector2(rayOrigin7.position.x, rayOrigin7.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit8 = Physics2D.Raycast(new Vector2(rayOrigin8.position.x, rayOrigin8.position.y), Vector2.down, rayDistance);
        RaycastHit2D hit9 = Physics2D.Raycast(new Vector2(rayOrigin9.position.x, rayOrigin9.position.y), Vector2.down, rayDistance);

        if ((hit == true) && (hit2 == true) && (hit3 == true) &&
            (hit4 == true) && (hit5 == true) && (hit6 == true) &&
            (hit7 == true) && (hit8 == true) && (hit9 == true))
        {
            //Debug.Log("Raycast Hit " + hit.transform.gameObject.name);
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckPlatform()
    {
        if (OnPlatform() == false)
            Direction = -Direction;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Ground")
        {
            Direction = -Direction;
        }
    }

    void CheckIfSeen()
    {
        if (mRenderer.isVisible)
        {
            seen = true;
        }
    }
}
