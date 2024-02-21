using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float shotSpeed;
    public GameObject bullet;

    public float damage;

    //public float shotDistance;


    private void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(shotSpeed);

        GameObject inst = Instantiate(bullet, transform.position, transform.rotation);

        inst.GetComponent<EnemyBullet>().damage = damage;

        StartCoroutine(Shot());
    }
}
