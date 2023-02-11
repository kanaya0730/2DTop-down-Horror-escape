using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>キャラの切り替え</summary>
public class CharChange : MonoBehaviour
{
    /// <summary>切り替え可能キャラ</summary>
    [SerializeField]
    [Header("切り替え可能キャラ")]
    List<Sprite> _playerData = new List<Sprite>();

    [SerializeField]
    [Header("スプライトレンダラー")]
    SpriteRenderer _rend;

    [SerializeField]
    [Header("追加キャラ")]
    Sprite _char;

    /// <summary>キャラNo.</summary>
    int _num = 0;

    bool _playChar = false;
    void Start() => _rend = GetComponent<SpriteRenderer>();

    void Update()
    {
        //Eキーを押したとき
        if(Input.GetKeyDown(KeyCode.E))
        {
            _num++;
        }

        //Qキーでキャラを追加(テスト用)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddChar(_char);
            _playChar = true;
        }

        //_num = 現在のキャラ
        switch (_num)
        {
            case 0:
            case 1:
                _rend.sprite = _playerData[_num];
                break;
            case 2:
                if (_playChar == false) _num = 0;
                _rend.sprite = _playerData[_num];
                break;
            default:
                _num = 0;
                break;
        }
    }

    /// <summary>途中でキャラを追加</summary>
    public void AddChar(Sprite sprite)
    {
        if (_playChar == false)
        {
            _playerData.Add(sprite);
        }
        else
        {
            Debug.Log("これ以上追加できません");
        }
    }
}
