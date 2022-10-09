using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// Player追従クラス
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤー")]
    GameObject _player;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MoveCamera());
    }

    void MoveCamera()
    {
        Vector3 playerPos = _player.transform.position;
        // カメラとプレイヤーの位置を一緒にする
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
