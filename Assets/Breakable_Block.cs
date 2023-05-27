using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Block : MonoBehaviour
{

    //当たった弾が消滅
    //壁がダメージくらう
    //public GameObject Block;
    float HP = 10;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
            HP -= 2;
        }

        if (collider.gameObject.tag == "Bullet_player_Charge")
        {
            HP -= 4;
        }

        if (collider.gameObject.tag == "Bullet_player_Quick")
        {
            HP -= 0.006f;
        }
    }


    private void Start()
    {
        effect = GameObject.Find("Effect_Block");
    }


#if true
    //エネミーおよびエネミーの弾ストップ
    //生滅エフェクト生成
    //エネミー消滅
    GameObject effect;
    bool E = true; //エフェクトを作ったかどうか
    float n = 0;//HPが0になってから消滅するまでのカウント
    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            n += 1;
        }
        if (n >= 2)
        {
            GameObject.Destroy(gameObject);
        }
        if (n >= 1 && n < 2)
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
}
