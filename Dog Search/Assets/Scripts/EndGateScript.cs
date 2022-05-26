using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGateScript : MonoBehaviour
{
    [SerializeField] GameObject act1WinScreen;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        act1WinScreen.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            act1WinScreen.SetActive(true);
            Player.SetActive(false);
        }
        
      
    }

}
