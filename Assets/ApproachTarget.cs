using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTarget : MonoBehaviour
{
    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;

    Transform OT;
    private void Start()
    {
        GameObject othereEnemy = GameObject.FindGameObjectWithTag("Enemy");
        OT = othereEnemy.transform;
    }




    // オブジェクトの移動速度を格納する変数
    [HideInInspector]//←これを付ければ、インスペクターウィンドウスクリプトで変数を変えたときにインスペクターウィンドウの方の値が優先されなくなる。
    public float moveSpeed = 5f;

    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数

    public float stopDistance = 50f;

    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    [HideInInspector]
    public float moveDistance = 4000f;


    int a = 0;
    int b = 0;

    void Update()
    {
#if true
        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;
        // 自分自身のY座標を変数 target のY座標に格納
        //（ターゲットオブジェクトのX、Z座標のみ参照）
        targetPos.y = transform.position.y;
        // オブジェクトを変数 targetPos の座標方向に向かせる
        transform.LookAt(targetPos);

        // 変数 distance を作成してオブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, target.position);
        // オブジェクトとターゲットオブジェクトの距離判定
        // 変数 distance（ターゲットオブジェクトとオブジェクトの距離）が変数 moveDistance の値より小さければ
        // さらに変数 distance が変数 stopDistance の値よりも大きい場合
        if (distance < moveDistance && distance > stopDistance && b == 0)
        {
            // 変数 moveSpeed を乗算した速度でオブジェクトを前方向に移動する
            transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        }
#endif





#if true
        Vector3 OTP = OT.position;

        float distanceO = Vector3.Distance(transform.position, OT.position);

        a++;

        if(a > 500)
        {

            if (distanceO < stopDistance)
            {
                Vector3 XZrandom = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));

                b++;

                if (b > 1 && b < 700)
                {
                    transform.position = transform.position + XZrandom * 50f * Time.deltaTime;
                }

                b = 0;
            }
            a = 0;
        } 
#endif
    }
}