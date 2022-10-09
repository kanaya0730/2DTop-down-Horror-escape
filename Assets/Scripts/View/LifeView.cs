using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// MVRP‚ÌV
/// </summary>
public class LifeView : MonoBehaviour
{
    [SerializeField]
    Slider _lifeSlider;

    public void SetLife(int lifeValue)
    {
        _lifeSlider.value = lifeValue;
    }
}
