using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class CarSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> carDestination = new List<Transform>();
    [SerializeField] private GameObject car;

    private bool _canSpawnVehicle = false;
    private bool _isRunning;
    private float _randomValue;

    private void Update()
    {
        if (_canSpawnVehicle)
        {
            var temporaryCar = Instantiate(car, transform.position, Quaternion.identity);
            temporaryCar.GetComponent<Vehicle>().myDestination = carDestination[Random.Range(0,carDestination.Count)];

            _canSpawnVehicle = false;
        }

        else
        {
            StartCoroutine(SpawnTimer());
        }
    }

    private IEnumerator SpawnTimer()
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _randomValue = Random.Range(4, 12);
            yield return new WaitForSeconds(_randomValue);
            _canSpawnVehicle = true;
            _isRunning = false;
        }
    }
}
