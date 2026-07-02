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
}

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

