using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TMP_Text tHp;
    public TMP_Text tExp;
    public TMP_Text tRes;

    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        tHp.text = "HP = " + player.GetComponent<PlayerController>().hp + "/" + player.GetComponent<PlayerController>().maxHp;

        tExp.text = "EXP = " + GameController.expCount;

        tRes.text = "RES = " + GameController.resourcesCount;
    }
}
