using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments.NetworkVariable;
using System.Threading;

using Task = NationalInstruments.DAQmx.Task;

namespace NI_ELVIS_Console_App
{
    class AOReader
    {
        AnalogSingleChannelReader reader;
        private Task waveTask;
        private int samples = 1000;
        private int samplingRate = 3000;
        private double[] data = new double[1000];

        Timer t;

        NetworkVariableBufferedWriter<double[]> bufferedWriter;
        string variablelacation = @"\\localhost\system\variable2";

        public AOReader()
        {
            bufferedWriter = new NetworkVariableBufferedWriter<double[]>(variablelacation);
            bufferedWriter.Connect();
        }


        public double[] Data
        {
            get { return data; }
        }
        public void StartWaveTask()
        {
            try
            {
                waveTask = new Task();

                // Create a virtual channel
                waveTask.AIChannels.CreateVoltageChannel("Dev3/ai0", "",
                     (AITerminalConfiguration)(-1), Convert.ToDouble(-10),
                         Convert.ToDouble(10), AIVoltageUnits.Volts);

                waveTask.Timing.ConfigureSampleClock(string.Empty, samplingRate, SampleClockActiveEdge.Rising,
                                                         SampleQuantityMode.ContinuousSamples, samples);

                // Verify the Task
                waveTask.Control(TaskAction.Verify);
                reader = new AnalogSingleChannelReader(waveTask.Stream);
                t = new Timer(DisplayTimeEvent, null, 0, 100);
            }

            catch (DaqException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void DisplayTimeEvent(object o)
        {
            data = reader.ReadMultiSample(samples);
            bufferedWriter.WriteValue(data);
        }

        public void StopRead()
        {
            waveTask.Dispose();
        }
    }
}
