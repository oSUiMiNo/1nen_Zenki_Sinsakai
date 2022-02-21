using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApproachTarget : MonoBehaviour
{
    public GameObject target;

    private NavMeshAgent agent;



    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

    }



    void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position;

        targetPos.y = this.transform.position.y;

        agent.destination = target.transform.position;

    }
}
