using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments.NetworkVariable;
using System.Threading;
using System.ComponentModel;
using Task = NationalInstruments.DAQmx.Task;
using NationalInstruments.UI;
using System.Windows.Forms;
using NI_Elvis_Form2;

namespace NI_ELVIS_Console_App
{
    class Writer
    {
        private NationalInstruments.DAQmx.Task fGenTask;
        //private NetworkVariableBufferedWriter<double[]> _bufferedWriter;
        //private const string NetworkVariableLocation = @"\\localhost\system\variable2";
        AOReader reader;
        //private Thread _workerThread;
        

        public Writer()
        {
            //_bufferedWriter = new NetworkVariableBufferedWriter<double[]>(NetworkVariableLocation);

            //_bufferedWriter.Connect();

            reader = new AOReader();





        }

        public void Write(string frequency, string wavetype, string amplitude)
        {

            try
            {
                // create the task and channel
                fGenTask = new Task();
                fGenTask.AOChannels.CreateVoltageChannel("Dev3/ao0",
                            "",
                            Convert.ToDouble(-10),
                            Convert.ToDouble(10),
                            AOVoltageUnits.Volts);

                // verify the task before doing the waveform calculations
                fGenTask.Control(TaskAction.Verify);

                // calculate some waveform parameters and generate data
                FunctionGenerator fGen = new FunctionGenerator(
                    fGenTask.Timing,
                    frequency,
                    "250",
                    "5",
                    wavetype,
                    amplitude);

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
                reader.StartWaveTask();

                //fGenRun.Enabled = false;
                //fGenStop.Enabled = true;

                //statusCheckTimer.Enabled = true;
            }
            catch (DaqException err)
            {
                //statusCheckTimer.Enabled = false;
                Console.WriteLine(err.Message);
                fGenTask.Dispose();
            }
        }
    }
}
