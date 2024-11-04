using System;
using System.Collections.Generic;
using System.Linq;

class Exemplar
{
    private static int nextTombo = 1;
    public int Tombo { get; private set; }
    private List<Emprestimo> emprestimos;

    public Exemplar()
    {
        Tombo = nextTombo++;
        emprestimos = new List<Emprestimo>();
    }

    public bool Emprestar()
    {
        if (disponivel())
        {
            emprestimos.Add(new Emprestimo(DateTime.Now, DateTime.MinValue));
            return true;
        }
        return false;
    }

    public bool Devolver()
    {
        foreach (var emprestimo in emprestimos)
        {
            if (emprestimo.DtDevolucao == DateTime.MinValue)
            {
                emprestimo.DtDevolucao = DateTime.Now;
                return true;
            }
        }
        return false;
    }

    public bool disponivel()
    {
        return emprestimos.All(e => e.DtDevolucao != DateTime.MinValue);
    }

    public int qtdeEmprestimos()
    {
        return emprestimos.Count;
    }
}
