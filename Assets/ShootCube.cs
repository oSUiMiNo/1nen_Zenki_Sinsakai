using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCube : MonoBehaviour
{
    public float span = 7f;
    private float currentTime = 0f;

    public GameObject EnemyBullet1;

    float bulletSpeed = 5f;


    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            GameObject runcherBullet1 = GameObject.Instantiate(EnemyBullet1) as GameObject;
            runcherBullet1.GetComponent<Rigidbody>().velocity = new Vector3(1, 0 ,0) * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet1.transform.position = transform.position;

            GameObject runcherBullet2 = GameObject.Instantiate(EnemyBullet1) as GameObject;
            runcherBullet2.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet2.transform.position = transform.position;

            GameObject runcherBullet3 = GameObject.Instantiate(EnemyBullet1) as GameObject;
            runcherBullet3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1) * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet3.transform.position = transform.position;

            GameObject runcherBullet4 = GameObject.Instantiate(EnemyBullet1) as GameObject;
            runcherBullet4.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1) * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet4.transform.position = transform.position;

            currentTime = 0f;
        }
    }
}
