using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyVectorDraw : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject vectorRef;

    private Vector3 vectorPosition;
    private Vector3 vectorReference;
    private Vector3 ziseVectorInit;


    void Start()
    {
        vectorReference = vectorRef.transform.position;
        ziseVectorInit = transform.localScale;
    }
    void Update()
    {
        vectorPosition = transform.position;
        lineRenderer.SetPositions(new Vector3[]{vectorReference, vectorPosition});
    }
    
    private void OnMouseEnter() {
        transform.localScale = ziseVectorInit + new Vector3(0.1f, 0.1f, 0.1f);
    }
    private void OnMouseExit() {
        transform.localScale = ziseVectorInit;    
    }
}
