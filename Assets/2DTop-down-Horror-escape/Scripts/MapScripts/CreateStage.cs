using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CreateStage : MonoBehaviour
{
    GameObject stageFolder;
    public List <string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private GameObject obj;

    public void ReadStageData()
    {
        TextAsset _csvFile = Resources.Load("Assets/Resources/MapData/Map") as TextAsset; //Resouces下のCSV読み込み
        StringReader reader = new StringReader(_csvFile.text);
        string ObjectAddress = "Object/";
        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        int maxX = -1;
        int maxY = -1;
        string line = "";
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
            Debug.Log("" + line);
            maxY++;
        }
        maxX = CountChar(line, ',');

        for (int x = 0; x <= maxX; ++x) // yを1～9まで、1ずつ増やして繰り返し
        {
            for (int y = 0; y <= maxY; ++y) // yを1～9まで、1ずつ増やして繰り返し
            {
                if (csvDatas[y][x] != "0")
                {
                    CreateStageObject(maxY - y, x, ObjectAddress + csvDatas[y][x]);
                }
            }
        }
    }
    //プレハブを作成する
    private void CreateStageObject(int y, int x, string objname)
    {
        Debug.Log((GameObject)Resources.Load(objname));
        obj = Instantiate((GameObject)Resources.Load(objname), new Vector3(x, y, 0), Quaternion.identity);

        obj.transform.parent = transform;//オブジェクトの中に入れる
    }
    //列数をカウントする
    public static int CountChar(string s, char c)
    {
        return s.Length - s.Replace(c.ToString(), "").Length;
    }
}