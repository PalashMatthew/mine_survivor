using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp;
    public float damage;

    public float attackDistance;
    bool isAttack;
    public float attackSpeed;

    GameObject player;

    public GameObject expObj;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance && !isAttack)
        {
            isAttack = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<PlayerController>().Hit(damage);

        yield return new WaitForSeconds(attackSpeed);

        isAttack = false;
    }

    public void Hit(float _damage)
    {
        hp -= _damage;

        if (hp <= 0)
        {
            GameObject.Find("GameController").GetComponent<EnemySpawn>().enemyInst.Remove(gameObject);

            Vector3 pos = new Vector3(Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f), 1, Random.Range(transform.position.z - 3.5f, transform.position.z + 3.5f));

            Instantiate(expObj, pos, transform.rotation);

            Destroy(gameObject);
        }
    }
}
