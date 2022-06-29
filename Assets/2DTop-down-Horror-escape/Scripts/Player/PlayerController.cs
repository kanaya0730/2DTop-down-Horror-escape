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
        



        if (horizintalkey > 0)
        {
            _rb.AddForce(transform.right * 10.0f);
        }

        else if (horizintalkey < 0)
        {
            _rb.AddForce(-transform.right * 10.0f);

        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
     }
}


       
    


