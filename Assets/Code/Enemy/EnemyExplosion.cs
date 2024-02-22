using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public float damage;
    SphereCollider col;

    public bool isDamagePlayer;

    private void Start()
    {
        col = GetComponent<SphereCollider>();

        StartCoroutine(Life());
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && isDamagePlayer)
        {
            other.GetComponent<PlayerController>().Hit(damage);
        }

        if (other.tag == "enemy")
        {
            other.GetComponent<EnemyController>().Hit(damage);
        }
    }
}
