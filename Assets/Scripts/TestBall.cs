using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour, IObject
{
    public void AnyObject()
    {
        print("‚±‚ê‚Í" + transform.name + "‚Å‚·");
    }
}