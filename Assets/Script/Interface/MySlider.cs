using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class MySlider : MonoBehaviour
{
    [SerializeField] private TMP_Text angleText;
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    private void Start() {
        slider.onValueChanged.AddListener(showAngle);
    }

    private void showAngle(float arg0)
    {
        float value = Mathf.Round(slider.value / 0.01f) * 0.01f;
        
        
        slider.value = value;
        angleText.text = "" + slider.value.ToString("F2");
    }
}