using NumSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public interface ILayer
    {
        public NDArray forward(NDArray input);
        public NDArray backward(NDArray input);
        public IList<double> GetOutputs();
    }
}
