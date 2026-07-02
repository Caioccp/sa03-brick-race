using System;

// ============================
// SISTEMA GERAL DO JOGO
// ============================
// Esta classe controla:
// - Vidas do jogador
// - Pontuação
// - Nível
// - Velocidade do jogo
// - Efeitos sonoros
// - Resultado da partida

public class SistemaJogo
{
    // ============================
    // PROPRIEDADES DO JOGO
    // ============================

    // Quantidade de vidas do jogador
    public int Vidas { get; set; }

    // Pontuação atual do jogador
    public int Pontos { get; set; }

    // Nível atual do jogo
    public int Nivel { get; set; }

    // Velocidade do jogo (usado no Thread.Sleep)
    public int Velocidade { get; set; }

    // Quantidade de obstáculos desviados pelo jogador
    public int ObstaculosDesviados { get; set; }

    // ============================
    // RESULTADO DA PARTIDA
    // ============================

    // Última pontuação registrada
    public int UltimaPontuacao { get; set; }

    // Último nível alcançado
    public int UltimoNivel { get; set; }

    // Últimos obstáculos desviados
    public int UltimosObstaculos { get; set; }

    // Variável interna para controlar mudança de nível
    private int nivelAnterior;

    // ============================
    // CONSTRUTOR
    // ============================

    // Inicializa os valores padrão do jogo
    public SistemaJogo()
    {
        Vidas = 3;                 // Jogador começa com 3 vidas
        Pontos = 0;                // Pontuação inicial
        Nivel = 1;                 // Começa no nível 1
        Velocidade = 300;         // Velocidade inicial do jogo
        ObstaculosDesviados = 0;  // Nenhum obstáculo no início

        nivelAnterior = 1;        // Controle interno de nível
    }

    // ============================
    // PERDER VIDA
    // ============================

    // Método chamado quando o jogador colide com obstáculo
    public void PerderVida()
    {
        // Só perde vida se ainda tiver vidas
        if (Vidas > 0)
        {
            Vidas--; // remove 1 vida

            // ============================
            // EFEITOS SONOROS - DANO
            // ============================

            Console.Beep(300, 150);
            Console.Beep(200, 250);

            // Se zerar vidas, toca som de game over
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

    // ============================
    // SOMAR PONTOS
    // ============================

    // Método chamado quando o jogador desvia de um obstáculo
    public void SomarPontos()
    {
        Pontos += 10;              // adiciona pontos
        ObstaculosDesviados++;     // conta obstáculo evitado
    }

    // ============================
    // ATUALIZAR NÍVEL
    // ============================

    // Ajusta o nível baseado na pontuação
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

        // ============================
        // SOM DE UP DE NÍVEL
        // ============================

        // Se o nível aumentou, toca efeito sonoro
        if (Nivel > nivelAnterior)
        {
            Console.Beep(700, 100);
            Console.Beep(900, 100);
            Console.Beep(1100, 200);
        }

        // Atualiza controle interno
        nivelAnterior = Nivel;
    }

    // ============================
    // ATUALIZAR VELOCIDADE
    // ============================

    // Ajusta velocidade do jogo conforme o nível
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

    // ============================
    // SALVAR RESULTADO FINAL
    // ============================

    // Guarda dados da última partida jogada
    public void SalvarResultado()
    {
        UltimaPontuacao = Pontos;
        UltimoNivel = Nivel;
        UltimosObstaculos = ObstaculosDesviados;
    }
}