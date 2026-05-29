using MovieManagement.Business.Services;
using MovieManagement.Data.Repositories;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Enums;
using MovieManagement.Domain.Interfaces;

FilmeRepository repository = new();

FilmeServices service = new(repository);

bool sair = false;

while (!sair)
{
    Console.Clear();

    Console.WriteLine("=== MOVIE MANAGEMENT ===");
    Console.WriteLine("1 - Adicionar Filme");
    Console.WriteLine("2 - Listar Filmes");
    Console.WriteLine("3 - Procurar Filme");
    Console.WriteLine("4 - Remover Filme");
    Console.WriteLine("0 - Sair");

    Console.Write("\nOpção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            AdicionarFilme();
            break;

        case "2":
            ListarFilmes();
            break;

        case "3":
            ProcurarFilme();
            break;

        case "4":
            RemoverFilme();
            break;

        case "0":
            sair = true;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            Console.ReadKey();
            break;
    }
}

void AdicionarFilme()
{
    try
    {
        Console.Clear();

        Console.WriteLine("=== ADICIONAR FILME ===");

        Console.Write("Título: ");
        string? titulo = Console.ReadLine();

        // Regra 1 - Título obrigatório.
        //Adicionei condição para não permitir avançar com campo vazio.
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("\nTítulo inválido.");
            Console.ReadKey();
            return;
        }

        // Regra 2 - Não permitir títulos duplicados
        //Desta forma, no caso de inserirmos um filme que já exista na lista, aparece logo o erro "Titulo inválido" sem pedir os restantes dados do menu.
        //Sem termos que introduzir os dados até ao fim.
        if (service.Procurar(titulo) != null)
        {
            Console.WriteLine("\nTítulo inválido. Já existe um filme com esse título.");
            Console.ReadKey();
            return;
        }

        Console.Write("Ano: ");
        int ano = int.Parse(Console.ReadLine()!);

        Console.Write("Língua: ");
        string? lingua = Console.ReadLine();

        Console.WriteLine("\nClassificação:");

        foreach (ClassificacaoFilme classificacao in Enum.GetValues(typeof(ClassificacaoFilme)))
        {
            Console.WriteLine($"{(int)classificacao} - {classificacao}");
        }

        Console.Write("\nEscolha: ");

        ClassificacaoFilme classificacaoEscolhida =
            (ClassificacaoFilme)int.Parse(Console.ReadLine()!);

        Filme filme = new()
        {
            Titulo = titulo!,
            Ano = ano,
            Lingua = lingua!,
            Classificacao = classificacaoEscolhida
        };

        service.Adicionar(filme);

        Console.WriteLine("\nFilme adicionado com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }

    Console.ReadKey();
}

void ListarFilmes()
{
    Console.Clear();

    Console.WriteLine("=== LISTA DE FILMES ===\n");

    List<Filme> filmes = service.ObterTodos();

    if (filmes.Count == 0)
    {
        Console.WriteLine("Não existem filmes registados.");
    }
    else
    {
        foreach (Filme filme in filmes)
        {
            Console.WriteLine(
                $"Id: {filme.Id} | " +
                $"Título: {filme.Titulo} | " +
                $"Ano: {filme.Ano} | " +
                $"Língua: {filme.Lingua} | " +
                $"Classificação: {filme.Classificacao}");
        }
    }

    Console.ReadKey();
}

void ProcurarFilme()
{
    Console.Clear();

    Console.WriteLine("=== PROCURAR FILME ===");

    Console.Write("Título: ");

    string? titulo = Console.ReadLine();

    Filme? filme = service.Procurar(titulo!);

    if (filme == null)
    {
        Console.WriteLine("\nFilme não encontrado.");
    }
    else
    {
        Console.WriteLine("\nFilme encontrado:");

        Console.WriteLine(
            $"Id: {filme.Id}\n" +
            $"Título: {filme.Titulo}\n" +
            $"Ano: {filme.Ano}\n" +
            $"Língua: {filme.Lingua}\n" +
            $"Classificação: {filme.Classificacao}");
    }

    Console.ReadKey();
}

void RemoverFilme()
{
    Console.Clear();

    Console.WriteLine("=== REMOVER FILME ===");

    Console.Write("Id do filme: ");

    int id = int.Parse(Console.ReadLine()!);

    bool removido = service.Remover(id);

    if (removido)
    {
        Console.WriteLine("\nFilme removido com sucesso.");
    }
    else
    {
        Console.WriteLine("\nFilme não encontrado.");
    }

    Console.ReadKey();
}