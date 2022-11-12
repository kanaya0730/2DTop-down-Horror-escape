using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>キャラの切り替え</summary>
public class CharChange : MonoBehaviour
{
    [SerializeField]
    [Header("切り替え可能キャラ")]
    List<Sprite> _playerData = new List<Sprite>();
    
    [SerializeField]
    [Header("スプライトレンダラー")]
    SpriteRenderer _rend;

    /// <summary>キャラナンバー</summary>
    int _num = 0; 

    void Start() => _rend = GetComponent<SpriteRenderer>();

    void Update()
    {
        //Eキーを押したとき
        if(Input.GetKeyDown(KeyCode.E))
        {
            _num++;
        }

        //_num = 現在のキャラ
        switch (_num)
        {
            case 0:
            case 1:
            case 2:
                Debug.Log($"キャラを{_num}番に切り替えた");
                _rend.sprite = _playerData[_num];
                if (_playerData[_num] == null) _num = 0;
                break;
            default:
                _num = 0;
                break;
        }

    }

    /// <summary>途中でキャラを追加</summary>
    /// <param name="sprite"></param>
    public void AddChar(Sprite sprite) => _playerData.Add(sprite);
}
