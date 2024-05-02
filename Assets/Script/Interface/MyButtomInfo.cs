using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButtomInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject panelInfo;
    private bool panelIsActive = false;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>{
            if (panelIsActive){
                panelInfo.SetActive(false);
                panelIsActive = false;
            }
            else{
                panelInfo.SetActive(true);
                panelIsActive = true;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
