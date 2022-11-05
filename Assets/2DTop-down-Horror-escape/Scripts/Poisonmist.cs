using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Timers;
using System;


public class Poisonmist : MonoBehaviour
{
    public float span = 1f;

    public string objName;
    GameObject Obj;
    private void Start() {
  
    }
    void OnTriggerEnter2D(Collider2D collision) {
        objName = collision.gameObject.name;
        Obj = collision.gameObject;
        if (objName == "Sibasaki_Arata_0") {
            Debug.Log("息が苦しい、何らかのガスが発生しているようだ…");
            InvokeRepeating("Logging", span, span);
        }
        else {
            Debug.Log("少々視界が悪いがなんの問題もない");
        }
    }

    void Logging() {
        Debug.LogFormat("4Damage", span);
    }
}
