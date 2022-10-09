using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx.Triggers;
using UniRx;
/// <summary>
/// Playerの動きだけ
/// </summary>
public class PlayerBase : MonoBehaviour,IDoor
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
        //_playerData.Damage(10);// 後でマジックナンバーを変更します。
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Vector2 dir = new Vector2(x, y).normalized;
        _rb2D.velocity = new Vector2(x, y) * _speed;

        if (x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (x > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
    }

    public void SceneName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        print(sceneName + "へ移動した");
    }
}