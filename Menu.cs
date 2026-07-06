using System;
// Importa a biblioteca padrão do C#
// Ela permite usar Console, leitura de teclado, escrita na tela, etc.

public class Menu
{
    // Classe responsável por controlar todo o menu do jogo
    // Aqui o jogador escolhe iniciar, ver instruções, resultado ou sair

    // =========================
    // MÉTODO PRINCIPAL DO MENU
    // =========================
    public void Exibir()
    {
        // Método que exibe o menu e mantém ele rodando até o usuário sair

        int opcao;
        // Variável que guarda a escolha do usuário no menu

        do
        {
            // Loop do-while garante que o menu sempre reaparece após uma ação

            Console.Clear();
            // Limpa a tela do console para redesenhar o menu atualizado

            // =========================
            // DESENHO VISUAL DO MENU
            // =========================

            Console.WriteLine("╔════════════════════════════════════╗");
            // Imprime a borda superior do menu

            Console.WriteLine("║            BRICK RACE              ║");
            // Título do jogo dentro do menu

            Console.WriteLine("╠════════════════════════════════════╣");
            // Linha de separação visual

            Console.WriteLine("║ 1 - Iniciar jogo                   ║");
            // Opção 1: iniciar o jogo

            Console.WriteLine("║ 2 - Instruções                     ║");
            // Opção 2: mostrar regras e controles

            Console.WriteLine("║ 3 - Último resultado               ║");
            // Opção 3: mostrar último resultado jogado

            Console.WriteLine("║ 0 - Sair                           ║");
            // Opção 0: encerrar o programa

            Console.WriteLine("╚════════════════════════════════════╝");
            // Borda inferior do menu


            Console.Write("Escolha: ");
            // Solicita entrada do usuário

            bool ok = int.TryParse(Console.ReadLine()!, out opcao);
            // Lê o que o usuário digitou e tenta converter para número inteiro
            // TryParse evita erro caso o usuário digite texto inválido
            // "!" garante que não será nulo (safe operator)

            if (!ok)
            {
                // Se a conversão falhar (entrada inválida)

                Console.WriteLine("Opção inválida!");
                // Mostra mensagem de erro

                Console.ReadKey();
                // Espera o usuário pressionar uma tecla

                continue;
                // Volta para o início do loop do menu sem quebrar o programa
            }

            // =========================
            // CONTROLE DAS OPÇÕES
            // =========================

            switch (opcao)
            {
                // Estrutura que verifica qual opção o usuário escolheu

                case 1:
                    // Caso usuário escolha iniciar o jogo

                    Jogo jogo = new Jogo();
                    // Cria uma nova instância da classe Jogo

                    jogo.Iniciar();
                    // Chama o método que inicia o loop do jogo

                    break;
                // Finaliza este caso do switch

                case 2:
                    // Caso usuário escolha ver instruções

                    MostrarInstrucoes();
                    // Chama método que exibe regras do jogo

                    break;
                // Encerra este caso

                case 3:
                    // Caso usuário escolha ver último resultado

                    MostrarResultado();
                    // Chama método que exibe resultado (ainda simples)

                    break;
                // Encerra este caso

                case 0:
                    // Caso usuário escolha sair

                    Console.WriteLine("Saindo...");
                    // Mostra mensagem de encerramento

                    break;
                // Encerra este caso

                default:
                    // Caso usuário digite número que não existe no menu

                    Console.WriteLine("Opção inválida!");
                    // Mostra mensagem de erro

                    Console.ReadKey();
                    // Aguarda tecla para continuar

                    break;
                    // Finaliza o caso padrão
            }

        } while (opcao != 0);
        // O menu continua rodando enquanto a opção NÃO for 0
        // Quando for 0, o programa encerra o loop
    }

    // =========================
    // INSTRUÇÕES DO JOGO
    // =========================
    void MostrarInstrucoes()
    {
        // Método responsável por mostrar as regras do jogo

        Console.Clear();
        // Limpa a tela antes de mostrar instruções

        Console.WriteLine("===== INSTRUÇÕES =====");
        // Título da tela de instruções

        Console.WriteLine("- Desvie dos obstáculos");
        // Explica objetivo principal

        Console.WriteLine("- Use A/D ou ← →");
        // Explica controles do jogo

        Console.WriteLine("- Você começa com 3 vidas");
        // Explica regra inicial

        Console.WriteLine("- Cada colisão perde 1 vida");
        // Explica penalidade

        Console.WriteLine("- 0 vidas = fim de jogo");
        // Explica condição de derrota

        Console.WriteLine("\nPressione qualquer tecla...");
        // Instrução para voltar ao menu

        Console.ReadKey();
        // Espera o usuário apertar uma tecla
    }

    // =========================
    // RESULTADO DO JOGO
    // =========================
    void MostrarResultado()
    {
        // Método que mostra último resultado da partida

        Console.Clear();
        // Limpa a tela

        Console.WriteLine("===== ÚLTIMO RESULTADO =====");
        // Título da tela

        Console.WriteLine("Ainda não implementado.");
        // Mensagem temporária (vai ser substituída depois)

        Console.ReadKey();
        // Espera o usuário pressionar tecla para voltar ao menu
    }
}