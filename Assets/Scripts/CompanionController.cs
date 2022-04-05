using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {  target = PlayerManager.instance.player.transform;
       agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
         if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance <=agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }
    void FaceTarget(){
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);  //to smoothen the rotation animation
}
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


