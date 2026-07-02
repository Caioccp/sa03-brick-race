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

    // Objeto responsável por controlar o foguete do jogador.
    Foguete foguete = new Foguete();


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

    // ============================
    // DESENHA A TELA
    // ============================

void DesenharTela()
{
    // Limpa o console para desenhar uma nova tela.
    Console.Clear();

    // ============================
    // CABEÇALHO DO JOGO
    // ============================

    // Exibe o título do jogo.
    Console.WriteLine("==============================================");
    Console.WriteLine("              BRICK RACE");
    Console.WriteLine("==============================================");

    Console.WriteLine();

    // ============================
    // DESENHO DA PISTA
    // ============================

    // ============================
    // DESENHO DA PISTA
    // ============================

    // Desenha a borda superior da pista.
    Console.WriteLine("+-------------------------+");

    // Repete 12 vezes para formar a altura da pista.
        for (int i = 0; i < 12; i++)
{
    // Cada linha representa uma parte da pista.
    // A linha vertical do meio separa as duas faixas.
    Console.WriteLine("|           |             |");
}

    // Desenha a borda inferior da pista.
    Console.WriteLine("+-------------------------+");

    Console.WriteLine();

    // ============================
    // PAINEL DE INFORMAÇÕES
    // ============================

    // Exibe a quantidade de vidas.
    Console.WriteLine("VIDAS : " + vidas);

    // Exibe a pontuação atual.
    Console.WriteLine("PONTOS: " + pontos);

    // Exibe o nível atual.
    Console.WriteLine("NÍVEL : " + nivel);

    // Exibe a velocidade do jogo.
    Console.WriteLine("VELOC.: " + velocidade + " ms");

    Console.WriteLine();

    // ============================
// CONTROLES
// ============================

// Mostra os comandos do jogo.
Console.WriteLine("CONTROLES");
Console.WriteLine("A ou ← = Esquerda");
Console.WriteLine("D ou → = Direita");
Console.WriteLine("ESC = Sair");


// ============================
// DESENHA O FOGUETE
// ============================

// Desenha o foguete na posição atual.
// Esse comando deve ficar por último para que o foguete
// apareça sobre a pista.
foguete.Desenhar();

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

    // Envia a tecla pressionada para o foguete.
    // O próprio foguete decide se deve mudar de pista.
    foguete.LerTecla(tecla);

    // Se pressionar ESC,
    // volta para o menu principal.
    if (tecla == ConsoleKey.Escape)
    {
        rodando = false;
    }

    // Os comandos A, D e as setas já estão sendo enviados
    // para o foguete. Depois vamos apenas desenhá-lo na tela.
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