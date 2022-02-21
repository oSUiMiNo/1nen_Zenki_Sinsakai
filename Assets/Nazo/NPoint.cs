using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPoint : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Follow_Camera F = new Follow_Camera();


        Vector3 E = new Vector3(F.X, 0f, F.Y);
        float V = 1;

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(E * V);
        }

    }
}