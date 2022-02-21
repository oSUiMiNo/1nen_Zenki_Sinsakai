using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_EnemyBullet1 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet1")
        {
            GameObject.Destroy(collider.gameObject);
        }
    }
}
