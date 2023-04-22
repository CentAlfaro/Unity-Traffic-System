using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Vehicle : MonoBehaviour
{
    private NavMeshAgent _agent;


    [SerializeField] public Transform myDestination;
    [SerializeField] public StopLight myStopLight;

    [SerializeField] private List<Material> colorMaterials;


    private void Start()
    {
        GetComponent<Renderer>().material = colorMaterials[Random.Range(0, colorMaterials.Count)];
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = myDestination.position;
    }
    
}
