using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
/// <summary>
/// Playerの動きだけ
/// </summary>
public class PlayerBase : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの描画
    /// </summary>
    SpriteRenderer _renderer;

    [SerializeField]
    [Header("プレイヤーの移動スピード")]
    float _speed = 0.05f;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => Move());
        _renderer = GetComponent<SpriteRenderer>();
    }


    void Move()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= _speed;
            _renderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += _speed;
            _renderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            position.y += _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.y -= _speed;
        }

        transform.position = position;
    }
}