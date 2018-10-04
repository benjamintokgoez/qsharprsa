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
            //a^k mod N
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
    // transform as a^p*k mod N
    operation vectorTransformation( a:Int, N:Int, p:Int , t:Qubit[] ) : () {
        body {
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
            let bitSize = BitSize (N);
            let bitEstimated = 2*bitSize +1;
            mutable temp = 0;

            using(eigenStates = Qubit[bitSize])
            {
                
                let eigenStatesLE = LittleEndian(eigenStates);
                InPlaceXorLE(1, eigenStatesLE);
                
                Message($"The bitSize of {N} is {bitSize}");

                let transformation = DiscreteOracle(vectorTransformation(a, N, _ , _ ));
                let phase = RobustPhaseEstimation(bitEstimated, transformation, eigenStatesLE);
                set temp = Round(phase * ToDouble(2^bitEstimated)/2.0/PI());
                
                //reset all Qubits to save RAM
                ResetAll(eigenStates);
            }              

            let (k, d) = ContinuedFractionConvergent(Fraction(temp, 2^(bitEstimated)), N);
            let (kAbs, dAbs) = (AbsI(k), AbsI(d));
            set tempResult = dAbs * tempResult / GCD(tempResult, dAbs); 
            
            Message($"Q#: The Period of {a} mod {N} is {tempResult}");

            return tempResult;
        }
    }
}
