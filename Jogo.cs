using System;
using System.Threading;

public class Jogo
{
    bool rodando = true;

    int inicioDaPista = 1;

    SistemaJogo sistema = new SistemaJogo();

    Foguete foguete = new Foguete();

    Obstaculo obstaculo = new Obstaculo(30);

    PowerUp powerUp = new PowerUp(30);

public void Iniciar()
{
    Som.Iniciar();

    while (rodando)
    {
        DesenharTela();
        LerTeclado();
        Atualizar();

        Thread.Sleep(sistema.Velocidade);
    }
            Som.Parar();
}
    void DesenharTela()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("================================================");
    Console.WriteLine("                 SPACE RUN");
    Console.WriteLine("================================================");
    Console.ResetColor();

    Console.WriteLine();

    Console.SetCursorPosition(inicioDaPista, Console.CursorTop);

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("+-----------------------------------+");

    for (int i = 0; i < 13; i++)
    {
        Console.SetCursorPosition(inicioDaPista, Console.CursorTop);
        Console.WriteLine("|                 |                 |");
    }

    Console.SetCursorPosition(inicioDaPista, Console.CursorTop);
    Console.WriteLine("+-----------------------------------+");
    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("VIDAS   : ");

    for (int i = 0; i < sistema.Vidas; i++)
    {
        Console.Write("♥ ");
    }

    for (int i = sistema.Vidas; i < 3; i++)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("♡ ");
        Console.ForegroundColor = ConsoleColor.Red;
    }

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("PONTOS  : " + sistema.Pontos.ToString("D6"));

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("RECORDE : " + SistemaJogo.Recorde.ToString("D6"));

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("NIVEL   : " + sistema.Nivel.ToString("D2"));

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("VELOC.  : " + sistema.Velocidade + " m/s");

    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("CONTROLES");
    Console.WriteLine("A ou ← = Esquerda");
    Console.WriteLine("D ou → = Direita");
    Console.WriteLine("ESC = Sair");
    Console.ResetColor();

    foguete.Desenhar();
    obstaculo.Desenhar();
    powerUp.Desenhar();
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
        obstaculo.CriarObstaculo();
        obstaculo.Atualizar();

        powerUp.CriarPowerUp();
        powerUp.Atualizar();

        VerificarColisao();
        VerificarPowerUp();

        sistema.AtualizarNivel();
        sistema.AtualizarVelocidade();
    }

    void VerificarColisao()
{
    for (int i = obstaculo.Obstaculos.Count - 1; i >= 0; i--)
    {
        var o = obstaculo.Obstaculos[i];

        if (o.Pista == foguete.Pista && o.Linha >= 14 && o.Linha <= 17)
        {
            sistema.PerderVida();

            Som.TocarColisao(sistema.DanosRecebidos);

            obstaculo.Obstaculos.RemoveAt(i);

            if (sistema.Vidas <= 0)
            {
                sistema.SalvarResultado();
                GameOver();
                rodando = false;
            }
        }
        else if (o.Linha > 18)
        {
            sistema.SomarPontos();
            obstaculo.Obstaculos.RemoveAt(i);
        }
    }
}

void GameOver()
{
    Som.Parar();

    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("╔════════════════════════════════════════════╗");
    Console.WriteLine("║               FIM DE JOGO                  ║");
    Console.WriteLine("╠════════════════════════════════════════════╣");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"║ Pontuacao final: {sistema.Pontos:D6}                    ║");

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"║ Nivel alcancado: {sistema.Nivel:D3}                       ║");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"║ Obstaculos desviados: {sistema.ObstaculosDesviados:D3}                  ║");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"║ Recorde: {SistemaJogo.Recorde:D6}                           ║");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("║                                            ║");
    Console.WriteLine("║ Pressione qualquer tecla para voltar       ║");
    Console.WriteLine("║ ao menu principal.                         ║");
    Console.WriteLine("╚════════════════════════════════════════════╝");

    Console.ResetColor();

    Console.ReadKey();
}

void VerificarPowerUp()
{
    for (int i = powerUp.PowerUps.Count - 1; i >= 0; i--)
    {
        var p = powerUp.PowerUps[i];

        if (p.Pista == foguete.Pista && p.Linha >= 14 && p.Linha <= 17)
        {
            sistema.Vidas++;

            powerUp.PowerUps.RemoveAt(i);
        }
    }
}
}

