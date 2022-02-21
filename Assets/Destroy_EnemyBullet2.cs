using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_EnemyBullet2 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet2")
        {
            GameObject.Destroy(collider.gameObject);
        }
    }
}
