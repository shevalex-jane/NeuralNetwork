using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Neuro.Learning;
using AForge.Neuro;
using System.IO;
using Accord.Neuro.ActivationFunctions;
using Accord.Neuro.Networks;
using Accord.Neuro.Learning;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace NNetwork_FileWriting
{
    public partial class CalculationForm : Form
    {
        public CalculationForm(string pathTo)
        {
            InitializeComponent();
            if ((pathTo == null)|| (pathTo.Length == 0)) path =  @"D:\NNetworks_txtFiles";
            else path =pathTo;
        }

        string path;
        ActivationNetwork network;
        AForge.Neuro.Learning.BackPropagationLearning learner;
        int inputSize = 142500;
        int inputSets;
        double[][] trainingInputsFiles;
        double[][] trainingOutputsFiles;
        AForge.Neuro.Learning.BackPropagationLearning[] learnerSplit;

        ActivationNetwork[] networks;
        double[] epsilon;
        double[] results;

        double learningRate = 14;
        double weightDecay = 0.0001;
        int neuronsHidden = 10;

        public string OpenFolder()
        {
            string folderName = "";

            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = fd.SelectedPath;
            }
            return folderName;
        }
        private void DefineNetworks(double learningRate, double momentum, int neuronsFirstLayer)
        {
            for (int i = 0; i < networks.Length; i++)
            {
                networks[i] = new ActivationNetwork(
                    new SigmoidFunction(2),
                    inputSets, // inputs in the network
                    neuronsFirstLayer, // neurons in the first layer
                    1); // one neuron in the second layer

                // create teacher
                learnerSplit[i] = new AForge.Neuro.Learning.BackPropagationLearning(networks[i]) { LearningRate = learningRate, Momentum = momentum };
            }
        }
        private void SplittedAforgeMethod(double[][] trainingInputs, double[][] trainingOutputs)
        {
            for (int i = 0; i < networks.Length; i++)
            {
                epsilon[i] = learnerSplit[i].Run(trainingInputs[i], trainingOutputs[i]);
                results[i] = networks[i].Compute(trainingInputs[i])[0];
            }
        }
        private void LearningAForgeMethod(double[][] trainingInputs, double[][] trainingOutputs, double learningRate, double momentum, int _maxIterations, int neuronsFirstLayer, double epsilon)
        {
            // Create neural network
            
            network = new ActivationNetwork(
            new SigmoidFunction(2),
            inputSize, // inputs in the network
            neuronsFirstLayer, // neurons in the first layer
            1); // one neuron in the second layer

            // create teacher
            learner = new AForge.Neuro.Learning.BackPropagationLearning(network) { LearningRate = learningRate, Momentum = momentum };

            // loop
            double error = 1;
            int iterations = 0;
            while (error > epsilon && iterations < _maxIterations)
            {

                error = learner.RunEpoch(trainingInputs, trainingOutputs);
                iterations++;

                if (iterations % _maxIterations/10 == 0)
                {
                    textBoxOutput.Text += iterations + " - " + error + Environment.NewLine;
                }
            }
            textBoxOutput.Text += iterations + " - " + error + Environment.NewLine;

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            InitializationInpOutp();
            LearningAForgeMethod(trainingInputsFiles, trainingOutputsFiles, learningRate: 100, momentum: 0.1, _maxIterations: 800, neuronsFirstLayer: 100, epsilon: 0.05);

        }
        void InitializingInputOutput(double[][] trainingInputsFiles, double[][] trainingOutputsFiles)
        {
            // Inintializing input and output arrays

            double[] data = GetData(checkedListBox1.CheckedItems[0].ToString());

            for (var i = 0; i < trainingInputsFiles.Length; i++)
                trainingInputsFiles[i] = new double[inputSize];

            for (var i = 0; i < trainingOutputsFiles.Length; i++)
                trainingOutputsFiles[i] = new double[1];

            // Assigning values

            FillInputOutputData(trainingInputsFiles, trainingOutputsFiles);
        }
        void FillInputOutputData(double[][] trainingInputs, double[][] trainingOutputs)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("No file's selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Inputs

            int counter = 0;
            foreach (var fileName in checkedListBox1.CheckedItems)
            {
                double[] data = GetData(fileName.ToString());

                for (int i = 0; i < data.Length; i++)
                {
                    trainingInputs[counter][i] = data[i];
                }


                // Outputs

                string[] substr = fileName.ToString().Split('_');
                
                switch (substr[2].Substring(0,1))
                {
                    case "0":
                        {
                            trainingOutputs[counter][0] = 0;
                            break;
                        }
                    case "1":
                        {
                            trainingOutputs[counter][0] = 1;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Outputs error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                }
                counter++;
            }
        }
        private double[] GetData(string filePath)
        {
            Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double[] data = new double[inputSize];
            int i = 0;
            try
            {
                if (Directory.Exists(path))
                {
                    filePath = Directory.GetFiles(path, filePath, SearchOption.AllDirectories).First();
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(fs))
                        {
                            while (!reader.EndOfStream)
                            {
                                data[i] = Convert.ToDouble(reader.ReadLine().Replace('.', separator).Replace(',', separator));
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;

        }

        int maxSteps = 400;
        private void CalculationForm_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                for (var i = 0; i < files.Length; i++)
                {
                    string[] substr = files[i].Split('\\');
                    checkedListBox1.Items.Add(substr[substr.Length - 1]);
                }
                checkedListBox1.SelectedIndex = 0;
            }
            toolTip1.SetToolTip(buttonClearChart,"If you want to see difference in graph creating you may not clear Chart");
            toolTip1.SetToolTip(button6, "Choose 2 files to draw Hilbert representation");
            toolTip1.SetToolTip(textBoxLR, "The learning rate hyperparameter controls the rate or speed at which the model learns");
            toolTip1.SetToolTip(textBoxWD, "After each update the weights are multiplied by Weight Decay");
            toolTip1.SetToolTip(textBoxNeurons, "Number of neurons on the hidden layer");
            toolTip1.SetToolTip(buttonAbort, "Stop calculating");

            progressBar1.Visible = false;
            labelLoading.Visible = false;

            textBoxLR.Text = learningRate.ToString();
            textBoxWD.Text = weightDecay.ToString();
            textBoxNeurons.Text = neuronsHidden.ToString();
            textBoxGainingAccuracy.Text = gainingAccuracy.ToString();
            textBoxEveryStep.Text = "10";
            textBoxSteps.Text = maxSteps.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var error = learner.Run(trainingInputsFiles[0], trainingOutputsFiles[0]);

            textBoxOutput.Text += $"------ \r\nNetwork: \r\n Error = {error}. \r\n Must be: {trainingOutputsFiles[0][0]} \r\n Real output = {network.Compute(trainingInputsFiles[0])[0]}";

            //var path = @"D:\NNetworks_txtFiles\1.txt";
            //network.Save(path);
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    Network network1 = Network.Load(fs);
            //    textBoxOutput.Text += $"Network1: \r\n Must be: {output[1][0]} \r\n Real output = {network1.Compute(input[1])[0]}";

            //}
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            #region Identification IO sets
            var numberSets = checkedListBox1.CheckedItems.Count;
            double[][] inputs = trainingInputsFiles;
            double[][] outputs = new double[numberSets][];
            for (var i = 0; i < numberSets; i++)
                outputs[i] = new double[2];
            int counter = 0;
            foreach (var fileName in checkedListBox1.CheckedItems)
            {
                // Outputs

                string[] substr = fileName.ToString().Split('_');

                switch (substr[2].Remove(substr[2].Length - 4, 4))
                {
                    case "0":
                        {
                            outputs[counter][0] = 1;
                            outputs[counter][1] = 0;
                            break;
                        }
                    case "1":
                        {
                            outputs[counter][0] = 0;
                            outputs[counter][1] = 1;
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Outputs error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                }
                counter++;
            }
            #endregion
            
            // Create a Bernoulli activation function
            var function = new BernoulliFunction(alpha: 1);
            // Create a Restricted Boltzmann Machine for 6 inputs and with 1 hidden neuron
            var rbm = new RestrictedBoltzmannMachine(function, inputsCount: inputs[0].Length, hiddenNeurons: 10);

            // Create the learning algorithm for RBMs
            var teacher = new ContrastiveDivergenceLearning(rbm)
            {
                Momentum = 0,
                LearningRate = 20,
                Decay = 0
            };

            // learn 5000 iterations
            for (int i = 0; i < 5000; i++)
            {
                var epsilon = teacher.RunEpoch(inputs);
                if (i%500==0)
                    textBoxOutput.Text += $"{i}:  {epsilon} \r\n";
            }

            //Compute the machine answers for the given inputs:
            double[] a = rbm.Compute(trainingInputsFiles[0]);
            textBoxOutput.Text += $"Accord: \r\n result = {{ {a[0]},  {a[1]}}}." +
                $" \r\nIdeal result: {outputs[0][0]}, {outputs[0][1]}";
            if (numberSets > 1)
            {
                double[] b = rbm.Compute(trainingInputsFiles[1]);
                textBoxOutput.Text += $"Accord: \r\n result = {{ {b[0]},  {b[1]}}}." +
                $" \r\nIdeal result: {outputs[0][0]}, {outputs[0][1]}";
            }


        }

        bool netInitialized = false;
        private void InitializationInpOutp()
        {
            //if (checkedListBox1.CheckedItems.Count == 0) { MessageBox.Show("Check files first", "No files checked", MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
            // initialize input and output values
            var line = Directory.GetFiles(path, checkedListBox1.CheckedItems[0].ToString(), SearchOption.AllDirectories).First(); 

            // Defining inputSize

            using (FileStream fs = new FileStream(line,FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    inputSize = 0;
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine();
                        inputSize++;
                    }
                }
            }
            var numberSets = checkedListBox1.CheckedItems.Count;
            trainingInputsFiles = new double[numberSets][];
            trainingOutputsFiles = new double[numberSets][];
            InitializingInputOutput(trainingInputsFiles, trainingOutputsFiles);
            netInitialized = true;
        }

        public string file1, file2;
        public double[] file1Data, file2Data;

        private void ButtonConvolution_Click(object sender, EventArgs e)
        {
            // Defininig input/output datas

            InitializationInpOutp(); // taking trainingInputsFiles and trainingOutputsFiles
            double[] epsilonIter = new double[trainingInputsFiles.Length];
            double[] resultIter = new double[trainingInputsFiles.Length];
            double epsilonAverage = 1;

            inputSets = 250;
            networks = new ActivationNetwork[trainingInputsFiles[0].Length / inputSets * 2 - 1];
            epsilon = new double[trainingInputsFiles[0].Length / inputSets * 2 - 1];
            results = new double[trainingInputsFiles[0].Length / inputSets * 2 - 1];
            learnerSplit = new AForge.Neuro.Learning.BackPropagationLearning[trainingInputsFiles[0].Length / inputSets * 2 - 1];

            double learningRate = 20;
            double momentum = 0.01;
            int neuronsFirstLayer = 100;

            DefineNetworks(learningRate, momentum, neuronsFirstLayer);
            chart1.Series[0].ChartType = SeriesChartType.Spline;

            int counter = 0;
            while ((epsilonAverage>0.05)&&(counter<1000))
            {
                for (int i = 0; i < trainingInputsFiles.Length; i++)
                {
                    DefineSplittedArrays(trainingInputsFiles[i], trainingOutputsFiles[i]); // splitting files
                    SplittedAforgeMethod(splittedInputs, splittedOutputs);
                    epsilonIter[i] = epsilon.Average();
                    resultIter[i] = results.Sum()/splittedInputs.Length;
                    textBoxOutput.Text += $"{trainingOutputsFiles[i][0]}: eps = {Math.Round(epsilon[0],2).ToString()}, result = {Math.Round(results[0],2)} \r\n";
                }

                chart1.Series[0].Points.AddXY(counter, epsilon[0]);
                
                epsilonAverage = epsilonIter.Average();
                counter++;
            }

            
        }

        double[][] splittedInputs;
        double[][] splittedOutputs;
        Convolution[] networksBP;
        int chartAreaNumber = 0;
        Thread threadCalc;
        async private void ButtonBP_Click(object sender, EventArgs e)
        {
            var everyStep = 1;
            textBoxOutput.Text = "";
            try
            {
                Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                // Assigning evaluation parameters from textboxes

                if (textBoxLR.TextLength > 0) learningRate = Convert.ToDouble(textBoxLR.Text.Replace('.', separator).Replace(',', separator));
                if (textBoxWD.TextLength > 0) weightDecay = Convert.ToDouble(textBoxWD.Text.Replace('.', separator).Replace(',', separator));
                if (textBoxNeurons.TextLength > 0) neuronsHidden = Convert.ToInt32(textBoxNeurons.Text);
                if (textBoxGainingAccuracy.TextLength > 0) gainingAccuracy = Convert.ToDouble(textBoxGainingAccuracy.Text.Replace('.', separator).Replace(',', separator));
                if (textBoxSteps.TextLength > 0) maxSteps = Convert.ToInt32(textBoxSteps.Text);
                if ((textBoxEveryStep.TextLength > 0) && (Convert.ToInt32(textBoxEveryStep.Text)!=0)) everyStep = Convert.ToInt32(textBoxEveryStep.Text);
                

                foreach (Legend objLegend in chart1.Legends)
                {
                    objLegend.Enabled = false;
                }

                InitializationInpOutp(); // taking trainingInputsFiles and trainingOutputsFiles
                double[] epsilonIterBP = new double[trainingInputsFiles.Length];
                double epsilonAverageBP = 0.5;
                double[] resultBP = new double[trainingInputsFiles.Length];

                inputSets = 250;
                networksBP = new Convolution[trainingInputsFiles[0].Length / inputSets * 2 - 1];
                var result1iter = new double[trainingInputsFiles[0].Length / inputSets * 2 - 1];


                IReadOnlyList<int> structure = new[] { inputSets, neuronsHidden, 1 };

                //Chart

                chart1.Series.Add(chartAreaNumber.ToString());
                chart1.Series[chartAreaNumber.ToString()].ChartType = SeriesChartType.Spline;

                int counter = 0;
                for (int i = 0; i < trainingInputsFiles[0].Length / inputSets * 2 - 1; i++)
                {
                    networksBP[i] = new Convolution(structure, weightDecay, learningRate);
                }

                double[] epsilon1iter = new double[trainingInputsFiles[0].Length / inputSets * 2 - 1];

                double[] minEpsilon = new double[trainingInputsFiles.Length];
                double[] maxEpsilon = new double[trainingInputsFiles.Length];
                //List<Task> taskEpoch = new List<Task>();
                while ((epsilonAverageBP > gainingAccuracy) && (counter < maxSteps))
                {
                    for (int i = 0; i < trainingInputsFiles.Length; i++)        // on every file
                    {
                        DefineSplittedArrays(trainingInputsFiles[i], trainingOutputsFiles[i]); // splitting files

                        threadCalc = new Thread(() =>
                        {
                            for (int j = 0; j < trainingInputsFiles[0].Length / inputSets * 2 - 1; j++)     // on every set
                            {
                                var tempInput = new double[1][];
                                tempInput[0] = splittedInputs[j];
                                var tempOutput = new double[1][];
                                tempOutput[0] = splittedOutputs[j];
                                networksBP[j].Train(tempInput, tempOutput);
                                epsilon1iter[j] = networksBP[j].Accuracy(tempInput, tempOutput);
                                result1iter[j] = networksBP[j].Test(tempInput[0])[0];
                            }
                            minEpsilon[i] = epsilon1iter.Min();
                            maxEpsilon[i] = epsilon1iter.Max();
                        });
                        threadCalc.Start();
                        while (threadCalc.IsAlive)
                        {
                            await Task.Delay(100);
                        }
                        epsilonIterBP[i] = epsilon1iter.Average();       // average accuracy on all sets in file
                        resultBP[i] = result1iter.Average();

                        if (_abort)
                        {
                            _abort = false;
                            textBoxOutput.Text += $"\r\nIteration {counter}: accuracy: {epsilonAverageBP.ToString()}\r\n";
                            chartAreaNumber++;
                            return;
                        }
                    }
                    if (counter%everyStep ==0) textBoxOutput.Text += $"\r\nIteration {counter}: accuracy: {epsilonAverageBP.ToString()}\r\n";
                    epsilonAverageBP = epsilonIterBP.Average();
                    chart1.Series[chartAreaNumber.ToString()].Points.AddXY(counter, epsilonAverageBP);
                    chart1.Update();
                    counter++;
                }
                chartAreaNumber++;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
        }
        double gainingAccuracy=0.1;

        private void ButtonTestBP_Click(object sender, EventArgs e)
        {
            try
            {
                if (networksBP == null) { MessageBox.Show("Press Restore or Convolution first"); return; }
                inputSets = 250;
                if (checkedListBox1.CheckedItems.Count == 0) return;
                textBoxOutput.Text = "";
                InitializationInpOutp();
                DefineSplittedArrays(trainingInputsFiles[0], trainingOutputsFiles[0]); // splitting files

                var resultTest = new double[trainingInputsFiles[0].Length / inputSets * 2 - 1];
                for (int j = 0; j < trainingInputsFiles[0].Length / inputSets * 2 - 1; j++)
                {
                    resultTest[j] = networksBP[j].Test(splittedInputs[j])[0];
                }
                var result = resultTest.Average();
                var epsilon = Math.Abs(splittedOutputs[0][0] - result);
                textBoxOutput.Text += $"==Test== \r\nS{splittedOutputs[0][0]}: \r\nresult = {result.ToString()}\r\n";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
        }

        private void ButtonSaveBP_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete all the .dat files in root directory to avoid misleading after restoring

                var pathDat = OpenFolder();

                // Deleting previous files

                string[] line = Directory.GetFiles(pathDat, "*.dat");
                foreach (var f in line) File.Delete(f);

                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                if (checkedListBox1.CheckedItems.Count == 0) { MessageBox.Show("Choose 1 file at least"); return; }
                if (networksBP == null) { MessageBox.Show("Press ConvolutionBP button first"); return; }
                string pathName = checkedListBox1.CheckedItems[0].ToString().Remove(checkedListBox1.CheckedItems[0].ToString().Length - 5, 5);
                for (int i = 0; i < networksBP.Length; i++)
                {
                    using (FileStream fs = new FileStream(String.Join("", pathDat + "\\" + pathName, i.ToString(), ".dat"), FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, networksBP[i]);
                    }
                }

                // Writing number of sets into a file for restoring network
                File.WriteAllText(pathDat + "\\SetsNumber.txt", networksBP.Length.ToString());
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
            
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }

        private void ButtonClearChart_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        async private void ButtonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var pathDat = OpenFolder();
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                labelLoading.Text = "Loading files...";
                labelLoading.Visible = true;
                labelLoading.Update();

                int size=0;
                if (File.Exists((pathDat + "\\SetsNumber.txt")))
                {
                    size = Convert.ToInt32(File.ReadAllText(pathDat + "\\SetsNumber.txt"));
                }
                else { MessageBox.Show("No SetsNumber.txt file found");}
                
                networksBP = new Convolution[size];
                BinaryFormatter formatterDeserial = new BinaryFormatter();
                for (int i = 0; i < size; i++)
                {
                    string[] path = Directory.GetFiles(pathDat, "*.dat");
                    if (path.Length == 0) { MessageBox.Show("There's no files to restore"); return; }

                    // Sorting path array with ascending file'snumber

                    List<string> ChosenFiles = new List<string>();
                    List<int> substr = new List<int>();
                    foreach (var file in path)
                    {
                        ChosenFiles.Add(file);
                        var f = file.Split('\\').Last();
                        substr.Add(Convert.ToInt32(f.Split('_')[2].Remove(f.Split('_')[2].Length - 4, 4)));
                    }

                    List<string> newList = new List<string>();
                    List<int> temp = new List<int>();
                    for (int j = 0; j < path.Length; j++)
                    {
                        int indexMin = substr.IndexOf(substr.Except(temp).Min());
                        newList.Add(ChosenFiles[indexMin]);
                        temp.Add(substr[indexMin]);
                    }
                    ChosenFiles = newList;



                    using (FileStream fs = new FileStream(ChosenFiles[i], FileMode.OpenOrCreate))
                    {
                        networksBP[i] = (Convolution)formatterDeserial.Deserialize(fs);
                    }
                    progressBar1.Value = i * 100 / networksBP.Length;
                }

                labelLoading.Text = "Done";
                labelLoading.Update();
                await Task.Delay(500);
                labelLoading.Visible = false;
                progressBar1.Visible = false;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message);}
        }

        private bool _abort = false;
        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            _abort = true;
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            path = OpenFolder();
            try
            {
                checkedListBox1.Items.Clear();

                if ((path != null) && (path != ""))
                {
                    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                    for (var i = 0; i < files.Length; i++)
                    {
                        string[] substr = files[i].Split('\\');
                        checkedListBox1.Items.Add(substr[substr.Length - 1]);
                    }

                    checkedListBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
                if (f.GetType() != typeof(Form1))
                    f.Hide();
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculationForm_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        void DefineSplittedArrays(double[] trainingInputs, double[] trainingOutputs)
        {
            // counting the number of sets

            int numberSets =(trainingInputs.Length / inputSets) * 2 - 1;
            
            splittedInputs = new double[numberSets][];      // 1st dimention - number of a new set, 2nd dimention - values (numberValues values in every set)
            splittedOutputs = new double[numberSets][];

            for (int i = 0; i < numberSets; i++)
            {
                splittedInputs[i] = new double[inputSets];
            }
            for (int i = 0; i < numberSets; i++)
            {
                splittedOutputs[i] = new double[1];
            }

            // Filling splitted arrays with data

            int kTrain = 0;
            for (int sets = 0; sets < numberSets; sets++)
            {
                for (int j = 0; j < inputSets; j++)
                {
                    splittedInputs[sets][j] = trainingInputs[kTrain];
                    kTrain++;
                }
                kTrain -= inputSets / 2;
                splittedOutputs[sets][0] = trainingOutputs[0];
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {

            try
            {
                if ((checkedListBox1.CheckedItems.Count != 2))
                {
                    MessageBox.Show("Choose 2 files", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                InitializationInpOutp();

                file1 = checkedListBox1.CheckedItems[0].ToString();
                file2 = checkedListBox1.CheckedItems[1].ToString();
                file1Data = trainingInputsFiles[0];
                file2Data = trainingInputsFiles[1];
                this.Hide();
                Hilbert Hilbert = new Hilbert(file1Data, file2Data, file1, file2);
                Hilbert.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
