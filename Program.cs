using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>
{
    new Suite("standard", 3, 30),
    new Suite("executiva", 3, 200),
    new Suite("premium", 3, 300)
};

bool realizarReserva = true;

while (realizarReserva)
{
    Console.WriteLine("Menu Hotel Plazza");
    Console.WriteLine("Deseja realizar uma reserva: digite 1 para sim 2 para não");
    int resposta = Convert.ToInt32(Console.ReadLine());

    if (resposta == 1)
    {
        Console.WriteLine("Informe o número de pessoas que deseja hospedar:  ");
        int numeroDeHospedes = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        for (int i = 0; i < numeroDeHospedes; i++)
        { 
            Pessoa hospediCadastro = new Pessoa();
            Console.WriteLine($"Digite o nome do hospede {i + 1}");
            string nome = Console.ReadLine();
            hospediCadastro.Nome = nome;
            Console.Clear();
            hospedes.Add(hospediCadastro);
        }

        Console.WriteLine("Digite a suite desejada");

        for (int numero = 0; numero < suites.Count; numero++)
        {
            Console.WriteLine($" Suite {numero + 1} Categoria {suites[numero].TipoSuite}, " + 
                              $"capacidade {suites[numero].Capacidade} " +
                              $"e valor da diária {suites[numero].ValorDiaria}");
        }

        int suiteEscolhida = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("Informe quantos dias de reserva: ");
        int quantidadeDiasReservados = Convert.ToInt32((Console.ReadLine()));
        Console.Clear();

        Reserva reserva = new Reserva(quantidadeDiasReservados);
        reserva.CadastrarSuite(suites[suiteEscolhida - 1]);
        reserva.CadastrarHospedes(hospedes);
        Console.WriteLine("Reversa realizada com sucesso");
        Console.WriteLine("Dados da sua reserva");
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes(hospedes)}");
        realizarReserva = false;
        
        foreach (var hospede in hospedes)
        {
            Console.WriteLine($"Nome: {hospede.Nome}");
        }

        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
        Thread.Sleep(8000);
        Console.Clear();
    }
    else if (resposta == 2)
    {
        Console.WriteLine("Você será redirecionado para o menu principal");
        Thread.Sleep(5000);
        Console.Clear();
    }
    else
    {
        Console.WriteLine("Opção ínvalida você será redirecionado para o menu principal");
    }
}