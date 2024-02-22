using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;

    public bool isRepulsion;
    public bool isExplosion;
    public GameObject grenadeExplosionObj;


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

            if (isRepulsion)
            {
                other.GetComponent<EnemyController>().Repulsion();
            }

            if (isExplosion)
            {
                Instantiate(grenadeExplosionObj, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        if (other.tag == "block")
        {
            if (isExplosion)
            {
                Instantiate(grenadeExplosionObj, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
