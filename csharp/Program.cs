using System;

namespace qsharprsa
{
    class Program
    {
        static void Main(string[] args)
        {
           //run RSA encrypt function
           Encrypt e = new Encrypt();
           e.encryptRSA(3,7,2,11);


        }
    }
}
