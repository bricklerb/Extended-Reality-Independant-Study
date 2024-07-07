using Assets.NeuralNet;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Neuron : MonoBehaviour
{
    public List<GameObject> previous = new List<GameObject>();

    //Reference to the game object used to connect nodes together
    public GameObject connectionObject;

    private Dictionary<GameObject, GameObject> nodeToConnection = new Dictionary<GameObject, GameObject>();
    private bool connectionsCreated = false;
    private bool displayValueText = false;


    //public WeatherPredictionNeuralNet.Network.Network.Neuron nueronInNetwork { get; set; }
    public double Output { get; set; } = 0;
    public bool DisplayOutputText
    {
        get => displayValueText;
        set
        {
            displayValueText = value;
            transform.GetChild(0).gameObject.SetActive(value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material.color = Color.black + new Color((float)Output, (float)Output, (float)Output);

        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshPro>().text = Output.ToString("0.00");
        }

        //this.GetComponent<Renderer>().material.color = new Color((float)(255 * this.nueronInNetwork.output), (float)(255 * this.nueronInNetwork.output), (float)(255 * this.nueronInNetwork.output), 255);
        //this.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color - new Color(255, 255, 255);
        //this.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color + new Color((float)(255 * this.nueronInNetwork.output) - 10, (float)(255 * this.nueronInNetwork.output) - 10, (float)(255 * this.nueronInNetwork.output) - 10);
    }

    private void FixedUpdate()
    {
        if (!connectionsCreated)
        {
            var radius = gameObject.GetComponent<MeshRenderer>().bounds.extents.x;
            foreach (var node in previous)
            {
                connectionsCreated = true;

                var newConnection = Instantiate(connectionObject);
                newConnection.transform.position = this.gameObject.transform.position;
                newConnection.GetComponent<Connection>().fromNode = node;
                newConnection.GetComponent<Connection>().toNode = gameObject;

                //Calulate the distance to the previous node and scale the cylinder to reach that node
                //var cylinderLength = newConnection.GetComponent<MeshRenderer>().bounds.size.y;
                //var heading = node.transform.position - gameObject.transform.position;
                //var distance = heading.magnitude;
                //var scaleFactor = distance / cylinderLength;
                //newConnection.transform.localScale = new Vector3(newConnection.transform.localScale.x, newConnection.transform.localScale.y * scaleFactor, newConnection.transform.localScale.z);

                //Point the cylinder at the prev node
                //newConnection.transform.up = heading.normalized;


                //This moves the end postion of the connection cylinder to the middle of the neuron

                //var offsetLength = cylinderLength / 2f + radius;

                //Vector3 positionOffset = new Vector3(heading.normalized.x, heading.normalized.y, heading.normalized.z);
                //positionOffset.Scale(new Vector3(offsetLength, offsetLength, offsetLength));
                //newConnection.transform.position += positionOffset;

                //nodeToConnection.Add(node, newConnection);

                //Reposition the connection lines based on where the neurons are in space
            }
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        //GetComponent<Renderer>().material.SetColor("black", Color.black);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        //GetComponent<Renderer>().material.SetColor("white", Color.white);
    }


}
