﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.NetworkVariable;
using NI_ELVIS_Console_App;

namespace NI_ELVIS_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _subscriber = new Subscriber();
            _subscriber.Connect();

            Console.ReadLine();
        }
    }
}
