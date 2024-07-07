using NumSharp;
using System.Collections.Generic;

namespace NeuralNetwork
{
    public class Network
    {
        //public List<List<Neuron>> neurons = new List<List<Neuron>>();
        //public List<NDArray> lastActivations = new List<NDArray>();
        //public List<NDArray> biases = new List<NDArray>();
        //public List<NDArray> weights = new List<NDArray>();

        public double LearningRate { get; set; }
        public IList<ILayer> Layers { get; set; }

        //private List<NDArray> _outputs;

        public Network(int input, int output, int[] hiddenLayerSizes, double learningRate)
        {
            LearningRate = learningRate;
            Layers = new List<ILayer>();

            //Layers.Add()
            //int lastLayerSize = input;
            //for (int i = 0; i < hiddenLayerSizes.Length; i++)
            //{
            //    weights.Add(np.random.randn(lastLayerSize, hiddenLayerSizes[i]));
            //    biases.Add(np.zeros(1, hiddenLayerSizes[i]));

            //    lastLayerSize = hiddenLayerSizes[i];
            //}

            //weights.Add(np.random.randn(lastLayerSize, output));
            //biases.Add(np.zeros(1, output));
            //lastActivations.Add(np.zeros())


            ////Generate Input Layer
            //neurons.Add(new List<Neuron>());
            //for (int i = 0; i < input; i++)
            //{
            //    Neuron n = new Neuron(0, i, null);
            //    neurons[0].Add(n);
            //}

            ////Generate Hidden Layers
            //for (int i = 0; i < layerSizes.Length; i++)
            //{
            //    neurons.Add(new List<Neuron>());
            //    for (int j = 0; j < layerSizes[i]; j++)
            //    {
            //        Neuron n = new Neuron(i + 1, j, neurons[i]);
            //        neurons[i + 1].Add(n);
            //    }
            //}

            ////Generate Output Layers
            //neurons.Add(new List<Neuron>());
            //for (int i = 0; i < output; i++)
            //{
            //    Neuron n = new Neuron(neurons.Count - 1, i, neurons[neurons.Count - 2]);
            //    neurons[neurons.Count - 1].Add(n);
            //}
        }

        public NDArray Train(NDArray inputs, NDArray expectedOutputs, int iterations)
        {
            List<NDArray> output = null;
            for (int i = 0; i < iterations; i++)
            {
                output = FeedForward(inputs);
            }

            return output[output.Count - 1];
        }

        /// <summary>
        /// Runs the feed foward algo on a given matrix of inputs
        /// Returns a list of the activations for all layers for all inputs
        /// Layers X Input Set X Node
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private List<NDArray> FeedForward(NDArray inputs)
        {
            foreach (var layer in Layers)
            {

            }

            return null;
            //List<NDArray> outputs = new List<NDArray>();

            //NDArray inputActivation = np.dot(inputs, weights[0]) + biases[0];
            //var inputOutput = MathFunctions.Sigmoid(inputActivation);

            //outputs.Add(inputOutput);

            //for (int i = 0; i < weights.Count - 1; i++)
            //{
            //    //Calulate for our input matrix this layers based on the activations of the last
            //    var activation = np.dot(outputs[i], weights[i + 1]);
            //    var output = MathFunctions.Sigmoid(activation);

            //    outputs.Add(output);
            //}

            //_outputs = outputs;
            //return outputs;


            //double[,] outputMatrix = new double[inputs.GetLength(0), inputs.GetLength(1)];

            //for (int i = 0; i < inputs.Length; i++)
            //{
            //    for (int j = 0;j < inputs.GetLength(0); j++)
            //    {
            //        neurons[0][j].Output = inputs[i][j];
            //    }

            //    outputMatrix[i] = new double[inputs[i].Length];

            //    for (int j = 0; j < inputs[i].Length; j++)
            //    {
            //        outputMatrix[i][j] = neurons[neurons.Count - 1][j].Output;
            //    }
            //}

            //return outputMatrix;
        }

        //private void BackPropagate(NDArray inputs, NDArray expectedOutputs)
        //{
        //    NDArray outputError = expectedOutputs - _outputs[_outputs.Count - 1];
        //    NDArray outputDelta = outputError * MathFunctions.SigmoidDerivative(_outputs[_outputs.Count - 1]);

        //    NDArray lastErrorDelta = outputDelta;
        //    for (int i = weights.Count - 2; i >= 0; i--)
        //    {
        //        var hiddenLayerError = np.dot(lastErrorDelta, weights[i].T);
        //        var hiddenLayerDelta = hiddenLayerError * MathFunctions.SigmoidDerivative(_outputs[i]);

        //        weights[i + 1] += np.dot(_outputs[i].T, lastErrorDelta) * LearningRate;
        //        biases[i + 1] += np.sum(lastErrorDelta, axis: 0, keepdims: true) * LearningRate;
        //    }


        //    weights[i] += np.dot(_outputs[].T, delta) * LearningRate;
        //    biases[i] += np.sum(delta, axis: 0, true) * LearningRate;

        //    for (int i = _outputs.Count - 1; i >= 0; i--)
        //    {



        //    }

        //double[,] outputError = expectedOutputs.Subtract(actualOutputs);
        //double[,] outputWithDerApplied = actualOutputs.ApplyFunctionElementWise(MathFunctions.SigmoidDerivative);
        //double[,] outputRelativeError = outputError.ElementWiseMultiply(outputWithDerApplied);

        ////Loop backwards through all the hidden layers
        //for (int i = inputs.Length - 2; i > 0; i--)
        //{

        //}


        //}

        private void UpdateValuesInNeuronArray()
        {
            //for (int i = 0; i < layers.Count; i++)
            //{
            //    for (int j = 0; j < layers.Count; j++)
            //    {
            //        //Update Bias
            //        neurons[i][j].Bias = 
            //    }
            //}
        }
    }


}