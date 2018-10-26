using System;
using System.Diagnostics;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace qsharp
{

    class ShorsAlgorithm{

            protected Random random = new Random();
            public int a;
            public void FindGCD(int N)
            {
                int Ntemp = N;

                    //Step 1: An a<N and a>2 is randomly selected
                    a = random.Next(3, N);
                    int atemp = a;

                    //Step 2: The GCD of a and N is detected and 
                    while (atemp != 0)
                    {
                        int tmp = Ntemp % atemp;
                        Ntemp = atemp;
                        atemp = tmp;
                    }
                    //Step 3: If the GCD is not 1 the classic part can be exited.
                    if (Ntemp != 1)
                    {
                        FindGCD(N);
                    }
                    else
                    {
                        //Getting the smallest order r (period) of a in Mod N equal to 1 from the QuantumSimulator.   
                        int period = (int) shorsPeriod.Run(new QuantumSimulator(), N, a).Result;
                        Console.WriteLine("C#: Period of " + N + " is: "+  period);
                        VerifyR(period, N);
                    }
                
            }

            public void VerifyR(int r, int N)
            {
                //Step 4: Check if r is uneven.
                if (r % 2 != 0)
                {
                    FindGCD(N);
                }
                //	Step 5: Check if a^(r/2)=-1(mod N) or if a^(r/2)=-1(mod N).
                else
                {
                    int atemp = a;
                    for (int x = 2; x <= r / 2; x++)
                    {
                        atemp *= a;
                    }
                    if (N % atemp == -1)
                    {
                        FindGCD(N);
                    }
                    else if (N % atemp == 1)
                    {
                        FindGCD(N);
                    }
                    else
                    {
                        FindPnQ(atemp, N);
                    }
                }
            }

         
            public void FindPnQ(int a, int N)
            {
                //Gcd(a^(r/2)+1, N) is a non trivial factor of N.
                Console.WriteLine("Finales a: " + a + " Finales N: " + N);
                int Ntemp = N;
                int p = a + 1;
                int q = a - 1;
                while (N != 0)
                {
                    int tmp = p % N;
                    p = N;
                    N = tmp;
                }
                while (Ntemp != 0)
                {
                    int tmp = q % Ntemp;
                    q = Ntemp;
                    Ntemp = tmp;
                }
                Debug.WriteLine("Private key p: " + p + " and  private key q: " + q + " multiply to the public key: " + N);
            }
           

        }

}
