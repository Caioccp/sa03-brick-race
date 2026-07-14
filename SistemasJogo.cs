using System;

// Classe responsável por controlar todas as informações da partida.
public class SistemaJogo
{
    // Quantidade de vidas do jogador.
    public int Vidas { get; set; }

    // Pontuação atual.
    public int Pontos { get; set; }

    // Nível atual.
    public int Nivel { get; set; }

    // Velocidade do jogo.
    public int Velocidade { get; set; }

    // Quantidade de obstáculos desviados.
    public int ObstaculosDesviados { get; set; }

    // Quantidade de danos recebidos.
    public int DanosRecebidos { get; set; }

    // Indica se o escudo está ativo.
    public bool EscudoAtivo { get; set; }

    // Indica se os pontos dobrados estão ativos.
    public bool PontosDobrados { get; set; }

    // Tempo restante do buff de pontos dobrados.
    public int TempoPontosDobrados { get; set; }

    // Matriz utilizada para representar a pista.
    public char[,] Pista = new char[20, 35];

    // Informa se já existe uma partida salva.
    public static bool ExisteResultado = false;

    // Dados da última partida.
    public static int UltimaPontuacao;
    public static int UltimoNivel;
    public static int UltimosObstaculos;

    // Melhor pontuação do jogo.
    public static int Recorde = 0;

    // Guarda o nível anterior.
    private int nivelAnterior;

    // Construtor da classe.
    public SistemaJogo()
    {
        // Valores iniciais da partida.
        Vidas = 3;
        Pontos = 0;
        Nivel = 1;
        Velocidade = 80;
        ObstaculosDesviados = 0;
        DanosRecebidos = 0;

        nivelAnterior = 1;

        EscudoAtivo = false;
        PontosDobrados = false;
        TempoPontosDobrados = 0;

        // Preenche toda a pista com espaços vazios.
        for (int linha = 0; linha < 20; linha++)
        {
            for (int coluna = 0; coluna < 35; coluna++)
            {
                Pista[linha, coluna] = ' ';
            }
        }
    }

    // Remove uma vida do jogador.
    public void PerderVida()
    {
        if (Vidas > 0)
        {
            Vidas--;
            DanosRecebidos++;
        }
    }

    // Soma pontos ao jogador.
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

        // Atualiza o nível do jogador de acordo com a pontuação.
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

        // Guarda o nível atual.
        nivelAnterior = Nivel;
    }

    // Atualiza a velocidade do jogo conforme o nível.
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
            case 14: Velocidade = 30; break;
            case 15: Velocidade = 30; break;
            case 16: Velocidade = 30; break;
            case 17: Velocidade = 30; break;
            case 18: Velocidade = 30; break;
            case 19: Velocidade = 30; break;
            case 20: Velocidade = 30; break;
            default: Velocidade = 30; break;
        }
    }

    // Salva os dados da última partida.
    public void SalvarResultado()
    {
        UltimaPontuacao = Pontos;
        UltimoNivel = Nivel;
        UltimosObstaculos = ObstaculosDesviados;

        ExisteResultado = true;

        // Atualiza o recorde caso a pontuação seja maior.
        if (Pontos > Recorde)
        {
            Recorde = Pontos;
        }
    }

    // Atualiza o tempo restante dos buffs.
    public void AtualizarBuffs()
    {
        if (PontosDobrados)
        {
            TempoPontosDobrados--;

            if (TempoPontosDobrados <= 0)
            {
                PontosDobrados = false;
            }
        }
    }
}