using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour
{
    public GameObject well_form;
    public GameObject start_burning;
    public GameObject advance_form;
    public GameObject extinguished;
    public GameObject dead;
    public Slider slider;
    public string state; 
    public float rate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        state = "well";
        slider.value = slider.maxValue;
        well_form.SetActive(true);
        start_burning.SetActive(false);
        advance_form.SetActive(false);
        extinguished.SetActive(false);
        dead.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            state = "dead";
            well_form.SetActive(false);
            start_burning.SetActive(false);
            advance_form.SetActive(false);
            extinguished.SetActive(false);
            dead.SetActive(true);
        }
        else if (state == "burning")
        {
            slider.value -= rate * Time.deltaTime;
            if(slider.value > 0.5)
            {
                well_form.SetActive(false);
                start_burning.SetActive(true);
            }
            else
            {
                start_burning.SetActive(false);
                advance_form.SetActive(true);
            }
        }
        else if (state == "well")
        {
            if (slider.value > 0.5)
            {
                well_form.SetActive(true);
                start_burning.SetActive(false);
            }
            else
            {
                start_burning.SetActive(false);
                advance_form.SetActive(true);
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
            start_burning.SetActive(false);
            advance_form.SetActive(false);
            extinguished.SetActive(true);
        }
    }
}
