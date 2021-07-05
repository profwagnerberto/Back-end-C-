using System;
using System.IO;

class MainClass {
  public static void Main (string[] args) {

    Conta c = new Conta();
    c.numero = 1;
    c.titular = "victor";
    c.saldo = 100;

    StreamWriter sw = new StreamWriter("dados/Conta.dat",true);
    sw.WriteLine("{0,5},{1,-20},{2,9:F2},", 
                  c.numero, c.titular, c.saldo);
    sw.Close();

  }
}