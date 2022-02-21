using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    Player P;
    Follow_Camera FC;



    void Start()
    {
        Cursor.visible = false; // マウスカーソルを削除する
        Cursor.lockState = CursorLockMode.Locked;  // マウスカーソルを画面内にロックする

        P = player.GetComponent<Player>();
        FC = camera.GetComponent<Follow_Camera>();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            P.enabled = false;
            FC.enabled = false; //Follow_Cameraコンポーネントを停止してカメラの動きを止める
        }
    }
}


