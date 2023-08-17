
namespace NI_Elvis_Form2
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
            this.HorizontalAxisKnob = new NationalInstruments.UI.WindowsForms.Knob();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.VerticalAxisKnob = new NationalInstruments.UI.WindowsForms.Knob();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AmplitudeNumeric = new System.Windows.Forms.NumericUpDown();
            this.FrequencyNumeric = new System.Windows.Forms.NumericUpDown();
            this.knob4 = new NationalInstruments.UI.WindowsForms.Knob();
            this.knob3 = new NationalInstruments.UI.WindowsForms.Knob();
            this.fGenStop = new System.Windows.Forms.Button();
            this.fGenRun = new System.Windows.Forms.Button();
            this.SineBtn = new System.Windows.Forms.Button();
            this.TriBtn = new System.Windows.Forms.Button();
            this.SquareBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.HorizontalAxisNumeric = new System.Windows.Forms.NumericUpDown();
            this.VerticalAxisNumeric = new System.Windows.Forms.NumericUpDown();
            this.statusCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WriterStatusTextBox = new System.Windows.Forms.TextBox();
            this.SubscriberStatusTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalAxisKnob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAxisKnob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalAxisNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAxisNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // HorizontalAxisKnob
            // 
            this.HorizontalAxisKnob.Caption = "Horizontal Axis (ms)";
            this.HorizontalAxisKnob.Enabled = false;
            this.HorizontalAxisKnob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorizontalAxisKnob.Location = new System.Drawing.Point(6, 19);
            this.HorizontalAxisKnob.Name = "HorizontalAxisKnob";
            this.HorizontalAxisKnob.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.HorizontalAxisKnob.Range = new NationalInstruments.UI.Range(100D, 500D);
            this.HorizontalAxisKnob.ScaleVisible = false;
            this.HorizontalAxisKnob.Size = new System.Drawing.Size(153, 121);
            this.HorizontalAxisKnob.TabIndex = 0;
            this.HorizontalAxisKnob.Value = 100D;
            this.HorizontalAxisKnob.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob1_AfterChangeValue);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(330, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(330, 108);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Channel:";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(413, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // VerticalAxisKnob
            // 
            this.VerticalAxisKnob.Caption = "Vertical Axis (V)";
            this.VerticalAxisKnob.Enabled = false;
            this.VerticalAxisKnob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerticalAxisKnob.Location = new System.Drawing.Point(165, 19);
            this.VerticalAxisKnob.Name = "VerticalAxisKnob";
            this.VerticalAxisKnob.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.VerticalAxisKnob.Size = new System.Drawing.Size(159, 121);
            this.VerticalAxisKnob.TabIndex = 5;
            this.VerticalAxisKnob.ToolTipsEnabled = false;
            this.VerticalAxisKnob.Value = 5D;
            this.VerticalAxisKnob.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob2_AfterChangeValue);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // waveformGraph1
            // 
            this.waveformGraph1.Location = new System.Drawing.Point(40, 25);
            this.waveformGraph1.Name = "waveformGraph1";
            this.waveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1});
            this.waveformGraph1.Size = new System.Drawing.Size(619, 333);
            this.waveformGraph1.TabIndex = 8;
            this.waveformGraph1.UseColorGenerator = true;
            this.waveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.waveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AmplitudeNumeric);
            this.groupBox1.Controls.Add(this.FrequencyNumeric);
            this.groupBox1.Controls.Add(this.knob4);
            this.groupBox1.Controls.Add(this.knob3);
            this.groupBox1.Controls.Add(this.fGenStop);
            this.groupBox1.Controls.Add(this.fGenRun);
            this.groupBox1.Controls.Add(this.SineBtn);
            this.groupBox1.Controls.Add(this.TriBtn);
            this.groupBox1.Controls.Add(this.SquareBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(678, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 333);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function Generator";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // AmplitudeNumeric
            // 
            this.AmplitudeNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmplitudeNumeric.Location = new System.Drawing.Point(23, 152);
            this.AmplitudeNumeric.Name = "AmplitudeNumeric";
            this.AmplitudeNumeric.Size = new System.Drawing.Size(120, 20);
            this.AmplitudeNumeric.TabIndex = 12;
            this.AmplitudeNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // FrequencyNumeric
            // 
            this.FrequencyNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrequencyNumeric.Location = new System.Drawing.Point(192, 152);
            this.FrequencyNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.FrequencyNumeric.Name = "FrequencyNumeric";
            this.FrequencyNumeric.Size = new System.Drawing.Size(120, 20);
            this.FrequencyNumeric.TabIndex = 14;
            this.FrequencyNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // knob4
            // 
            this.knob4.Caption = "Frequency (kHz)";
            this.knob4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knob4.Location = new System.Drawing.Point(165, 19);
            this.knob4.MajorDivisions.LabelVisible = false;
            this.knob4.Name = "knob4";
            this.knob4.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.knob4.Range = new NationalInstruments.UI.Range(0D, 5000D);
            this.knob4.Size = new System.Drawing.Size(153, 121);
            this.knob4.TabIndex = 6;
            this.knob4.Value = 100D;
            this.knob4.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob4_AfterChangeValue);
            // 
            // knob3
            // 
            this.knob3.Caption = "Amplitude (V)";
            this.knob3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knob3.Location = new System.Drawing.Point(6, 19);
            this.knob3.Name = "knob3";
            this.knob3.OutOfRangeMode = NationalInstruments.UI.NumericOutOfRangeMode.CoerceToRange;
            this.knob3.Size = new System.Drawing.Size(153, 121);
            this.knob3.TabIndex = 5;
            this.knob3.Value = 4D;
            this.knob3.AfterChangeValue += new NationalInstruments.UI.AfterChangeNumericValueEventHandler(this.knob3_AfterChangeValue);
            // 
            // fGenStop
            // 
            this.fGenStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGenStop.Location = new System.Drawing.Point(192, 266);
            this.fGenStop.Name = "fGenStop";
            this.fGenStop.Size = new System.Drawing.Size(65, 31);
            this.fGenStop.TabIndex = 4;
            this.fGenStop.Text = "Stop";
            this.fGenStop.UseVisualStyleBackColor = true;
            this.fGenStop.Click += new System.EventHandler(this.fGenStop_Click);
            // 
            // fGenRun
            // 
            this.fGenRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fGenRun.Location = new System.Drawing.Point(64, 266);
            this.fGenRun.Name = "fGenRun";
            this.fGenRun.Size = new System.Drawing.Size(67, 31);
            this.fGenRun.TabIndex = 3;
            this.fGenRun.Text = "Run";
            this.fGenRun.UseVisualStyleBackColor = true;
            this.fGenRun.Click += new System.EventHandler(this.fGenRun_Click);
            // 
            // SineBtn
            // 
            this.SineBtn.Location = new System.Drawing.Point(53, 201);
            this.SineBtn.Name = "SineBtn";
            this.SineBtn.Size = new System.Drawing.Size(52, 35);
            this.SineBtn.TabIndex = 2;
            this.SineBtn.Text = "Sine";
            this.SineBtn.UseVisualStyleBackColor = true;
            // 
            // TriBtn
            // 
            this.TriBtn.Location = new System.Drawing.Point(141, 201);
            this.TriBtn.Name = "TriBtn";
            this.TriBtn.Size = new System.Drawing.Size(47, 35);
            this.TriBtn.TabIndex = 1;
            this.TriBtn.UseVisualStyleBackColor = true;
            this.TriBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // SquareBtn
            // 
            this.SquareBtn.Location = new System.Drawing.Point(220, 201);
            this.SquareBtn.Name = "SquareBtn";
            this.SquareBtn.Size = new System.Drawing.Size(50, 35);
            this.SquareBtn.TabIndex = 0;
            this.SquareBtn.UseVisualStyleBackColor = true;
            this.SquareBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.HorizontalAxisNumeric);
            this.groupBox2.Controls.Add(this.HorizontalAxisKnob);
            this.groupBox2.Controls.Add(this.VerticalAxisKnob);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.VerticalAxisNumeric);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(69, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 181);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oscilloscope";
            // 
            // HorizontalAxisNumeric
            // 
            this.HorizontalAxisNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HorizontalAxisNumeric.Location = new System.Drawing.Point(23, 146);
            this.HorizontalAxisNumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.HorizontalAxisNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HorizontalAxisNumeric.Name = "HorizontalAxisNumeric";
            this.HorizontalAxisNumeric.Size = new System.Drawing.Size(120, 20);
            this.HorizontalAxisNumeric.TabIndex = 13;
            this.HorizontalAxisNumeric.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // VerticalAxisNumeric
            // 
            this.VerticalAxisNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerticalAxisNumeric.Location = new System.Drawing.Point(183, 146);
            this.VerticalAxisNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.VerticalAxisNumeric.Name = "VerticalAxisNumeric";
            this.VerticalAxisNumeric.Size = new System.Drawing.Size(120, 20);
            this.VerticalAxisNumeric.TabIndex = 11;
            this.VerticalAxisNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // statusCheckTimer
            // 
            this.statusCheckTimer.Tick += new System.EventHandler(this.statusCheckTimer_Tick);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Sine Wave",
            "Triangular Wave",
            "Square Wave"});
            this.comboBox2.Location = new System.Drawing.Point(701, 415);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Writer Status:";
            // 
            // WriterStatusTextBox
            // 
            this.WriterStatusTextBox.Location = new System.Drawing.Point(752, 491);
            this.WriterStatusTextBox.Name = "WriterStatusTextBox";
            this.WriterStatusTextBox.Size = new System.Drawing.Size(100, 20);
            this.WriterStatusTextBox.TabIndex = 13;
            // 
            // SubscriberStatusTextBox
            // 
            this.SubscriberStatusTextBox.Location = new System.Drawing.Point(752, 525);
            this.SubscriberStatusTextBox.Name = "SubscriberStatusTextBox";
            this.SubscriberStatusTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubscriberStatusTextBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(634, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Subscriber Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubscriberStatusTextBox);
            this.Controls.Add(this.WriterStatusTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.waveformGraph1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalAxisKnob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAxisKnob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knob3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalAxisNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalAxisNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.Knob HorizontalAxisKnob;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private NationalInstruments.UI.WindowsForms.Knob VerticalAxisKnob;
        private System.Windows.Forms.Timer timer1;
        private NationalInstruments.UI.WindowsForms.WaveformGraph waveformGraph1;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SineBtn;
        private System.Windows.Forms.Button TriBtn;
        private System.Windows.Forms.Button SquareBtn;
        private System.Windows.Forms.Button fGenStop;
        private System.Windows.Forms.Button fGenRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private NationalInstruments.UI.WindowsForms.Knob knob4;
        private NationalInstruments.UI.WindowsForms.Knob knob3;
        private System.Windows.Forms.Timer statusCheckTimer;
        private System.Windows.Forms.NumericUpDown AmplitudeNumeric;
        private System.Windows.Forms.NumericUpDown FrequencyNumeric;
        private System.Windows.Forms.NumericUpDown HorizontalAxisNumeric;
        private System.Windows.Forms.NumericUpDown VerticalAxisNumeric;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WriterStatusTextBox;
        private System.Windows.Forms.TextBox SubscriberStatusTextBox;
        private System.Windows.Forms.Label label3;
    }
}

