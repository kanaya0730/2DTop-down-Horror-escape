using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //入力の保持用の変数
    //variable to hold the input
    public int hoji;
    //分かるようにするための変数
    //variables for clarity
    public int wakaru;
    //もっと細かく分かるようにするための変数
    //Variables for better understanding
    public int metyawaka;
    // Start is called before the first frame update
    void Start()
    {
        //デバッグログは基本消して構わない
        //自分が忘れそうだったから書いた
        //Debug logs can basically be deleted
        Debug.Log("三色の扉がある…");
        Debug.Log("真ん中の扉には「特定の順番で叩けよ」と書いてある張り紙が貼ってある");
        Debug.Log("足元に紙が落ちている「忘れないように書いたメモ、叩く順番はアカ、アオ、ミドリ、アカ。by張り紙を書いた人」張り紙を書いた奴が落としたようだ");
        hoji = 0;
        wakaru = 0;
        metyawaka = 0;
    }

    // Update is called once per frame
    //押したデータを保持する方法が分からなかったから変数とifを使ったゴリ押し
    //I didn't know how to hold the pressed data, so I pushed using variables and if
    void Update()
    {
        if (hoji == 0 && wakaru == 0 && metyawaka == 0) {
            Debug.Log("どの扉を叩こう");
        }
       else if (hoji == 1 && wakaru == 0 && metyawaka == 3) {
            Debug.Log("テスト用　正解1");
            wakaru += 1;                                       
        }
       else if (hoji == 3 && wakaru == 1 && metyawaka == 4) {
            wakaru += 1;
            Debug.Log("テスト用　正解2");
        }
       else if (hoji == 6 && wakaru == 2 && metyawaka == 6) {
            wakaru += 1;
            Debug.Log("テスト用　正解3");
        }
       else if (hoji == 7 && wakaru == 3 && metyawaka == 9) {
            wakaru += 1;
            Debug.Log("正解");
            //ここに赤い扉が開いて通れるようになるコード又はそれを呼び出すための奴を書く
            //Write here the code that opens the red door and allows you to pass through, or someone to call it
        }

    }
    public void RedButton() {
        hoji += 1;
        metyawaka += 3;
        Debug.Log("紅の扉をたたいた");
    }
    public void BlueButton() {
        hoji += 2;
        metyawaka += 1;
        Debug.Log("蒼の扉をたたいた");
    }
    public void GreenButton() {
        hoji += 3;
        metyawaka += 2;
        Debug.Log("翠の扉をたたいた");
    }
    //UnityにもとからあるButtonを使って作ってる想定
    //Assuming that it is made using Button that is originally in Unity
    //これはリセットボタンが押されたときにリセットされるように作ってある
    //This is made to be reset when the reset button is pressed
    //作り変えて扉をたたく画面から離れるときに呼び出してもいい
    //Remake it and knock on the door You can call it when you leave the screen
    public void ResetButton() {
        hoji = 0;
        wakaru = 0;
        metyawaka = 0;
        Debug.Log("reset");
    }
    private void Acashia() {
        //nothing in particular
        //is like a log
        //nice folds today
        //flowers are blooming
        //Even the birds are singing
        //On a day like this, someone like you
        //burn in hell
        //you are really stupid
        //Can you go by defeating about 10 bodies by yourself?
        //落書き。
        //あまり気にしないで。
        //r-@-q=p
        //|゜゜T
        //| ~  |＜ほっといテヨ。
        //!    !
        // ~~~~~
    }
}
