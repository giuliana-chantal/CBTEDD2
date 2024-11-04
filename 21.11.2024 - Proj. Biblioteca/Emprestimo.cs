using System;

class Emprestimo
{
    public DateTime DtEmprestimo { get; private set; }
    public DateTime DtDevolucao { get; private set; }

    public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
    {
        DtEmprestimo = dtEmprestimo;
        DtDevolucao = dtDevolucao;
    }
}
