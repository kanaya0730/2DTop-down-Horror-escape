using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// シーンを変更するときに呼び出す関数
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public static void SceneChange(string sceneName) => SceneManager.LoadSceneAsync(sceneName);
}
