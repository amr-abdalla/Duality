using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TreeHealth : MonoBehaviour
{
    Slider slider;
    public bool hit;
    public float rate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            if(slider.value != slider.minValue)
            {
                slider.value -= rate * Time.deltaTime;
            }
        }
    }

    public void Burn()
    {
        hit = true;
    }

    public void StopBurn()
    {
        hit = false;
    }

}
