using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("鍵がいるかいらないか")]
    bool _isKey;

    [SerializeField]
    [Header("移動したいシーンの場所を入れてください")]
    Transform _scenePos;

    [SerializeField]
    [Header("鍵の名前")]
    string _keyName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door) && !_isKey)
        {
            door.PosChange(_scenePos);
            //SoundManager.Instance.PlaySFX(SFXType.Door);// 現在はサウンドがないためエラーを吐きますが気にしないでください
        }
        else if (_isKey)// 鍵を使用したときの処理
        {
            door.PosChange(_scenePos);
            print("鍵を使用しました");
        }
        else
        {
            print("鍵が必要です");
        }
    }
}
