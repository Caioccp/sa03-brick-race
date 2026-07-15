using System;

// Classe responsável pelo jogador.
// Controla a posição, movimentação e desenho do foguete.
public class Foguete
{
    // Guarda a pista atual do foguete.
    // 0 = pista esquerda
    // 1 = pista direita
    public int Pista { get; private set; }


    // Construtor da classe.
    // Define a posição inicial do jogador.
    public Foguete()
    {
        // O foguete começa na pista esquerda.
        Pista = 0;
    }


    // Move o foguete para a pista esquerda.
    public void MoverEsquerda()
    {
        Pista = 0;
    }


    // Move o foguete para a pista direita.
    public void MoverDireita()
    {
        Pista = 1;
    }


    // Verifica qual tecla o jogador apertou.
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


    // Desenha o foguete na tela.
    public void Desenhar(bool escudoAtivo)
    {
        int coluna;
        int linha = 21;

        // Escolhe a coluna dependendo da pista.
        if (Pista == 0)
        {
            coluna = 8;
        }
        else
        {
            coluna = 26;
        }

        // ===== ESCUDO =====
        if (escudoAtivo)
        {
            // Faz o escudo piscar entre azul e ciano
            if (DateTime.Now.Millisecond < 500)
                Console.ForegroundColor = ConsoleColor.Cyan;
            else
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(coluna, linha - 1);
            Console.Write("◜─◝");
        }

        // ===== FOGUETE =====

        // Parte superior
        Console.ForegroundColor = ConsoleColor.White;

        Console.SetCursorPosition(coluna, linha);
        Console.Write(" ▲ ");

        // Corpo
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.SetCursorPosition(coluna, linha + 1);
        Console.Write("/█\\");

        Console.SetCursorPosition(coluna, linha + 2);
        Console.Write("/_\\");

        // Chama
        Console.ForegroundColor = ConsoleColor.Red;

        Console.SetCursorPosition(coluna, linha + 3);
        Console.Write("^v^");

        Console.ResetColor();
    }
}