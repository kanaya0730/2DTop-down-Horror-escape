using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
/// <summary>
/// Playerの動きだけ
/// </summary>
public class PlayerBase : MonoBehaviour,IDoor
{
    /// <summary>
    /// アニメーター
    /// </summary>
    Animator _animator;

    /// <summary>
    /// Rigidbody2D(剛体)
    /// </summary>
    Rigidbody2D _rb;

    /// <summary>
    /// ポーズカウント
    /// </summary>
    int _pauseCount = 1;

    /// <summary>
    /// プレイヤーインプット
    /// </summary>
    Vector2 _movement;

    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("プレイヤーの移動スピード")]
    float _speed = 0.05f;

    [SerializeField]
    [Header("ポーズパネル")]
    Image _pausePanel;

    [SerializeField]
    [Header("UIManager")]
    UIManager _uiManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        this.UpdateAsObservable().Subscribe(x => Move());
        this.UpdateAsObservable().Subscribe(x => PauseResume());
        this.FixedUpdateAsObservable().Subscribe(x => MovePosition());
        //print(_pauseCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグを使いたくないのでInterfaceを使いましょう
        // (例)↓
        //if (collision.gameObject.TryGetComponent(out IDamage damage))
        //{
        //    damage.Damage(_damage);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObject anyObj))
        {
            anyObj.AnyObject();
            _uiManager.LogText.text = "○○ゲットした";
            collision.gameObject.SetActive(false);
        }
    }

    void PauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SoundManager.Instance.PlaySFX(SFXType.Pause);// 現在音源が入っていないためエラーを吐くのでコメントアウトしておきます。
            switch (_pauseCount)
            {
                case 1:
                    PauseTime.OnPaused.Subscribe(x => _speed = 4.55f).AddTo(gameObject);
                    PauseTime.Pause();
                    _pausePanel.gameObject.SetActive(true);
                    break;

                case 2:
                    PauseTime.OnResume.Subscribe(x => _speed = 4.55f).AddTo(gameObject);
                    PauseTime.Resume();
                    _pausePanel.gameObject.SetActive(false);
                    _pauseCount = 0;
                    break;
            }
            ++_pauseCount;
        }
    }

    /// <summary>
    /// Playerの動きを制御する関数
    /// </summary>
    void Move()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetBool("IsWalking", _movement != Vector2.zero);
        if (_movement != Vector2.zero)
        {
            _animator.SetFloat("X", _movement.x);
            _animator.SetFloat("Y", _movement.y);
        }
    }

    void MovePosition()
    {
        _rb.MovePosition(_rb.position + _movement.normalized * _speed * Time.deltaTime);
    }

    /// <summary>
    /// シーンを変える関数
    /// </summary>
    /// <param name="sceneName">遷移したいシーンの名前</param>
    public void PosChange(Transform sceneName)
    {
        transform.position = sceneName.transform.position;
        print(sceneName.transform.name + "へ移動した");
    }
}