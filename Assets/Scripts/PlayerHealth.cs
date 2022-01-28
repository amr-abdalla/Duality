using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider slider;
    public float rate = 0.3f;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
    }

    public void hit()
    {
        slider.value -= rate;
    }
}
