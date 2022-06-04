using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    GameObject player;
    PlayerMovementScript ps;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<PlayerMovementScript>();
    }
    public void Click()
    {
        ps.Jump();
    }
}
