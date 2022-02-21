using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float leaveSpeed = 10;

    //当たった弾が消滅
    //エネミーがダメージくらう
    public GameObject enemy;
    public float HP = 100;

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

        if (collider.gameObject.tag == "Enemy")
        {
            Vector3 enemyPos = collider.gameObject.transform.position;

            enemyPos.y = transform.position.y;

            transform.LookAt(enemyPos * (-1));

            transform.position = transform.position + transform.forward * leaveSpeed * Time.deltaTime;
        }
    }

    
    
    public GameObject Ene;
    ApproachTarget AP;
    Enemy_Shoot ES;

    void Start()
    {
        AP = Ene.GetComponent<ApproachTarget>(); //Eneの中にあるApproactTargetを取得して変数に格納する
        ES = Ene.GetComponent<Enemy_Shoot>();
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
            AP.moveSpeed = 0;
            ES.enabled = false;

            n += Time.deltaTime;
        }
        if (n >= 3)
        {
            GameObject.Destroy(enemy);
        }
        if (n > 0.1 && n < 0.2)
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
