using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    [SerializeField] private Button btnProductPoint;
    [SerializeField] private Button btnCuaternion;
    [SerializeField] private Button btnRotateVector;

    // Start is called before the first frame update
    void Start()
    {
        btnCuaternion.onClick.AddListener(()=>LoadScene("Cuaternion"));
        btnRotateVector.onClick.AddListener(()=>LoadScene("RotateVector"));
        btnProductPoint.onClick.AddListener(()=>LoadScene("ProductoPunto"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadScene(string nameScene){
        SceneManager.LoadScene(nameScene);
    }
}
