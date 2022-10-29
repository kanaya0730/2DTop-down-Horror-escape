using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("移動したいシーンの場所を入れてください")]
    Transform _scenePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door))
        {
            door.SceneName(_scenePos);
            SoundManager.Instance.PlaySFX(SFXType.Door);// 現在はサウンドがないためエラーを吐きますが気にしないでください
        }
    }
}
