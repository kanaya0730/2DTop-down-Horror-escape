using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// MVRPのV
/// </summary>
public class LifeView : MonoBehaviour
{
    [SerializeField]
    [Header("HPスライダー")]
    Slider _lifeSlider;


    public void SetLife(int lifeValue) => _lifeSlider.value = lifeValue;
}
