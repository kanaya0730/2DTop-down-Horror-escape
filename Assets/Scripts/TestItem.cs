using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : MonoBehaviour, IObject
{
    [SerializeField]
    [Header("アイテム表示")]
    Image _itemImage;

    public void AnyObject()
    {
        print(transform.name + "ゲット");
        _itemImage.gameObject.SetActive(true);
    }
}