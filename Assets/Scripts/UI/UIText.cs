using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>会話ウィンドウの管理</summary>
public class UIText : MonoBehaviour
{
    /// <summary>テキスト判定</summary>
    public bool Playing => _playing;

    /// <summary>喋っている人の名前</summary>
    [SerializeField]
    [Header("喋っている人の名前")]
    Text _nameText;

    /// <summary>喋っている内容やナレーション</summary>
    [SerializeField]
    [Header("喋っている内容やナレーション")]
    Text _talkText;

    /// <summary>テキスト判定</summary>
    [SerializeField]
    bool _playing = false;

    /// <summary>テキストの表示速度</summary>
    [SerializeField]
    [Header("テキストの表示速度")] 
    float textSpeed = 0.1f;

    /// <summary>クリックで次のページを表示させる</summary>
    public bool IsClicked()
    {
        if (Input.GetMouseButtonDown(0)) return true;
        return false;
    }

    /// <summary>名前とセリフをテキストに反映</summary>
    public void DrawText(string name, string text)
    {
        _nameText.text = name;
        StartCoroutine(CoDrawText(text));
    }

    /// <summary>テキストがヌルヌル出てくるためのコルーチン</summary>
    IEnumerator CoDrawText(string text)
    {
        _playing = true;
        float time = 0;

        while (true)
        {
            yield return null;
            time += Time.deltaTime;

            // クリックされると一気に表示
            if (IsClicked()) break;

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            _talkText.text = text.Substring(0, len);
        }

        _talkText.text = text;
        yield return null;
        _playing = false;
    }
}
