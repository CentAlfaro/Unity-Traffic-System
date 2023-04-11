using System;
using UnityEngine;

public class StopLight : MonoBehaviour
{
        public Vector3 startPos;

        private void Start()
        {
                startPos = transform.position;
        }

        public void RedLight()
        {
                transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }

        public void GreenLight()
        {
                transform.position = new Vector3(startPos.x, 10f, startPos.z);
        }
}