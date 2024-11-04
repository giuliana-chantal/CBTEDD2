using System;
using System.Collections.Generic;
using System.Linq;

class Livro
{
    public int Isbn { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Editora { get; private set; }
    private List<Exemplar> exemplares;

    public Livro(int isbn, string titulo, string autor, string editora)
    {
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
        Editora = editora;
        exemplares = new List<Exemplar>();
    }

    public void adicionarExemplar(Exemplar exemplar)
    {
        exemplares.Add(exemplar);
    }

    public int qtdeExemplares() => exemplares.Count;

    public int qtdeDisponiveis() => exemplares.Count(e => e.disponivel());

    public int qtdeEmprestimos() => exemplares.Sum(e => e.qtdeEmprestimos());

    public double percDisponibilidade() 
    {
        if (qtdeExemplares() == 0) return 0;
        return (qtdeDisponiveis() / (double)qtdeExemplares()) * 100;
    }

    public List<Exemplar> Exemplares => exemplares;
}
