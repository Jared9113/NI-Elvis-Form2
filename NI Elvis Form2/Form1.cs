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

namespace NI_Elvis_Form2
{
    public partial class Form1 : Form
    {
        //private DispatcherTimer dispatcherTimer;
        private NationalInstruments.DAQmx.Task oscilloscopeTask;
        private NationalInstruments.DAQmx.Task fGenTask;
        private int samples = 500;
        private int samplingRate = 250;
        //private static string waveType;


        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External));
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            GetChannels();

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

        public void GetChannels()
        {
            int deviceNo = DaqSystem.Local.Devices.Length;
            if (deviceNo > 0)
            {
                button1.Enabled = true;
                knob1.Enabled = true;
                knob2.Enabled = true;
                comboBox1.Enabled = true;

            }
            else
            {
                button1.Enabled = false;
                knob1.Enabled = false;
                knob2.Enabled = false;
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
            xAxis1.Range = new NationalInstruments.UI.Range(0, e.NewValue);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            comboBox1.Enabled = false;

            timer2.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            comboBox1.Enabled = true;

            timer2.Stop();
            oscilloscopeTask.Dispose();

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
        public enum WaveformType
        {
            SineWave = 0,
            SquareWave = 1,
            TriangularWave = 2
        }

        public class FunctionGenerator
        {
            private double[] _data;
            private double _resultingSampleClockRate;
            private double _resultingFrequency;
            private double _desiredSampleClockRate;
            private double _samplesPerCycle;

            public FunctionGenerator(
                Timing timingSubobject,
                string desiredFrequency,
                string samplesPerBuffer,
                string cyclesPerBuffer,
                string type,
                string amplitude)
            {
                WaveformType t = new WaveformType();
                t = WaveformType.SineWave;// May have to change this
                if (type == "Sine Wave")
                    t = WaveformType.SineWave;
                else if (type == "Triangular Wave")
                    t = WaveformType.TriangularWave;
                else if (type == "Square Wave")
                    t = WaveformType.SquareWave;
                else
                    Debug.Assert(false, "Invalid Waveform Type");

                Init(
                    timingSubobject,
                    Double.Parse(desiredFrequency),
                    Double.Parse(samplesPerBuffer),
                    Double.Parse(cyclesPerBuffer),
                    t,
                    Double.Parse(amplitude));
            }

            public FunctionGenerator(
                Timing timingSubobject,
                double desiredFrequency,
                double samplesPerBuffer,
                double cyclesPerBuffer,
                WaveformType type,
                double amplitude)
            {
                Init(
                    timingSubobject,
                    desiredFrequency,
                    samplesPerBuffer,
                    cyclesPerBuffer,
                    type,
                    amplitude);
            }

            private void Init(
                Timing timingSubobject,
                double desiredFrequency,
                double samplesPerBuffer,
                double cyclesPerBuffer,
                WaveformType type,
                double amplitude)
            {
                if (desiredFrequency <= 0)
                    throw new ArgumentOutOfRangeException("desiredFrequency", desiredFrequency, "This parameter must be a positive number");
                if (samplesPerBuffer <= 0)
                    throw new ArgumentOutOfRangeException("samplesPerBuffer", samplesPerBuffer, "This parameter must be a positive number");
                if (cyclesPerBuffer <= 0)
                    throw new ArgumentOutOfRangeException("cyclesPerBuffer", cyclesPerBuffer, "This parameter must be a positive number");

                // First configure the Task timing parameters
                if (timingSubobject.SampleTimingType == SampleTimingType.OnDemand)
                    timingSubobject.SampleTimingType = SampleTimingType.SampleClock;

                _desiredSampleClockRate = (desiredFrequency * samplesPerBuffer) / cyclesPerBuffer;
                _samplesPerCycle = samplesPerBuffer / cyclesPerBuffer;

                // Determine the actual sample clock rate
                timingSubobject.SampleClockRate = _desiredSampleClockRate;
                _resultingSampleClockRate = timingSubobject.SampleClockRate;

                _resultingFrequency = _resultingSampleClockRate / (samplesPerBuffer / cyclesPerBuffer);

                switch (type)
                {
                    case WaveformType.SineWave:
                        _data = GenerateSineWave(_resultingFrequency, amplitude, _resultingSampleClockRate, samplesPerBuffer);
                        break;
                    case WaveformType.TriangularWave:
                        _data = GenerateTriangularWave(_resultingFrequency, amplitude, _resultingSampleClockRate, samplesPerBuffer);

                        break;
                    case WaveformType.SquareWave:
                        _data = GenerateSquareWave(_resultingFrequency, amplitude, _resultingSampleClockRate, samplesPerBuffer);

                        break;
                    default:
                        // Invalid type value
                        Debug.Assert(false);
                        break;
                }
            }

            public double[] Data
            {
                get
                {
                    return _data;
                }
            }

            public double ResultingSampleClockRate
            {
                get
                {
                    return _resultingSampleClockRate;
                }
            }

            public static double[] GenerateSineWave(
                double frequency,
                double amplitude,
                double sampleClockRate,
                double samplesPerBuffer)
            {
                double deltaT = 1 / sampleClockRate; // sec./samp
                int intSamplesPerBuffer = (int)samplesPerBuffer;

                double[] rVal = new double[intSamplesPerBuffer];

                for (int i = 0; i < intSamplesPerBuffer; i++)
                    rVal[i] = amplitude * Math.Sin((2.0 * Math.PI) * frequency * (i * deltaT));

                return rVal;
            }

            public static double[] GenerateSquareWave(
                double frequency,
                double amplitude,
                double sampleClockRate,
                double samplesPerBuffer)
            {
                double deltaT = 1 / sampleClockRate; // sec./samp
                int intSamplesPerBuffer = (int)samplesPerBuffer;

                double[] rVal = new double[intSamplesPerBuffer];

                for (int i = 0; i < intSamplesPerBuffer; i++)
                {
                    if (i <= (intSamplesPerBuffer / 2))
                        rVal[i] = amplitude;
                    if (i >= (intSamplesPerBuffer / 2))
                        rVal[i] = -amplitude;

                }
                    //rVal[i] = amplitude * Math.Sin((2.0 * Math.PI) * frequency * (i * deltaT));

                return rVal;
            }

            public static double[] GenerateTriangularWave(
                double frequency,
                double amplitude,
                double sampleClockRate,
                double samplesPerBuffer)
            {
                double deltaT = 1 / sampleClockRate; // sec./samp
                int intSamplesPerBuffer = (int)samplesPerBuffer;

                double[] rVal = new double[intSamplesPerBuffer];

                for (int i = 0; i < intSamplesPerBuffer; i++)
                {
                    if (i <= (intSamplesPerBuffer / (float)4))
                        rVal[i] = 4 * amplitude * frequency * (i * deltaT);
                    else if ((i >= (intSamplesPerBuffer / (float)4)) && (i <= (intSamplesPerBuffer * (float)3 / 4)))
                        rVal[i] = -4 * amplitude * frequency * (i * deltaT) + 2 * amplitude;
                    else
                        rVal[i] = 4 * amplitude * frequency * (i * deltaT) - 4 * amplitude;
                }
                    //rVal[i] = amplitude * Math.Sin((2.0 * Math.PI) * frequency * (i * deltaT));

                return rVal;
            }
        }

        private void fGenRun_Click(object sender, EventArgs e)
        {
            try
            {
                // create the task and channel
                fGenTask = new Task();
                fGenTask.AOChannels.CreateVoltageChannel("Dev4/ao1",
                    "",
                    Convert.ToDouble(-10),
                    Convert.ToDouble(10),
                    AOVoltageUnits.Volts);

                // verify the task before doing the waveform calculations
                fGenTask.Control(TaskAction.Verify);

                // calculate some waveform parameters and generate data
                FunctionGenerator fGen = new FunctionGenerator(
                    fGenTask.Timing,
                    FrequencyNumeric.Value.ToString(),
                    "250",
                    "5",
                    comboBox2.Text,
                    AmplitudeNumeric.Value.ToString());

                // configure the sample clock with the calculated rate
                fGenTask.Timing.ConfigureSampleClock("",
                    fGen.ResultingSampleClockRate,
                    SampleClockActiveEdge.Rising,
                    SampleQuantityMode.ContinuousSamples, 1000);


                AnalogSingleChannelWriter writer =
                    new AnalogSingleChannelWriter(fGenTask.Stream);

                //write data to buffer
                writer.WriteMultiSample(false, fGen.Data);

                //start writing out data
                fGenTask.Start();

                fGenRun.Enabled = false;
                fGenStop.Enabled = true;

                statusCheckTimer.Enabled = true;
            }
            catch (DaqException err)
            {
                statusCheckTimer.Enabled = false;
                MessageBox.Show(err.Message);
                fGenTask.Dispose();
            }
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

        //private void SineBtn_Click(object sender, EventArgs e)
        //{
        //    waveType = WaveformType.SineWave.ToString();
        //}
    }
}
