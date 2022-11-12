using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class JsonTest : MonoBehaviour
{
    [SerializeField] InputField inputArea;
    [SerializeField] Text counterText;

    [System.Serializable]
    public class PlayerData
    {
        public int clickCount;
        public string playerName;
    }

    PlayerData myData = new PlayerData();

    public void OnClickEvent()
    {
        myData.clickCount++;
        counterText.text = myData.clickCount.ToString();
    }

    

    public void SavePlayerData()
    {
        StreamWriter writer;
        var playerName = inputArea.text;
        myData.playerName = playerName;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save" + playerName + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public void LoadPlayerData()
    {
        string datastr = "";
        var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + playerName + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log(myData.playerName + "のデータをロードしました");
        counterText.text = myData.clickCount.ToString();
    }

}