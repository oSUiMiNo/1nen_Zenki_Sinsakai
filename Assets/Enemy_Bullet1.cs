using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject EnemyBullet;

    public float span = 3f;
    private float currentTime = 0f;
    float bulletSpeed = 5f;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            GameObject runcherBullet = GameObject.Instantiate(EnemyBullet) as GameObject;
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = transform.position;

            currentTime = 0f;
        }
    }
}