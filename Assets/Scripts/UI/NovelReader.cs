using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NovelReader : MonoBehaviour
{
    /// <summary>テキスト判定</summary>
    public bool Playing => _playing;

    public bool IsLoading => _isLoading;

    public string[][] Datas => _datas;
    
    bool _isLoading;

    string[][] _datas;

    /// <summary>喋っている人の名前</summary>
    [SerializeField]
    [Header("喋っている人の名前")]
    Text _nameText = null;

    /// <summary>喋っている内容やナレーション</summary>
    [SerializeField]
    [Header("喋っている内容やナレーション")]
    Text _talkText = null;

    [SerializeField]
    [Header("キャラクターイメージ")]
    Image _charaImage;

    [SerializeField]
    [Header("キャラクタースプライト一覧")]
    Sprite[] _charaSprite;
    /// <summary>テキスト判定</summary>
    [SerializeField]
    bool _playing = false;

    /// <summary>テキストの表示速度</summary>
    [SerializeField]
    [Header("テキストの表示速度")]
    float textSpeed = 0.1f;

    /// <summary>現在の行数</summary>
    int _textID = 1;

    [SerializeField]
    bool _pause;

    [SerializeField]
    string _sheetID = "読み込むシートのID";
    [SerializeField]
    string _sheetName = "読み込むシート";

    private void Awake()
    {
        StartCoroutine(GetFromWeb());
    }

    /// <summary>GSS(グーグルスプレッドシート)を読み込む</summary>
    IEnumerator GetFromWeb()
    {
        _isLoading = true;
        var url = "https://docs.google.com/spreadsheets/d/" + _sheetID + "/gviz/tq?tqx=out:csv&sheet=" + _sheetName;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        _isLoading = false;

        var protocol_error = request.result == UnityWebRequest.Result.ProtocolError ? true : false;
        var connection_error = request.result == UnityWebRequest.Result.ConnectionError ? true : false;
        if (protocol_error || connection_error)
        {
            Debug.LogError(request.error);
        }
        else
        {
            _datas = ConvertGSStoJaggedArray(request.downloadHandler.text);
            StartCoroutine(Cotext());
        }
    }

    /// <summary>読み込んだGSSをstring化</summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public string[][] ConvertGSStoJaggedArray(string text)
    {
        var reader = new StringReader(text);
        var rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine();        // 一行ずつ読み込み
            var elements = line.Split(',');    // 行のセルは,で区切られる
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }

    /// <summary>GSSの名前とセリフをテキストに反映</summary>
    public void DrawText(string name, string text)
    {
        _nameText.text = name;
        StartCoroutine(CoDrawText(text));
    }

    /// <summary>GSSのIDでキャライメージを反映</summary>
    public void DrawImage(int id)
    {
        _charaImage.sprite = _charaSprite[id - 1];
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

            if (IsClicked()) break;

            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            _talkText.text = text.Substring(0, len);
        }

        _talkText.text = text;
        yield return null;
        _playing = false;
    }

    /// <summary>スペースキーで次のページを表示させる</summary>
    public bool IsClicked()
    {
        if (Input.GetMouseButtonDown(0)) return true;
        return false;
    }

    /// <summary>クリックされると一気に表示</summary>
    IEnumerator Skip()
    {
        while (Playing) yield return null;
        while (!IsClicked()) yield return null;
    }

    /// <summary>GSSを上から一行ずつ出力</summary>
    IEnumerator Cotext()
    {
        if (!_pause)
        {
            Debug.Log($"現在：{_textID}行");
            DrawImage(int.Parse(_datas[_textID][0]));//キャライメージ反映
            DrawText(_datas[_textID][1], _datas[_textID][3]); //(名前,セリフ)反映
            yield return StartCoroutine(Skip());//クリックで進む
            _textID++; //次の行へ
            StartCoroutine(Cotext());
        }

        else
        {
            Debug.Log("ポーズ中");
        }
    }
}