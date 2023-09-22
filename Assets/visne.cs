using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visne : MonoBehaviour
{

    public float donmeHizi = 90.0f;


    void Update()
    {
        transform.Rotate(Vector3.up * donmeHizi * Time.deltaTime);


    }
}
