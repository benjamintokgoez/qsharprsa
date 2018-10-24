namespace qsharp
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Extensions.Math;
    open Microsoft.Quantum.Extensions.Convert;


    //f(a) which is used later as an oracle
    operation oracelExpModFunction(a:Int, N:Int, p:Int, t:Qubit[]) : () {
        body{
            //we use this function as a helper function on the whole register.
            //because of the funtion we have to use the littleendian presentation
            //our function is a^p mod N
            ModularMultiplyByConstantLE(ExpMod(a,p,N), N, LittleEndian(t));
        
        }
        adjoint auto
        controlled auto
        adjoint controlled auto
    
    }




  operation customPhaseEstimation(oracle:DiscreteOracle, target:Qubit[], register:BigEndian) : ()
  {
       body
       {
            let n = Length(register);
            //check if all Qubits in the register are |0>
            //AssertAllZeroTol(register, 1e-06);
            //use Hadamard-transformation on each Qubit in the register

            ApplyToEachCA(H, register);
            
            for(i in 0..(n-1))
            {
            
                let tempQubit = register[i];
              //calculate the current exp
                let k = 2^(n - i - 1);
                (oracle)((k, target));                
            
            }
            //Run QFT on prepared register
            (Adjoint QFT)(register);            
        }
        adjoint auto
        controlled auto
        controlled adjoint auto
    
    }

    operation calculatingPeriod (N : Int, a : Int) : (Int)
    {
        body
        {
            mutable tempResult = 0;
            //set bitSize value for the amount of Qubits in the register.
            let bitSize = BitSize (N);


            //set the Qubit register
            using(register = Qubit[bitSize])
            {
                
                //we set the oracle based on our function U_f
                let oracle = DiscreteOracle(oracelExpModFunction(a, N, _, _));
                let eigenstatesBE = BigEndian(register);
                //didn't work right now
                //let phase = customPhaseEstimation(oracle, register, eigenstatesBE);
                Message("phase is {phase}");



                ResetAll(register);
            
            }

            return 1;
        }
    }

    operation quantumPeriod (N : Int, a : Int) : (Int)
    {
        body
        {            
            //N=p*q
            //a is co prime to N
            //a^k mod N
            if(IsCoprime(a, N)){
                
                Message($"Calculate period of {N} mod {a}");
                let period = calculatingPeriod(N, a);
                
                return period;           
            }
            else{
               
                Message($"{a} is not coprime to {N}. Try a different a");
                
                return 0;
            }

        }
    }


}