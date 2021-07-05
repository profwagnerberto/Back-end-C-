using System.IO;

class Conta
{
  // numero, titular e saldo são atributos do objeto
  public int numero;
  public string titular;
  public double saldo;

  public void Criar(){
    StreamWriter sw = new StreamWriter("dados/Conta.dat",true);
    string linha;
    linha = "{0,5},{1,-20},{2,9:F2},";
    sw.WriteLine(linha,this.numero, this.titular, this.saldo);
    sw.Close();
  }

  public bool Recuperar(int valorProcurado){
    int chave;
    bool ehFimDoArquivo = false;
    bool foiEncontrado = false;
    string linha;
    string stringTmp;
    double doubleTmp;
    StreamReader sr = new StreamReader("dados/Conta.dat");
    do {
      linha = sr.ReadLine();
      if ( linha == null ) 
        ehFimDoArquivo = true;
      else{
        stringTmp = linha.Substring(0,5);
        chave = int.Parse(stringTmp);
        if ( valorProcurado == chave ) {
          foiEncontrado = true;
          stringTmp = linha.Substring(6,20);
          doubleTmp = double.Parse(linha.Substring(27,9));
          this.numero = chave;
          this.titular = stringTmp;
          this.saldo = doubleTmp;
        }
      }
    } while ( !ehFimDoArquivo && !foiEncontrado );
    sr.Close();
    return foiEncontrado;
  }

  public bool Deletar(){
    int chave;
    bool ehFimDoArquivo = false;
    bool foiEncontrado = false;
    string linha;
    string stringTmp;
    StreamWriter sw = new StreamWriter("dados/Temp.dat",false);
    StreamReader sr = new StreamReader("dados/Conta.dat");
    do {
      linha = sr.ReadLine();
      if ( linha == null ) 
        ehFimDoArquivo = true;
      else{
        stringTmp = linha.Substring(0,5);
        chave = int.Parse(stringTmp);
        if ( this.numero != chave ) {
          sw.WriteLine(linha);
        }
        else
          foiEncontrado = true;
      }
    } while ( !ehFimDoArquivo );
    sr.Close();
    sw.Close();
    File.Delete("dados/Conta.dat");
    File.Move("dados/Temp.dat", "dados/Conta.dat");
    return foiEncontrado;
  }

}