using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;

    public GameObject turret;

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
            Instantiate(turret, new Vector3(transform.position.x, 2.25f, transform.position.z), transform.rotation);
        }
    }
}
