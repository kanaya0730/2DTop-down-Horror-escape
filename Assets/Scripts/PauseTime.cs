using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System;

public class PauseTime : MonoBehaviour
{
    static Subject<string> _pauseSubject = new Subject<string>();
    static Subject<string> _resumeSubject = new Subject<string>();

    static bool _isPaused = false;

    public static IObservable<string> OnPaused
    {
        get { return _pauseSubject; }
    }

    public static IObservable<string> OnResume
    {
        get { return _resumeSubject; }
    }

    public static void Pause()
    {
        _isPaused = true;

        _pauseSubject.OnNext("pause");

    }

    public static void Resume()
    {
        _isPaused = false;

        _resumeSubject.OnNext("resume");
    }

    public static bool IsPaused()
    {
        return _isPaused;
    }

}
