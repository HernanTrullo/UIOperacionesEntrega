using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyInputField : MonoBehaviour
{
    TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input= GetComponent<TMP_InputField>();
        input.onValueChanged.AddListener((string text)=>{
            if (string.IsNullOrEmpty(text))
            {
                input.text = "0";
                input.MoveTextEnd(true);
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
    }
}
