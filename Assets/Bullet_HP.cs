using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_HP : MonoBehaviour
{
    public GameObject bullet;
    public int HP;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet2")
        {
            HP -= 4;
        }
    }

    void Update()
    {
        if (HP <= 0)
        {
            Destroy(bullet);
        }
    }
}
