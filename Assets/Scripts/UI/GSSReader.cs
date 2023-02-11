using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class GSSReader : MonoBehaviour
{
    public static GSSReader I = null;
    public bool IsLoading => _isLoading;

    public string[][] Datas => _datas;

    private bool _isLoading;

    private string[][] _datas;

    [SerializeField]
    string _sheetID = "読み込むシートのID";
    [SerializeField]
    string _sheetName = "読み込むシート";
    [SerializeField]
    public UnityEvent _onLoadEnd;

    ///<summary>現在の行数</summary>
    int _textID = 0;

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
            _onLoadEnd.Invoke();
        }
    }

    public void Reload() => StartCoroutine(GetFromWeb());

    public static string[][] ConvertGSStoJaggedArray(string text)
    {
        var reader = new StringReader(text);
        reader.ReadLine();  //ヘッダ読み飛ばし
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

}