using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnguloVectorManager : MonoBehaviour
{
    // elementos gameobject
    [SerializeField] GameObject vector1;
    [SerializeField] GameObject vector2;
    [SerializeField] GameObject vector3;
    [SerializeField] GameObject vectorRef;
    // Elmentos UI
    [SerializeField] TMP_Text angle;
    [SerializeField] TMP_Text norma1;
    [SerializeField] TMP_Text norma2;

    // Vecotores de posisición
    private Vector3 vector1_;
    private Vector3 vector2_;
    private Vector3 vector3_;
    private Vector3 vectorRef_;

    // Start is called before the first frame update
    void Start()
    {
        vectorRef_=vectorRef.transform.position;
        showPosition();
    }

    // Update is called once per frame
    void Update()
    {
        showPosition(); 
    }

    void showPosition(){
        vector1_= vector1.transform.position;
        vector2_=vector2.transform.position;
        vector3_= Operaciones.CrossProduct(vector1_-vectorRef_,vector2_-vectorRef_);

        angle.text = Operaciones.CalculateAngle(vector1_-vectorRef_,vector2_-vectorRef_).ToString("F1");
        norma1.text = Operaciones.Norma(vector1_-vectorRef_).ToString("F2");
        norma2.text = Operaciones.Norma(vector2_-vectorRef_).ToString("F2");
        vector3.transform.position = vector3_+vectorRef_;
    }
    


}
