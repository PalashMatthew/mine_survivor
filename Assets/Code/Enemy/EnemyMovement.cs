using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    public AIDestinationSetter destinationSetter;
    public AIPath aiPatch;

    private void Start()
    {
        player = GameObject.Find("Player");

        destinationSetter.target = player.transform;
        aiPatch.canMove = true;
    }

    private void Update()
    {

    }    
}
