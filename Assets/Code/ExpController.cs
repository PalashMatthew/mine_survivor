using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
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
            transform.DOMove(player.position, 0.2f);

            if (Vector3.Distance(transform.position, player.position) < 1)
            {
                GameController.expCount++;
                Destroy(gameObject);
            }
        }
    }
}
