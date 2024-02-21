using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int expCount;
    public static int resourcesCount;

    public List<int> expToLevel;

    public static int playerLevel;

    private void Start()
    {
        playerLevel = 1;
    }

    private void Update()
    {
        if (expCount >= expToLevel[playerLevel - 1] && playerLevel < 10)
        {
            playerLevel++;
        }
    }
}
