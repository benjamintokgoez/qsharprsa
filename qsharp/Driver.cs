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
            Console.WriteLine("Enter a positive integer to factor:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(N);
            ClassicPart cp = new ClassicPart();
            cp.FindGCD(N);
        }
        
        class ClassicPart
        {
            protected Random random = new Random();
            public int a;
            //public int N;

             public void FindGCD(int N)
            {
                bool finished = false;
                int M = N;

                //während keine entsprechende Primzahl gefunden würde läuft diese erste While Schleife
                while (finished == false)
                {
                    //Schritt 1: Ein randomisiertes a<N und a>2 wird gewählt
                    a = random.Next(3, N);
                    Console.WriteLine("this is the basic a " + a);
                    Debug.WriteLine("this is the basic a " + a);
                    int b = a;

                    //Schritt 2: der ggT von a und N wird ermittelt und als M ausgegeben
                    while (b != 0)
                    {
                        int tmp = M % b;
                        M = b;
                        b = tmp;
                    }
                    //Schritt 3: Ist der ggT ungleich 1 kann a zurückgegeben werden und der klassische Teil ist beendet.
                    if (M != 1)
                    {
                        //finished = true;
                        //Console.WriteLine("this is the basic " + a);
                        FindGCD(N);
                    }
                    else if (M == 1)
                    {
                        //a & N werden an den Quantenteil übergeben, um dort die kleinste Ordnung r von a in Mod N gleich 1 zu ermitteln.  
                        //QuantPa.QPart1(a);
                        //VerifyR(4,N); Dieser Aufruf muss nun aus einer anderen Klasse erfolgen
                        finished = true;
                        var period = shorsPeriod.Run(new QuantumSimulator(), N, a).Result;
                        Console.WriteLine("C#: Period of " + N + " is: "+  period);
                    }
                }
            }

            public void VerifyR(int r, int N)
            {
                //r ist ermittelt. Nun wird überprüft, ob es ungerade ist. Sollte dem so sein wird neu gestartet.
                if (r % 2 != 0)
                {
                    ClassicStart.Main();
                }
                //	6. Sollte a^(r/2)=-1(mod N) wird neu gestartet.
                else
                {
                    int b = a;
                    for (int x = 2; x <= r / 2; x++)
                    {
                        b *= a;
                    }
                    Console.WriteLine("this is a to half order r " + b);
                    Debug.WriteLine("this is a to half order r " + b);
                    if (N % b == -1)
                    {
                        ClassicStart.Main();
                    }
                    else if (N % b == 1)
                    {
                        ClassicStart.Main();
                    }
                    else
                    {
                        FindPnQ(b, N);
                    }
                }
            }

         
            public void FindPnQ(int a, int N)
            {
                //Gcd(a^(r/2)+1, N) ist ein nicht trivialer Faktor von N.
                Console.WriteLine("Finales a: " + a + " Finales N: " + N);
                Debug.WriteLine("Finales a: " + a + " Finales N: " + N);
                int M = N;
                int p = a + 1;
                int q = a - 1;
                while (N != 0)
                {
                    int tmp = p % N;
                    p = N;
                    N = tmp;
                    Debug.WriteLine("tmp: " + tmp);
                    Debug.WriteLine("p: " + p);
                    Debug.WriteLine("N: " + N);
                }
                while (M != 0)
                {
                    int tmp = q % M;
                    q = M;
                    M = tmp;
                }
                Console.WriteLine("Faktor p: "+p + " und Faktor q: "+q);
                Debug.WriteLine("Faktor p: " + p + " und Faktor q: " + q);
            }
        }   

        }
    }
}
