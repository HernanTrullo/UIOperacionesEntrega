using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyDropDown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] panels;
    

    //[SerializeField] TMP_Dropdown myDropdown;
    void Start()
    {
        GetComponent<TMP_Dropdown>().onValueChanged.AddListener(changePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changePanel(int i){
        for (var j = 0; j < panels.Length; j++)
        {
            if (j==i){
                panels[j].SetActive(true);
            }
            else{
                panels[j].SetActive(false);
            }
            
        }
    }
}
