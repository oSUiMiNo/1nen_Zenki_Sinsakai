using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier_Effect : MonoBehaviour
{
    bool E = true;
    GameObject effect;
    GameObject SE;
    int n;

    private void Start()
    {
        effect = GameObject.Find("Effect_Barrier");
        SE = GameObject.Find("SE_Barrier");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerBullet")
        {
            E = false;

        }    
    }

#if true

    private void FixedUpdate()
    {
        if (E == false)
        {
            n++;
        }

        if (E == true)
        {
            n = 0;
        }

        if (n >= 1)
        {
            if (n <= 2)
            {
                Instantiate(effect, this.transform.position, this.transform.rotation);
                Instantiate(SE, this.transform.position, this.transform.rotation);

                E = true;
                
            }
        }
    }
#endif
}
