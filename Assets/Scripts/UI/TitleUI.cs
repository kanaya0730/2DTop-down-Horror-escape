using UnityEngine;

/// <summary>タイトル画面のUI</summary>
public class TitleUI : MonoBehaviour
{
    /// <summary>操作説明画面</summary>
    [SerializeField]
    [Header("操作説明画面")]
    GameObject _controlPanel;

    /// <summary>パネルを非表示</summary>
    public void OffPanel() => _controlPanel.SetActive(false);

    /// <summary>パネルを表示</summary>
    public void OnPanel() => _controlPanel.SetActive(true);
}
