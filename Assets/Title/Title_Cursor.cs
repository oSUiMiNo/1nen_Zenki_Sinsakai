using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //UIのやつ
using UnityEngine.SceneManagement;  //シーン管理


public class Title_Cursor : MonoBehaviour
{
    public GameObject Canvas_Title;
    public GameObject Canvas_Menu;
    public GameObject Canvas_Config;
    
    //タイトルの
    public GameObject Start_P;  //Startテキストの位置
    public GameObject Config_P;
    public Text Start_T;        //Startテキスト
    public Text Config_T;

    
    public  GameObject effect;   //シーン切り替え時のエフェクト


    public float redS, greenS, blueS, alfaS;   //Startの文字の色、不透明度を管理
    public float redC, greenC, blueC, alfaC;   //Configの文字の色、不透明度を管理

    public float T;    //タイマーの時間


    void Update()
    {
        T += Time.deltaTime;

        if (T >= 19 && T <= 19.5)   //シーンを開いて19秒くらいしたらスタンバイする
        {
            Standby();
        }


        if (Input.GetKeyDown(KeyCode.W))   //Wを押したらStartを選択
        {
            this.transform.position = Start_P.transform.position + new Vector3(-24.6f, 1.4f, -2.2f);

            redS = 0.8f;　　　　　　　　　//選択時にStartとConfigの色の値を変更
            greenS = 0.8f;
            blueS = 0.8f;
            alfaS = 0.8f;

            redC = 0.6f;
            greenC = 0.6f;
            blueC = 0.6f;
            alfaC = 0.8f;

            SetColor();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = Config_P.transform.position + new Vector3(-25f, 2.5f, -2.2f);

            redS = 0.6f;
            greenS = 0.6f;
            blueS = 0.6f;
            alfaS = 0.8f;

            redC = 0.8f;
            greenC = 0.8f;
            blueC = 0.8f;
            alfaC = 0.8f;

            SetColor();
        }


        if (redS == 0.8f && greenS == 0.8f && blueS == 0.8f && alfaS == 0.8f)   //Startが選択されている時の文字の色を条件にした
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);   //指定した座標にエフェクトを生成

                Invoke("ChangeCanvas1", 8.5f);   //Invokeは、数秒後に処理を実行するというメソッド。
                                                 //8.5秒後にキャンバス切り替え用の ChangeCanvas1() が実行される。
            }
        }

        if (redS == 0.6f && greenS == 0.6f && blueS == 0.6f && alfaS == 0.8f)   //Configが選択されている時の文字の色を条件にした
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);   //指定した座標にエフェクトを生成

                Invoke("ChangeCanvas2", 8.5f);   //Invokeは、数秒後に処理を実行するというメソッド。
                                                 //8.5秒後にキャンバス切り替え用の ChangeCanvas2() が実行される。
            }
        }
    }


    void Standby()   //カーソル位置とメニュー色のスタンバイ
    {
        this.transform.position = Start_P.transform.position + new Vector3(-24.6f, 1.4f, -2.2f);

        redS = 0.8f;         //選択時にStartとConfigの色の値を変更
        greenS = 0.8f;
        blueS = 0.8f;
        alfaS = 0.8f;

        redC = 0.6f;
        greenC = 0.6f;
        blueC = 0.6f;
        alfaC = 0.8f;

        SetColor();
    }

    void SetColor()   //変更した色の値をStartテキストの色情報に突っ込んで実際に色を変える
    {
        Config_T.color = new Color(redC, greenC, blueC, alfaC);
        Start_T.color = new Color(redS, greenS, blueS, alfaS);
    }


    void ChangeCanvas1()
    {
        Canvas_Title.SetActive(false);
        Canvas_Menu.SetActive(true);
    }

    void ChangeCanvas2()
    {
        Canvas_Title.SetActive(false);
        Canvas_Config.SetActive(true);
    }

    void ChangeCanvas3()
    {
        Canvas_Title.SetActive(true);
        Canvas_Menu.SetActive(false);
    }


    public void ChangeScine()   //Gameシーンに移動
    {
        SceneManager.LoadScene("Game");
    }
}
