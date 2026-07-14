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
        // Define a pista como esquerda.
        Pista = 0;
    }


    // Move o foguete para a pista direita.
    public void MoverDireita()
    {
        // Define a pista como direita.
        Pista = 1;
    }


    // Verifica qual tecla o jogador apertou.
    public void LerTecla(ConsoleKey tecla)
    {
        // Se apertar A ou seta esquerda,
        // movimenta o foguete para a esquerda.
        if (tecla == ConsoleKey.A || tecla == ConsoleKey.LeftArrow)
        {
            MoverEsquerda();
        }

        // Se apertar D ou seta direita,
        // movimenta o foguete para a direita.
        else if (tecla == ConsoleKey.D || tecla == ConsoleKey.RightArrow)
        {
            MoverDireita();
        }
    }


    // Desenha o foguete na tela.
    public void Desenhar()
    {
        // Guarda a posição horizontal do foguete.
        int coluna;

        // Define a linha onde o foguete aparece.
        int linha = 21;


        // Escolhe a coluna dependendo da pista.
        if (Pista == 0)
        {
            // Posição da pista esquerda.
            coluna = 8;
        }
        else
        {
            // Posição da pista direita.
            coluna = 26;
        }


        // Desenha a parte superior do foguete.
        Console.ForegroundColor = ConsoleColor.White;

        Console.SetCursorPosition(coluna, linha);
        Console.Write(" ▲ ");


        // Desenha o corpo do foguete.
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.SetCursorPosition(coluna, linha + 1);
        Console.Write("/█\\");


        Console.SetCursorPosition(coluna, linha + 2);
        Console.Write("/_\\");


        // Desenha a chama do foguete.
        Console.ForegroundColor = ConsoleColor.Red;

        Console.SetCursorPosition(coluna, linha + 3);
        Console.Write("^v^");


        // Volta a cor do console para o padrão.
        Console.ResetColor();
    }
}