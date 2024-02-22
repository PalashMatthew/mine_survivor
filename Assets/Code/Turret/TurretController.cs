using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public DefaultGun gun;
    TurretUpgrade turretUpgrade;

    private void Start()
    {
        turretUpgrade = GameObject.Find("GameController").GetComponent<TurretUpgrade>();
    }

    private void Update()
    {
        gun.damage = turretUpgrade.turretDamage;
        gun.attackSpeed = turretUpgrade.turretShotSpeed;
    }
}
