using System;


namespace qsharprsa
{

class Encrypt{

public void encryptRSA(double p, double q, double e, double msg){
    double n = p*q;
    double totient = (p-1) * (q-1);

    while(e<totient){
    double count = gcd((int) e,(int) totient);
    if(count == 1)
        break;
    else
        e++;
    }

    double k = 2;
    double d = (1+ (k*totient))/e;
    double c = Math.Pow(msg,e);
    double m = Math.Pow(c,d);
    c= c % n;


    Console.WriteLine(msg + " original message");
    Console.WriteLine(c + " encrypted message");

}

private int gcd(int a, int h){
    int temp = 0;
    while(true){
        temp = a%h;
        if(temp == 0){
            return h;
        }
        a = h;
        h = temp;
    }
}    
}
}