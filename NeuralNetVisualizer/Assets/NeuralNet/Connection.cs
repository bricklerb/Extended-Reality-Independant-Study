using System;
using UnityEngine;

namespace Assets.NeuralNet
{
    public class Connection : MonoBehaviour
    {
        public GameObject fromNode;
        public GameObject toNode;

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set {
                _weight = value;
                UpdateColor();
            } 
        }

        private Vector3 previousMidpoint;
        static System.Random r = new System.Random();
        private void Start()
        {
            
            
            Weight = (r.NextDouble() * 4);
            if (r.Next(0, 2) == 1)
            {
                Weight *= -1;
            }
        }

        private void Update()
        {


        }

        private void UpdateColor()
        {
            double percent = ZValue.GetPercentile(Weight);

            Color color = Color.black;
            if (Weight < 0)
            {
                color += new Color((float)(percent * 255), (float)((1 - percent) * 255f), 0f);
            }
            else
            {
                color += new Color((float)((1 - percent) * 255), (float)(percent * 255f), 0f);
            }

            GetComponent<MeshRenderer>().material.color = color;
        }

        private void FixedUpdate()
        {
            if (fromNode == null || toNode == null)
            {
                return;
            }

            if ((fromNode.transform.position - toNode.transform.position) / 2 != previousMidpoint)
            {
                previousMidpoint = (fromNode.transform.position - toNode.transform.position) / 2;
                RepostionConnectionCylinder();
            }  
        }
        private void RepostionConnectionCylinder()
        {
            var heading = fromNode.transform.position - toNode.transform.position;
            var midPoint = (fromNode.transform.position + toNode.transform.position) / 2;

            gameObject.transform.up = Vector3.up;
            var cylinderLength = gameObject.GetComponent<MeshRenderer>().bounds.size.y;
            var scaleAmount = heading.magnitude / cylinderLength;
            var scaleDifference = scaleAmount - gameObject.transform.localScale.y;

            gameObject.transform.localScale += new Vector3(0, scaleDifference, 0);

            gameObject.transform.position = midPoint;
            gameObject.transform.up = heading.normalized;
        }
    }
}
