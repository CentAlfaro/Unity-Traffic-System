using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
        [SerializeField] private List<StopLight> stopLights = new List<StopLight>();

        [SerializeField] private float trafficTimer = 5f;

        private bool _triggerNewTurn = false;
        private bool _isRunning = false;

        private void Start()
        {
                StartCoroutine(StartTraffic());
        }

        private void Update()
        {
                AttemptTrafficLightTrigger();
        }
        

        private void AttemptTrafficLightTrigger()
        {
                if (_triggerNewTurn)
                {
                        if (stopLights[0].LightStatus == "Green")
                        {
                                stopLights[0].RedLight();
                                stopLights[1].GreenLight();
                                Debug.Log("StopLight 1 is green");
                        }
                        
                        else if (stopLights[1].LightStatus == "Green")
                        {
                                stopLights[1].RedLight();
                                stopLights[2].GreenLight();
                                Debug.Log("StopLight 2 is green");
                                
                        }
                        else if (stopLights[2].LightStatus == "Green")
                        {
                                stopLights[2].RedLight();
                                stopLights[3].GreenLight();
                                Debug.Log("StopLight 3 is green");
                        }
                        else if (stopLights[3].LightStatus == "Green")
                        {
                                stopLights[3].RedLight();
                                stopLights[0].GreenLight();
                                Debug.Log("StopLight 0 is green");
                        }

                        _triggerNewTurn = false;
                }
                
                else
                {
                        StartCoroutine(TrafficTimer());
                }
        }

        private IEnumerator TrafficTimer()
        {
                if (!_isRunning)
                {
                        _isRunning = true;
                        yield return new WaitForSeconds(trafficTimer);
                        _triggerNewTurn = true;
                        _isRunning = false;
                }
        }

        private IEnumerator StartTraffic()
        {
                yield return new WaitForSeconds(1f);
                stopLights[0].GreenLight();
                stopLights[1].RedLight();
                stopLights[2].RedLight();
                stopLights[3].RedLight();
                Debug.Log("StopLight 0 is green");
        }
}