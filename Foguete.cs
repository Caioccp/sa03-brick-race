using System;

// ============================
// CLASSE FOGUETE (JOGADOR)
// ============================
// Responsável por:
// - Controlar posição do foguete
// - Receber comandos do teclado
// - Desenhar o foguete na tela

public class Foguete
{
    // ============================
    // POSIÇÃO DO FOGUETE
    // ============================

    // 0 = pista esquerda
    // 1 = pista direita
    public int Pista { get; private set; }

    // ============================
    // CONSTRUTOR
    // ============================

    // Define posição inicial do foguete
    public Foguete()
    {
        // Começa sempre na pista esquerda
        Pista = 0;
    }

    // ============================
    // MOVIMENTO DO FOGUETE
    // ============================

    // Move o foguete para a pista da esquerda
    public void MoverEsquerda()
    {
        Pista = 0;
    }

    // Move o foguete para a pista da direita
    public void MoverDireita()
    {
        Pista = 1;
    }

    // ============================
    // CONTROLE DE TECLADO
    // ============================

    // Lê tecla pressionada e decide movimento
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

    // ============================
    // DESENHO DO FOGUETE
    // ============================

    // Desenha o foguete na tela na posição atual
    public void Desenhar()
    {
        int coluna;
        int linha = 13;

        // Define coluna baseada na pista
        if (Pista == 0)
        {
            coluna = 5;
        }
        else
        {
            coluna = 20;
        }

        // ============================
        // FORMATO DO FOGUETE
        // ============================

        Console.SetCursorPosition(coluna, linha);
        Console.Write(" ▲ ");

        Console.SetCursorPosition(coluna, linha + 1);
        Console.Write("/█\\");

        Console.SetCursorPosition(coluna, linha + 2);
        Console.Write("/_\\");

        Console.SetCursorPosition(coluna, linha + 3);
        Console.Write(" | ");
    }
}