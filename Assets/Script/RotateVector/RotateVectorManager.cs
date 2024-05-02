using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class RotateVectorManager : MonoBehaviour
{
     // elementos gameobject
    [SerializeField] GameObject vector1;
    [SerializeField] GameObject vector2;
    [SerializeField] GameObject vectorRef;

    // Elmentos UI
    [SerializeField] TMP_Text angle;
    [SerializeField] Slider mySlider;
    [SerializeField] Button btnReset;

    // Vecotores de posisición
    private Vector3 vector1_;
    private Vector3 vector2_;
    private Vector3 vectorRef_;
    private Vector3 ejeRerencia;

    private float angleVector = 0;
    // Start is called before the first frame update
    void Start()
    {
        vectorRef_=vectorRef.transform.position;
        ejeRerencia = vector1.transform.position;
        mySlider.onValueChanged.AddListener(rotate_vector);
        btnReset.onClick.AddListener(resetValue);
        showPosition();
    }

    // Update is called once per frame
    void Update()
    {
        showPosition(); 
    }

    void showPosition(){
        vector1_= vector1.transform.position;
        vector2_= Operaciones.reflectVector(vector1_-vectorRef_);

        vector2.transform.position = vector2_+vectorRef_;
        angle.text = Operaciones.CalculateAngle(vector1_-vectorRef_,vector2_-vectorRef_).ToString("F1");
    }
    void rotate_vector(float args){
        angleVector = mySlider.value;
        vector1_ = Operaciones.RotateVector(angleVector,ejeRerencia-vectorRef_);
        vector1.transform.position = vector1_ + vectorRef_;
    }
    void resetValue(){
        vector1.transform.position = new Vector3(5,1,0);
        showPosition();
    }
}
