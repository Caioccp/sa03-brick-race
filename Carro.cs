using System;

public class Foguete
{
    // 0 = pista esquerda
    // 1 = pista direita
    public int Pista { get; private set; }

    public Foguete()
    {
        // O foguete começa na pista da esquerda
        Pista = 0;
    }

    // Move para a pista da esquerda
    public void MoverEsquerda()
    {
        Pista = 0;
    }

    // Move para a pista da direita
    public void MoverDireita()
    {
        Pista = 1;
    }

    // Lê as teclas do jogador
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

    // Desenha o foguete
public void Desenhar()
{
    int coluna;
    int linha = 14;

    // Escolhe a pista
    if (Pista == 0)
    {
        coluna = 8;
    }
    else
    {
        coluna = 26;
    }

    // Cor do foguete
    Console.ForegroundColor = ConsoleColor.Green;

    Console.SetCursorPosition(coluna, linha);
    Console.Write(" ▲ ");

    Console.SetCursorPosition(coluna, linha + 1);
    Console.Write("/█\\");

    Console.SetCursorPosition(coluna, linha + 2);
    Console.Write("/_\\");

    Console.SetCursorPosition(coluna, linha + 3);
    Console.Write("^v^");

    // Volta para a cor padrão
    Console.ResetColor();
}
}