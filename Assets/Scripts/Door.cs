using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("鍵がいるかいらないか")]
    bool _isKey;

    [SerializeField]
    [Header("移動したいシーンの場所を入れてください")]
    Transform _scenePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door) && !_isKey)
        {
            door.PosChange(_scenePos);
            //SoundManager.Instance.PlaySFX(SFXType.Door);// 現在はサウンドがないためエラーを吐きますが気にしないでください
        }
        else if (collision.TryGetComponent(out IKey key))// 鍵を使用したときの処理
        {
            key.OpenDoor(_isKey = false);
            door.PosChange(_scenePos);
            print("鍵を使用しました");
        }
        else if (_isKey)
        {
            print("鍵が必要です");
        }
    }
}
