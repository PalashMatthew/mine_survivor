using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2, enemy3;

    public float enemy2Chance, enemy3Chance;

    public float enemyCount;
    public float spawnTime;

    public float maxEnemyInLevel;

    public float minX, minZ;
    public float maxX, maxZ;
    public float minForward, maxForward;

    GameObject player;

    public List<GameObject> enemyInst;

    public List<GameObject> spawnEnemyPoint;

    [Header("Boss")]
    public GameObject bossObj;
    public float timeBossSpawn;

    private int enemySpawnType;

    public float timeToAddEnemy;

    [Header("Roy")]
    public float royTime;
    public int royCount;
    public int enemyCountInRoy;


    private void Start()
    {
        enemySpawnType = 1;

        player = GameObject.Find("Player");

        StartCoroutine(SpawnEnemy());

        StartCoroutine(SpawnBoss());

        StartCoroutine(AddEnemyType());

        StartCoroutine(SpawnRoy());
    }

    IEnumerator AddEnemyType()
    {
        yield return new WaitForSeconds(timeToAddEnemy);

        enemySpawnType++;

        if (enemySpawnType < 3)
            StartCoroutine(AddEnemyType());
    }

    IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(timeBossSpawn);
        GameObject gm = Instantiate(bossObj, SpawnPosition(), transform.rotation);
        enemyInst.Add(gm);
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnTime);
        
        for (int i = 0; i < enemyCount; i++)
        {
            if (enemyInst.Count < maxEnemyInLevel)
            {
                if (enemySpawnType == 1)
                {
                    GameObject gm = Instantiate(enemy, SpawnPosition(), transform.rotation);
                    enemyInst.Add(gm);
                }

                if (enemySpawnType == 2)
                {
                    GameObject _enemy;

                    int rand = Random.Range(1, 101);

                    if (rand <= enemy2Chance)
                    {
                        _enemy = enemy2;
                    }
                    else
                    {
                        _enemy = enemy;
                    }

                    GameObject gm = Instantiate(_enemy, SpawnPosition(), transform.rotation);
                    enemyInst.Add(gm);
                }

                if (enemySpawnType == 3)
                {
                    GameObject _enemy;

                    int rand = Random.Range(1, 101);

                    if (rand <= enemy2Chance)
                    {
                        _enemy = enemy2;
                    }
                    else if (rand > enemy2Chance && rand < enemy3Chance)
                    {
                        _enemy = enemy3;
                    }
                    else
                    {
                        _enemy = enemy;
                    }

                    GameObject gm = Instantiate(_enemy, SpawnPosition(), transform.rotation);
                    enemyInst.Add(gm);
                }
            }
        }        

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnRoy()
    {
        yield return new WaitForSeconds(royTime);

        royCount--;

        for (int i = 0; i < enemyCountInRoy; i++)
        {
            if (enemyInst.Count < maxEnemyInLevel)
            {
                GameObject _enemy;

                int rand = Random.Range(1, 101);

                if (rand <= enemy2Chance)
                {
                    _enemy = enemy2;
                }
                else if (rand > enemy2Chance && rand < enemy3Chance)
                {
                    _enemy = enemy3;
                }
                else
                {
                    _enemy = enemy;
                }

                GameObject gm = Instantiate(_enemy, SpawnPosition(), transform.rotation);
                enemyInst.Add(gm);
            }
            yield return new WaitForSeconds(0.1f);
        }

        if (royCount > 0)
        {
            StartCoroutine(SpawnRoy());
        }
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
