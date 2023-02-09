using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class ItemScriptableObject : ScriptableObject
{
    public List<ItemInformation> ItemInformation => _itemInformation;

    [SerializeField]
    private List<ItemInformation> _itemInformation = new();
}

[System.Serializable]
public class ItemInformation
{
    public string ItemName => _itemName;

    [SerializeField]
    string _itemName;

    [SerializeField]
    SpriteRenderer _itemImage;
}