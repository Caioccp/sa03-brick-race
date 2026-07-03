using System;

public class SistemaJogo
{
    public int Vidas { get; set; }
    public int Pontos { get; set; }
    public int Nivel { get; set; }
    public int Velocidade { get; set; }
    public int ObstaculosDesviados { get; set; }

    public int UltimaPontuacao { get; set; }
    public int UltimoNivel { get; set; }
    public int UltimosObstaculos { get; set; }

    private int nivelAnterior;

    public SistemaJogo()
    {
        Vidas = 3;
        Pontos = 0;
        Nivel = 1;
        Velocidade = 300;
        ObstaculosDesviados = 0;
        nivelAnterior = 1;
    }

    public void PerderVida()
    {
        if (Vidas > 0)
        {
            Vidas--;

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

    public void SomarPontos()
    {
        Pontos += 10;
        ObstaculosDesviados++;
    }

    public void AtualizarNivel()
    {
        if (Pontos >= 300)
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

        nivelAnterior = Nivel;
    }

    public void AtualizarVelocidade()
    {
        switch (Nivel)
        {
            case 1:
                Velocidade = 300;
                break;
            case 2:
                Velocidade = 250;
                break;
            case 3:
                Velocidade = 200;
                break;
            default:
                Velocidade = 150;
                break;
        }
    }

    public void SalvarResultado()
    {
        UltimaPontuacao = Pontos;
        UltimoNivel = Nivel;
        UltimosObstaculos = ObstaculosDesviados;
    }
}