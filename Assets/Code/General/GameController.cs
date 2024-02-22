using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int expCount;
    public static int resourcesCount;

    public List<int> expToLevel;

    public static int playerLevel;

    public float expPickUpDistance;

    public GameObject gun2, gun3;
    public int levelGun2, levelGun3;

    private void Start()
    {
        Application.targetFrameRate = 60;

        playerLevel = 1;
    }

    private void Update()
    {
        if (expCount >= expToLevel[playerLevel - 1] && playerLevel < expToLevel.Count)
        {
            playerLevel++;
            GetComponent<UpgradeController>().ShowUpgrade();

            if (playerLevel == levelGun2)
                gun2.SetActive(true);

            if (playerLevel == levelGun3)
                gun3.SetActive(true);
        }
    }
}
