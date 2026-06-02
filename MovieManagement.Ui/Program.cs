using MovieManagement.Business.Services;
using MovieManagement.Data.Repositories;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Enums;
using MovieManagement.Domain.Interfaces;

//Filmes:
FilmeRepository repository = new();
FilmeServices service = new(repository);

//Categorias:
CategoriaRepository categoriaRepository = new();
CategoriaService categoriaService = new(categoriaRepository);

//Realizadores:
RealizadorRepository realizadorRepository = new();
RealizadorService realizadorService = new(realizadorRepository);


bool sair = false;

while (!sair)
{
    Console.Clear();

    Console.WriteLine("=== MOVIE MANAGEMENT ===");
    Console.WriteLine("1 - Adicionar Filme");
    Console.WriteLine("2 - Listar Filmes");
    Console.WriteLine("3 - Procurar Filme");
    Console.WriteLine("4 - Remover Filme");
    Console.WriteLine("");
    Console.WriteLine("=== CATEGORIAS ===");
    Console.WriteLine("5 - Adicionar Categoria");
    Console.WriteLine("6 - Listar Categorias");
    Console.WriteLine("7 - Procurar Categoria");
    Console.WriteLine("8 - Remover Categoria");
    Console.WriteLine("");
    Console.WriteLine("=== REALIZADORES ===");
    Console.WriteLine("9 - Adicionar Realizador");
    Console.WriteLine("10 - Listar Realizadores");
    Console.WriteLine("11 - Procurar Realizador");
    Console.WriteLine("12 - Remover Realizador");
    Console.WriteLine("");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("");
    Console.Write("Opção: ");

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

        case "5":
            AdicionarCategoria();
            break;

        case "6":
            ListarCategorias();
            break;

        case "7":
            ProcurarCategoria();
            break;

        case "8":
            RemoverCategoria();
            break;

        case "9":
            AdicionarRealizador();
            break;

        case "10":
            ListarRealizadores();
            break;

        case "11":
            ProcurarRealizador();
            break;

        case "12":
            RemoverRealizador();
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

        ClassificacaoFilme classificacaoEscolhida = (ClassificacaoFilme)int.Parse(Console.ReadLine()!);

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
            Console.WriteLine($"Id: {filme.Id} | " + $"Título: {filme.Titulo} | " + $"Ano: {filme.Ano} | " + $"Língua: {filme.Lingua} | " + $"Classificação: {filme.Classificacao}");
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

        Console.WriteLine($"Id: {filme.Id}\n" + $"Título: {filme.Titulo}\n" + $"Ano: {filme.Ano}\n" + $"Língua: {filme.Lingua}\n" + $"Classificação: {filme.Classificacao}");
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

void AdicionarCategoria()
{
    try
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR CATEGORIA ===");
        Console.Write("Nome: ");
        string? nome = Console.ReadLine();


        if (string.IsNullOrWhiteSpace(nome)) // Nome obrigatório
        {
            Console.WriteLine("\nO nome da categoria é obrigatório.");
            Console.ReadKey();
            return;
        }

        if (categoriaService.Procurar(nome) != null) // Não permitir categorias duplicadas
        {
            Console.WriteLine("\nJá existe uma categoria com esse nome.");
            Console.ReadKey();
            return;
        }


        Categoria categoria = new()
        {
            Nome = nome!
        };

        categoriaService.Adicionar(categoria);

        Console.WriteLine("\nCategoria adicionada com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }

    Console.ReadKey();
}

void ListarCategorias()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE CATEGORIAS ===\n");

    List<Categoria> categorias = categoriaService.ObterTodos();

    if (categorias.Count == 0)
    {
        Console.WriteLine("Não existem categorias registadas.");
    }
    else
    {
        foreach (Categoria categoria in categorias)
        {
            Console.WriteLine($"Id: {categoria.Id} | " + $"Nome: {categoria.Nome}");
        }
    }

    Console.ReadKey();
}

void ProcurarCategoria()
{
    Console.Clear();
    Console.WriteLine("=== PROCURAR CATEGORIA ===");
    Console.Write("Nome: ");
    string? nome = Console.ReadLine();

    Categoria? categoria = categoriaService.Procurar(nome!);

    if (categoria == null)
    {
        Console.WriteLine("\nCategoria não encontrada.");
    }
    else
    {
        Console.WriteLine("\nCategoria encontrada:");

        Console.WriteLine($"Id: {categoria.Id}\n" + $"Nome: {categoria.Nome}");
    }

    Console.ReadKey();
}

void RemoverCategoria()
{
    Console.Clear();
    Console.WriteLine("=== REMOVER CATEGORIA ===");
    Console.Write("Id da categoria: ");
    int id = int.Parse(Console.ReadLine()!);
    bool removida = categoriaService.Remover(id);

    if (removida)
    {
        Console.WriteLine("\nCategoria removida com sucesso.");
    }
    else
    {
        Console.WriteLine("\nCategoria não encontrada.");
    }

    Console.ReadKey();
}

void AdicionarRealizador()
{
    try
    {
        Console.Clear();
        Console.WriteLine("=== ADICIONAR REALIZADOR ===");
        Console.Write("Nome: ");
        string? nome = Console.ReadLine();

        // Nome obrigatório. 
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("\nO nome do realizador é obrigatório.");
            Console.ReadKey();
            return;
        }

        // Não permitir realizadores duplicados
        if (realizadorService.Procurar(nome) != null)
        {
            Console.WriteLine("\nJá existe um realizador com esse nome.");
            Console.ReadKey();
            return;
        }

        Console.Write("País: ");
        string? pais = Console.ReadLine();

        Realizador realizador = new()
        {
            Nome = nome!,
            Pais = pais!
        };

        realizadorService.Adicionar(realizador);
        Console.WriteLine("\nRealizador adicionado com sucesso.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
    }

    Console.ReadKey();
}

void ListarRealizadores()
{
    Console.Clear();
    Console.WriteLine("=== LISTA DE REALIZADORES ===\n");
    List<Realizador> realizadores = realizadorService.ObterTodos();

    if (realizadores.Count == 0)
    {
        Console.WriteLine("Não existem realizadores registados.");
    }
    else
    {
        foreach (Realizador realizador in realizadores)
        {
            Console.WriteLine($"Id: {realizador.Id} | " + $"Nome: {realizador.Nome} | " + $"País: {realizador.Pais}");
        }
    }

    Console.ReadKey();
}

void ProcurarRealizador()
{
    Console.Clear();
    Console.WriteLine("=== PROCURAR REALIZADOR ===");
    Console.Write("Nome: ");
    string? nome = Console.ReadLine();
    Realizador? realizador = realizadorService.Procurar(nome!);

    if (realizador == null)
    {
        Console.WriteLine("\nRealizador não encontrado.");
    }
    else
    {
        Console.WriteLine("\nRealizador encontrado:");

        Console.WriteLine($"Id: {realizador.Id}\n" + $"Nome: {realizador.Nome}\n" + $"País: {realizador.Pais}");
    }

    Console.ReadKey();
}


void RemoverRealizador()
{
    Console.Clear();
    Console.WriteLine("=== REMOVER REALIZADOR ===");
    Console.Write("Id do realizador: ");
    int id = int.Parse(Console.ReadLine()!);
    bool removido = realizadorService.Remover(id);

    if (removido)
    {
        Console.WriteLine("\nRealizador removido com sucesso.");
    }
    else
    {
        Console.WriteLine("\nRealizador não encontrado.");
    }

    Console.ReadKey();
}

