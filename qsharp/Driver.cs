using System;
using System.Diagnostics;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace qsharp
{
    class Driver
    {
        static void Main(string[] args)
        {
            //on a notebook, please check only with numbers < 32
            //int N = 7;
            //int a = 2; //random Number, co prime
            //Console.WriteLine("Enter a positive integer to factor:");
            //int N = int.Parse(Console.ReadLine());
            //Console.WriteLine(N);
            //Starts the Shor Algorithm with a public key of 15
            int N = 15;
            ShorsAlgorithm s = new ShorsAlgorithm();
            s.FindGCD(N);
        }
    }

    
}
