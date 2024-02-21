using Pathfinding;
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

    [Header("Repulsion")]
    public float repulsionTime;
    public float repulsionSpeed;
    private bool isRepulsion;

    public AIPath aiPatch;

    [Header("Repulsion")]
    public bool isExplosion;
    public float distanceExplosion;
    public GameObject explosionObj;
    bool explosionActive;
    public float explosionPause;


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

        if (isRepulsion)
        {
            transform.Translate(-Vector3.forward * repulsionSpeed * Time.deltaTime);
        }

        if (isExplosion)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= distanceExplosion && !explosionActive)
            {
                explosionActive = true;
                aiPatch.canMove = false;
                StartCoroutine(Explosion());                
            }
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(explosionPause);
        GameObject gm = Instantiate(explosionObj, transform.position, transform.rotation);
        gm.GetComponent<EnemyExplosion>().damage = damage;

        GameObject.Find("GameController").GetComponent<EnemySpawn>().enemyInst.Remove(gameObject);

        Destroy(gameObject);
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

            Vector3 pos = new Vector3(Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f), 1, Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f));

            Instantiate(expObj, pos, transform.rotation);

            Destroy(gameObject);
        }
    }

    public void Repulsion()
    {
        aiPatch.canMove = false;
        isRepulsion = true;
        StartCoroutine(RepulsionEnum());
    }

    IEnumerator RepulsionEnum()
    {
        yield return new WaitForSeconds(repulsionTime);
        isRepulsion = false;
        aiPatch.canMove = true;
    }
}
