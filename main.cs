using System;
using System.IO;

class MainClass {
  public static void Main (string[] args) {

    Conta c = new Conta();
    c.numero = 1;
    c.titular = "victor";
    c.saldo = 100;

    Conta d = new Conta();
    d.numero = 2;
    d.titular = "beth";
    d.saldo = 200;

    c.Criar();
    d.Criar();

    if ( c.Recuperar( 1 ) )
      Console.WriteLine("{0}\n{1}\n{2}",
                        c.numero, 
                        c.titular, 
                        c.saldo);
    else
      Console.WriteLine("Conta Não Encontrada");

    if ( d.Deletar() )
      Console.WriteLine("Conta Deletada");
    else
      Console.WriteLine("Conta Não Encontrada");

    if( c.Saca(100.0) )
    {
      Console.WriteLine("Saque realizado com sucesso");
      c.Atualizar();
    }
    else
    {
      Console.WriteLine("Saldo Insuficiente");
    }

  }
}