using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bullet : MonoBehaviour
{
    int n;
    GameObject effect;
    bool E = true;


    private void Start()
    {
        effect = GameObject.Find("Effect_Bullet");
    }

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
