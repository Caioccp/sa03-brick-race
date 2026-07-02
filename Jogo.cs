using System;
// Permite utilizar funções do Console.

using System.Threading;
// Permite utilizar o Thread.Sleep() para controlar a velocidade do jogo.

public class Jogo
{
    // ============================
    // VARIÁVEIS DO JOGO
    // ============================

    // Indica se o jogo continua rodando.
    bool rodando = true;

    // Quantidade de vidas do jogador.
    int vidas = 3;

    // Pontuação da partida.
    int pontos = 0;

    // Nível atual.
    int nivel = 1;

    // Velocidade de atualização da tela (em milissegundos).
    int velocidade = 250;

    // ============================
    // MÉTODO QUE INICIA O JOGO
    // ============================

    public void Iniciar()
    {
        // Enquanto a variável "rodando" for verdadeira,
        // o jogo continuará funcionando.
        while (rodando)
        {
            // Desenha toda a tela.
            DesenharTela();

            // Verifica se o jogador pressionou alguma tecla.
            LerTeclado();

            // Atualiza informações do jogo.
            Atualizar();

            // Aguarda alguns milissegundos antes de atualizar novamente.
            Thread.Sleep(velocidade);
        }
    }

    // ============================
    // DESENHA A TELA
    // ============================

    void DesenharTela()
    {
        // Limpa o console para redesenhar tudo.
        Console.Clear();

        // Título do jogo.
        Console.WriteLine("==============================================");
        Console.WriteLine("              BRICK RACE");
        Console.WriteLine("==============================================");

        Console.WriteLine();

        // Mensagem temporária.
        // Depois será substituída pela pista.
        Console.WriteLine("A pista será desenhada aqui.");

        Console.WriteLine();

        // Painel de informações.
        Console.WriteLine("VIDAS : " + vidas);
        Console.WriteLine("PONTOS: " + pontos);
        Console.WriteLine("NÍVEL : " + nivel);
        Console.WriteLine("VELOC.: " + velocidade + " ms");

        Console.WriteLine();

        // Controles.
        Console.WriteLine("CONTROLES");
        Console.WriteLine("A ou ← = Esquerda");
        Console.WriteLine("D ou → = Direita");
        Console.WriteLine("ESC = Sair");
    }

    // ============================
    // LÊ O TECLADO
    // ============================

    void LerTeclado()
    {
        // Se nenhuma tecla foi pressionada,
        // o método termina.
        if (!Console.KeyAvailable)
        {
            return;
        }

        // Lê a tecla pressionada.
        ConsoleKey tecla = Console.ReadKey(true).Key;

        // Se pressionar ESC,
        // volta para o menu principal.
        if (tecla == ConsoleKey.Escape)
        {
            rodando = false;
        }

        // Os comandos A, D e setas serão adicionados
        // quando criarmos o carro.
    }

    // ============================
    // ATUALIZA O JOGO
    // ============================

    void Atualizar()
    {
        // Neste momento ainda não existe lógica.

        // Aqui futuramente teremos:
        // • Movimento dos obstáculos.
        // • Colisão.
        // • Pontuação.
        // • Nível.
        // • Velocidade.
    }
}