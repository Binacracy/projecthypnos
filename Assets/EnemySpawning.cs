using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnRadius;
    public Vector3 spawnCenter;
    public int startWait;
    public float spawnWaitMax;
    public float spawnWaitMin;
    float spawnWait;
    public float spawnMaximum;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());

        spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);

        int i = 0;

        while (spawnMaximum > i)
        {
            randEnemy = Random.Range(0, enemies.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadius.x, spawnRadius.x), Random.Range(-spawnRadius.y, spawnRadius.y), Random.Range(-spawnRadius.z, spawnRadius.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(spawnCenter.x, spawnCenter.y, spawnCenter.z), gameObject.transform.rotation);
            i++;

            yield return new WaitForSeconds(spawnWait);
        }
    }
}