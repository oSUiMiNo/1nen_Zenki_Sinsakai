using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;

    float bulletSpeed = 35f;
    float moveSpeed = 26f;

    Rigidbody rb;

    public GameObject player;
    public GameObject PlayerBullet;
    public GameObject PlayerBullet_C;
    public GameObject PlayerBullet_Q;
    public GameObject effect;

    public int HP = 50;
    int n = 0;

    int b = 0;
    int bC = 0;
    int bQ = 0;

    bool E = true;

  


    Quaternion rx = Quaternion.Euler(90.0f, 0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    

    void Update()
    {
        //視点
        //移動
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized; //カメラの方向から、X-Z平面の単位ベクトルを取得
        
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal; //方向キーの入力値とカメラの向きから、移動方向を決定

        rb.AddForce(moveForward * moveSpeed + new Vector3(0, 0, 0)); //移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。

        transform.rotation = Quaternion.LookRotation(cameraForward); //キャラクターの向きを進行方向に




        //死亡
        //消滅エフェクト
        if (HP <= 0)
        {
            n++;
        }
        if (n > 200)
        {
            GameObject.Destroy(player);
        }
        if (n > 20 && n < 50)
        {
            E = false;
        }
        if (E == false)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            E = true;
        }



        //速弾連射
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.Space) == false)
        {
            bQ++;
        }

        if (bQ == 2)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet_Q);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * 65; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            bQ = 0;
        }




            //通常弾1発発射
            if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Space) == false)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            b = 0; //連射のリズムが狂わないように
        }

        //通常弾連射
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space) == false)
        {
            b++;
        }

        if (b == 27)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            b = 0;
        }


        //溜め
        if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space))
        {
            bC++;

            if (bC == 220)
            {
                GameObject runcherBulletS = Instantiate(PlayerBullet_C);
                runcherBulletS.GetComponent<Rigidbody>().velocity = transform.forward * 0.25f; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
                runcherBulletS.transform.rotation = transform.rotation * rx;
                runcherBulletS.transform.position = transform.position;

                bC = 0;


                if (Input.GetKeyUp(KeyCode.Space))
                {
                    runcherBulletS.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
                }
            }
        }
    }





    //ダメージ
    //敵の弾当たって消す
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "EnemyBullet1")
        {
            GameObject.Destroy(collider.gameObject);

            HP -= 2;
        }

        if (collider.gameObject.tag == "EnemyBullet2")
        {
            GameObject.Destroy(collider.gameObject);

            HP -= 2;
        }

        if (collider.gameObject.tag == "Damage")
        {
            HP -= 5;
        }
    }
}