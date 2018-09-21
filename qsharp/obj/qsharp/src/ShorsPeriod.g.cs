#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("qsharp", "shorsPeriod (N : Int, a : Int) : Int", new string[] { }, "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs", 155L, 7L, 5L)]
[assembly: OperationDeclaration("qsharp", "findingPeriod (N : Int, a : Int) : Int", new string[] { }, "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs", 758L, 36L, 5L)]
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
#line 15 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            if (MicrosoftQuantumCanonIsCoprime.Apply((a, N)))
            {
#line 16 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                var period = findingPeriod.Apply((N, a));
#line 18 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                return period;
            }
            else
            {
#line 23 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                Message.Apply($"{a} is not coprime to {N}. Try a different a");
#line 24 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
                return 0L;
            }

#line 29 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
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
        protected ICallable<Int64, Int64> MicrosoftQuantumCanonBitSize
        {
            get;
            set;
        }

        protected ICallable<String, QVoid> Message
        {
            get;
            set;
        }

        public override Func<(Int64,Int64), Int64> Body => (__in) =>
        {
            var (N,a) = __in;
#line 41 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var tempResult = 1L;
#line 43 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var bitSize = MicrosoftQuantumCanonBitSize.Apply(N);
#line 44 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            var bitEstimated = ((2L * bitSize) + 1L);
            // repeat
            //{
            //   mutable temp = 0;
            // using(eigenStates = Qubit[bitSize])
            //{
            //   let eigenStatesLE = LittleEndian(eigenStates);
            //  InPlaceXorLE(1, eigenStatesLE);
#line 55 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            Message.Apply($"The bitSize of {N} is {bitSize}");
#line 57 "C:\\Users\\betokgz\\Documents\\QuantumProjects\\qsharprsa\\qsharp\\ShorsPeriod.qs"
            return 0L;
            //}
            //}
            ;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonBitSize = this.Factory.Get<ICallable<Int64, Int64>>(typeof(Microsoft.Quantum.Canon.BitSize));
            this.Message = this.Factory.Get<ICallable<String, QVoid>>(typeof(Microsoft.Quantum.Primitive.Message));
        }

        public override IApplyData __dataIn((Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 N, Int64 a)
        {
            return __m__.Run<findingPeriod, (Int64,Int64), Int64>((N, a));
        }
    }
}