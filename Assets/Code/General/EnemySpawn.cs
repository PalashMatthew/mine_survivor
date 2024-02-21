using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public float enemyCount;
    public float spawnTime;

    public float maxEnemyInLevel;

    public float minX, minZ;
    public float maxX, maxZ;
    public float minForward, maxForward;

    GameObject player;
    Transform cameraTransform;

    private NavMeshPath path;

    public List<GameObject> enemyInst;

    public List<GameObject> spawnEnemyPoint;


    private void Start()
    {
        player = GameObject.Find("Player");
        cameraTransform = player.transform;

        path = new NavMeshPath();

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnTime);

        for (int i = 0; i < enemyCount; i++)
        {
            if (enemyInst.Count < maxEnemyInLevel)
            {
                GameObject gm = Instantiate(enemy, SpawnPosition(), transform.rotation);
                enemyInst.Add(gm);
            }
        }        

        StartCoroutine(SpawnEnemy());
    }

    Vector3 SpawnPosition()
    {
        bool done = false;
        Vector3 position = Vector3.zero;

        while (!done)
        {
            int rand = Random.Range(0, spawnEnemyPoint.Count);

            if (!spawnEnemyPoint[rand].GetComponent<CheckVisible>().Check())
            {
                done = true;
                position = spawnEnemyPoint[rand].transform.position;
            }
        }

        return position;
    }
}
