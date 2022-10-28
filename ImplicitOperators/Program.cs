////Nesse caso, a conversão implícita é aceita porque o INT também é um DOUBLE
//int x = 100;
//double y = x;

////A única maneira do Y receber o valor de X, é explicitando o tipo antes da variável
//double x = 100.5;
//int y = (int)x;

//var telefone = new Telefone
//{
//    CodigoPais = "55",
//    Area = "31",
//    Numero = "999999999"
//};

//var telefoneString = "123";
////O objeto String está recebendo o valor de um objeto Telefone, porque existe na classe, um método Implicit Operator que transforma o objeto Telefone em String
//telefoneString = telefone;
//Console.WriteLine(telefoneString);

var telefone = new Telefone();
//O objeto Telefone está recebendo uma String, e através do Implicit Operators, transforma essa String em Telefone
telefone = "55 31 999999999";
//O WriteLine imprime uma String, e apesar do ToString nativo da classe, o Implicit Operators String sobrescreve este método nativo, transformando novamente o objeto
Console.WriteLine(telefone);

public class Telefone
{
    public string CodigoPais { get; set; }
    public string Area { get; set; }
    public string Numero { get; set; }

    //public override string ToString() => 
    //    $"+{CodigoPais} ({Area}) {Numero.Substring(0, 5)}-{Numero.Substring(5, 4)}";
    
    public static implicit operator string(Telefone telefone) =>
        $"+{telefone.CodigoPais} " +
        $"({telefone.Area}) " +
        $"{telefone.Numero.Substring(0, 5)}-" +
        $"{telefone.Numero.Substring(5, 4)}";

    public static implicit operator Telefone(string telefone)
    {
        var result = telefone.Split(" ");
        return new Telefone
        {
            CodigoPais = result[0],
            Area = result[1],
            Numero = result[2]
        };
    }
}