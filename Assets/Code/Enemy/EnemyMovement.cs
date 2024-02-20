using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;

    GameObject player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");        
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }    
}
