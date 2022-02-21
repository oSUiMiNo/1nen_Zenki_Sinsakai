using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Battery : MonoBehaviour
{

    float inputHorizontal;
    float inputVertical;

    float bulletSpeed = 30f;
    float moveSpeed = 13f;

    Rigidbody rb;

    public GameObject PlayerBullet;

    int a = 0;
    int b = 0;

    Quaternion rx = Quaternion.Euler(90.0f, 0f, 0f);


    public Vector3 cameraForward
    {
        set
        {
            cameraForward = value;
        }
        get
        {
            return cameraForward;
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.AddForce(moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0));
        // キャラクターの向きを進行方向に


        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("space"))
            {
                GameObject runcherBullet = GameObject.Instantiate(PlayerBullet) as GameObject;
                runcherBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; //アタッチしているオブジェクトの前方にbullet speedの速さで発射
                runcherBullet.transform.position = transform.position;

                runcherBullet.transform.rotation = transform.rotation * rx;
            }
        }
    }
}
