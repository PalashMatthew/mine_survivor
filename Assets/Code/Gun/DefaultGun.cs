using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : MonoBehaviour
{
    public float attackSpeed;
    public float damage;

    EnemySpawn enemySpawn;

    public LayerMask layer;

    public GameObject bulletObj;
    public Transform spawnPos;


    private void Start()
    {
        enemySpawn = GameObject.Find("GameController").GetComponent<EnemySpawn>();

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackSpeed);

        float dist = 99999;
        GameObject enemyObj = null;

        foreach (GameObject gm in enemySpawn.enemyInst)
        {
            if (Vector3.Distance(transform.position, gm.transform.position) < dist && CheckRay(gm))
            {
                enemyObj = gm;
                dist = Vector3.Distance(transform.position, gm.transform.position);
            }
        }

        if (enemyObj != null)
        {            
            GameObject _bullet = Instantiate(bulletObj, spawnPos.position, transform.rotation);
            _bullet.transform.forward = enemyObj.transform.position - transform.position;
            //_bullet.transform.position = new Vector3(_bullet.transform.position.x, 1.5f, _bullet.transform.position.z);

            _bullet.GetComponent<Bullet>().damage = damage;
        }

        StartCoroutine(Attack());
    }

    bool CheckRay(GameObject _enemy)
    {
        RaycastHit hit;

        Vector3 dir = (_enemy.transform.position - spawnPos.position).normalized;

        if (Physics.Raycast(spawnPos.position, dir, out hit, Mathf.Infinity, layer))
        {
            Debug.DrawRay(spawnPos.position, dir * hit.distance, Color.yellow);

            if (hit.collider.tag == "enemy")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.DrawRay(spawnPos.position, dir * 1000, Color.red);
        }

        return false;
    }
}
