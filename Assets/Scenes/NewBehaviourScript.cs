using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randEnemy = Random.Range(0, 2);
            Debug.Log(randEnemy);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(0, spawnValues.y), Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0.5f, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
