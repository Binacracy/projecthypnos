using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterBoxController : MonoBehaviour
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
        positionChangeTimer = 200;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        FaceTarget();

        xPositionChange = Random.Range(-10, 10);
        zPositionChange = Random.Range(-10, 10);

        if (distance < 35 && positionChangeTimer == 100)
        {
            newPosition = new Vector3(target.transform.position.x + xPositionChange, 0, target.transform.position.z + zPositionChange);
            agent.SetDestination(newPosition);
        }
        else if (distance > 40)
        {
            agent.SetDestination(target.transform.position);
        }
        else if (positionChangeTimer == 0)
        {
            positionChangeTimer = 210;
        }
        positionChangeTimer--;
        print(positionChangeTimer);

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
