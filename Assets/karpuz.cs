using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Karpuz : MonoBehaviour
{
 

    public float donmeHizi = 90.0f;


    void Update()
    {
        transform.Rotate(Vector3.up * donmeHizi * Time.deltaTime);


    }
}