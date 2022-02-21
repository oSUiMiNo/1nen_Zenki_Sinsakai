using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCube : MonoBehaviour
{
    public GameObject Player;
    int n;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Damage")
        {
            GameObject.Destroy(collider.gameObject);

            n++;
        }

        if (n == 3)
        {
            GameObject.Destroy(Player);
        }
    }
}
