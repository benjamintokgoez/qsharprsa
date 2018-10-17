using System;

namespace qsharprsa
{
    //class for brute force decryption written in c#
    class Decrypt
    {
        int p=0;
        int q=0;
        //not finished/tested yet. prime factorization of n
        //actually we are finding the factors of n
        //IMPORTANT: We will implement this simple brute force function in q# via Shor's algorithm
        public int decryptMessageKeyBruteForce(int n){
            for(int i=2; i<n/2+1; i++){
                for(int j=2; j<n/2+1;j++){
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