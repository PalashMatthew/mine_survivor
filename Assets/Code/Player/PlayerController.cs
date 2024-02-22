using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;

    public GameObject turret;

    public bool isRegen;
    public float regenValue;

    private void Start()
    {
        StartCoroutine(Regen());
    }

    public void Hit(float _damage)
    {
        hp -= _damage;

        if (hp <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(turret, new Vector3(transform.position.x, 1f, transform.position.z), transform.rotation);
        }
    }

    IEnumerator Regen()
    {
        yield return new WaitForSeconds(1);

        if (isRegen)
        {
            hp += hp / 100 * regenValue;
        }

        StartCoroutine(Regen());
    }
}
