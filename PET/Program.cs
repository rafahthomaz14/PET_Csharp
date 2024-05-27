using System;
using System.Collections.Generic;

public class Program{
    public static void Main(string[] args){

        Console.WriteLine("Digite o Nome do Cachorro: ");
        string CachorroNome = Console.ReadLine();
        Console.WriteLine("Digite a Cor do Cachorro: ");
        string CachorroCor = Console.ReadLine();
        Console.WriteLine("Digite o Nome do Dono do Cachorro: ");
        string CachorroDono = Console.ReadLine();

        Cachorro cachorro1 = new Cachorro(CachorroNome, CachorroCor, CachorroDono);
        // Limpa todas as informações anteriores do Console 
        Console.Clear();
        
        Console.WriteLine("Digite o Nome do Gato: ");
        string GatoNome = Console.ReadLine();
        Console.WriteLine("Digite a Cor do Gato: ");
        string GatoCor = Console.ReadLine();
        Console.WriteLine("Digite o Nome do Dono do Gato: ");
        string GatoDono = Console.ReadLine();
        
        Gato gato1 = new Gato(GatoNome, GatoCor, GatoDono);
        // Limpa todas as informações anteriores do Console 
        Console.Clear();

        PETSHOP PT1 = new PETSHOP("Unidade-1", "Avenida Brasil 221");
        PT1.animal.Add(gato1);
        PT1.animal.Add(cachorro1);

        Console.WriteLine("Informações PETSHOP:");
        Console.WriteLine("Nome: {0}\nEndereço: {1}", PT1.Nome, PT1.Endereco);
        Console.WriteLine();

        EntradaPonto ponto = new EntradaPonto();

        foreach(Animal animais in PT1.animal){
            ponto.RegistrarEntrada(animais);
            Console.WriteLine("Informações do Animal:");
            animais.INFO();
            animais.EmitirSom();
            ponto.RegistrarSaida(animais);
            Console.WriteLine("");
        }
    }
}

public abstract class Animal{
    public string Nome { get; set; }
    public string Cor { get; set; }

    public Animal(string Nome, string Cor){
        this.Nome = Nome;
        this.Cor = Cor;
    }

    public abstract void EmitirSom();
    public abstract void INFO();
}

public class Gato : Animal{
    public string Dono { get; set; }

    public Gato(string Nome, string Cor, string Dono) : base(Nome, Cor){
        this.Dono = Dono;
    }

    public override void EmitirSom(){
        Console.WriteLine("MIAU MIAU");
    }

    public override void INFO(){
        Console.WriteLine("Nome do Gato: {0}\nCor do Gato: {1}\nNome do Dono: {2}", this.Nome, this.Cor, this.Dono);
    }
}

public class Cachorro : Animal{
    public string Dono { get; set; }

    public Cachorro(string Nome, string Cor, string Dono) : base(Nome, Cor){
        this.Dono = Dono;
    }

    public override void EmitirSom(){
        Console.WriteLine("AU AU");
    }

    public override void INFO(){
        Console.WriteLine("Nome do Cachorro: {0}\nCor do Cachorro: {1}\nNome do Dono: {2}", this.Nome, this.Cor, this.Dono);
    }
}

public class PETSHOP{
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public List<Animal> animal { get; set; }

    public PETSHOP(string Nome, string Endereco){
        this.Nome = Nome;
        this.Endereco = Endereco;
        animal = new List<Animal>();
    }
}

public class EntradaPonto{
    public void RegistrarEntrada(Animal animal){
        GerarComprovante(animal, true);
    }
    public void RegistrarSaida(Animal animal){
        GerarComprovante(animal, false);
    }
    public void GerarComprovante(Animal animal, bool entrada){
        string TipoEntrada = entrada ? "Entrando":"Saindo";
        Console.WriteLine("O {0} esta {1} no dia {2}",animal.GetType().Name,TipoEntrada,DateTime.Now);
    }
}