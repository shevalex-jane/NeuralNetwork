using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNetwork_FileWriting
{
    [Serializable]
    class Convolution
    {
        private Random rnd = new Random();

        public double[][] values;            // 1st dimention - is the layer it belongs to, 2nd diention - number of the node
        public double[][] biases;            // --||--
        public double[][][] weights;         // 1st dimention is a layer, 2nd - what node it connects to, 3rd - it's connected from

        public double[][] desiredValues;     // desiredValues - these are values on every node that the ideal neural net has (not output rtaining values)
        public double[][] biasesSmudge;
        public double[][][] weightsSmudge;

        private double weightDecay;
        private double learningRate;

        public double WeightDecay { get { return weightDecay; } set { weightDecay = value; } }
        public double LearningRate { get { return learningRate; } set { learningRate = value; } }


        public Convolution(IReadOnlyList<int> structure, double _weightDecay, double _learningRate)
        {
            WeightDecay = _weightDecay;
            LearningRate = _learningRate;
            values = new double[structure.Count][];
            desiredValues = new double[structure.Count][];
            biases = new double[structure.Count][];
            biasesSmudge = new double[structure.Count][];
            weights = new double[structure.Count - 1][][];         // weights number is less by 1 than values cause the last output nodes don't have outcoming weights
            weightsSmudge = new double[structure.Count - 1][][];

            // Initializing all arrays on every leayer (=i)

            for (var i = 0; i < structure.Count; i++)
            {
                values[i] = new double[structure[i]];
                desiredValues[i] = new double[structure[i]];
                biases[i] = new double[structure[i]];
                biasesSmudge[i] = new double[structure[i]];
            }

            for (var i = 0; i < structure.Count - 1; i++)
            {
                weights[i] = new double[values[i + 1].Length][];
                weightsSmudge[i] = new double[values[i + 1].Length][];
                for (var j = 0; j < weights[i].Length; j++)
                {
                    weights[i][j] = new double[values[i].Length];
                    weightsSmudge[i][j] = new double[values[i].Length];
                    for (var k = 0; k < weights[i][j].Length; k++)
                    {

                        weights[i][j][k] = (rnd.NextDouble() * 2 - 1) * Math.Sqrt(2.0 / ((double)weights[i][j].Length)); // it's proven this formula gives far better solution
                        weightsSmudge[i][j][k] = 0;
                    }
                }
            }

            for (int i = 0; i < biases.Length; i++)
            {
                for (int j = 0; j < biases[i].Length; j++)
                {
                    biases[i][j] = 0;
                }
            }

        }
        public double[] Test(double[] input)
        {
            // Setting initial values

            for (var i = 0; i < values[0].Length; i++)
            {
                values[0][i] = input[i];
            }

            // Calculating values over every layer

            for (var i = 1; i < values.Length; i++)
                for (var j = 0; j < values[i].Length; j++)
                {
                    values[i][j] = Sigmoid(Sum(values[i - 1], weights[i - 1][j]) + biases[i][j]);
                    desiredValues[i][j] = values[i][j];                   // store values in desiredValues for the Train method
                }
            return values[values.Length - 1];
        }

        private static double Sum(IEnumerable<double> values, IReadOnlyList<double> weights) => values.Select((v, i) => v * weights[i]).Sum(); //v1*w1+v2*w2+...

        public void Train(double[][] trainingInputs, double[][] trainingOutputs)
        {
            for (var i = 0; i < trainingInputs.Length; i++)         // on every set of input datas
            {
                Test(trainingInputs[i]);                        // front pass for the current set of training inputs

                for (var j = 0; j < desiredValues[desiredValues.Length - 1].Length; j++)
                    desiredValues[desiredValues.Length - 1][j] = trainingOutputs[i][j];     // assigning to the output values for the last layer 

                // Backward propagation

                for (var j = values.Length - 1; j >= 1; j--)
                {
                    for (var k = 0; k < values[j].Length; k++)
                    {
                        var biasSmudge = SigmoidDerivative(values[j][k]) * (desiredValues[j][k] - values[j][k]);
                        biasesSmudge[j][k] += biasSmudge;

                        for (var l = 0; l < values[j - 1].Length; l++)
                        {
                            var weightSmudge = values[j - 1][l] * biasSmudge;
                            weightsSmudge[j - 1][k][l] += weightSmudge;

                            var valueSmudge = weights[j - 1][k][l] * biasSmudge;
                            desiredValues[j - 1][l] += valueSmudge;
                        }
                    }
                }
            }

            for (var i = values.Length - 1; i >= 1; i--)
            {
                for (var j = 0; j < values[i].Length; j++)
                {
                    biases[i][j] += biasesSmudge[i][j] * learningRate;
                    biases[i][j] *= 1 - weightDecay;
                    biasesSmudge[i][j] = 0;

                    for (var k = 0; k < values[i - 1].Length; k++)
                    {
                        weights[i - 1][j][k] += weightsSmudge[i - 1][j][k] * learningRate;
                        weights[i - 1][j][k] *= 1 - weightDecay;
                        weightsSmudge[i - 1][j][k] = 0;
                    }
                    desiredValues[i][j] = 0;
                }
            }
        }

        public double Accuracy(double[][] testingInputs, double[][] testingOutputs)
        {
            var accuracies = new List<double>();

            for (var i = 0; i < testingInputs.Length; i++)
            {
                var output = Test(testingInputs[i]);            //real output
                double sum = 0;

                for (var j = 0; j < output.Length; j++)
                {
                    sum += Math.Pow(output[j] - testingOutputs[i][j], 2);
                }

                double epsilon = Math.Sqrt(sum / output.Length);
                accuracies.Add(epsilon);
            }
            return accuracies.Average();
        }
        private static double Sigmoid(double x) => 1 / (1 + (double)Math.Exp(-x));

        private static double SigmoidDerivative(double x) => x * (1 - x);
    }
}
