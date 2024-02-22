using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public GameObject canvas;

    public TMP_Text tCard1, tCard2, tCard3;

    public List<string> cardName;
    private List<string> upgrades = new List<string>();

    public int commonChance, rareChance, epicChance;

    public Image imgCard1, imgCard2, imgCard3;
    public string rarityCard1, rarityCard2, rarityCard3;

    public DefaultGun gun1;
    public ShotGun gun2;
    public GrenadeController gun3;


    private void Start()
    {
        canvas.SetActive(false);
    }

    public void ShowUpgrade()
    {
        canvas.SetActive(true);

        Time.timeScale = 0;

        upgrades.Clear();

        for (int i = 0; i < 3; i++)
        {
            string s = cardName[Random.Range(0, cardName.Count)];

            if (!upgrades.Contains(s))
            {
                upgrades.Add(s);
            }
            else
            {
                i--;
            }
        }

        tCard1.text = upgrades[0];
        tCard2.text = upgrades[1];
        tCard3.text = upgrades[2];

        int rar1 = Random.Range(1, 101);
        if (rar1 <= commonChance)
        {
            rarityCard1 = "common";
        }
        if (rar1 > commonChance && rar1 <= rareChance)
        {
            rarityCard1 = "rare";
        }
        if (rar1 > rareChance)
        {
            rarityCard1 = "epic";
        }

        rar1 = Random.Range(1, 101);
        if (rar1 <= commonChance)
        {
            rarityCard2 = "common";
        }
        if (rar1 > commonChance && rar1 <= rareChance)
        {
            rarityCard2 = "rare";
        }
        if (rar1 > rareChance)
        {
            rarityCard2 = "epic";
        }

        rar1 = Random.Range(1, 101);
        if (rar1 <= commonChance)
        {
            rarityCard3 = "common";
        }
        if (rar1 > commonChance && rar1 <= rareChance)
        {
            rarityCard3 = "rare";
        }
        if (rar1 > rareChance)
        {
            rarityCard3 = "epic";
        }

        if (rarityCard1 == "common")
        {
            imgCard1.color = Color.white;
        }
        if (rarityCard2 == "common")
        {
            imgCard2.color = Color.white;
        }
        if (rarityCard3 == "common")
        {
            imgCard3.color = Color.white;
        }

        if (rarityCard1 == "rare")
        {
            imgCard1.color = Color.blue;
        }
        if (rarityCard2 == "rare")
        {
            imgCard2.color = Color.blue;
        }
        if (rarityCard3 == "rare")
        {
            imgCard3.color = Color.blue;
        }

        if (rarityCard1 == "epic")
        {
            imgCard1.color = Color.red;
        }
        if (rarityCard2 == "epic")
        {
            imgCard2.color = Color.red;
        }
        if (rarityCard3 == "epic")
        {
            imgCard3.color = Color.red;
        }
    }

    public void ChooseUpgrade(int num)
    {
        if (upgrades[num] == cardName[0])
        {
            Damage_Upg(num);
        }

        if (upgrades[num] == cardName[1])
        {
            Health_Upg(num);
        }

        if (upgrades[num] == cardName[2])
        {
            WalkSpeed_Upg(num);
        }

        if (upgrades[num] == cardName[3])
        {
            MiningSpeed_Upg(num);
        }

        if (upgrades[num] == cardName[4])
        {
            Magnet_Upg(num);
        }

        if (upgrades[num] == cardName[5])
        {
            Regen_Upg(num);
        }
    }

    public void CloseUpgrade()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    #region Upgrades
    void Damage_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        gun1.damage += gun1.damage / 100 * value;
        gun2.damage += gun2.damage / 100 * value;
        gun3.damage += gun3.damage / 100 * value;
    }

    void Health_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        GameObject.Find("Player").GetComponent<PlayerController>().maxHp += GameObject.Find("Player").GetComponent<PlayerController>().maxHp / 100 * value;
        GameObject.Find("Player").GetComponent<PlayerController>().hp += GameObject.Find("Player").GetComponent<PlayerController>().hp / 100 * value;
    }

    void WalkSpeed_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        GameObject.Find("Player").GetComponent<PlayerMovement>().speed += GameObject.Find("Player").GetComponent<PlayerMovement>().speed / 100 * value;
    }

    void MiningSpeed_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        GameObject.Find("Player").GetComponent<PlayerMining>().miningForce += GameObject.Find("Player").GetComponent<PlayerMining>().miningForce / 100 * value;
        GameObject.Find("Player").GetComponent<PlayerMining>().miningSpeed -= GameObject.Find("Player").GetComponent<PlayerMining>().miningSpeed / 100 * value;
    }

    void Magnet_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        GameObject.Find("GameController").GetComponent<GameController>().expPickUpDistance += GameObject.Find("GameController").GetComponent<GameController>().expPickUpDistance / 100 * value;
    }

    void Regen_Upg(int num)
    {
        float value = 0;

        if (num == 0)
        {
            if (rarityCard1 == "common")
            {
                value = 5;
            }

            if (rarityCard1 == "rare")
            {
                value = 7;
            }

            if (rarityCard1 == "epic")
            {
                value = 10;
            }
        }

        if (num == 1)
        {
            if (rarityCard2 == "common")
            {
                value = 5;
            }

            if (rarityCard2 == "rare")
            {
                value = 7;
            }

            if (rarityCard2 == "epic")
            {
                value = 10;
            }
        }

        if (num == 2)
        {
            if (rarityCard3 == "common")
            {
                value = 5;
            }

            if (rarityCard3 == "rare")
            {
                value = 7;
            }

            if (rarityCard3 == "epic")
            {
                value = 10;
            }
        }

        GameObject.Find("Player").GetComponent<PlayerController>().isRegen = true;
        GameObject.Find("Player").GetComponent<PlayerController>().regenValue += GameObject.Find("Player").GetComponent<PlayerController>().regenValue / 100 * value;
    }
    #endregion
}
