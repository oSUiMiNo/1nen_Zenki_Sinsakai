using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Bullet : MonoBehaviour
{
    public GameObject PlayerBullet;
    float bulletSpeed = 3f;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            GameObject runcherBullet = GameObject.Instantiate(PlayerBullet) as GameObject;
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = transform.position;
        }
    }
}