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

    private bool isOnClicked = false;
    private Vector3 offset;

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
    private void OnMouseDown() {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isOnClicked = true;
    }
    private void OnMouseUp() {
        isOnClicked = false;    
    }
    private void OnMouseOver() {
        if (isOnClicked){
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, transform.position.z);
            
        }
    }
}
