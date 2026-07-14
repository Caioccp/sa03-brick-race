using System;


// Classe responsável por controlar todos os dados da partida.
// Guarda informações como:
// - vidas do jogador
// - pontuação
// - nível
// - recorde
// - poderes ativos
public class SistemaJogo
{

    // Quantidade de vidas atuais do jogador.
    public int Vidas { get; set; }


    // Pontuação atual da partida.
    public int Pontos { get; set; }


    // Nível atual do jogador.
    public int Nivel { get; set; }



    // Tempo entre movimentos dos obstáculos.
    // Quanto menor o valor, mais rápido o jogo fica.
    public int Velocidade { get; set; }



    // Quantidade de obstáculos que o jogador conseguiu desviar.
    public int ObstaculosDesviados { get; set; }



    // Quantidade de vezes que o jogador sofreu dano.
    public int DanosRecebidos { get; set; }



    // Indica se o escudo está ativo.
    // true = protegido
    // false = sem escudo
    public bool EscudoAtivo { get; set; }



    // Indica se o bônus de pontos está ativo.
    // true = ganha pontos dobrados
    // false = pontuação normal
    public bool PontosDobrados { get; set; }



    // Controla quanto tempo falta para acabar o bônus de pontos dobrados.
    public int TempoPontosDobrados { get; set; }



    // Matriz que representa a pista do jogo.
    // Possui 20 linhas e 35 colunas.
    public char[,] Pista = new char[20, 35];



    // Informa se existe algum resultado salvo.
    public static bool ExisteResultado = false;



    // Guarda a pontuação da última partida.
    public static int UltimaPontuacao;


    // Guarda o nível alcançado na última partida.
    public static int UltimoNivel;


    // Guarda a quantidade de obstáculos desviados na última partida.
    public static int UltimosObstaculos;


    // Guarda o maior recorde conseguido.
    public static int Recorde = 0;



    // Guarda o nível anterior.
    // Usado para controlar mudanças de nível.
    private int nivelAnterior;





    // Construtor da classe.
    // Define os valores iniciais de uma nova partida.
    public SistemaJogo()
    {

        // O jogador começa com 3 vidas.
        Vidas = 3;


        // A pontuação começa zerada.
        Pontos = 0;


        // O jogo começa no nível 1.
        Nivel = 1;


        // Define a velocidade inicial.
        Velocidade = 80;


        // Nenhum obstáculo foi desviado no início.
        ObstaculosDesviados = 0;


        // Nenhum dano recebido no início.
        DanosRecebidos = 0;


        // Salva o nível inicial.
        nivelAnterior = 1;


        // O escudo começa desligado.
        EscudoAtivo = false;


        // O bônus de pontos começa desligado.
        PontosDobrados = false;


        // Tempo do bônus começa zerado.
        TempoPontosDobrados = 0;



        // Percorre todas as posições da matriz da pista.
        for (int linha = 0; linha < 20; linha++)
        {
            for (int coluna = 0; coluna < 35; coluna++)
            {

                // Preenche todos os espaços vazios.
                Pista[linha, coluna] = ' ';
            }
        }
    }





    // Método chamado quando o jogador recebe dano.
    public void PerderVida()
    {

        // Verifica se ainda existem vidas.
        if (Vidas > 0)
        {

            // Remove uma vida.
            Vidas--;


            // Soma um dano recebido.
            DanosRecebidos++;
        }
    }





    // Método responsável por adicionar pontos ao jogador.
    public void SomarPontos()
    {

        // Verifica se o bônus de pontos está ativo.
        if (PontosDobrados)
        {

            // Com bônus ativo, ganha 20 pontos.
            Pontos += 20;
        }
        else
        {

            // Sem bônus, ganha 10 pontos.
            Pontos += 10;
        }


        // Aumenta a quantidade de obstáculos desviados.
        ObstaculosDesviados++;
    }
}