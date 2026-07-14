using System;

public class SistemaJogo
{
    public int Vidas { get; set; }
    public int Pontos { get; set; }
    public int Nivel { get; set; }

    public int Velocidade { get; set; }
    public int ObstaculosDesviados { get; set; }
    public int DanosRecebidos { get; set; }
    public bool EscudoAtivo { get; set; }
    public bool PontosDobrados { get; set; }

    public char[,] Pista = new char[20, 35];

    public static bool ExisteResultado = false;

    public static int UltimaPontuacao;
    public static int UltimoNivel;
    public static int UltimosObstaculos;
    public static int Recorde = 0;

    private int nivelAnterior;

    public SistemaJogo()
    {
        Vidas = 3;
        Pontos = 0;
        Nivel = 1;
        Velocidade = 80;
        ObstaculosDesviados = 0;
        DanosRecebidos = 0;
        nivelAnterior = 1;
        EscudoAtivo = false;
        PontosDobrados = false;

        for (int linha = 0; linha < 20; linha++)
        {
            for (int coluna = 0; coluna < 35; coluna++)
            {
                Pista[linha, coluna] = ' ';
            }
        }
    }

    public void PerderVida()
    {
        if (Vidas > 0)
        {
            Vidas--;
            DanosRecebidos++;
        }
    }

    public void SomarPontos()
    {
        if (PontosDobrados)
        {
            Pontos += 20;
        }
        else
        {
            Pontos += 10;
        }

        ObstaculosDesviados++;
    }
    public void AtualizarNivel()
{
    if (Pontos >= 1900)
        Nivel = 20;
    else if (Pontos >= 1800)
        Nivel = 19;
    else if (Pontos >= 1700)
        Nivel = 18;
    else if (Pontos >= 1600)
        Nivel = 17;
    else if (Pontos >= 1500)
        Nivel = 16;
    else if (Pontos >= 1400)
        Nivel = 15;
    else if (Pontos >= 1300)
        Nivel = 14;
    else if (Pontos >= 1200)
        Nivel = 13;
    else if (Pontos >= 1100)
        Nivel = 12;
    else if (Pontos >= 1000)
        Nivel = 11;
    else if (Pontos >= 900)
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

    nivelAnterior = Nivel;
}

    public void AtualizarVelocidade()
{
    switch (Nivel)
    {
        case 1: Velocidade = 150; break;
        case 2: Velocidade = 140; break;
        case 3: Velocidade = 130; break;
        case 4: Velocidade = 120; break;
        case 5: Velocidade = 110; break;
        case 6: Velocidade = 100; break;
        case 7: Velocidade = 90; break;
        case 8: Velocidade = 80; break;
        case 9: Velocidade = 70; break;
        case 10: Velocidade = 60; break;
        case 11: Velocidade = 50; break;
        case 12: Velocidade = 40; break;
        case 13: Velocidade = 30; break;
        case 14: Velocidade = 20; break;
        case 15: Velocidade = 10; break;
        case 16: Velocidade = 10; break;
        case 17: Velocidade = 10; break;
        case 18: Velocidade = 10; break;
        case 19: Velocidade = 10; break;
        case 20: Velocidade = 10; break;
        default: Velocidade = 10; break;
    }
}

    public void SalvarResultado()
    {
        UltimaPontuacao = Pontos;
        UltimoNivel = Nivel;
        UltimosObstaculos = ObstaculosDesviados;
        ExisteResultado = true;

        if (Pontos > Recorde)
        {
            Recorde = Pontos;
        }
    }
}