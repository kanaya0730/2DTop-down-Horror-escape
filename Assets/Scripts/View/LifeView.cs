using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeView : MonoBehaviour
{
    [SerializeField]
    Slider _lifeSlider;

    public void SetLife(int lifeValue)
    {
        _lifeSlider.value = lifeValue;
    }
}
