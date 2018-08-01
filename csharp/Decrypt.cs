using System;

namespace qsharprsa
{
    //class for brute force decryption written in c#
    class Decrypt
    {
        int p=0;
        int q=0;
        public double decryptMessageWithKeys(int d, int n, int msg){
            double temp = Math.Pow(msg, d);
            double result = temp%n;


            return result;
        }
        //not finished/tested yet. prime factorization of n
        //IMPORTANT: We will implement this simple brute force function in q#!
        public int decryptMessageBruteForce(int n, int e ){
            //TODO check for prime numbers before setting the result
            for(int i=2; i<n/2; i++){
                for(int j=2; j<n/2;j++){
                    if(j*i == n){
                        p=i;
                        q=j;
                        break;
                    }
                if(j*i == n){
                        p=i;
                        q=j;
                        break;
                }
                }

            }

            return 1;
        }
    }

}