using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace qsharp
{
    class Driver
    {
        static void Main(string[] args)
        {
            //on a notebook, please check only with numbers < 32
            int N = 16;
            int a = 7; //random Number, co prime

            var period = shorsPeriod.Run(new QuantumSimulator(), N, a).Result;
            Console.WriteLine("C#: Period of " + N + " is: "+  period);            

        }
    }
}