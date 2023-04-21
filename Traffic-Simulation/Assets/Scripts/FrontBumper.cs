using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrontBumper : MonoBehaviour
{
    [SerializeField] private NavMeshAgent myCarAgent;
    [SerializeField] private Vehicle myCar;

    [SerializeField] private float vehicleSpeed = 4;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarDestination"))
        {
            Destroy(myCar.gameObject);
        }

        if (other.CompareTag("BackBumper"))
        {
            myCarAgent.SetDestination(myCar.gameObject.transform.position);
        }

        if (other.CompareTag("StopLight") && myCar.myStopLight.LightStatus == "Red")
        {
            myCarAgent.SetDestination(myCar.gameObject.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BackBumper"))
        {
            myCarAgent.SetDestination(myCar.myDestination.position);
        }

        if (other.CompareTag("StopLight") && myCar.myStopLight.LightStatus == "Green")
        {
            myCarAgent.SetDestination(myCar.myDestination.position);
        }
    }
}
