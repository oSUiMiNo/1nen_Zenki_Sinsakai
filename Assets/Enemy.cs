using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    public GameObject EffectBox;
    ApproachTarget AP;
    Enemy_Shoot ES;
    Transform Tr;
    //NavMeshAgent AI;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AP = enemy.GetComponent<ApproachTarget>(); //Eneの中にあるApproactTargetを取得して変数に格納する
        ES = enemy.GetComponent<Enemy_Shoot>();
        effect = GameObject.Find("Effect_E");
        Tr = this.GetComponent<Transform>();
        FakeenemyBody = GameObject.Find("EneBody");
    }




    public float leaveSpeed = 10;

    //当たった弾が消滅
    //エネミーがダメージくらう
    public GameObject enemy;
    public GameObject enemyBody;
    GameObject FakeenemyBody;
    GameObject Fake1;
    GameObject Fake2;

    public float HP = 100;
    Rigidbody rb;
 

    public GameObject effectBullet;
    public GameObject BulletSE;

    int m1;
    int m2;
    bool F1 = true;
    bool F2 = true;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
#if true
            F1 = false;
            F2 = false;
#endif

            //Instantiate(effectBullet, this.transform.position, this.transform.rotation);
            //Instantiate(BulletSE, this.transform.position, this.transform.rotation);

            GameObject.Destroy(collider.gameObject);
            HP -= 2;
        }

        if (collider.gameObject.tag == "Bullet_player_Charge")
        {
            GameObject.Destroy(collider.gameObject);
            HP -= 4;
        }

        if (collider.gameObject.tag == "Bullet_player_Quick")
        {
            GameObject.Destroy(collider.gameObject);
            HP -= 0.006f;
        }

#if false
        if (collider.gameObject.tag == "Enemy")
        {
            Vector3 enemyPos = collider.gameObject.transform.position;

            enemyPos.y = transform.position.y;

            transform.LookAt(enemyPos * (-1));

            transform.position = transform.position + transform.forward * leaveSpeed * Time.deltaTime;
        }
#endif
    }







    //エネミーおよびエネミーの弾ストップ
    //生滅エフェクト生成
    //エネミー消滅
    GameObject effect;
    bool E = true; //エフェクトを作ったかどうか
    float n = 0;//HPが0になってから消滅するまでのカウント


    void FixedUpdate()
    {
        if (HP <= 0)
        {
            AP.enabled = false;
            ES.enabled = false;
         
          
            n += 1;
        }
     

        if (n >= 2 && n <= 3 )
        {
            //GameObject.Destroy(enemyBody);
            //Fake1 =  Instantiate(FakeenemyBody, this.transform.position, this.transform.rotation) as GameObject ;
            //Fake2 = Fake1;
        }
        
        if (n >= 1 && n <= 2)
        {
            E = false;
        }
        
        if (E == false)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            E = true;
        }

        if(n > 40)
        {
            Destroy(enemy);

            if (n > 50)
            {
                n = 0;
            }
        }



        if(F1 == true)
        {
            m1 = 0;
        }

        
        if (F1 == false)
        {
            m1++;
        }

        if (m1 >= 1)
        {
            if(m1 <= 2)
            {
                Instantiate(effectBullet, EffectBox.transform.position, this.transform.rotation);
                Instantiate(BulletSE, this.transform.position, this.transform.rotation);

                F1 = true;
            }
        }
    }
}


