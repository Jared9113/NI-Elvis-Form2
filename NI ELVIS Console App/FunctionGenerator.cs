using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using NationalInstruments.NetworkVariable;
using System.Diagnostics;


namespace NI_ELVIS_Console_App
{
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
                    rVal[i] = amplitude * Math.Sign(Math.Sin((2.0 * Math.PI) * frequency * (i * deltaT)));

            //{
            //    if (i <= (intSamplesPerBuffer / 2))
            //        rVal[i] = amplitude;
            //    if (i >= (intSamplesPerBuffer / 2))
            //        rVal[i] = -amplitude;

            //}

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
            //float newFreq = 1/ intSamplesPerBuffer;

            for (int i = 0; i < intSamplesPerBuffer; i++)
            {
                //if (i <= (intSamplesPerBuffer / (float)4))
                //    rVal[i] = 4 * amplitude * newFreq * (i * deltaT);
                //else if ((i >= (intSamplesPerBuffer / (float)4)) && (i <= (intSamplesPerBuffer * (float)3 / 4)))
                //    rVal[i] = (-4 * amplitude * newFreq * (i * deltaT)) + (2 * amplitude);
                //else
                //    rVal[i] = (4 * amplitude * newFreq * (i * deltaT)) - (4 * amplitude);

                //rVal[i] = amplitude * (1f - 4f) * (float)Math.Abs(Math.Round(i * deltaT * frequency) -
                //    (i * deltaT * frequency));

                rVal[i] = amplitude / 2 - 4 * (float)Math.Abs
                        (Math.Round(deltaT * i * frequency - (0.25))
                        - (deltaT * i * frequency - 0.25));
            }
            //rVal[i] = amplitude * Math.Sin((2.0 * Math.PI) * frequency * (i * deltaT));

            return rVal;
        }
    }
}
