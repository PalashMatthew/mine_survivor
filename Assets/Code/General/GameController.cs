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
        }
    }
}
