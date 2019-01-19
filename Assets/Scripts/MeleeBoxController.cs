using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeBoxController : MonoBehaviour
{
    Transform target;
    public NavMeshAgent agent;
    Vector3 newPosition;
    float xPositionChange, zPositionChange;
    int positionChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        FaceTarget();

        agent.SetDestination(target.transform.position);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
