using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawCube : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Slider angleS;
    [SerializeField] private TMP_InputField[] inputXYZ;
    private Vector3 posIniLinerender;

    [Header("Scale component")]
    [SerializeField] Slider[] sliders_scale;
    private Vector3 scale;
    ScaleManager myScale = new();

    [Header("Position component")]
    [SerializeField] Slider[] sliders_position;
    private Vector3 position;
    PositionManager myPos = new();

    [Header("Boton Reser")]
    [SerializeField] Button btnReset;


    private Vector3 axis = new();
    private Vector3 center = new();
    private Vector3[] vertices = new Vector3[]
    

    {        
        new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
        new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
        new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
        new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
        new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
        new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
        new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
        new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

    };



    private void Start()
    {
        axis = input2Vector3(inputXYZ);
        scale = new Vector3(sliders_scale[0].value,sliders_scale[1].value,sliders_scale[2].value);
        axis = new Vector3(sliders_position[0].value,sliders_position[1].value,sliders_position[2].value);

        btnReset.onClick.AddListener(resetValues);
        posIniLinerender = transform.position;

        foreach (var slider in sliders_position)
        {
            slider.onValueChanged.AddListener(updateCube);
        }
        foreach (var slider in sliders_scale)
        {
            slider.onValueChanged.AddListener(updateCube);
        }
    }

    private void Update()
    {
        updateCube(0);
    }

    private void updateCube(float arg)
    {
        RestartCubePosition(transform.position);
        RotationCube();
        ResizeCube();
        SetPosition();
        DrawCube3D();
    }

    private Vector3 input2Vector3(TMP_InputField[] input){
        Vector3 axis = new()
        {
            x = float.Parse(input[0].text ),
            y = float.Parse(input[1].text),
            z = float.Parse(input[2].text)
        };
        return axis;
    }


    private void RestartCubePosition(Vector3 pos)
    {
        vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f), // Vertex 0
            new Vector3(0.5f, -0.5f, -0.5f),  // Vertex 1
            new Vector3(0.5f, -0.5f, 0.5f),   // Vertex 2
            new Vector3(-0.5f, -0.5f, 0.5f),  // Vertex 3
            new Vector3(-0.5f, 0.5f, -0.5f),  // Vertex 4
            new Vector3(0.5f, 0.5f, -0.5f),   // Vertex 5
            new Vector3(0.5f, 0.5f, 0.5f),    // Vertex 6
            new Vector3(-0.5f, 0.5f, 0.5f)    // Vertex 7

        };
        center = pos;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i] + center;
        }
    }

    private void DrawCube3D()
    {
        // vertex on linerenderer
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        // define lines that conect vertex
        int[] cubeIndex = new int[]
        {
            0,1,1,2,2,3,3,0, // bottom cube face
            4,5,5,6,6,7,7,4, // upper cube face
            0,4,1,5,2,6,3,7
        };

        // draw lines
        lineRenderer.positionCount = cubeIndex.Length;
        for(int i = 0; i < cubeIndex.Length; i++)
        {
            lineRenderer.SetPosition(i, vertices[cubeIndex[i]]);
        }
    }

    private void RotationCube()
    {
        axis = input2Vector3(inputXYZ);
        for (int i = 0;i < vertices.Length;i++)
        {
            vertices[i] = QuaternionManager.instance.RotatePoint(vertices[i], angleS.value, axis);
        }
    }
    private void ResizeCube()
    {
        scale.x = sliders_scale[0].value;
        scale.y = sliders_scale[1].value;
        scale.z = sliders_scale[2].value;
        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = myScale.ScalePoint(scale, vertices[i]);
        }
    }

    private void SetPosition()
    {
        position.x = sliders_position[0].value;
        position.y = sliders_position[1].value;
        position.z = sliders_position[2].value;

        for(int i=0; i < vertices.Length; i++)
        {
            vertices[i] = myPos.SetPointPos(position, vertices[i]);
        }
    }
    void resetValues(){
        foreach (var slider in sliders_position)
        {
            slider.value = 0;
        }
        foreach (var slider in sliders_scale)
        {
            slider.value = 1;
        }
        foreach (var input in inputXYZ)
        {
            input.text = "0";
        }
        angleS.value = 0;

        RestartCubePosition(posIniLinerender);
        DrawCube3D();
    }
}
