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
            case 0:
                SceneManager.LoadScene("GameScene");
                Debug.Log("マップ0へ");
                break;

            case 1:
                SceneManager.LoadScene("Map1");
                Debug.Log("マップ1へ");
                break;

            case 2:
                SceneManager.LoadScene("Map2");
                Debug.Log("マップ2へ");
                break;

            case 3:
                SceneManager.LoadScene("Map3");
                Debug.Log("マップ3へ");
                break;

            case 4:
                SceneManager.LoadScene("Map4");
                Debug.Log("マップ4へ");
                break;

            case 5:
                SceneManager.LoadScene("Map5");
                Debug.Log("マップ5へ");
                break;

            case 6:
                SceneManager.LoadScene("Map6");
                Debug.Log("マップ6へ");
                break;

            case 7:
                SceneManager.LoadScene("Map7");
                Debug.Log("マップ7へ");
                break;

            case 8:
                SceneManager.LoadScene("Map8");
                Debug.Log("マップ8へ");
                break;

            case 9:
                SceneManager.LoadScene("Map9");
                Debug.Log("マップ9へ");
                break;

            case 10:
                SceneManager.LoadScene("Map10");
                Debug.Log("マップ10へ");
                break;

            case 11:
                SceneManager.LoadScene("Map11");
                Debug.Log("マップ11へ");
                break;
        }
    }
}
