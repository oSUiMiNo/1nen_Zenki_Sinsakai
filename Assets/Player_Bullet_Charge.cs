using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Charge : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = player.transform.forward * 10f;
        }
    }
}
