using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeChange : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Player1;
    public GameObject Player2;
    //public GameObject Player3;
    private bool playerFlag = true;

    void Start()
    {
        rb = Player1.GetComponent<Rigidbody2D>();
        Player2.SetActive(false);
    }
    void Update()
    {
        if (playerFlag)
        {
            rb = Player2.GetComponent<Rigidbody2D>();
        }
        else
        {
            rb = Player1.GetComponent<Rigidbody2D>();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            playerFlag = !playerFlag;
            if(Player1.activeSelf == true)
            {
                Player2.SetActive(true);
                Player1.SetActive(false);
                //Player3.SetActive(false);
            }
            else if(Player2.activeSelf == true)
            {
                Player1.SetActive(true);
                Player2.SetActive(false);
                //Player3.SetActive(false);
            }

            


        }
    }
}
