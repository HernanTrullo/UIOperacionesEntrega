using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField]private GameObject target; 
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
        transform.position = target.transform.position - offset;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotación de 90 grados al presionar las teclas de flecha
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime*5);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime*5);
        }
        transform.LookAt(target.transform);

    }
}
