namespace qsharp
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Extensions.Math;
    open Microsoft.Quantum.Extensions.Convert;

    operation shorsPeriod (N : Int, a : Int) : (Int)
    {
        body
        {            
            //N=p*q
            //a is co prime to N
            if(IsCoprime(a, N)){
                
                Message($"Calculate period of {N} mod {a}");
                let period = findingPeriod(N, a);
                
                return period;           
            }
            else{
               
                Message($"{a} is not coprime to {N}. Try a different a");
                
                return 0;
            }

            return 0;
        }
    }
    // craete an oracle helper function
    operation oracleExpModFunction( a:Int, N:Int, p:Int , t:Qubit[] ) : () {
        body {
            //we use this function as a helper function on the whole register.
            //because of the funtion we have to use the littleendian presentation
            //our function is a^p mod N
            ModularMultiplyByConstantLE(ExpMod(a,p,N),N,LittleEndian(t));
        }
        adjoint auto
        controlled auto
        adjoint controlled auto
    }


    //Actual function for finding the period
    operation findingPeriod (N : Int, a : Int) : (Int)
    {
        body
        {
            mutable tempResult = 1;
            //set bitSize value for the amount of Qubits in the register.
            let bitSize = BitSize (N);
            let bitEstimated = 2*bitSize +1;
            mutable temp = 0;

            //set the Qubit register
            using(eigenStates = Qubit[bitSize])
            {
                
                let eigenStatesLE = LittleEndian(eigenStates);
                InPlaceXorLE(1, eigenStatesLE);
                
                Message($"The bitSize of {N} is {bitSize}");

                //we set the oracle based on our function U_f
                let oracle = DiscreteOracle(oracleExpModFunction(a, N, _ , _ ));
                //this call performs the phase estimation
                //set register to 0
                //use the Hadamard function to the Qubits
                //use the oracle U_f based on the function a mod N as a blackbox
                //perform a quantum fourier transformation
                //
                let phase = RobustPhaseEstimation(bitEstimated, oracle, eigenStatesLE);
                set temp = Round(phase * ToDouble(2^bitEstimated)/2.0/PI());
                
                //reset all Qubits to save RAM
                ResetAll(eigenStates);
            }              
            //transform the output of the QFT to get the actual period
            let (k, d) = ContinuedFractionConvergent(Fraction(temp, 2^(bitEstimated)), N);
            let (kAbs, dAbs) = (AbsI(k), AbsI(d));
            set tempResult = dAbs * tempResult / GCD(tempResult, dAbs); 
            
            Message($"Q#: The Period of {a} mod {N} is {tempResult}");

            return tempResult;
        }
    }
}
