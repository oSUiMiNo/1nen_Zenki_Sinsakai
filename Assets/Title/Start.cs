using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public Fade fade;              //フェードキャンバス取得


    public void OnClickStartButton()
    {
        fade.FadeIn(0.5f, () =>
        {
            SceneManager.LoadScene("Game");
        });



    }  
}
