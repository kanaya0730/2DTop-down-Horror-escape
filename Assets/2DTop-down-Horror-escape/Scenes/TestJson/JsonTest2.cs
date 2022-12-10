using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class JsonTest2 : MonoBehaviour
{
    [SerializeField] [Header("カウント用のテキスト")] Text counterText;
    [SerializeField] [Header("セーブ用パネル")] GameObject savePanel;
    [SerializeField] [Header("ロード用のパネル")] GameObject loadPanel;
    [SerializeField] [Header("セーブロードを伝えるテキスト")] Text saveLoadMessageText;

    [System.Serializable]
    public class PlayerData
    {
        public int clickCount;
    }

    PlayerData myData = new PlayerData();

    /// <summary>クリック時に+1</summary>
    public void OnClickEvent()
    {
        myData.clickCount++;
        counterText.text = myData.clickCount.ToString();
    }


    /// <summary>数次式でセーブデータにセーブ</summary>
    public void SavePlayerDataToSaveNum(int Num)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save"+ Num +".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

        saveLoadMessageText.text = "セーブデータ" + Num + "にデータをセーブしました";
    }

    /// <summary>数次式でセーブデータをロード</summary>
    public void LoadPlayerDataFromSaveNum(int Num)
    {
        string datastr = "";
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + Num + ".json");

        if (reader == null)
        {
            Debug.Log("データが存在しなかったため、データを新しく作成しました");
            PlayerData myData = new PlayerData();
        }

        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log("save" + Num + "のデータをロードしました");
        saveLoadMessageText.text = "セーブデータ" + Num + "のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        ShowOrHideLoadPanel();
    }

    /// <summary>文章式でセーブデータにセーブ</summary>
    public void SavePlayerDataToSaveStr(string Str)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + Str + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

        saveLoadMessageText.text = Str + "にデータをセーブしました";
    }

    /// <summary>文章式でセーブデータをロード</summary>
    public void LoadPlayerDataFromSaveStr(string Str)
    {
        /*
        if (PlayerData == null)
        {
            PlayerData myData = new PlayerData();
        }
        */

        string datastr = "";
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + Str + ".json");
        if (datastr == null)
        {
            Debug.Log("データが存在しなかったため新しく作成しました");
        }
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log(Str + "のデータをロードしました");
        saveLoadMessageText.text = Str + "のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        ShowOrHideLoadPanel();
    }

    private void OnApplicationQuit() => OverWriteSaveData();




    //セーブデータの上書き
    void OverWriteSaveData()
    {
        Debug.Log("自動保存");
        /*
        //新たなセーブデータを作成処理
        PlayerData myData = new PlayerData();

        //既存のセーブデータを上書き
        JsonUtility.FromJson<myData>.Save(PlayerData, myData);
        myData = JsonUtility.FromJson<PlayerData>(datastr);
        */
    }


    /// <summary>セーブパネルの表示/非表示切り替え</summary>
    public void ShowOrHideSavePanel()
    {
        if (savePanel.activeInHierarchy)
        {
            savePanel.SetActive(false);
            //表示されてたら非表示
        }
        else
        {
            savePanel.SetActive(true);
            //非表示だったら表示
        }
        
    }

    /// <summary>ロードパネルの表示/非表示切り替え</summary>
    public void ShowOrHideLoadPanel()
    {
        if (loadPanel.activeInHierarchy)
        {
            loadPanel.SetActive(false);
            //表示されてたら非表示
        }
        else
        {
            loadPanel.SetActive(true);
            //非表示だったら表示
        }

    }
}