namespace NNetwork_FileWriting
{
    partial class CalculationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonConvolution = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonBP = new System.Windows.Forms.Button();
            this.buttonTestBP = new System.Windows.Forms.Button();
            this.buttonSaveBP = new System.Windows.Forms.Button();
            this.buttonClearChart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.labelLoading = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxWD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNeurons = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxEveryStep = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxGainingAccuracy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(269, 28);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(426, 616);
            this.textBoxOutput.TabIndex = 0;
            this.textBoxOutput.TextChanged += new System.EventHandler(this.TextBoxOutput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Learning";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 62);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(250, 582);
            this.checkedListBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 484);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AForge.Net";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(12, 548);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acoord.Net";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 31);
            this.button4.TabIndex = 2;
            this.button4.Text = "Learning";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1405, 600);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 42);
            this.button6.TabIndex = 8;
            this.button6.Text = "Hilbert";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // buttonConvolution
            // 
            this.buttonConvolution.Location = new System.Drawing.Point(144, 613);
            this.buttonConvolution.Name = "buttonConvolution";
            this.buttonConvolution.Size = new System.Drawing.Size(112, 41);
            this.buttonConvolution.TabIndex = 9;
            this.buttonConvolution.Text = "Convolution_AF";
            this.buttonConvolution.UseVisualStyleBackColor = true;
            this.buttonConvolution.Click += new System.EventHandler(this.ButtonConvolution_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(703, 34);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(832, 362);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // buttonBP
            // 
            this.buttonBP.Location = new System.Drawing.Point(16, 21);
            this.buttonBP.Name = "buttonBP";
            this.buttonBP.Size = new System.Drawing.Size(112, 41);
            this.buttonBP.TabIndex = 11;
            this.buttonBP.Text = "Convolution_BP";
            this.buttonBP.UseVisualStyleBackColor = true;
            this.buttonBP.Click += new System.EventHandler(this.ButtonBP_Click);
            // 
            // buttonTestBP
            // 
            this.buttonTestBP.Location = new System.Drawing.Point(134, 21);
            this.buttonTestBP.Name = "buttonTestBP";
            this.buttonTestBP.Size = new System.Drawing.Size(117, 41);
            this.buttonTestBP.TabIndex = 12;
            this.buttonTestBP.Text = "Test";
            this.buttonTestBP.UseVisualStyleBackColor = true;
            this.buttonTestBP.Click += new System.EventHandler(this.ButtonTestBP_Click);
            // 
            // buttonSaveBP
            // 
            this.buttonSaveBP.Location = new System.Drawing.Point(257, 21);
            this.buttonSaveBP.Name = "buttonSaveBP";
            this.buttonSaveBP.Size = new System.Drawing.Size(117, 41);
            this.buttonSaveBP.TabIndex = 13;
            this.buttonSaveBP.Text = "Save";
            this.buttonSaveBP.UseVisualStyleBackColor = true;
            this.buttonSaveBP.Click += new System.EventHandler(this.ButtonSaveBP_Click);
            // 
            // buttonClearChart
            // 
            this.buttonClearChart.Location = new System.Drawing.Point(1429, 396);
            this.buttonClearChart.Name = "buttonClearChart";
            this.buttonClearChart.Size = new System.Drawing.Size(106, 32);
            this.buttonClearChart.TabIndex = 14;
            this.buttonClearChart.Text = "Clear Chart";
            this.buttonClearChart.UseVisualStyleBackColor = true;
            this.buttonClearChart.Click += new System.EventHandler(this.ButtonClearChart_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonAbort);
            this.groupBox3.Controls.Add(this.labelLoading);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.buttonLoad);
            this.groupBox3.Controls.Add(this.buttonBP);
            this.groupBox3.Controls.Add(this.buttonSaveBP);
            this.groupBox3.Controls.Add(this.buttonTestBP);
            this.groupBox3.Location = new System.Drawing.Point(703, 525);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 119);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Convolution Network";
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(382, 21);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(117, 41);
            this.buttonAbort.TabIndex = 17;
            this.buttonAbort.Text = "Abort";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.ButtonAbort_Click);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(273, 68);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(93, 16);
            this.labelLoading.TabIndex = 16;
            this.labelLoading.Text = "Loading files...";
            this.labelLoading.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(139, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 23);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(16, 68);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(117, 41);
            this.buttonLoad.TabIndex = 14;
            this.buttonLoad.Text = "Restore";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Files:";
            // 
            // textBoxLR
            // 
            this.textBoxLR.Location = new System.Drawing.Point(151, 24);
            this.textBoxLR.Name = "textBoxLR";
            this.textBoxLR.Size = new System.Drawing.Size(100, 22);
            this.textBoxLR.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Learning Rate = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Weight Decay = ";
            // 
            // textBoxWD
            // 
            this.textBoxWD.Location = new System.Drawing.Point(151, 52);
            this.textBoxWD.Name = "textBoxWD";
            this.textBoxWD.Size = new System.Drawing.Size(100, 22);
            this.textBoxWD.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Neurons number = ";
            // 
            // textBoxNeurons
            // 
            this.textBoxNeurons.Location = new System.Drawing.Point(151, 80);
            this.textBoxNeurons.Name = "textBoxNeurons";
            this.textBoxNeurons.Size = new System.Drawing.Size(100, 22);
            this.textBoxNeurons.TabIndex = 21;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBoxEveryStep);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBoxSteps);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxGainingAccuracy);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBoxNeurons);
            this.groupBox4.Controls.Add(this.textBoxLR);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxWD);
            this.groupBox4.Location = new System.Drawing.Point(703, 402);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(505, 118);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filling network paramemetrs";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(465, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 31;
            this.label10.Text = "step";
            // 
            // textBoxEveryStep
            // 
            this.textBoxEveryStep.Location = new System.Drawing.Point(416, 80);
            this.textBoxEveryStep.Name = "textBoxEveryStep";
            this.textBoxEveryStep.Size = new System.Drawing.Size(47, 22);
            this.textBoxEveryStep.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Display epsilon on every ";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(399, 46);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(100, 22);
            this.textBoxSteps.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Max steps = ";
            // 
            // textBoxGainingAccuracy
            // 
            this.textBoxGainingAccuracy.Location = new System.Drawing.Point(399, 21);
            this.textBoxGainingAccuracy.Name = "textBoxGainingAccuracy";
            this.textBoxGainingAccuracy.Size = new System.Drawing.Size(100, 22);
            this.textBoxGainingAccuracy.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Gaining accuracy = ";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(175, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(81, 39);
            this.buttonOpen.TabIndex = 24;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Open directory with files:";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1499, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 30);
            this.button3.TabIndex = 53;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1405, -3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 30);
            this.button5.TabIndex = 54;
            this.button5.Text = "<< ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // CalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1544, 654);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonClearChart);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonConvolution);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalculationForm";
            this.Load += new System.EventHandler(this.CalculationForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CalculationForm_MouseDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonConvolution;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonBP;
        private System.Windows.Forms.Button buttonTestBP;
        private System.Windows.Forms.Button buttonSaveBP;
        private System.Windows.Forms.Button buttonClearChart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNeurons;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxGainingAccuracy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxEveryStep;
        private System.Windows.Forms.Label label9;
    }
}