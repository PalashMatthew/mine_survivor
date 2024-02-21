using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObj : MonoBehaviour
{
    public float hpUp;

    public float pickUpDistance;
    Transform player;

    bool isPickUp = false;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < pickUpDistance && !isPickUp)
        {
            isPickUp = true;
        }

        if (isPickUp)
        {
            transform.DOMove(player.position, 0.5f);

            if (Vector3.Distance(transform.position, player.position) < 1)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().hp += hpUp;
                Destroy(gameObject);
            }
        }
    }
}