using System;
using System.Threading;

public class Jogo
{
    bool rodando = true;

    int inicioDaPista = 1;

    SistemaJogo sistema = new SistemaJogo();

    Foguete foguete = new Foguete();

    Obstaculo obstaculo = new Obstaculo(30);

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

        Console.WriteLine("================================================");
        Console.WriteLine("                 BRICK RACE");
        Console.WriteLine("================================================");

        Console.WriteLine();

        Console.SetCursorPosition(inicioDaPista, Console.CursorTop);

        Console.WriteLine("+-----------------------------------+");

        for (int i = 0; i < 13; i++)
        {
            Console.SetCursorPosition(inicioDaPista, Console.CursorTop);
            Console.WriteLine("|                 |                 |");
        }

        Console.SetCursorPosition(inicioDaPista, Console.CursorTop);

        Console.WriteLine("+-----------------------------------+");

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
        obstaculo.Desenhar();
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
        sistema.LimparPista();
        
        obstaculo.CriarObstaculo();
        obstaculo.Atualizar();

        VerificarColisao();

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
        Console.Clear();

        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║               FIM DE JOGO                  ║");
        Console.WriteLine("╠════════════════════════════════════════════╣");
        Console.WriteLine($"║ Pontuacao final: {sistema.Pontos.ToString("D6")}                    ║");
        Console.WriteLine($"║ Nivel alcancado: {sistema.Nivel.ToString("D3")}                       ║");
Console.WriteLine($"║ Obstaculos desviados: {sistema.ObstaculosDesviados.ToString("D3")}                  ║");
        Console.WriteLine("║                                            ║");
        Console.WriteLine("║ Pressione qualquer tecla para voltar       ║");
        Console.WriteLine("║ ao menu principal.                         ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        Console.ReadKey();
    }
}