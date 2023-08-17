using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NationalInstruments.DAQmx;
using NationalInstruments.UI;
using NationalInstruments.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using Task = NationalInstruments.DAQmx.Task;
using NationalInstruments.NetworkVariable;

namespace NI_Elvis_Form2
{
    public partial class Form1 : Form
    {
        //private DispatcherTimer dispatcherTimer;
        private NationalInstruments.DAQmx.Task oscilloscopeTask;
        private NationalInstruments.DAQmx.Task fGenTask;
        private int samples = 1000;
        private int samplingRate = 3000;
        //private static string waveType;

        private NetworkVariableBufferedWriter<string[]> variable1Writer;
        private string variable1location = @"\\localhost\system\variable1";

        private NetworkVariableSubscriber<double[]> variable2Subscriber;
        private string variable2location = @"\\localhost\system\variable2";



        //private string wavetype;


        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            GetChannels();

            variable1Writer = new NetworkVariableBufferedWriter<string[]>(variable1location);
            variable1Writer.PropertyChanged += variable1Writer_PropertyChanged;
            variable1Writer.Connect();


            variable2Subscriber = new NetworkVariableSubscriber<double[]>(variable2location);
            variable2Subscriber.ConnectionBehavior = SubscriberConnectionBehavior.UpdateOnConnect;
            variable2Subscriber.PropertyChanged += variable2Subscriber_PropertyChanged;
            variable2Subscriber.DataUpdated += variable2Subscriber_DataUpdated;

            //dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            //dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        private void variable2Subscriber_DataUpdated(object sender, DataUpdatedEventArgs<double[]> e)
        {
            if (e.Data.HasValue)
            {
                double[] data = e.Data.GetValue();
                //waveGraph.DataSource = data;
                waveformGraph1.PlotY(data);


            }

        }

        private void variable2Subscriber_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnectionStatus")
                WriterStatusTextBox.Text = variable2Subscriber.ConnectionStatus.ToString();
        }

        private void variable1Writer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnectionStatus")
                SubscriberStatusTextBox.Text = variable1Writer.ConnectionStatus.ToString();
        }

        public void GetChannels()
        {
            int deviceNo = DaqSystem.Local.Devices.Length;
            if (deviceNo > 0)
            {
                button1.Enabled = true;
                HorizontalAxisKnob.Enabled = true;
                VerticalAxisKnob.Enabled = true;
                comboBox1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
                HorizontalAxisKnob.Enabled = false;
                VerticalAxisKnob.Enabled = false;
                comboBox1.Enabled = false;
            }
            //    int channelNo = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External).Length;

            //for (int i = 0; i < channelNo; i++)
            //    comboBox1.Items.Add(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External).GetValue(i));

            //comboBox1.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            //if (comboBox1.Items.Count > 0)
            //    comboBox1.SelectedIndex = 0;

            //if (comboBox1.Items.Count > 0)
            //        comboBox1.SelectedIndex = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void knob1_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            samples = (int)e.NewValue;
            HorizontalAxisNumeric.Value = (decimal)e.NewValue;
            xAxis1.Range = new NationalInstruments.UI.Range(0, e.NewValue);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            comboBox1.Enabled = false;
            variable2Subscriber.Connect();
            //timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            comboBox1.Enabled = true;
            variable2Subscriber.Disconnect();
            //timer2.Stop();
            //oscilloscopeTask.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetChannels();

        }

        //private void DispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //try
        //{
        //    // Disable the Run button
        //    //button1.Enabled = false;

        //    //Create a new task
        //    using (myTask = new NationalInstruments.DAQmx.Task())
        //    {
        //        //Create a virtual channel
        //        myTask.AIChannels.CreateVoltageChannel(comboBox1.Text, "",
        //            (AITerminalConfiguration)(-1), Convert.ToDouble(-10),
        //            Convert.ToDouble(10), AIVoltageUnits.Volts);

        //        AnalogSingleChannelReader streamReader = new AnalogSingleChannelReader(myTask.Stream);

        //        myTask.Timing.ConfigureSampleClock(string.Empty, samplingRate, SampleClockActiveEdge.Rising,
        //            SampleQuantityMode.ContinuousSamples, samples);

        //        //Verify the Task
        //        myTask.Control(TaskAction.Verify);

        //        //Initialize the table
        //        //InitializeDataTable(myTask.AIChannels, ref dataTable);
        //        //acquisitionDataGrid.DataSource = dataTable;

        //        ////Plot Multiple Channels to the table
        //        //double[] data = reader.ReadSingleSample();
        //        //dataToDataTable(data, ref dataTable);

        //        double[] data = streamReader.ReadMultiSample(samples);

        //        waveformGraph1.PlotY(data);
        //    }
        //}
        //catch (DaqException exception)
        //{
        //    MessageBox.Show(exception.Message);
        //}
        //finally
        //{
        //    // Enable the Run button
        //    //button1.Enabled = true;
        //}
        //}

        private void knob2_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            VerticalAxisNumeric.Value = (decimal)e.NewValue;
            yAxis1.Range = new NationalInstruments.UI.Range(-e.NewValue, e.NewValue);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                // Disable the Run button
                //button1.Enabled = false;

                //Create a new task
                using (oscilloscopeTask = new NationalInstruments.DAQmx.Task())
                {
                    //Create a virtual channel
                    oscilloscopeTask.AIChannels.CreateVoltageChannel(comboBox1.Text, "",
                        (AITerminalConfiguration)(-1), Convert.ToDouble(-10),
                        Convert.ToDouble(10), AIVoltageUnits.Volts);

                    AnalogSingleChannelReader streamReader = new AnalogSingleChannelReader(oscilloscopeTask.Stream);

                    oscilloscopeTask.Timing.ConfigureSampleClock(string.Empty, samplingRate, SampleClockActiveEdge.Rising,
                        SampleQuantityMode.ContinuousSamples, samples);

                    //Verify the Task
                    oscilloscopeTask.Control(TaskAction.Verify);

                    //Initialize the table
                    //InitializeDataTable(myTask.AIChannels, ref dataTable);
                    //acquisitionDataGrid.DataSource = dataTable;

                    ////Plot Multiple Channels to the table
                    //double[] data = reader.ReadSingleSample();
                    //dataToDataTable(data, ref dataTable);

                    double[] data = streamReader.ReadMultiSample(samples);

                    waveformGraph1.PlotY(data);
                }
            }
            catch (DaqException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                // Enable the Run button
                //button1.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // waveType = WaveformType.TriangularWave.ToString();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
        

        private void fGenRun_Click(object sender, EventArgs e)
        {
            //_workerThread = new Thread(WriteData);
            //_workerThread.Start();

            string[] data = new string[] {FrequencyNumeric.Value.ToString(),
            comboBox2.Text, AmplitudeNumeric.Value.ToString()};
            variable1Writer.WriteData(new NetworkVariableData<string[]>(data));

            fGenRun.Enabled = false;
            fGenStop.Enabled = true;

            //Cursor.Current = Cursors.Default;
        }

        private void statusCheckTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Getting myTask.IsDone also checks for errors that would prematurely
                // halt the continuous generation.
                if (fGenTask.IsDone)
                {
                    statusCheckTimer.Enabled = false;
                    fGenTask.Stop();
                    fGenTask.Dispose();
                    fGenRun.Enabled = true;
                    fGenStop.Enabled = false;
                }
            }
            catch (DaqException ex)
            {
                statusCheckTimer.Enabled = false;
                System.Windows.Forms.MessageBox.Show(ex.Message);
                fGenTask.Dispose();
                fGenRun.Enabled = true;
                fGenStop.Enabled = false;
            }
        }

        private void fGenStop_Click(object sender, EventArgs e)
        {
            statusCheckTimer.Enabled = false;
            if (fGenTask != null)
            {
                try
                {
                    fGenTask.Stop();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                fGenTask.Dispose();
                fGenTask = null;
                fGenRun.Enabled = true;
                fGenStop.Enabled = false;
            }
        }

        private void knob4_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            FrequencyNumeric.Value = (decimal)e.NewValue;
        }

        private void knob3_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            AmplitudeNumeric.Value = (decimal)e.NewValue;
        }

        //private void SineBtn_Click(object sender, EventArgs e)
        //{
        //    waveType = WaveformType.SineWave.ToString();
        //}
    }
}
