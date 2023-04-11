using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vehicle : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] public Transform myDestination;
    [SerializeField] private float vehicleSpeed = 4;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = myDestination.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarDestination"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("BackBumper"))
        {
            _agent.speed = 0;
        }

        if (other.CompareTag("StopLight"))
        {
            _agent.speed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BackBumper"))
        {
            _agent.speed = vehicleSpeed;
        }
        
        if (other.CompareTag("StopLight"))
        {
            _agent.speed = vehicleSpeed;
        }
    }
}
