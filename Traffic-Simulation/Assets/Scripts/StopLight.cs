using System;
using UnityEngine;

public class StopLight : MonoBehaviour
{
        public Vector3 startPos;
        public string LightStatus;
        [SerializeField] private GameObject greenLight, redLight;

        private void Start()
        {
                startPos = transform.position;
        }

        public void RedLight()
        {
                LightStatus = "Red";
                transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
                redLight.SetActive(true);
                greenLight.SetActive(false);
        }

        public void GreenLight()
        {
            LightStatus = "Green";
            transform.position = new Vector3(startPos.x, 10f, startPos.z);
            redLight.SetActive(false);
            greenLight.SetActive(true);
        }
}