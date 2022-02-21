using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{

    public GameObject Canvas_Title;
    public GameObject Canvas_Menu;

    public GameObject effect;



    public void OnClickStartButton()
    {
        Instantiate(effect, new Vector3(0, 0, 0), Quaternion.identity);   //指定した座標にエフェクトを生成

        Invoke("ChangeCanvasB", 8.5f);   //Invokeは、数秒後に処理を実行するというメソッド。
                                         //8秒後にキャンバス切り替え用の ChangeCanvas1() が実行される。
    }

    void ChangeCanvasB()
    {
        Canvas_Title.SetActive(true);
        Canvas_Menu.SetActive(false);
    }
}
