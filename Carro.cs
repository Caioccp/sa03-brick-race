using System;

public class Foguete
{
    // 0 = pista esquerda
    // 1 = pista direita
    public int Pista { get; private set; }

    public Foguete()
    {
        Pista = 0; // começa na esquerda
    }

    public void MoverEsquerda()
    {
        Pista = 0;
    }

    public void MoverDireita()
    {
        Pista = 1;
    }

    public void LerTecla(ConsoleKey tecla)
    {
        if (tecla == ConsoleKey.A || tecla == ConsoleKey.LeftArrow)
        {
            MoverEsquerda();
        }
        else if (tecla == ConsoleKey.D || tecla == ConsoleKey.RightArrow)
        {
            MoverDireita();
        }
    }

    public void Desenhar()
    {
        int coluna;
        int linha = 14;

        // 🚀 posições melhor centralizadas
        if (Pista == 0)
        {
            coluna = 12; // pista esquerda
        }
        else
        {
            coluna = 30; // pista direita
        }

        Console.SetCursorPosition(coluna, linha);
        Console.Write("  ▲  ");

        Console.SetCursorPosition(coluna, linha + 1);
        Console.Write(" /█\\ ");

        Console.SetCursorPosition(coluna, linha + 2);
        Console.Write(" |█| ");

        Console.SetCursorPosition(coluna, linha + 3);
        Console.Write("/___\\");

        Console.SetCursorPosition(coluna, linha + 4);
        Console.Write("  ║  ");
    }
}