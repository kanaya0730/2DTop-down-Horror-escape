using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject _controlPanel;

    void Update()
    {

    }
    public void OffPanel() => _controlPanel.SetActive(false);
    public void OnPanel() => _controlPanel.SetActive(true);
}
