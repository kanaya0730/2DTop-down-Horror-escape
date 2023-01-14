using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IObject
{
    [SerializeField]
    private ItemScriptableObject _itemInformation;

    [SerializeField]
    private int _itemNum;

    [SerializeField]
    [Header("UIManager")]
    private UIManager _uiManager;

    public void AnyObject()
    {
        StartCoroutine(TextNull());
        _uiManager.LogText.text = _itemInformation.ItemInformation[_itemNum].ItemName + "‚ðƒQƒbƒg‚µ‚½";
    }

    IEnumerator TextNull()
    {
        yield return new WaitForSeconds(1f);
        _uiManager.LogText.text = null;
    }
}