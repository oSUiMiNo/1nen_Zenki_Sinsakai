using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet1")
        {
            GameObject.Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "EnemyBullet2")
        {
            GameObject.Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "PlayerBullet")
        {
            GameObject.Destroy(collider.gameObject);
        }
    }
}
