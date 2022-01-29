using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public Slider slider;
    public string state; 
    public float rate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            Destroy(gameObject);
        }
        
    }


    public void hit()
    {
        slider.value -= rate;
    }
}
