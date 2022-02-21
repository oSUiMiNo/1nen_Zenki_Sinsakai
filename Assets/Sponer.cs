using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
   
    float n = 0f;

    public GameObject Enemy;


    void Update()
    {
        n++;

        if (n > 7000f)
        {
            Instantiate(Enemy, this.transform.position, this.transform.rotation);

            n = 0f;
        }
    }
}