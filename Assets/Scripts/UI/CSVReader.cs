using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CSVReader : MonoBehaviour
{
    const string SHEET_ID = "1xTZ2Xvx3pPuaPjDKANB4pBR8UQknj1ipKAmbhpaC0y0";
    const string SHEET_NAME = "シート1";

    /// <summary>GSSデータの保存場所</summary>
    List<string[]> _gssData = new();

    /// <summary>現在の行数</summary>
    int _textID = 0;

    public void Awake()
    {
        StartCoroutine(Method(SHEET_NAME));
    }

    IEnumerator Method(string _SHEET_NAME)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            ViewCSV(request.downloadHandler.text);
        }
    }
    public void ReLoadGoogleSheet()
    {
        StartCoroutine(Method(SHEET_NAME));
    }

    void ViewCSV(string _text)
    {
        StringReader reader = new StringReader(_text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // 一行ずつ読み込み
            //_gssData.Add(line.Split(','));
            var elements = line.Split(',');    // 行のセルは,で区切られる
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            _gssData.Add(elements);
        }
        StartCoroutine(Cotext());
    }
    /// <summary>CSVを上から一行ずつ出力</summary>
    IEnumerator Cotext()
    {
        UIText.I.DrawText(_gssData[_textID][0], _gssData[_textID][1]); //(名前,セリフ)
        yield return StartCoroutine(Skip());//クリックで進む
        _textID++; //次の行へ
        StartCoroutine(Cotext());
    }

    IEnumerator Skip()
    {
        while (UIText.I.Playing) yield return null;
        while (!UIText.I.IsClicked()) yield return null;
    }

}
