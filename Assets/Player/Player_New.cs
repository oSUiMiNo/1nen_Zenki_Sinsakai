using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_New : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;

    Vector3 cameraForward;
    Vector3 moveForward;

    static public float bulletSpeed = 65f;  //弾速
    public float MoveSpeed = 22f;  //移動速度

    public float NormalMoveSpeed = 22;  //通常加速
    public float BoostMoveSpeed1 = 300;  //ブースト加速
    public float BoostMoveSpeed2 = 250;
    public float BoostMoveSpeed3 = 170;
    public float BoostMoveSpeed4 = 70;

    public Text PropulsionMeter;

    public Text TestMarker;  //作動しているかどうか確認用の記号を表示

    public Text SpeedMeterText;   //移動速度表示
    public float Speed;  //移動速度計測測用
    public int SpeedMeter;

    float SpeedB;  //スピードBefore
    float SpeedA;  //スピードAfter

    int SpeedT;  //スピード制御用のタイマー
    int MoveT;  //初速をかける長さのタイマー


    Rigidbody rb;
    float T;  //こいつにTime.deltaTimeを代入してる。


    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public GameObject PlayerBullet1;
    public GameObject PlayerBullet2;
    public GameObject PlayerBullet_C;
    public GameObject PlayerBullet_Q;
    public GameObject effect;

    public int HP = 50;
    float n = 0;  //死亡エフェクトのタイミング用タイマー

    float b = 0;
    float bC = 0;
    float bQ = 0;

    bool E = true;

    Quaternion rx = Quaternion.Euler(90.0f, 0f, 0f);  //なんだっけこれ



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        FlameCorrection();
    }

    void FixedUpdate()
    {
        PlayerMove();
        
        DestroyPlayer();

        Bullet();

        Forward();

        Meter();

        Vector3 speedForward = rb.velocity.normalized;
    }



    //ちゃんと機能してるのか分からん
    //Time.deltaTimeを基準に処理を分割して対処する
    //この場合、何らかの原因によりフレーム更新が0.01秒をこえると複数回へと処理が分割されるようになる
    void FlameCorrection()
    {
        if (Time.deltaTime < 0.1f)
        {
            T = Time.deltaTime;
        }
        else
        {
            int n = (int)(Time.deltaTime / 0.1f) + 1;
            for (int i = 0; i < n; i++)
            {
                T = (Time.deltaTime / (float)n);
            }
        }
    }



    //視点とプレイヤーの向き
    void Forward()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized; //カメラの方向から、X-Z平面の単位ベクトルを取得

        moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal; //方向キーの入力値とカメラの向きから、移動方向を決定

        transform.rotation = Quaternion.LookRotation(cameraForward); //キャラクターの向きを進行方向に向ける        
    }




    //適切にスピードをかけて移動
    void PlayerMove()
    {
        rb.AddForce(moveForward * MoveSpeed); //移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。

        //Spaceボタンで加速
        if (Input.GetKey(KeyCode.Space))
        {
            MoveSpeed = BoostMoveSpeed4;
        }

#if true

        //初速
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            MoveT += 1;

            if(MoveT > 1)
            {
                MoveSpeed = BoostMoveSpeed4;
                if (MoveT >= 2)
                {
                    TestMarker.text = "初";
                    MoveT = 0;
                }
            }
        }
#endif

        //急切り替え
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            SpeedT += 1;

            if (SpeedT >= 1 && SpeedT < 2)
            {
                if (Speed <= 7)
                {
                    MoveSpeed = 80;
                    TestMarker.text = "初";
                }
            }


            if (SpeedT >= 2 && SpeedT < 3)
            {
                TestMarker.text = "B";
                SpeedB = Speed;
            }


            if ((SpeedT >= 3) && (SpeedT < 4))
            {
                TestMarker.text = "A";
                SpeedA = Speed;
            }


            if (SpeedT >= 4)
            {
                if (SpeedA >= SpeedB)
                {

                    TestMarker.text = "〇";

                    MoveSpeed = NormalMoveSpeed;

                    if (SpeedT > 5)
                    {
                        TestMarker.text = "×";
                        SpeedT = 0;
                    }
                }

                if (SpeedA < SpeedB)
                {
                    if (Speed >= 200)
                    {
                        TestMarker.text = "●";

                        MoveSpeed = BoostMoveSpeed1;

                        if (SpeedT > 130)
                        {
                            TestMarker.text = "×";
                            SpeedT = 0;
                        }
                    }

                    if ((Speed < 200) && (Speed >= 100))
                    {
                        TestMarker.text = "●";

                        MoveSpeed = BoostMoveSpeed1;

                        if (SpeedT > 60)
                        {
                            TestMarker.text = "×";
                            SpeedT = 0;
                        }
                    }

                    if ((Speed < 100) && (Speed >= 50))
                    {
                        TestMarker.text = "●";

                        MoveSpeed = BoostMoveSpeed2;

                        if (SpeedT > 30)
                        {
                            TestMarker.text = "×";
                            SpeedT = 0;
                        }
                    }

                    if (Speed < 50)
                    {
                        TestMarker.text = "●";

                        MoveSpeed = BoostMoveSpeed3;

                        if (SpeedT > 5)
                        {
                            TestMarker.text = "×";
                            SpeedT = 0;
                        }
                    }
                }
            }
        }
    }



    //スピードメーター
    //推進力メーター
    void Meter()
    {
        Speed = rb.velocity.magnitude;  //スピード計測
        SpeedMeter = (int)Speed;  //整数部分だけメーターに表示したいのでintに変換

        SpeedMeterText.text = SpeedMeter.ToString();  //スピードをテキストに表示

        //ちなみにnormalized は、vector3の単位ベクトル(つまり方向)を返してくれる。magnitudeは、ベクトルの大きさを返してくれる。

        PropulsionMeter.text = MoveSpeed.ToString();
    }


#if true
    //死亡
    //消滅エフェクト
    void DestroyPlayer()
    {
        if (HP <= 0)
        {
            n += 1;
        }
        if (n > 20)
        {
            GameObject.Destroy(player1);
        }
        if (n > 5 && n < 50)
        {
            E = false;
        }
        if (E == false)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            E = true;
        }
    }
#endif

#if true
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
#endif



    //弾発射
    void Bullet()
    {
        //速弾連射
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.Space) == false)
        {
            bQ += 1;
        }

        if (bQ >= 1)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet_Q);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * 15; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            bQ = 0;
        }

        //エフェクト付き通常弾1発発射
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Space) == false)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet1);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            b = 0; //連射のリズムが狂わないように
        }

        //エフェクト付き通常弾連射
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space) == false)
        {
            b += 1;
        }

#if true
        if (b >= 5)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet1);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            b = 0;
        }
#endif
#if false
        //通常弾連射
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space) == false)
        {
            b += 1;
        }

        if (b >= 10)
        {
            GameObject runcherBullet = Instantiate(PlayerBullet2);
            runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
            runcherBullet.transform.rotation = transform.rotation * rx;
            runcherBullet.transform.position = transform.position;

            b = 0;
        }
#endif

        //溜め
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Space))
        {
            bC += 1;

            if (bC >= 100)
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
}

