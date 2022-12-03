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

    public void LoadPlayerDataFromSaveNum(int Num)
    {
        string datastr = "";
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + Num + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerData>(datastr); // ロードしたデータで上書き
        Debug.Log("save" + Num + "のデータをロードしました");
        saveLoadMessageText.text = "セーブデータ" + Num + "のデータをロードしました";
        counterText.text = myData.clickCount.ToString();
        ShowOrHideLoadPanel();
    }





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