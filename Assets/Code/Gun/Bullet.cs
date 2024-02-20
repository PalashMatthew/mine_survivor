using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;


    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            other.GetComponent<EnemyController>().Hit(damage);
            Destroy(gameObject);
        }

        if (other.tag == "block")
        {
            Destroy(gameObject);
        }
    }
}
