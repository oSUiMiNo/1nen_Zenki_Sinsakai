using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Script : MonoBehaviour
{
    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
       GameObject.Destroy(collider.gameObject);
    }
}

