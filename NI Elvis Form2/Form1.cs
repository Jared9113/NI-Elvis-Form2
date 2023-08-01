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

namespace NI_Elvis_Form2
{
    public partial class Form1 : Form
    {
        private DispatcherTimer dispatcherTimer;
        private NationalInstruments.DAQmx.Task myTask;
        private int samples = 250;

        public Form1()
        {
            InitializeComponent();
            GetChannels();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

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
                int channelNo = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External).Length;

                for (int i = 0; i < channelNo; i++)
                    comboBox1.Items.Add(DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AI, PhysicalChannelAccess.External).GetValue(i));

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
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

            dispatcherTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            comboBox1.Enabled = true;

            dispatcherTimer.Stop();
            myTask.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetChannels();

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Disable the Run button
                //button1.Enabled = false;

                //Create a new task
                using (myTask = new NationalInstruments.DAQmx.Task())
                {
                    //Create a virtual channel
                    myTask.AIChannels.CreateVoltageChannel(comboBox1.Text, "",
                        (AITerminalConfiguration)(-1), Convert.ToDouble(-10),
                        Convert.ToDouble(10), AIVoltageUnits.Volts);

                    AnalogSingleChannelReader reader = new AnalogSingleChannelReader(myTask.Stream);

                    //Verify the Task
                    myTask.Control(TaskAction.Verify);

                    //Initialize the table
                    //InitializeDataTable(myTask.AIChannels, ref dataTable);
                    //acquisitionDataGrid.DataSource = dataTable;

                    ////Plot Multiple Channels to the table
                    //double[] data = reader.ReadSingleSample();
                    //dataToDataTable(data, ref dataTable);

                    double[] data = reader.ReadMultiSample(samples);

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

        private void knob2_AfterChangeValue(object sender, AfterChangeNumericValueEventArgs e)
        {
            yAxis1.Range = new NationalInstruments.UI.Range(-e.NewValue, e.NewValue);

        }
    }
}
