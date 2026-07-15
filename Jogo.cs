using System;
using System.Threading;

// Classe responsável por controlar toda a partida.
// Ela desenha a tela, atualiza os objetos, verifica colisões
// e controla o início e o fim do jogo.
public class Jogo
{
    // Controla se o jogo continua em execução.
    bool rodando = true;

    // Define a posição horizontal onde a pista começa.
    int inicioDaPista = 1;

    // Sistema responsável por controlar vidas, pontos, nível e buffs.
    SistemaJogo sistema = new SistemaJogo();

    // Objeto do jogador.
    Foguete foguete = new Foguete();

    // Gerencia os obstáculos.
    Obstaculo obstaculo = new Obstaculo(40);

    // Gerencia os poderes.
    PowerUp powerUp = new PowerUp(30);

    bool frase670 = false;
    void VerificarFrase670()
{
    if (sistema.Pontos >= 670 && !frase670)
    {
        frase670 = true;

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("============================================================================");
        Console.WriteLine("                                     PARABÉNS!");
        Console.WriteLine("                             Você tem 670 pontos!");
        Console.WriteLine("                                Você farmou aura");
        Console.WriteLine("                      Continue jogando normalmente...");
        Console.WriteLine("============================================================================");
        Console.ResetColor();

        Thread.Sleep(3000);
    }
}




    // Método responsável por iniciar a partida.
    public void Iniciar()
    {
        // Inicia a música de fundo.
        Som.Iniciar();

        // Loop principal do jogo.
        while (rodando)
        {
            // Desenha toda a tela.
            DesenharTela();

            // Lê as teclas pressionadas.
            LerTeclado();

            // Atualiza todos os elementos do jogo.
            Atualizar();

            // Controla a velocidade da partida.
            Thread.Sleep(sistema.Velocidade);
        }

        // Para a música quando o jogo termina.
        Som.Parar();
    }



    // Método responsável por desenhar todos os elementos na tela.
    void DesenharTela()
    {
        // Limpa o console.
        Console.Clear();

        // Desenha o título do jogo.
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("================================================");
        Console.WriteLine("                 SPACE RUN");
        Console.WriteLine("================================================");

        Console.ResetColor();

        Console.WriteLine();

        // Posiciona o cursor no início da pista.
        Console.SetCursorPosition(inicioDaPista, Console.CursorTop);

        // Desenha a borda superior da pista.
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("+-----------------------------------+");

        // Desenha o interior da pista.
        for (int i = 0; i < 20; i++)
        {
            Console.SetCursorPosition(inicioDaPista, Console.CursorTop);
            Console.WriteLine("|                 |                 |");
        }

        // Desenha a borda inferior.
        Console.SetCursorPosition(inicioDaPista, Console.CursorTop);
        Console.WriteLine("+-----------------------------------+");

        Console.ResetColor();

        Console.WriteLine();

        // Exibe a quantidade de vidas.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(42, 5);
        Console.Write("VIDAS: ");

        // Desenha um coração para cada vida.
        for (int i = 0; i < sistema.Vidas; i++)
        {
            Console.Write("♥ ");
        }

        Console.ResetColor();

        Console.WriteLine();

        // Exibe a pontuação atual.
        Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(42, 6);
        Console.WriteLine("PONTOS  : " + sistema.Pontos.ToString("D6"));

        // Exibe o recorde.
        Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(42, 7);
        Console.WriteLine("RECORDE : " + SistemaJogo.Recorde.ToString("D6"));

        // Exibe o nível atual.
        Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(42, 8);
        Console.WriteLine("NIVEL   : " + sistema.Nivel.ToString("D2"));

        // Exibe a velocidade do jogo.
        Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(42, 9);
        Console.WriteLine("VELOC.  : " + sistema.Velocidade + " m/s");

        // Mostra os buffs ativos.
        MostrarBuffs();

        Console.ResetColor();

        Console.WriteLine();

        // Exibe os controles.
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(42, 17);
        Console.WriteLine("CONTROLES");
        Console.SetCursorPosition(42, 18);
        Console.WriteLine("A ou ← = Esquerda");
        Console.SetCursorPosition(42, 19);
        Console.WriteLine("D ou → = Direita");
        Console.SetCursorPosition(42, 20);
        Console.WriteLine("ESC = Sair");

        Console.ResetColor();

        // Desenha todos os elementos do jogo.
        foguete.Desenhar(sistema.EscudoAtivo);
        obstaculo.Desenhar();
        powerUp.Desenhar();
    }

    // Método responsável por ler as teclas pressionadas pelo jogador.
    void LerTeclado()
    {
        // Verifica se existe alguma tecla pressionada.
        if (!Console.KeyAvailable)
            return;

        // Lê a tecla sem exibi-la na tela.
        ConsoleKey tecla = Console.ReadKey(true).Key;

        // Envia a tecla para o foguete decidir o movimento.
        foguete.LerTecla(tecla);

        // Se o jogador apertar ESC, encerra a partida.
        if (tecla == ConsoleKey.Escape)
            rodando = false;
    }



    // Método responsável por atualizar todos os elementos do jogo.
    void Atualizar()
    {
        // Cria novos obstáculos.
        obstaculo.CriarObstaculo();

        // Move os obstáculos.
        obstaculo.Atualizar();

        // Cria novos poderes.
        powerUp.CriarPowerUp();

        // Move os poderes.
        powerUp.Atualizar();

        // Verifica colisões com obstáculos.
        VerificarColisao();

        // Verifica se algum poder foi coletado.
        VerificarPowerUp();

        // Atualiza o tempo restante dos buffs.
        sistema.AtualizarBuffs();

        // Atualiza o nível do jogador.
        sistema.AtualizarNivel();

        // Atualiza a velocidade conforme o nível.
        sistema.AtualizarVelocidade();

        VerificarFrase670();
    }



    // Método responsável por verificar colisões entre
    // o foguete e os obstáculos.
    void VerificarColisao()
    {
        // Percorre todos os obstáculos de trás para frente.
        // Isso evita erros ao remover itens da lista.
        for (int i = obstaculo.Obstaculos.Count - 1; i >= 0; i--)
        {
            // Guarda o obstáculo atual.
            var o = obstaculo.Obstaculos[i];

            // Verifica se o obstáculo está na mesma pista
            // e na posição do foguete.
            if (o.Pista == foguete.Pista &&
                o.Linha >= 21 &&
                o.Linha <= 24)
            {
                // Se o escudo estiver ativo,
                // ele protege o jogador.
                if (sistema.EscudoAtivo)
                {
                    // Consome o escudo.
                    sistema.EscudoAtivo = false;

                    // Remove o obstáculo que bateu.
                     obstaculo.Obstaculos.RemoveAt(i);

                    // Toca um som (opcional).
                    Som.TocarEscudo();
                }
                else 
                {
                    // Caso contrário, perde uma vida.
                    sistema.PerderVida();

                    // Remove o obstáculo atingido.
                    obstaculo.Obstaculos.RemoveAt(i);

                    // Verifica se acabaram as vidas.
                    if (sistema.Vidas <= 0)
                    {
                        // Salva o resultado da partida.
                        sistema.SalvarResultado();
                        // Mostra a tela "Você Perdeu"
                        TelaPerdeu();
                        // Encerra o jogo.
                        rodando = false;

                        return;
                    }
                    else
                    {
                        // Ainda possui vidas, então toca o som de colisão.
                        Som.TocarColisao(sistema.DanosRecebidos);
                    }
                }
            }

            // Caso o obstáculo tenha saído da tela,
            // o jogador ganha pontos.
            else if (o.Linha > 24)
            {
                sistema.SomarPontos();

                // Remove o obstáculo que saiu da pista.
                obstaculo.Obstaculos.RemoveAt(i);
            }
        }
    }
    void TelaPerdeu()
    {
        // Para a música de fundo
        Som.Parar();

        // Limpa a tela
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine();
        Console.WriteLine("=======================================");
        Console.WriteLine("            VOCÊ PERDEU :(");
        Console.WriteLine("=======================================");

        Console.ResetColor();

        // Toca o som de derrota
        Som.TocarGameOver();

        Thread.Sleep(3000);

        // Limpa qualquer tecla pressionada durante os 3 segundos
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }

        GameOver();
    }


    // Método responsável por exibir a tela de fim de jogo.
    void GameOver()
    {
        // Para a música de fundo.
        Som.Parar();

        // Limpa a tela.
        Console.Clear();

        // Exibe o título.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║               FIM DE JOGO                  ║");
        Console.WriteLine("╠════════════════════════════════════════════╣");

        // Exibe a pontuação final.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"║ Pontuação final: {sistema.Pontos:D6}                    ║");

        // Exibe o nível alcançado.
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"║ Nível alcançado: {sistema.Nivel:D3}                       ║");

        // Exibe a quantidade de obstáculos desviados.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"║ Obstáculos desviados: {sistema.ObstaculosDesviados:D3}                  ║");

        // Exibe o recorde.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"║ Recorde: {SistemaJogo.Recorde:D6}                            ║");

        // Mensagem para voltar ao menu.
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("║                                            ║");
        Console.WriteLine("║ Pressione qualquer tecla para voltar       ║");
        Console.WriteLine("║ ao menu principal.                         ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        Console.ResetColor();

        // Aguarda o jogador pressionar uma tecla.
        // Limpa todas as teclas que ficaram pressionadas
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");

        // Limpa as teclas que ficaram pressionadas durante o jogo
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }

        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para voltar ao menu.");

        ConsoleKey tecla;

        do
        {
            tecla = Console.ReadKey(true).Key;
        }
        while (tecla != ConsoleKey.Enter);
    }



    // Verifica se o jogador coletou algum PowerUp.
    void VerificarPowerUp()
    {
        // Percorre a lista de trás para frente.
        for (int i = powerUp.PowerUps.Count - 1; i >= 0; i--)
        {
            var p = powerUp.PowerUps[i];

            // Verifica se o poder está na mesma pista
            // e na posição do foguete.
            if (p.Pista == foguete.Pista &&
                p.Linha >= 21 &&
                p.Linha <= 24)
            {
                switch (p.Tipo)
                {
                    // Vida extra.
                    case 0:
                        sistema.Vidas++;

                        Som.TocarPowerUp();
                        break;

                    // Escudo.
                    case 1:
                        sistema.EscudoAtivo = true;

                        Som.TocarEscudo();
                        break;

                    // Pontos dobrados.
                    case 2:
                        sistema.PontosDobrados = true;

                        // Duração do buff (10 segundos).
                        sistema.TempoPontosDobrados = 100;

                        Som.TocarPontos();
                        break;
                }

                // Remove o PowerUp após ser coletado.
                powerUp.PowerUps.RemoveAt(i);
            }
        }
    }



    // Exibe os buffs ativos na tela.
    void MostrarBuffs()
    {
        Console.WriteLine("");
        Console.SetCursorPosition(42, 11);
        Console.WriteLine("BUFFS:");

        // Escudo ativo.
        if (sistema.EscudoAtivo)
        {
            Console.SetCursorPosition(42, 12);
            Console.WriteLine("🛡 Escudo");
        }

        // Pontos dobrados ativos.
        if (sistema.PontosDobrados)
        {
            Console.SetCursorPosition(42, 12);
            Console.WriteLine($"$ x2 ({sistema.TempoPontosDobrados / 10}s)");
        }

        // Nenhum buff ativo.
        if (!sistema.EscudoAtivo && !sistema.PontosDobrados)
        {
            Console.SetCursorPosition(42, 12);
            Console.WriteLine("Nenhum ativo no momento.");

            Console.SetCursorPosition(42, 14);
            Console.WriteLine("Boa Sorte!");
        }
    }
}