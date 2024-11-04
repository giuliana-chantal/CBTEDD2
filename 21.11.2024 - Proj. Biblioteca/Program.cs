using System;

class Program
{
    static void Main()
    {
        Livros biblioteca = new Livros();
        int opcao;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    AdicionarLivro(biblioteca);
                    break;
                case 2:
                    PesquisarLivroSintetico(biblioteca);
                    break;
                case 3:
                    PesquisarLivroAnalitico(biblioteca);
                    break;
                case 4:
                    AdicionarExemplar(biblioteca);
                    break;
                case 5:
                    RegistrarEmprestimo(biblioteca);
                    break;
                case 6:
                    RegistrarDevolucao(biblioteca);
                    break;
            }
        } while (opcao != 0);
    }

    static void AdicionarLivro(Livros biblioteca)
    {
        Console.Write("ISBN: ");
        int isbn = int.Parse(Console.ReadLine());
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        Console.Write("Editora: ");
        string editora = Console.ReadLine();

        Livro livro = new Livro(isbn, titulo, autor, editora);
        biblioteca.adicionar(livro);
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    static void PesquisarLivroSintetico(Livros biblioteca)
    {
        Console.Write("Informe o ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Livro livro = biblioteca.pesquisar(isbn);
        
        if (livro != null)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Total Exemplares: {livro.qtdeExemplares()}, Disponíveis: {livro.qtdeDisponiveis()}, Emprestimos: {livro.qtdeEmprestimos()}, % Disponibilidade: {livro.percDisponibilidade()}%");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void PesquisarLivroAnalitico(Livros biblioteca)
    {
        Console.Write("Informe o ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Livro livro = biblioteca.pesquisar(isbn);

        if (livro != null)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Total Exemplares: {livro.qtdeExemplares()}, Disponíveis: {livro.qtdeDisponiveis()}, Emprestimos: {livro.qtdeEmprestimos()}, % Disponibilidade: {livro.percDisponibilidade()}%");
            foreach (var exemplar in livro.Exemplares)
            {
                Console.WriteLine($"Exemplar Tombo: {exemplar.Tombo}, Disponível: {exemplar.disponivel()}, Empréstimos: {exemplar.qtdeEmprestimos()}");
            }
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void AdicionarExemplar(Livros biblioteca)
    {
        Console.Write("Informe o ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Livro livro = biblioteca.pesquisar(isbn);

        if (livro != null)
        {
            Exemplar exemplar = new Exemplar();
            livro.adicionarExemplar(exemplar);
            Console.WriteLine("Exemplar adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void RegistrarEmprestimo(Livros biblioteca)
    {
        Console.Write("Informe o ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Livro livro = biblioteca.pesquisar(isbn);

        if (livro != null)
        {
            foreach (var exemplar in livro.Exemplares)
            {
                if (exemplar.Emprestar())
                {
                    Console.WriteLine($"Empréstimo registrado para o exemplar Tombo: {exemplar.Tombo}");
                    return;
                }
            }
            Console.WriteLine("Não há exemplares disponíveis para empréstimo.");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    static void RegistrarDevolucao(Livros biblioteca)
    {
        Console.Write("Informe o ISBN do livro: ");
        int isbn = int.Parse(Console.ReadLine());
        Livro livro = biblioteca.pesquisar(isbn);

        if (livro != null)
        {
            foreach (var exemplar in livro.Exemplares)
            {
                if (exemplar.Devolver())
                {
                    Console.WriteLine($"Devolução registrada para o exemplar Tombo: {exemplar.Tombo}");
                    return;
                }
            }
            Console.WriteLine("Não há exemplares emprestados.");
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }
}
