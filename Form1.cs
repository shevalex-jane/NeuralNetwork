using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NNetwork_FileWriting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = @"D:\NeuralNet_Data-cleared\good";
        string pathTo;
        const int inputSize = 7500;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Legend objLegend in chart1.Legends)
            {
                objLegend.Enabled = false;
            }
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

            radioButtonNormilized.Checked = true;

            toolTip1.SetToolTip(buttonOpenCalcForm, "You may write files on this form first or open evaluation form if you have ones");
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count > 0)
            {
                // Get the data of the selected file

                string filepath = checkedListBox1.SelectedItem.ToString();
                Int16[] data = GetData(filepath);

                // Clearing graph

                Series seriesOfPoints = new Series();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                chart1.Series.Clear();

                // The number of points for drawing

                seriesOfPoints.ChartType = SeriesChartType.Line;
                for (int x = 0; x < data.Length; x++)
                {
                    seriesOfPoints.Points.AddXY(x, data[x]);
                }

                // Adding the collection of dots to the Chart

                seriesOfPoints.LegendText = filepath;
                chart1.Series.Add(seriesOfPoints);
            }
        }

        private Int16[] GetData(string filePath)
        {
            byte[] buffer;
            Int16[] data = new Int16[inputSize];
            try
            {
                if (Directory.Exists(path))
                {
                    filePath = Directory.GetFiles(path, filePath, SearchOption.AllDirectories).First();
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        long n = fs.Length;
                        buffer = new byte[n];
                        fs.Read(buffer, 0, (int)n);
                    }

                    for (var i = 0; i < buffer.Length; i += 2)
                    {
                        data[i / 2] = (Int16)BitConverter.ToInt16(new byte[] { (byte)buffer[i], (byte)buffer[i + 1] }, 0);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;

        }
        void NormalizationInputData(List<double> inputVal)
        {
            int counterPlus = 0;
            int counterMinus = 0;
            List<double> inputValAbs = new List<double>();
            for (int i = 0; i < inputVal.Count; i++)
            {
                if (inputVal[i] > 600)
                {
                    inputVal[i] = 600;
                    if (counterPlus<1) MessageBox.Show("There is value > 600");
                    counterPlus++;
                }
                if (inputVal[i] < -600)
                {
                    inputVal[i] = -600;
                    if (counterMinus<1) MessageBox.Show("There is value < -600");
                    counterMinus++;
                }
                inputValAbs.Add(Math.Abs(inputVal[i]));
            }
            for (int i = 0; i < inputVal.Count; i++)
            {
                inputVal[i] /= (inputValAbs).Max();
            }

        }

         private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Creating file...";
            textBox1.Update();
            WritingFile(checkedListBox1);

                textBox1.Text = "Done";
        }

        void WritingFile(CheckedListBox chkbox)
        {
            // Sorting chosen files

            List<string> ChosenFiles = new List<string>();
            List<int> substr = new List<int>();
            foreach (var file in chkbox.CheckedItems)
            {
                var filePath = file.ToString();
                ChosenFiles.Add(filePath);

                substr.Add(Convert.ToInt32(filePath.Split('_')[3].Remove(filePath.Split('_')[3].Length - 4, 4)));
            }

            List<string> newList = new List<string>();
            List<int> temp = new List<int>();
            for (int i = 0; i < chkbox.CheckedItems.Count; i++)
            {
                int indexMin = substr.IndexOf(substr.Except(temp).Min());
                newList.Add(ChosenFiles[indexMin]);
                temp.Add(substr[indexMin]);
            }
            ChosenFiles = newList;

            // Getting data from files into 1! List filesValues

            List<double> filesValues = new List<double>();
            for (int i = 0; i < ChosenFiles.Count; i++)
            {
                Int16[] int16Values = GetData(ChosenFiles[i]);
                double[] doubleValues = new double[int16Values.Length];
                for (int j = 0; j < int16Values.Length; j++)
                {
                    doubleValues[j] = (double)int16Values[j];
                }
                for (int j = 0; j < doubleValues.Length; j++)
                {
                    filesValues.Add(doubleValues[j]);
                }
            }

            // Normalize on the whole array of files' datas if needs

            if (radioButtonNormilized.Checked)
                NormalizationInputData(filesValues);

            // Writing to txt file

            string localPath = pathTo + "\\" + textBoxFileName.Text;
            if (radioButtonNonNormilized.Checked) localPath += "_NonNormilized.txt";
            else localPath += ".txt";

            using (FileStream fs = File.Create(localPath))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < filesValues.Count - 1; i++)
                    {
                        sw.WriteLine(filesValues[i]);
                    }
                    sw.Write(filesValues[filesValues.Count - 1]);
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Clearing all checked items in the list

            for (var i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            // Looking for complyed files 
            string pattern = textBoxPattern.Text;
            for (var i=0; i< checkedListBox1.Items.Count; i++)
            {
                if ((checkedListBox1.Items[i].ToString()).Contains(pattern))
                    checkedListBox1.SetItemChecked(i, true);
            }

            if (checkedListBox1.CheckedItems.Count==0)
                MessageBox.Show("No files found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            textBox1.Text += $"Number of files {textBoxPattern.Text}: {checkedListBox1.CheckedItems.Count} \r\n";


        }

        private void TextBoxPattern_TextChanged(object sender, EventArgs e)
        {
            textBoxFileName.Text = textBoxPattern.Text;

        }

        private void ButtonOpenCalcForm_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                CalculationForm calcForm = new CalculationForm(pathTo);
                calcForm.ShowDialog();
                this.Show();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message);}
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            CalculationForm calcForm = new CalculationForm(null);
            pathTo = calcForm.OpenFolder();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            CalculationForm calcForm = new CalculationForm(null);
            path = calcForm.OpenFolder();
            checkedListBox1.Items.Clear();
            Form1_Load(this, null);
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void CheckedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (checkedListBox1.Items.Count > 0)
            {
                // Get the data of the selected file

                string filepath = checkedListBox1.SelectedItem.ToString();
                Int16[] data = GetData(filepath);

                // Clearing graph

                Series seriesOfPoints = new Series();
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                chart1.Series.Clear();

                // The number of points for drawing

                seriesOfPoints.ChartType = SeriesChartType.Line;
                for (int x = 0; x < data.Length; x++)
                {
                    seriesOfPoints.Points.AddXY(x, data[x]);
                }

                // Adding the collection of dots to the Chart

                seriesOfPoints.LegendText = filepath;
                chart1.Series.Add(seriesOfPoints);
            }
        }
    }
}
