using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Block : MonoBehaviour
{

    //当たった弾が消滅
    //壁がダメージくらう
    public GameObject Block;
    public float HP = 20;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
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
    }



    //エネミーおよびエネミーの弾ストップ
    //生滅エフェクト生成
    //エネミー消滅
    public GameObject effect;
    public bool E = true; //エフェクトを作ったかどうか
    float n = 0;//HPが0になってから消滅するまでのカウント
    private void Update()
    {
        if (HP <= 0)
        {
            n += Time.deltaTime;
        }
        if (n > 1.3)
        {
            GameObject.Destroy(Block);
        }
        if (n > 0.5)
        {
            E = false;
        }
        if (E == false)
        {
            Instantiate(effect, this.transform.position, this.transform.rotation);
            E = true;
        }
    }
}
