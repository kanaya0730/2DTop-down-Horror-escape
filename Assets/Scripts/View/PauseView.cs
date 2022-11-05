using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField]
    [Header("ポーズパネル")]
    Image _pausePanel;

    public void SetPauseUI()
    {
        _pausePanel.gameObject.SetActive(true);
    }
}
