using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade : MonoBehaviour
{
    public int resNeedToUpgrade;

    public float turretDamage;
    public float turretShotSpeed;

    public float turretDamageUp;
    public float turretShotSpeedUp;


    private void Update()
    {
        if (GameController.resourcesCount >= resNeedToUpgrade)
        {
            Upgrade();
            GameController.resourcesCount -= resNeedToUpgrade;
        }
    }

    void Upgrade()
    {
        turretDamage += turretDamageUp;
        turretShotSpeed -= turretShotSpeedUp;
    }
}
