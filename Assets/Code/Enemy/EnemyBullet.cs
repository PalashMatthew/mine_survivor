using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Vector3 target;
    public float moveSpeed;

    public float distToAttack;

    bool isAttack = false;

    public float damage;

    private void Start()
    {
        target = GameObject.Find("Player").transform.position;

        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        transform.LookAt(target);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            other.GetComponent<PlayerController>().Hit(damage);
            Destroy(gameObject);
        }

        if (other.tag == "block")
        {
            Destroy(gameObject);
        }
    }
}
