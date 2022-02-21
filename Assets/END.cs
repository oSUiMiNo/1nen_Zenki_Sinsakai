using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class END : MonoBehaviour
{
    GameObject Player;
    GameObject Enemy_Core;
    bool end = false;
    int n;

    public Fade fade;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Enemy_Core = GameObject.Find("enemy_Core");
    }

    private void FixedUpdate()
    {
        if(Player == false)
        {
            n++;

            if(n > 100)
            {
                fade.FadeIn(0.5f, () =>
                {
                    SceneManager.LoadScene("Title");
                });
            }
        }
        if(Enemy_Core == false)
        {
            n++;
            
            if(n > 4000)
            {
                fade.FadeIn(0.5f, () =>
                {
                    SceneManager.LoadScene("Title");
                });
            }

        }
        
    }
}
