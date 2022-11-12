using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class JsonTest2 : MonoBehaviour
{
    //[SerializeField] InputField inputArea;
    [SerializeField] Text counterText;
    [SerializeField] GameObject savePanel;
    [SerializeField] GameObject loadPanel;
    [SerializeField] Text saveLoadMessageText;

    [System.Serializable]
    public class PlayerData
    {
        public int clickCount;
        //public string playerName;
    }

    PlayerData myData = new PlayerData();

    public void OnClickEvent()
    {
        myData.clickCount++;
        counterText.text = myData.clickCount.ToString();
    }


    /*
    public void SavePlayerData()
    {
        StreamWriter writer;
        //var playerName = inputArea.text;
        //myData.playerName = playerName;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save" + playerName + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }
    */

    /*
    public void LoadPlayerData()
    {
        string datastr = "";
        //var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + playerName + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log(myData.playerName + "のデータをロードしました");
        counterText.text = myData.clickCount.ToString();
    }
*/


    public void SavePlayerDataToSave1()
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save1.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
        saveLoadMessageText.text = "セーブデータ1にデータをセーブしました";
    }

    public void LoadPlayerDataFromSave1()
    {
        string datastr = "";
        //var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save1.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log("save1のデータをロードしました");
        saveLoadMessageText.text = "セーブデータ1のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        HideLoadPanel();
    }

    public void SavePlayerDataToSave2()
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save2.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
        saveLoadMessageText.text = "セーブデータ2にデータをセーブしました";
    }

    public void LoadPlayerDataFromSave2()
    {
        string datastr = "";
        //var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save2.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log("save2のデータをロードしました");
        saveLoadMessageText.text = "セーブデータ2のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        HideLoadPanel();
    }

    public void SavePlayerDataToSave3()
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save3.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();

        saveLoadMessageText.text = "セーブデータ3にデータをセーブしました";
    }

    public void LoadPlayerDataFromSave3()
    {
        string datastr = "";
        //var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save3.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log("save3のデータをロードしました");
        saveLoadMessageText.text = "セーブデータ3のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        HideLoadPanel();
    }

    public void ShowSavePanel()
    {
        savePanel.SetActive (true);
    }

    public void HideSavePanel()
    {
        savePanel.SetActive(false);
    }

    public void ShowLoadPanel()
    {
        loadPanel.SetActive(true);
    }

    public void HideLoadPanel()
    {
        loadPanel.SetActive(false);
    }


    public void MADADESU()
    {
        Debug.Log("まだ待ってて！未実装！");
    }

}