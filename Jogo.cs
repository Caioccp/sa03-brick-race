using System;
using System.Threading;

public class Jogo
{
    bool rodando = true;

    SistemaJogo sistema = new SistemaJogo();

    Foguete foguete = new Foguete();

    int obstaculoLinha = 5;
    int obstaculoPista = 0;

    int pistaTop = 4;

    Random rnd = new Random();

    public void Iniciar()
    {
        while (rodando)
        {
            DesenharTela();
            LerTeclado();
            Atualizar();
            Thread.Sleep(sistema.Velocidade);
        }
    }

    void DesenharTela()
    {
        Console.Clear();

        Console.WriteLine("==============================================");
        Console.WriteLine("              BRICK RACE");
        Console.WriteLine("==============================================");

        Console.WriteLine();

        Console.WriteLine("+-------------------------+");

        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine("|           |             |");
        }

        Console.WriteLine("+-------------------------+");

        Console.WriteLine();

        Console.WriteLine("VIDAS : " + sistema.Vidas);
        Console.WriteLine("PONTOS: " + sistema.Pontos);
        Console.WriteLine("NÍVEL : " + sistema.Nivel);
        Console.WriteLine("VELOC.: " + sistema.Velocidade + " ms");

        Console.WriteLine();

        Console.WriteLine("CONTROLES");
        Console.WriteLine("A ou ← = Esquerda");
        Console.WriteLine("D ou → = Direita");
        Console.WriteLine("ESC = Sair");

        foguete.Desenhar();
        DesenharObstaculo();
    }

    void DesenharObstaculo()
    {
        int coluna;

        if (obstaculoPista == 0)
            coluna = 5;
        else
            coluna = 20;

        Console.SetCursorPosition(coluna, pistaTop + obstaculoLinha);
        Console.Write("█");
    }

    void LerTeclado()
    {
        if (!Console.KeyAvailable)
            return;

        ConsoleKey tecla = Console.ReadKey(true).Key;

        foguete.LerTecla(tecla);

        if (tecla == ConsoleKey.Escape)
            rodando = false;
    }

    void Atualizar()
{
    obstaculoLinha++;

    if (obstaculoLinha > 12)
    {
        obstaculoLinha = 1;
        obstaculoPista = rnd.Next(0, 2);

        // 🔥 ganha pontos ao desviar
        sistema.SomarPontos();
    }

    VerificarColisao();

    // 🔥 atualiza nível e velocidade automaticamente
    sistema.AtualizarNivel();
    sistema.AtualizarVelocidade();
}

void VerificarColisao()
{
    if (obstaculoPista == foguete.Pista &&
        obstaculoLinha >= 9 && obstaculoLinha <= 12)
    {
        sistema.PerderVida();

        obstaculoLinha = 1;
        obstaculoPista = rnd.Next(0, 2);

        // 🔥 GAME OVER
        if (sistema.Vidas <= 0)
        {
            sistema.SalvarResultado();
            GameOver();
            rodando = false;
        }
    }
}

void GameOver()
{
    Console.Clear();

    Console.WriteLine("╔════════════════════════════════════════════╗");
    Console.WriteLine("║               FIM DE JOGO                  ║");
    Console.WriteLine("╠════════════════════════════════════════════╣");
    Console.WriteLine($"║ Pontuacao final: {sistema.Pontos.ToString("D6")}                    ║");
    Console.WriteLine($"║ Nivel alcancado: {sistema.Nivel.ToString("D2")}                        ║");
    Console.WriteLine($"║ Obstaculos desviados: {sistema.ObstaculosDesviados}                     ║");
    Console.WriteLine("║                                            ║");
    Console.WriteLine("║ Pressione qualquer tecla para voltar       ║");
    Console.WriteLine("║ ao menu principal.                         ║");
    Console.WriteLine("╚════════════════════════════════════════════╝");

    Console.ReadKey();
}
}