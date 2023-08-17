using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.NetworkVariable;
using System.ComponentModel;

namespace NI_ELVIS_Console_App
{
    class Subscriber
    {
        private NetworkVariableSubscriber<string[]> _subscriber;
        private const string NetworkVariableLocation = @"\\localhost\system\variable1";

        Writer writer;
        public Subscriber()
        {
            writer = new Writer();
            _subscriber = new NetworkVariableSubscriber<string[]>(NetworkVariableLocation);
            //_subscriber.PropertyChanged += new PropertyChangedEventHandler(OnPropertyChanged);
            //_subscriber.DataUpdated += new EventHandler<DataUpdatedEventArgs<string[]>>(OnDataUpdated);

            _subscriber.PropertyChanged += OnPropertyChanged;
            _subscriber.DataUpdated += OnDataUpdated;

        }

        public void Connect()
        {
            _subscriber.Connect();

        }

        private void OnDataUpdated(object sender, DataUpdatedEventArgs<string[]> e)
        {
            //if (e.Data.HasTimeStamp)
            //    timeStampTextBox.Text = e.Data.TimeStamp.ToLocalTime().ToString();

            //if (e.Data.HasQuality)
            //    qualityTextBox.Text = e.Data.Quality.ToString();

            if (e.Data.HasValue)
            {
                //double[] data = e.Data.GetValue();
                //displayWaveformGraph.PlotYAppend(data);

                string[] data = e.Data.GetValue();
                string frequency = data[0];
                string wavetype = data[1];
                string amplitude = data[2];
                writer.Write(frequency, wavetype, amplitude);
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnectionStatus")
                Console.WriteLine(_subscriber.ConnectionStatus);
                //Subscriber.Text = _subscriber.ConnectionStatus.ToString();
        }
    }   
}
