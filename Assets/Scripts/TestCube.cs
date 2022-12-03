using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour, IObject
{
    public void AnyObject()
    {
        // ここにテキストとか出す関数を呼ぶ
        print("これは" + transform.name + "です");
    }
}
