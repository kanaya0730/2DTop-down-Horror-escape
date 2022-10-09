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

    /// <summary>
    /// Rigidbody2D(剛体)
    /// </summary>
    Rigidbody2D _rb2D;

    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;


    [SerializeField]
    [Header("プレイヤーの移動スピード")]
    float _speed = 0.05f;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => Move());
        _renderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject)// 仮にダメージを実装するのであればこのような感じで使ってもらえば大丈夫です
        //{
        //    _playerData.Damage(10);// 後でマジックナンバーを変更します。
        //}
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;
        _rb2D.velocity = dir * _speed;
    }
}