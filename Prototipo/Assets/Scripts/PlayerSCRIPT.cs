using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSCRIPT : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }
}
