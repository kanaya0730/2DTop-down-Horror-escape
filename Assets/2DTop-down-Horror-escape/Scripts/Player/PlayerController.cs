using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizintalkey = Input.GetAxis("Horizontal");
        float varticalkey = Input.GetAxis("Vertical");

        if (horizintalkey > 0)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        }
        else if (horizintalkey < 0)
        {
            _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
        }
        else
        {
            _rb.velocity = new Vector2(0,_rb.velocity.y);
        }        

        if (varticalkey > 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
        else if (varticalkey < 0)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -_speed);
        }
        else
        {
            _rb.velocity = new Vector2(_rb.velocity.x,0);
        }

     }
}


       
    


