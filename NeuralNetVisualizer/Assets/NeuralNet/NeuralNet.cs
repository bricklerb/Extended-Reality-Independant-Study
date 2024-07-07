using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNet : MonoBehaviour
{
    NeuralNetwork.Network net = null;

    public TextAsset weatherNet;
    public GameObject nueron;
    public GameObject feedFowardUpdate;

    private static float UpdateSpeed = .5f;

    //private List<GameObject> nuerons;
    private List<List<GameObject>> layersOfGameObjects;
    //public Dictionary<WeatherPredictionNeuralNet.Network.Network.Neuron, GameObject> neuronToObjectDict;

    private int[] _layerSizes = { 1, 1};

    public int LayerCount => _layerSizes.Length;

    public int GetLayerSize(int layer)
    {
        return _layerSizes[layer];
    }

    public void SetLayerSize(int layer, int size)
    {
        
    }

    public void AddLayer(int size)
    {

    }

    public void RemoveLayer(int layer)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //Object asset = Resources.Load("Assets/NeuralNet/weather");
        //net = new NeuralNetwork.Network()
        layersOfGameObjects = new List<List<GameObject>>();
        BuildNeuralNetObject();

        //layerSizes = new int[] { 2, 2, 2, 2 };
        //InitNetValues(new double[,]
        //{
        //        {.75f, .75f},
        //        {.75f, .75f},
        //        {.75f, .75f},
        //        {.75f, .75f},
        //});

        //neuronToObjectDict = new Dictionary<WeatherPredictionNeuralNet.Network.Network.Neuron, GameObject>();

        //BuildNeuralNetObject();

        //net.SetInput(new List<double> { 1, 1 });

    }

    // Update is called once per frame
    int count = 0;
    void Update()
    {
        if (count == 5000)
        {
            //ShowFeedFoward(new double[,]
            //{
            //        {.5, .5 },
            //        {.5, .5 },
            //        {.5, .5 },
            //        {.5, .5 },
            //});
            count = 0;
        }
        count++;
        //Set color based on current weight value

    }

    /// <summary>
    /// Shows the feedfoward animation from the current set of values to a new set
    /// </summary>
    /// <param name="inputs"></param>
    public void ShowFeedFoward(double[,] newOutputValues)
    {
        StartCoroutine(DoFeedFowardAnimation(newOutputValues));
    }

    IEnumerator DoFeedFowardAnimation(double[,] newOutputValues)
    {
        for (int i = 0; i < LayerCount; i++)
        {
            var layerSize = GetLayerSize(i);

            //If we are at the start or end of the network just update the node appearance
            if (i == 0)
            {
                for (int j = 0; j < layerSize; j++)
                {
                    layersOfGameObjects[i][j].GetComponent<Neuron>().Output = newOutputValues[i, j];
                }
            }
            else if (i == LayerCount- 1)
            {
                break;
            }


            //Make a set of update objects
            List<(GameObject updateObject, GameObject target)> updateNodes = new List<(GameObject updateObject, GameObject target)>();
            for (int j = 0; j < GetLayerSize(i + 1); j++)
            {
                var feedfowardUpdate = Instantiate(feedFowardUpdate);
                feedfowardUpdate.transform.position = layersOfGameObjects[i][j].transform.position;
                feedfowardUpdate.GetComponent<Neuron>().Output = newOutputValues[i + 1, j];
                feedfowardUpdate.GetComponent<Neuron>().DisplayOutputText = true;

                updateNodes.Add((feedfowardUpdate, layersOfGameObjects[i + 1][j]));
            }

            //Move the update object
            while (true)
            {
                for (int j = 0; j < updateNodes.Count; j++)
                {
                    var update = updateNodes[j];
                    var heading = update.target.transform.position - update.updateObject.transform.position;

                    //If the update object has reached the target node remove it
                    if (heading.magnitude <= (.01f * UpdateSpeed))
                    {
                        var value = update.updateObject.GetComponent<Neuron>().Output;
                        update.target.GetComponent<Neuron>().Output = value;

                        Destroy(update.updateObject);
                        updateNodes.Remove(update);
                        j--;
                    }
                    else
                    {
                        update.updateObject.transform.position += heading * .01f * UpdateSpeed;
                    }
                }

                yield return new WaitForEndOfFrame();

                //Once all animations are complete exit the while
                if (updateNodes.Count == 0)
                {
                    break;
                }
            }

        }

        yield return null;
    }

    private void BuildNeuralNetObject()
    {
        for (int i = 0; i < LayerCount; i++)
        {
            layersOfGameObjects.Add(new List<GameObject>());
            for (int j = 0; j < GetLayerSize(i); j++)
            {
                var newNeuron = Instantiate(nueron);

                newNeuron.transform.position = this.gameObject.transform.position;
                newNeuron.transform.SetParent(this.gameObject.transform);

                var diameter = newNeuron.GetComponent<MeshRenderer>().bounds.size.x;
                newNeuron.transform.position += new Vector3(diameter * 3f * (i + 1), diameter * 1.25f * (j + 1));

                layersOfGameObjects[i].Add(newNeuron);

                var script = newNeuron.GetComponent<Neuron>();

                if (i > 0)
                {
                    foreach (var prev in layersOfGameObjects[i - 1])
                    {
                        script.previous.Add(prev);
                    }
                }
            }


        }
    }

    private void InitNetValues(double[,] values)
    {
        for (int i = 0; i < layersOfGameObjects.Count; i++)
        {
            for (int j = 0; j < layersOfGameObjects[i].Count; j++)
            {
                layersOfGameObjects[i][j].GetComponent<Neuron>().Output = values[i, j];
            }
        }
    }
}

