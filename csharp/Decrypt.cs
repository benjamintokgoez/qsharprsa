using System;

namespace qsharprsa
{
    //class for brute force decryption written in c#
    class Decrypt
    {
    
        public double decryptMessage(int d, int n, int msg){
            double temp = Math.Pow(msg, d);
            double result = temp%n;


            return result;
        }
    }

}