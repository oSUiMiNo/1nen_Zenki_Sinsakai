using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public float span = 5f;
    public float currentTime = 0f;

    public GameObject EnemyBullet2;

    float bulletSpeed = 8f;


    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            GameObject runcherBullet = GameObject.Instantiate(EnemyBullet2) as GameObject;
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.position = transform.position;
           
            currentTime = 0f;
        }
    }
}
