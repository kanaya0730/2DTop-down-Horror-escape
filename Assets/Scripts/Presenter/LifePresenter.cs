using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
/// <summary>
/// MVRP‚ÌP
/// </summary>
public class LifePresenter : MonoBehaviour
{
    [SerializeField]
    PlayerData _playerData;

    [SerializeField]
    LifeView _lifeView;

    void Start()
    {
        _playerData.Life.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }

}
