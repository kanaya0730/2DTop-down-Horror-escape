using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    const string TITLE_SCENE_NAME = "Title";
    const string GAME_SCENE_NAME = "GameScene";

    AudioSource _audioSource;

    

    [SerializeField]
    [Header("効果音系")]
    SoundSFX[] _soundSFX;

    [SerializeField]
    [Header("BGM系")]
    SoundBGM[] _soundBGM;

    void Awake()
    {
        if (TryGetComponent(out _audioSource))
        {
            print("オーディオソースが参照できた");
        }


        FirstBGM();
    }

    /// <summary>
    /// シーンを読み込んだ時にシーンの名前によって鳴らす音楽を変える
    /// </summary>
    void FirstBGM()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case TITLE_SCENE_NAME:
                break;

            case GAME_SCENE_NAME:
                break;
        }

        _audioSource.Play();
    }

    /// <summary>
    /// BGMを鳴らす関数
    /// </summary>
    /// <param name="type"></param>
    public void PlayBGM(BGMType type)
    {
        var s = Array.Find(_soundBGM, e => e.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClipがないです");
        }
    }

    /// <summary>
    /// 効果音を鳴らす関数
    /// </summary>
    /// <param name="type"></param>
    public void PlaySFX(SFXType type)
    {
        var s = Array.Find(_soundSFX, e => e.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClipがないです");
        }
    }

    [Serializable]
    public class SoundSFX
    {
        public AudioClip Clip => _clip;

        public SFXType Type => _type;

        [SerializeField]
        SFXType _type;

        [SerializeField]
        AudioClip _clip;
    }

    [Serializable]
    public class SoundBGM
    {
        public BGMType Type => _type;

        public AudioClip Clip => _clip;

        [SerializeField]
        BGMType _type;

        [SerializeField]
        AudioClip _clip;
    }
}
