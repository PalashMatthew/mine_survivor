using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;

    public void Hit(float _damage)
    {
        hp -= _damage;

        if (hp <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
