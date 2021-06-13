using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NNetwork_FileWriting
{
    public partial class Hilbert : Form
    {
        double[] file1Data, file2Data;
        Series seriesOfPoints_file1, seriesOfPoints_file2;


        public Hilbert(double[] formCalc1Data, double[] formCalc2Data, string file1, string file2)
        {
            InitializeComponent();
            
            file1Data = formCalc1Data;
            file2Data = formCalc2Data;

            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            var f1 = file1.Split('_');
            var f2 = file2.Split('_');
            label1.Text = f1[1]+"_"+f1[2];
            label2.Text = f2[1] + "_" + f2[2];
            label5.Text = "Series #"+ file1.Split('_')[0];
        }

        double currentPos;
        private void ButtonFocus_Click(object sender, EventArgs e)
        {
            currentPos = 0;
            XYAutoScale_Hilbert(currentPos);
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            if (currentPos > file1Data.Length - 6000) currentPos = file1Data.Length - 3001;
            else currentPos += 3000;
            XYAutoScale_Hilbert(currentPos);
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            if (currentPos <= 3000) currentPos = 0;
            else currentPos -= 3000;
            XYAutoScale_Hilbert(currentPos);
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
                // спрячем все формы кроме основной
                if (f.GetType() != typeof(Form1))
                    f.Hide();
            Application.Exit();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Hilbert_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void XYAutoScale_Hilbert(double currentPos)
        {
            var charts = new List<Chart> { chart1, chart2 };
            double currentPos2;
            double _maxY =0;
            double _minY=0;

            currentPos2 = currentPos + 3000;

            foreach (var chart in charts)
            {
                double[] fileData;
                if (chart.Name.Contains("1")) fileData = file1Data;
                else fileData = file2Data;
                for (int i = (int)Math.Round(currentPos, 0); i < currentPos2; i++)
                {
                    if (fileData[i] > _maxY) _maxY = fileData[i];
                    if (fileData[i] < _minY) _minY = fileData[i];
                }
            }
            foreach (var chart in charts)
            {
                var x = chart.ChartAreas[0].AxisX;
                var y = chart.ChartAreas[0].AxisY;
                x.ScaleView.Zoom(currentPos, currentPos2);
                y.ScaleView.Zoom(_minY - (_maxY - _minY) / 10, _maxY + (_maxY - _minY) / 10);
            }

            // Hilbert

            int n = file1Data.Length;
            double[] XG1 = new double[n];
            double[] AG1 = new double[n];
            double[] FG1 = new double[n];
            double[] XG2 = new double[n];
            double[] AG2 = new double[n];
            double[] FG2 = new double[n];

            for (int i = (int)Math.Round(currentPos,0); i < currentPos2; i++)
            {
                XG1[i] = 0;
                XG2[i] = 0;
                for (int j = (int)Math.Round(currentPos, 0); j < currentPos2; j++)
                {
                    if (i != j)
                    {
                        XG1[i] += file1Data[j] / (Math.PI * (i - j));
                        XG2[i] += file2Data[j] / (Math.PI * (i - j));
                    }
                }
                AG1[i] = Math.Sqrt(file1Data[i] * file1Data[i] + XG1[i] * XG1[i]);
                AG2[i] = Math.Sqrt(file2Data[i] * file2Data[i] + XG2[i] * XG2[i]);
                if (file1Data[i] != 0)
                {
                    FG1[i] = Math.Atan(XG1[i] / file1Data[i]);
                }
                if (file2Data[i] != 0)
                {
                    FG2[i] = Math.Atan(XG2[i] / file2Data[i]);
                }
            }

            var dAG = new double[n];
            var dFG = new double[n];
            for (int i = (int)Math.Round(currentPos, 0); i < currentPos2; i++)
            {
                dAG[i] = AG1[i] - AG2[i];
                dFG[i] = FG1[i] - FG2[i];
            }

            // Graph

            // dAG

            Series seriesOfPoints_Hilbert_AG = new Series();
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            chart3.Series.Clear();

            // The number of points for drawing

            seriesOfPoints_Hilbert_AG.ChartType = SeriesChartType.Line;
            for (int x = (int)Math.Round(currentPos, 0); x < currentPos2; x++)
            {
                seriesOfPoints_Hilbert_AG.Points.AddXY(x, dAG[x]);
            }

            // Adding the collection of dots to the Chart

            seriesOfPoints_Hilbert_AG.LegendText = "";
            chart3.Series.Add(seriesOfPoints_Hilbert_AG);


            // dFG

            Series seriesOfPoints_Hilbert_FG = new Series();
            foreach (var series in chart4.Series)
            {
                series.Points.Clear();
            }
            chart4.Series.Clear();

            // The number of points for drawing

            seriesOfPoints_Hilbert_FG.ChartType = SeriesChartType.Line;
            for (int x = (int)Math.Round(currentPos, 0); x < currentPos2; x++)
            {
                seriesOfPoints_Hilbert_FG.Points.AddXY(x, dFG[x]);
            }

            // Adding the collection of dots to the Chart

            seriesOfPoints_Hilbert_FG.LegendText = "";
            chart4.Series.Add(seriesOfPoints_Hilbert_FG);

        }


        private void Hilbert_Load(object sender, EventArgs e)
        {         
            // 1st graph

            seriesOfPoints_file1 = new Series();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Series.Clear();

            // The number of points for drawing

            seriesOfPoints_file1.ChartType = SeriesChartType.Line;
            for (int x = 0; x < file1Data.Length; x++)
            {
                seriesOfPoints_file1.Points.AddXY(x, file1Data[x]);
            }

            // Adding the collection of dots to the Chart

            seriesOfPoints_file1.LegendText = "";
            chart1.Series.Add(seriesOfPoints_file1);

           
            // 2nd graph

            seriesOfPoints_file2 = new Series();
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            chart2.Series.Clear();

            // The number of points for drawing

            seriesOfPoints_file2.ChartType = SeriesChartType.Line;
            for (int x = 0; x < file2Data.Length; x++)
            {
                seriesOfPoints_file2.Points.AddXY(x, file2Data[x]);
            }

            // Adding the collection of dots to the Chart

            seriesOfPoints_file2.LegendText = "";
            chart2.Series.Add(seriesOfPoints_file2);

            // Deleting Legend for all Charts

            foreach (var chart in Controls.OfType<Chart>())
                foreach (Legend objLegend in chart.Legends)
                {
                    objLegend.Enabled = false;
                }

            label3.Text = "Δ Instanse \r\nAmplitudes";
            label4.Text = "Δ Instanse \r\nPhases";
        }
    }
}
