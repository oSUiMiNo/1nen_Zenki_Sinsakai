using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    //弾当たって消滅
    public int HP = 300;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
            GameObject.Destroy(collider.gameObject);

            HP -= 2;
        }
    }



    //エネミー消滅
    //生滅エフェクト生成
    public GameObject effect;
    bool E = true; //エフェクトを作ったかどうか
    float n = 0;//HPが0になってから消滅するまでのカウント

    private void Update()
    {
        if (HP <= 0)
        {
            n += Time.deltaTime;
        }
        if (n > 5)
        {
            GameObject.Destroy(gameObject);
        }
        if (n > 0.1 && n < 0.5)
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
