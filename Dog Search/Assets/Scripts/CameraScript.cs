using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject leftPoint = null, rightPoint = null, bottomPoint = null, topPoint = null;

    float minX, maxX, minY, maxY;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RefreshBorders();
        MoveCamera();
    }


    void RefreshBorders()
    {
        if ((leftPoint != null) && (rightPoint != null))
        {
            minX = leftPoint.transform.position.x;
            maxX = rightPoint.transform.position.x;
        }
        if((bottomPoint != null)&&(topPoint != null))
        {
            minY = bottomPoint.transform.position.y;
            maxY = topPoint.transform.position.y;
        }
    }

    private void MoveCamera()
    {
        float tempx, tempy;
        if (player != null)
        {
            if ((leftPoint != null) && (rightPoint != null))
            {
                if (player.transform.position.x <= minX)
                {
                    tempx = minX;
                    //gameObject.transform.position = new Vector3(minX, 0, -10);
                }
                else if (player.transform.position.x >= maxX)
                {
                    tempx = maxX;
                    //gameObject.transform.position = new Vector3(maxX, 0, -10);
                }
                else
                {
                    tempx = player.transform.position.x;
                    //gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
                }
            }
            else
            {
                tempx = player.transform.position.x;
                //gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
            }

            if ((topPoint != null) && (bottomPoint != null))
            {
                if (player.transform.position.y <= minY)
                {
                    tempy = minY;
                    //gameObject.transform.position = new Vector3(minX, 0, -10);
                }
                else if (player.transform.position.y >= maxY)
                {
                    tempy = maxY;
                    //gameObject.transform.position = new Vector3(maxX, 0, -10);
                }
                else
                {
                    tempy = player.transform.position.y;
                    //gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
                }
            }
            else
            {
                tempy = player.transform.position.y;
            }
            gameObject.transform.position = new Vector3(tempx, tempy, -10);

        }
        
    }
}
