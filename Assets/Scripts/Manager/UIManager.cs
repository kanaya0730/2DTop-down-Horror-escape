using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text LogText => _logText;

    [SerializeField]
    [Header("ログテキスト")]
    private Text _logText;

    void Start()
    {
        _logText.text = null;
    }
}
