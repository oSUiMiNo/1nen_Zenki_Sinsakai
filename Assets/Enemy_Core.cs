using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Core : MonoBehaviour
{
    //弾当たって消滅

    public int HP = 300;
    bool F1 = true;
    bool F2 = true;
    int m;

    public GameObject effectBullet;
    public GameObject BulletSE;
    public GameObject EffectBox;



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
            if(F2 == true)
            {
                F1 = false;

                GameObject.Destroy(collider.gameObject);
            }
            

            HP -= 2;
        }

       
    }





    private float currentTime0 = 0f;

    public float span1 = 0.3f;
    public float span2 = 0.3f;
    private float currentTime1 = 0f;
    private float currentTime2 = 0f;

    public GameObject EnemyBullet1;
    public GameObject EnemyBullet2;
    public GameObject effect;

    float bulletSpeed = 5f; //弾の速さ
    bool E = true; //エフェクトを作ったかどうか
    float n = 0; //HPが0になってから消滅するまでのカウント




    void FixedUpdate()
    {
#if true

        if (F1 == true)
        {
            m = 0;
        }


        if (F1 == false)
        {
            m++;
        }

        if (m >= 1)
        {
            if (m <= 2)
            {
                Instantiate(effectBullet, EffectBox.transform.position, this.transform.rotation);


                F1 = true;
            }
        }
#endif



        //エネミー消滅
        //生滅エフェクト生成
        if (HP <= 0)
        {
            n += Time.deltaTime;
            F2 = false;
        }
        if (n > 20)
        {
            GameObject.Destroy(gameObject);
        }
        if (n > 0.1f && n < 1f)
        {
            E = false;
        }
        if (E == false)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            E = true;
        }



        //エネミー弾発射
        currentTime0 += Time.deltaTime;

        if (currentTime0 > 5 && currentTime0 < 12)
        {
            currentTime1 += Time.deltaTime;
            currentTime2 += Time.deltaTime;

            if (currentTime1 > span1)
            {
                GameObject runcherBullet = GameObject.Instantiate(EnemyBullet1) as GameObject;  //asgameobjectって必要なのかあ後で調べる。
                runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
                runcherBullet.transform.position = transform.position;

                currentTime1 = 0f;
            }

            if (currentTime2 > span2)
            {
                GameObject runcherBullet = GameObject.Instantiate(EnemyBullet2) as GameObject;
                runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed * (-1); //アタッチしているオブジェクトの後方にbullet speedの速さで発射
                runcherBullet.transform.position = transform.position;

                currentTime2 = 0f;
            }  
        }

        if (currentTime0 > 12)
        {
            currentTime0 = 0;
        }

        transform.Rotate(new Vector3(0f, 0.2f, 0f));
    }
}
