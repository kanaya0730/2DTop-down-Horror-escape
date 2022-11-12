using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]

public class JsonClicker : MonoBehaviour
{
    public int hp;
    public int attack;
    public int defense;

    [System.Serializable]
    private struct PositionData
    {
        public Vector3 position;
    }


    // Start is called before the first frame update
    void Start()
    {
        /*
        JsonClicker player = new JsonClicker();
        player.hp = 100;
        player.attack = 20;
        player.defense = 7;
        string jsonstr = JsonUtility.ToJson(player);

        Debug.Log(jsonstr);

        JsonClicker player2 = JsonUtility.FromJson<JsonClicker>(jsonstr);

        Debug.Log(player2.hp);
        Debug.Log(player2.attack);
        Debug.Log(player2.defense);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
