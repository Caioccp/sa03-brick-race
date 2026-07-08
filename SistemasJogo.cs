using System;

public class SistemaJogo
{
    public int Vidas { get; set; }
    public int Pontos { get; set; }
    public int Nivel { get; set; }
    public int Velocidade { get; set; }
    public int ObstaculosDesviados { get; set; }

    public char[,] Pista = new char[13, 35];

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
        nivelAnterior = 1;

        for (int linha = 0; linha < 13; linha++)
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
        }
    }

    public void SomarPontos()
    {
        Pontos += 10;
        ObstaculosDesviados++;
    }

    public void AtualizarNivel()
    {
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
            default: Velocidade = 50; break;
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