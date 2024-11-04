using System;
using System.Collections.Generic;
using System.Linq;

class Livros
{
    private List<Livro> acervo;

    public Livros()
    {
        acervo = new List<Livro>();
    }

    public void adicionar(Livro livro)
    {
        acervo.Add(livro);
    }

    public Livro pesquisar(int isbn)
    {
        return acervo.FirstOrDefault(l => l.Isbn == isbn);
    }
}
