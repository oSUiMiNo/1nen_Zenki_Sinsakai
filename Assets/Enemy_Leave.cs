using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Leave : MonoBehaviour
{
    public float leaveSpeed = 10;
   
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Vector3 enemyPos = collider.gameObject.transform.position;

            enemyPos.y = transform.position.y;

            transform.LookAt(enemyPos * (-1));

            transform.position = transform.position + transform.forward * leaveSpeed * Time.deltaTime;
        }
    }
}
