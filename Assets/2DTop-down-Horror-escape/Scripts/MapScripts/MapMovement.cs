using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour
{

    [SerializeField] private int _num;

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(_num)
        {
            case 1:
                SceneManager.LoadScene("");
                Debug.Log("マップ1へ");
                break;

            case 2:
                SceneManager.LoadScene("");
                Debug.Log("マップ2へ");
                break;

            case 3:
                SceneManager.LoadScene("");
                Debug.Log("マップ3へ");
                break;

            case 4:
                SceneManager.LoadScene("");
                Debug.Log("マップ4へ");
                break;

            case 5:
                SceneManager.LoadScene("");
                Debug.Log("マップ5へ");
                break;

            case 6:
                SceneManager.LoadScene("");
                Debug.Log("マップ6へ");
                break;

            case 7:
                SceneManager.LoadScene("");
                Debug.Log("マップ7へ");
                break;

            case 8:
                SceneManager.LoadScene("");
                Debug.Log("マップ8へ");
                break;

            case 9:
                SceneManager.LoadScene("");
                Debug.Log("マップ9へ");
                break;
        }
    }
}
