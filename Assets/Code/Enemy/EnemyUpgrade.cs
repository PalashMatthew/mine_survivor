using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpgrade : MonoBehaviour
{
    public float timeUpgrade;

    public float hpUp;
    public float speedUp;
    public float damageUp;

    public EnemySpawn enemySpawn;


    private void Start()
    {
        StartCoroutine(Upgrade());
    }

    IEnumerator Upgrade()
    {
        yield return new WaitForSeconds (timeUpgrade);

        Debug.Log("Enemy Upgrade");

        foreach (GameObject gm in enemySpawn.enemyInst)
        {
            gm.GetComponent<EnemyController>().damage += damageUp;
            gm.GetComponent<EnemyController>().hp += hpUp;
            gm.GetComponent<AIPath>().maxSpeed += speedUp;
        }

        StartCoroutine(Upgrade());
    }
}
