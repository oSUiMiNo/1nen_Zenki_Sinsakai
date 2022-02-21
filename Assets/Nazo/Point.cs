using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Follow_Camera mainCamera = new Follow_Camera();
    }

    void Update()
    {
        Vector3 V = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            V = new Vector3(0f, 0f, 0.7f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            V = new Vector3(0f, 0f, -0.7f);

        }
        if (Input.GetKey(KeyCode.A))
        {
            V = new Vector3(-0.7f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            V = new Vector3(0.7f, 0f, 0f);
        }

        rb.AddForce(V);
    }
}
