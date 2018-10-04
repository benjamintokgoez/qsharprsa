#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("qsharp", "shorsPeriod (N : Int, a : Int) : Int", new string[] { }, "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs", 248L, 9L, 5L)]
[assembly: OperationDeclaration("qsharp", "vectorTransformation (a : Int, N : Int, p : Int, t : Qubit[]) : ()", new string[] { "Controlled", "Adjoint" }, "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs", 918L, 34L, 76L)]
[assembly: OperationDeclaration("qsharp", "findingPeriod (N : Int, a : Int) : Int", new string[] { }, "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs", 1220L, 46L, 5L)]
#line hidden
namespace qsharp
{
    public class shorsPeriod : Operation<(Int64,Int64), Int64>, ICallable
    {
        public shorsPeriod(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64)>, IApplyData
        {
            public In((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "shorsPeriod";
        String ICallable.FullName => "qsharp.shorsPeriod";
        protected ICallable<(Int64,Int64), Boolean> MicrosoftQuantumCanonIsCoprime
        {
            get;
            set;
        }

        protected ICallable<String, QVoid> Message
        {
            get;
            set;
        }

        protected ICallable<(Int64,Int64), Int64> findingPeriod
        {
            get;
            set;
        }

        public override Func<(Int64,Int64), Int64> Body => (__in) =>
        {
            var (N,a) = __in;
            //N=p*q
            //a is co prime to N
            //a^k mod N
#line 17 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            if (MicrosoftQuantumCanonIsCoprime.Apply((a, N)))
            {
#line 18 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                Message.Apply($"Calculate period of {N} mod {a}");
#line 19 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                var period = findingPeriod.Apply((N, a));
#line 21 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                return period;
            }
            else
            {
#line 24 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                Message.Apply($"{a} is not coprime to {N}. Try a different a");
#line 25 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                return 0L;
            }

#line 30 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            return 0L;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonIsCoprime = this.Factory.Get<ICallable<(Int64,Int64), Boolean>>(typeof(Microsoft.Quantum.Canon.IsCoprime));
            this.Message = this.Factory.Get<ICallable<String, QVoid>>(typeof(Microsoft.Quantum.Primitive.Message));
            this.findingPeriod = this.Factory.Get<ICallable<(Int64,Int64), Int64>>(typeof(qsharp.findingPeriod));
        }

        public override IApplyData __dataIn((Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 N, Int64 a)
        {
            return __m__.Run<shorsPeriod, (Int64,Int64), Int64>((N, a));
        }
    }

    public class vectorTransformation : Unitary<(Int64,Int64,Int64,QArray<Qubit>)>, ICallable
    {
        public vectorTransformation(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64,Int64,QArray<Qubit>)>, IApplyData
        {
            public In((Int64,Int64,Int64,QArray<Qubit>) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => ((IApplyData)Data.Item4)?.Qubits;
        }

        String ICallable.Name => "vectorTransformation";
        String ICallable.FullName => "qsharp.vectorTransformation";
        protected ICallable<(Int64,Int64,Int64), Int64> MicrosoftQuantumCanonExpMod
        {
            get;
            set;
        }

        protected IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)> MicrosoftQuantumCanonModularMultiplyByConstantLE
        {
            get;
            set;
        }

        public override Func<(Int64,Int64,Int64,QArray<Qubit>), QVoid> Body => (__in) =>
        {
            var (a,N,p,t) = __in;
#line 36 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Apply((MicrosoftQuantumCanonExpMod.Apply((a, p, N)), N, new Microsoft.Quantum.Canon.LittleEndian(t)));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(Int64,Int64,Int64,QArray<Qubit>), QVoid> AdjointBody => (__in) =>
        {
            var (a,N,p,t) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Adjoint.Apply((MicrosoftQuantumCanonExpMod.Apply((a, p, N)), N, new Microsoft.Quantum.Canon.LittleEndian(t)));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,(Int64,Int64,Int64,QArray<Qubit>)), QVoid> ControlledBody => (__in) =>
        {
            var (controlQubits,(a,N,p,t)) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Controlled.Apply((controlQubits, (MicrosoftQuantumCanonExpMod.Apply((a, p, N)), N, new Microsoft.Quantum.Canon.LittleEndian(t))));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,(Int64,Int64,Int64,QArray<Qubit>)), QVoid> ControlledAdjointBody => (__in) =>
        {
            var (controlQubits,(a,N,p,t)) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Adjoint.Controlled.Apply((controlQubits, (MicrosoftQuantumCanonExpMod.Apply((a, p, N)), N, new Microsoft.Quantum.Canon.LittleEndian(t))));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonExpMod = this.Factory.Get<ICallable<(Int64,Int64,Int64), Int64>>(typeof(Microsoft.Quantum.Canon.ExpMod));
            this.MicrosoftQuantumCanonModularMultiplyByConstantLE = this.Factory.Get<IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)>>(typeof(Microsoft.Quantum.Canon.ModularMultiplyByConstantLE));
        }

        public override IApplyData __dataIn((Int64,Int64,Int64,QArray<Qubit>) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Int64 a, Int64 N, Int64 p, QArray<Qubit> t)
        {
            return __m__.Run<vectorTransformation, (Int64,Int64,Int64,QArray<Qubit>), QVoid>((a, N, p, t));
        }
    }

    public class findingPeriod : Operation<(Int64,Int64), Int64>, ICallable
    {
        public findingPeriod(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64)>, IApplyData
        {
            public In((Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "findingPeriod";
        String ICallable.FullName => "qsharp.findingPeriod";
        protected ICallable<Int64, Int64> MicrosoftQuantumExtensionsMathAbsI
        {
            get;
            set;
        }

        protected Allocate Allocate
        {
            get;
            set;
        }

        protected ICallable<Int64, Int64> MicrosoftQuantumCanonBitSize
        {
            get;
            set;
        }

        protected ICallable<(Microsoft.Quantum.Canon.Fraction,Int64), Microsoft.Quantum.Canon.Fraction> MicrosoftQuantumCanonContinuedFractionConvergent
        {
            get;
            set;
        }

        protected ICallable<(Int64,Int64), Int64> MicrosoftQuantumCanonGCD
        {
            get;
            set;
        }

        protected IUnitary<(Int64,Microsoft.Quantum.Canon.LittleEndian)> MicrosoftQuantumCanonInPlaceXorLE
        {
            get;
            set;
        }

        protected ICallable<String, QVoid> Message
        {
            get;
            set;
        }

        protected ICallable<QVoid, Double> MicrosoftQuantumExtensionsMathPI
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get;
            set;
        }

        protected ICallable<(Int64,IUnitary,QArray<Qubit>), Double> MicrosoftQuantumCanonRobustPhaseEstimation
        {
            get;
            set;
        }

        protected ICallable<Double, Int64> MicrosoftQuantumExtensionsMathRound
        {
            get;
            set;
        }

        protected ICallable<Int64, Double> MicrosoftQuantumExtensionsConvertToDouble
        {
            get;
            set;
        }

        protected IUnitary<(Int64,Int64,Int64,QArray<Qubit>)> vectorTransformation
        {
            get;
            set;
        }

        public override Func<(Int64,Int64), Int64> Body => (__in) =>
        {
            var (N,a) = __in;
#line 51 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var tempResult = 1L;
#line 53 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var bitSize = MicrosoftQuantumCanonBitSize.Apply(N);
#line 54 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var bitEstimated = ((2L * bitSize) + 1L);
#line 57 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var temp = 0L;
#line 59 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var eigenStates = Allocate.Apply(bitSize);
#line 62 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var eigenStatesLE = new Microsoft.Quantum.Canon.LittleEndian(eigenStates);
#line 63 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            MicrosoftQuantumCanonInPlaceXorLE.Apply((1L, eigenStatesLE));
#line 65 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            Message.Apply($"The bitSize of {N} is {bitSize}");
#line 67 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var transformation = new Microsoft.Quantum.Canon.DiscreteOracle(vectorTransformation.Partial(new Func<(Int64,QArray<Qubit>), (Int64,Int64,Int64,QArray<Qubit>)>((_arg1) => (a, N, _arg1.Item1, _arg1.Item2))));
#line 69 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var phase = MicrosoftQuantumCanonRobustPhaseEstimation.Apply((bitEstimated, transformation, eigenStatesLE));
#line 71 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            temp = MicrosoftQuantumExtensionsMathRound.Apply((((phase * MicrosoftQuantumExtensionsConvertToDouble.Apply(2L.Pow(bitEstimated))) / 2D) / MicrosoftQuantumExtensionsMathPI.Apply(QVoid.Instance)));
            //reset all Qubits to save RAM
#line 73 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            ResetAll.Apply(eigenStates);
#line hidden
            Release.Apply(eigenStates);
#line 76 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var (k,d) = MicrosoftQuantumCanonContinuedFractionConvergent.Apply((new Microsoft.Quantum.Canon.Fraction((temp, 2L.Pow(bitEstimated))), N));
#line 77 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var (kAbs,dAbs) = (MicrosoftQuantumExtensionsMathAbsI.Apply(k), MicrosoftQuantumExtensionsMathAbsI.Apply(d));
#line 79 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            tempResult = ((dAbs * tempResult) / MicrosoftQuantumCanonGCD.Apply((tempResult, dAbs)));
#line 80 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            Message.Apply($"Q#: The Period of {a} mod {N} is {tempResult}");
#line 82 "C:\\Users\\benja\\Documents\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            return tempResult;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumExtensionsMathAbsI = this.Factory.Get<ICallable<Int64, Int64>>(typeof(Microsoft.Quantum.Extensions.Math.AbsI));
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumCanonBitSize = this.Factory.Get<ICallable<Int64, Int64>>(typeof(Microsoft.Quantum.Canon.BitSize));
            this.MicrosoftQuantumCanonContinuedFractionConvergent = this.Factory.Get<ICallable<(Microsoft.Quantum.Canon.Fraction,Int64), Microsoft.Quantum.Canon.Fraction>>(typeof(Microsoft.Quantum.Canon.ContinuedFractionConvergent));
            this.MicrosoftQuantumCanonGCD = this.Factory.Get<ICallable<(Int64,Int64), Int64>>(typeof(Microsoft.Quantum.Canon.GCD));
            this.MicrosoftQuantumCanonInPlaceXorLE = this.Factory.Get<IUnitary<(Int64,Microsoft.Quantum.Canon.LittleEndian)>>(typeof(Microsoft.Quantum.Canon.InPlaceXorLE));
            this.Message = this.Factory.Get<ICallable<String, QVoid>>(typeof(Microsoft.Quantum.Primitive.Message));
            this.MicrosoftQuantumExtensionsMathPI = this.Factory.Get<ICallable<QVoid, Double>>(typeof(Microsoft.Quantum.Extensions.Math.PI));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.ResetAll = this.Factory.Get<ICallable<QArray<Qubit>, QVoid>>(typeof(Microsoft.Quantum.Primitive.ResetAll));
            this.MicrosoftQuantumCanonRobustPhaseEstimation = this.Factory.Get<ICallable<(Int64,IUnitary,QArray<Qubit>), Double>>(typeof(Microsoft.Quantum.Canon.RobustPhaseEstimation));
            this.MicrosoftQuantumExtensionsMathRound = this.Factory.Get<ICallable<Double, Int64>>(typeof(Microsoft.Quantum.Extensions.Math.Round));
            this.MicrosoftQuantumExtensionsConvertToDouble = this.Factory.Get<ICallable<Int64, Double>>(typeof(Microsoft.Quantum.Extensions.Convert.ToDouble));
            this.vectorTransformation = this.Factory.Get<IUnitary<(Int64,Int64,Int64,QArray<Qubit>)>>(typeof(qsharp.vectorTransformation));
        }

        public override IApplyData __dataIn((Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 N, Int64 a)
        {
            return __m__.Run<findingPeriod, (Int64,Int64), Int64>((N, a));
        }
    }
}