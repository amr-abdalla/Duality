using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour
{
    public Slider slider;
    public string state; 
    public float rate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        state = "well";
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            state = "dead";
        }
        else if (state == "burning")
        {
            if (slider.value != slider.minValue)
            {
                slider.value -= rate * Time.deltaTime;
            }
        }
    }


    public void Burn()
    {
        state = "burning";
    }

    public void StopBurn()
    {
        if(state != "dead")
        {
            state = "fire extinguished";
        }
    }
}
