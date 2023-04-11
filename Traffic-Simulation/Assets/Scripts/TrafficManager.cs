using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
        [SerializeField] private List<StopLight> stopLights = new List<StopLight>();

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
                        if (stopLights[0].gameObject.transform.position != stopLights[0].startPos)
                        {
                                stopLights[0].RedLight();
                                stopLights[1].GreenLight();
                                Debug.Log("StopLight 1 is green");
                        }
                        
                        else if (stopLights[1].gameObject.transform.position != stopLights[1].startPos)
                        {
                                stopLights[1].RedLight();
                                stopLights[2].GreenLight();
                                Debug.Log("StopLight 2 is green");
                                
                        }
                        else if (stopLights[2].gameObject.transform.position != stopLights[2].startPos)
                        {
                                stopLights[2].RedLight();
                                stopLights[3].GreenLight();
                                Debug.Log("StopLight 3 is green");
                        }
                        else if (stopLights[3].gameObject.transform.position != stopLights[3].startPos)
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
                        yield return new WaitForSeconds(5f);
                        _triggerNewTurn = true;
                        _isRunning = false;
                }
        }

        private IEnumerator StartTraffic()
        {
                yield return new WaitForSeconds(2f);
                stopLights[0].GreenLight();
                stopLights[1].RedLight();
                stopLights[2].RedLight();
                stopLights[3].RedLight();
                Debug.Log("StopLight 0 is green");
        }
}