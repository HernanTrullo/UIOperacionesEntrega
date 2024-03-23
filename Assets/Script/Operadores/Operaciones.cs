using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;

public static class Operaciones
{
    public static float Norma(Vector3 vector){
        return Mathf.Sqrt(Mathf.Pow(vector.x,2)+ Mathf.Pow(vector.y,2)+Mathf.Pow(vector.z,2));
    }
    public static float ProductoPunto(Vector3 v1, Vector3 v2){
        return v1.x*v2.x + v1.y*v2.y + v1.z*v2.z ;
    }
    public static float CalculateAngle(Vector3 v1, Vector3 v2){
        return 360/(2*Mathf.PI)*Mathf.Acos(ProductoPunto(v1, v2)/(Norma(v1)*Norma(v2)));
    }
    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        float x = a.y * b.z - a.z * b.y;
        float y = a.z * b.x - a.x * b.z;
        float z = a.x * b.y - a.y * b.x;

        return new Vector3(x, y, z);
    }
    public static Vector3 reflectVector(Vector3 v){
        Vector3 vectorReflext = new()
        {
            x = -v.x,
            y = v.y
        };
        return vectorReflext;
    }

    public static Vector3 RotateVector(float angle, Vector3 pos){
        Vector3 vector = new Vector3
        {
            x = Mathf.Cos(Mathf.Deg2Rad * angle) * pos.x - Mathf.Sin(Mathf.Deg2Rad * angle) * pos.y,
            y = Mathf.Sin(Mathf.Deg2Rad * angle) * pos.x + Mathf.Cos(Mathf.Deg2Rad * angle) * pos.y
        };
        return vector;
    }
}
