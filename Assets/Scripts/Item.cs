using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;

public class Item : MonoBehaviour, IObject
{
    [SerializeField]
    private ItemScriptableObject _itemInformation;

    [SerializeField]
    private int _itemNum;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    [SerializeField]
    [Header("アイテムイメージ")]
    private Image _itemImage;

    private void Start()
    {
        _itemImage.gameObject.SetActive(false);
    }

    async public void AnyObject()
    {
        _itemImage.gameObject.SetActive(true);
        _uiManager.LogText.text = _itemInformation.ItemInformation[_itemNum].ItemName + "をゲットした";
        await TestTextNull();
    }

    async UniTask TestTextNull()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f));
        _uiManager.LogText.text = "";
    }
}