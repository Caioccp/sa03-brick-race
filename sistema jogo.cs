using System;

public class SistemaJogo
{
    // Quantidade de vidas do jogador
    public int Vidas { get; set; }

    // Pontuação atual
    public int Pontos { get; set; }

    // Nível atual
    public int Nivel { get; set; }

    // Velocidade do jogo (Thread.Sleep)
    public int Velocidade { get; set; }

    // Quantidade de obstáculos desviados
    public int ObstaculosDesviados { get; set; }

    // Último resultado
    public int UltimaPontuacao { get; set; }
    public int UltimoNivel { get; set; }
    public int UltimosObstaculos { get; set; }

    // Construtor
    public SistemaJogo()
    {
        Vidas = 3;
        Pontos = 0;
        Nivel = 1;
        Velocidade = 300;
        ObstaculosDesviados = 0;
    }

    public void PerderVida()
    {
        if (Vidas > 0)
        {
            Vidas--;

Console.Beep(300, 150);
Console.Beep(200, 250);

if (Vidas == 0)
{
    Console.Beep(700, 200);
    Console.Beep(600, 200);
    Console.Beep(500, 200);
    Console.Beep(400, 300);
    Console.Beep(300, 500);
}
}
        }
        
    }

    public void SomarPontos()
    {
        Pontos += 10;
        ObstaculosDesviados++;
    }

    public void AtualizarNivel()
{
    int nivelAnterior = Nivel;

    if (Pontos >= 900)
        Nivel = 10;
    else if (Pontos >= 800)
        Nivel = 9;
    else if (Pontos >= 700)
        Nivel = 8;
    else if (Pontos >= 600)
        Nivel = 7;
    else if (Pontos >= 500)
        Nivel = 6;
    else if (Pontos >= 400)
        Nivel = 5;
    else if (Pontos >= 300)
        Nivel = 4;
    else if (Pontos >= 200)
        Nivel = 3;
    else if (Pontos >= 100)
        Nivel = 2;
    else
        Nivel = 1;

    if (Nivel > nivelAnterior)
    {
        Console.Beep(700, 100);
        Console.Beep(900, 100);
        Console.Beep(1100, 200);
    }
}

    {

    public void AtualizarVelocidade()
{
    switch (Nivel)
    {
        case 1: Velocidade = 300; break;
        case 2: Velocidade = 280; break;
        case 3: Velocidade = 260; break;
        case 4: Velocidade = 240; break;
        case 5: Velocidade = 220; break;
        case 6: Velocidade = 200; break;
        case 7: Velocidade = 180; break;
        case 8: Velocidade = 160; break;
        case 9: Velocidade = 140; break;
        case 10: Velocidade = 120; break;
        default: Velocidade = 120; break;
    }
}

    public void SalvarResultado()
    {
        UltimaPontuacao = Pontos;
        UltimoNivel = Nivel;
        UltimosObstaculos = ObstaculosDesviados;
    }
}