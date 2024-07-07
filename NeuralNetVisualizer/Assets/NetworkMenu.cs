using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkMenu : MonoBehaviour
{
    public GameObject networkGameObject;
    public GameObject layerEditObject;
    private List<GameObject> objectsInMenu = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var neuralNet = networkGameObject.GetComponent<NeuralNet>();
        var layerSizes = networkGameObject.GetComponent<NeuralNet>().LayerCount;
        if (layerSizes == 0)
        {
            //Setup input and output layers
            var input = Instantiate(layerEditObject);
            var output = Instantiate(layerEditObject);

            objectsInMenu.Add(input);
            objectsInMenu.Add(output);
        }
        else
        {
            //Display layer editors for current network configuration
            for (int i = 0; i < neuralNet.LayerCount; i++)
            {
                var layer = Instantiate(layerEditObject);

                objectsInMenu.Add(layer);
            }
        }

        PositionItemsInMenu();
        SetLayerNames();
    }

    private void SetLayerNames()
    {
        for (int i = 0; i < objectsInMenu.Count; i++)
        {
            GameObject layer = objectsInMenu[i];

            string name = $"Hidden {i - 1}";
            if (i == 0)
            {
                name = "Input";
            }
            else if (i == objectsInMenu.Count - 1)
            {
                name = "Output";
            }

            layer.transform.Find("LayerName").GetComponent<TextMeshPro>().text = name;
        }
    }

    private void PositionItemsInMenu()
    {
        bool even = objectsInMenu.Count % 2 == 0;
        for (int i = 0; i < objectsInMenu.Count; i++)
        {
            //If the integer is greater than the midpoint then the direction is postitve
            var direction = i <= (objectsInMenu.Count / 2f) ? -1 : 1;


            //If the index minus half the count is less than an 1 away then this is the middle postion
            //Only needed for odd counts
            var distanceFromMid = objectsInMenu.Count / 2f - i;
            if (!even && distanceFromMid < 1 && distanceFromMid > 0)
            {
                objectsInMenu[i].transform.position = gameObject.transform.position;
            }
            else
            {
                objectsInMenu[i].transform.position = gameObject.transform.position;

                //This is the widest mesh on the object
                var mesh = objectsInMenu[i].transform.Find("CountDisplay").GetComponent<MeshRenderer>();

                var width = Vector3.Scale(mesh.bounds.size, gameObject.transform.right).magnitude;
                objectsInMenu[i].transform.position += Vector3.Scale(gameObject.transform.right, new Vector3(width, width, width)) * direction * 1.5f;
            }

            objectsInMenu[i].transform.position += Vector3.Scale(new Vector3(.15f, .15f, .15f), gameObject.transform.up);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void LayerUpSelected(SelectEnterEventArgs args)
        {
            var layer = objectsInMenu.IndexOf(args.interactable.gameObject.transform.parent.gameObject);
            var net = networkGameObject.GetComponent<NeuralNet>();
            net.SetLayerSize(layer, net.GetLayerSize(layer) + 1);
        }
    }
}
