using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PausePresenter : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    PauseView _pauseView;

}
