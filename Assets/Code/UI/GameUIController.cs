using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public TMP_Text tHp;

    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        tHp.text = "HP = " + player.GetComponent<PlayerController>().hp + "/" + player.GetComponent<PlayerController>().maxHp;
    }
}
