namespace NNetwork_FileWriting
{
    partial class Form1
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
            this.buttonWriteFile = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFindPattern = new System.Windows.Forms.Button();
            this.textBoxPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNonNormilized = new System.Windows.Forms.RadioButton();
            this.radioButtonNormilized = new System.Windows.Forms.RadioButton();
            this.buttonOpenCalcForm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWriteFile
            // 
            this.buttonWriteFile.Location = new System.Drawing.Point(185, 80);
            this.buttonWriteFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWriteFile.Name = "buttonWriteFile";
            this.buttonWriteFile.Size = new System.Drawing.Size(132, 53);
            this.buttonWriteFile.TabIndex = 0;
            this.buttonWriteFile.Text = "Write to File";
            this.buttonWriteFile.UseVisualStyleBackColor = true;
            this.buttonWriteFile.Click += new System.EventHandler(this.Button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 73);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(419, 514);
            this.checkedListBox1.TabIndex = 29;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged_1);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(441, 390);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1097, 202);
            this.chart1.TabIndex = 30;
            this.chart1.Text = "chart1";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(139, 25);
            this.textBoxFileName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(178, 22);
            this.textBoxFileName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "File name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 334);
            this.textBox1.TabIndex = 34;
            // 
            // buttonFindPattern
            // 
            this.buttonFindPattern.Location = new System.Drawing.Point(222, 57);
            this.buttonFindPattern.Name = "buttonFindPattern";
            this.buttonFindPattern.Size = new System.Drawing.Size(95, 55);
            this.buttonFindPattern.TabIndex = 36;
            this.buttonFindPattern.Text = "Find on pattern";
            this.buttonFindPattern.UseVisualStyleBackColor = true;
            this.buttonFindPattern.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textBoxPattern
            // 
            this.textBoxPattern.Location = new System.Drawing.Point(146, 24);
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.Size = new System.Drawing.Size(171, 22);
            this.textBoxPattern.TabIndex = 37;
            this.textBoxPattern.TextChanged += new System.EventHandler(this.TextBoxPattern_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Finding files:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonFindPattern);
            this.groupBox1.Controls.Add(this.textBoxPattern);
            this.groupBox1.Location = new System.Drawing.Point(8, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 118);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Finding in list";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonNonNormilized);
            this.groupBox2.Controls.Add(this.radioButtonNormilized);
            this.groupBox2.Controls.Add(this.buttonWriteFile);
            this.groupBox2.Controls.Add(this.textBoxFileName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 140);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Writing to the txt file";
            // 
            // radioButtonNonNormilized
            // 
            this.radioButtonNonNormilized.AutoSize = true;
            this.radioButtonNonNormilized.Location = new System.Drawing.Point(9, 106);
            this.radioButtonNonNormilized.Name = "radioButtonNonNormilized";
            this.radioButtonNonNormilized.Size = new System.Drawing.Size(116, 20);
            this.radioButtonNonNormilized.TabIndex = 34;
            this.radioButtonNonNormilized.TabStop = true;
            this.radioButtonNonNormilized.Text = "Non-normilized";
            this.radioButtonNonNormilized.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormilized
            // 
            this.radioButtonNormilized.AutoSize = true;
            this.radioButtonNormilized.Location = new System.Drawing.Point(9, 80);
            this.radioButtonNormilized.Name = "radioButtonNormilized";
            this.radioButtonNormilized.Size = new System.Drawing.Size(110, 20);
            this.radioButtonNormilized.TabIndex = 33;
            this.radioButtonNormilized.TabStop = true;
            this.radioButtonNormilized.Text = "Normilized file";
            this.radioButtonNormilized.UseVisualStyleBackColor = true;
            // 
            // buttonOpenCalcForm
            // 
            this.buttonOpenCalcForm.Location = new System.Drawing.Point(18, 45);
            this.buttonOpenCalcForm.Name = "buttonOpenCalcForm";
            this.buttonOpenCalcForm.Size = new System.Drawing.Size(240, 41);
            this.buttonOpenCalcForm.TabIndex = 41;
            this.buttonOpenCalcForm.Text = "Open Evaluation Form";
            this.buttonOpenCalcForm.UseVisualStyleBackColor = true;
            this.buttonOpenCalcForm.Click += new System.EventHandler(this.ButtonOpenCalcForm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 47);
            this.button1.TabIndex = 44;
            this.button1.Text = "Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Choose the directory save files TO:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(441, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 381);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Writing files";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 47);
            this.button2.TabIndex = 46;
            this.button2.Text = "Directory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Choose the directory save files FROM:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(11, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(419, 62);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reading files";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(793, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 365);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 16);
            this.label3.TabIndex = 50;
            this.label3.Text = "Open the form for evaluation united files:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.buttonOpenCalcForm);
            this.groupBox6.Location = new System.Drawing.Point(1143, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(266, 101);
            this.groupBox6.TabIndex = 51;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Start neural network evaluation";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1501, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 30);
            this.button3.TabIndex = 52;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1549, 602);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeuralNetwork_2020 Samara";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWriteFile;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFindPattern;
        private System.Windows.Forms.TextBox textBoxPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOpenCalcForm;
        private System.Windows.Forms.RadioButton radioButtonNonNormilized;
        private System.Windows.Forms.RadioButton radioButtonNormilized;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

