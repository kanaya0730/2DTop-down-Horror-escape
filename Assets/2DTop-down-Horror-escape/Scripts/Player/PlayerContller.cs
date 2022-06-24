using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContller : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody2D rB2;

    void Start()
    {
        rB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
