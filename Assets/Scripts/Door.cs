using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("ˆÚ“®‚µ‚½‚¢ƒV[ƒ“‚Ì–¼‘O‚ğ“ü‚ê‚Ä‚­‚¾‚³‚¢")]
    string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door))
        {
            door.SceneName(_sceneName);
        }
    }
}
