using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vehicle : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private FrontBumper myBumper;

    [SerializeField] public Transform myDestination;
    [SerializeField] public StopLight myStopLight;

    //[SerializeField] private float vehicleSpeed = 4;


    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = myDestination.position;
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarDestination"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("BackBumper"))
        {
            _agent.speed = 0;
        }

        if (other.CompareTag("StopLight") && myStopLight.LightStatus == "Red")
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
        
        if (other.CompareTag("StopLight") && myStopLight.LightStatus == "Green")
        {
            _agent.speed = vehicleSpeed;
        }
    }*/
}
