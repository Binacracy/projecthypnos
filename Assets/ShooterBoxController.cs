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

        if (distance < 20 && positionChangeTimer == 200)
        {
            xPositionChange = Random.Range(-40, 40);
            zPositionChange = Random.Range(-40, 40);

            newPosition = new Vector3(target.transform.position.x + xPositionChange, 0, target.transform.position.z + zPositionChange);
            agent.SetDestination(newPosition);
        }
        else if (positionChangeTimer == 100)
        {
            agent.SetDestination(target.transform.position);
            positionChangeTimer = 310;
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
