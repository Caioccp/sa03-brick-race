using System;
using System.Collections.Generic;

public class Obstaculo
{
    public List<(int Linha, int Pista, int Tipo)> Obstaculos { get; private set; }

    private Random random = new Random();
    private int alturaTela;
    private int ultimoTipo = -1;
    private int ultimaPista = -1;

    public Obstaculo(int alturaTela)
    {
        this.alturaTela = alturaTela;
        Obstaculos = new List<(int, int, int)>();
    }

    public void CriarObstaculo()
    {
        foreach (var obstaculo in Obstaculos)
        {
            if (obstaculo.Linha < 11)
                return;
        }

       int pista;

if (ultimaPista == -1)
{

    pista = random.Next(0, 2);
}
else
{

    if (random.Next(100) < 75)
        pista = 1 - ultimaPista;
    else
        pista = ultimaPista;
}

ultimaPista = pista;
        int tipo;

        do
        {
            tipo = random.Next(0, 4);
        }
        while (tipo == ultimoTipo);

        ultimoTipo = tipo;

        int espaco = CalcularEspacoLivre(0);

        if (espaco > 5)
        {
            Obstaculos.Add((3, pista, tipo));
        }
    }

    public void Atualizar()
    {
        for (int i = 0; i < Obstaculos.Count; i++)
        {
            Obstaculos[i] = (
                Obstaculos[i].Linha + 1,
                Obstaculos[i].Pista,
                Obstaculos[i].Tipo
            );
        }

        Obstaculos.RemoveAll(o => o.Linha > alturaTela);
    }

    public void Desenhar()
    {
        Console.ForegroundColor = ConsoleColor.Red;

        foreach (var obstaculo in Obstaculos)
        {
            int x = obstaculo.Pista == 0 ? 8 : 26;

            Console.SetCursorPosition(x, obstaculo.Linha);

            switch (obstaculo.Tipo)
            {
                case 0:
                    Console.Write("[☄]");
                    break;
                case 1:
                    Console.Write("<^>");
                    break;
                case 2:
                    Console.Write("<✦>");
                    break;
                case 3:
                    Console.Write("(◉)");
                    break;
            }
        }

        Console.ResetColor();
    }

    public int CalcularEspacoLivre(int linha)
    {
        if (linha >= alturaTela)
            return 0;

        return 1 + CalcularEspacoLivre(linha + 1);
    }
}