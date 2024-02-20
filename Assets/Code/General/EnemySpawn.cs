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
        int dir;
        float _x = 0;
        float _z = 0;

        Vector3 targetPos = Vector3.zero;

        bool isFind = false;

        while (!isFind)
        {
            dir = Random.Range(1, 5);

            if (dir == 1)
            {
                _z = Random.Range(cameraTransform.position.z + minForward, cameraTransform.position.z + maxForward);
                _x = Random.Range(cameraTransform.position.x - minX, cameraTransform.position.x + minX);
            }

            if (dir == 2)
            {
                _z = Random.Range(cameraTransform.position.z - minZ, cameraTransform.position.z - maxZ);
                _x = Random.Range(cameraTransform.position.x + minX, cameraTransform.position.x + maxX);
            }

            if (dir == 3)
            {
                _z = Random.Range(cameraTransform.position.z + minForward, cameraTransform.position.z + maxForward);
                _x = Random.Range(cameraTransform.position.x - minX, cameraTransform.position.x + minX);
            }

            if (dir == 4)
            {
                _z = Random.Range(cameraTransform.position.z - minForward, cameraTransform.position.z + minForward);
                _x = Random.Range(cameraTransform.position.x - minX, cameraTransform.position.x - maxX);
            }

            targetPos = new Vector3(_x, 1, _z);

            NavMesh.CalculatePath(player.transform.position, targetPos, NavMesh.AllAreas, path);

            if (path.status == NavMeshPathStatus.PathComplete)
            {
                isFind = true;
            }
            else
            {
                isFind = false;
            }
        }

        return targetPos;
    }
}
