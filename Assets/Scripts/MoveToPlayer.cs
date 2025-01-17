﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    public GameObject player;
    
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
    }
}
