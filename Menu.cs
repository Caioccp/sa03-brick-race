using System;


// Classe responsável pelo menu principal do jogo.
// Controla as opções escolhidas pelo jogador.
public class Menu
{

    // Método responsável por exibir o menu e controlar a navegação.
    public void Exibir()
    {
        // Guarda a opção escolhida pelo jogador.
        int opcao;


        // Repete o menu até o jogador escolher a opção 0 (sair).
        do
        {
            // Limpa a tela antes de mostrar o menu novamente.
            Console.Clear();


            // Cria o cabeçalho do menu.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");


            // Nome do jogo.
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║             SPACE RUN              ║");


            // Linha separadora do menu.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╠════════════════════════════════════╣");


            // Opções principais do jogo.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║ 1 - Iniciar jogo                   ║");
            Console.WriteLine("║ 2 - Instruções                     ║");
            Console.WriteLine("║ 3 - Último resultado               ║");
            Console.WriteLine("║ 4 - Créditos                       ║");


            // Opção sair em vermelho para destacar.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ 0 - Sair                           ║");


            // Fecha o quadro do menu.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚════════════════════════════════════╝");


            // Retorna a cor padrão do console.
            Console.ResetColor();


            // Solicita a escolha do jogador.
            Console.Write("\nEscolha: ");


            // Lê a opção digitada pelo usuário.
            string? entrada = Console.ReadLine();



            // Verifica se a entrada realmente é um número.
            // Caso não seja, mostra mensagem de erro.
            if (!int.TryParse(entrada, out opcao))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida!");

                Console.ResetColor();

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                // Volta para o começo do menu.
                continue;
            }



            // Analisa qual opção foi escolhida.
            switch (opcao)
            {

                // Inicia uma nova partida.
                case 1:

                    // Cria uma nova partida do jogo.
                    Jogo jogo = new Jogo();

                    // Inicia o jogo.
                    jogo.Iniciar();

                    break;



                // Mostra as instruções do jogo.
                case 2:

                    MostrarInstrucoes();

                    break;



                // Mostra o último resultado salvo.
                case 3:

                    MostrarResultado();

                    break;

                // Mostra os créditos do jogo.
                case 4:

                    MostrarCreditos();

                    break;


                // Encerra o programa.
                case 0:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saindo...");

                    Console.ResetColor();

                    break;



                // Caso seja digitada uma opção que não existe.
                default:

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida!");

                    Console.ResetColor();

                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadKey(true);

                    break;
            }


        }
        // Enquanto a opção escolhida for diferente de 0,
        // o menu continua aparecendo.
        while (opcao != 0);
    }



    // Método responsável por mostrar as regras do jogo.
    // Método responsável por exibir as instruções do jogo.
    void MostrarInstrucoes()
    {
        // Limpa a tela.
        Console.Clear();

        // Exibe o título.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=========== INSTRUÇÕES ===========\n");

        // Exibe o objetivo do jogo.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("OBJETIVO:");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Desvie dos obstáculos trocando entre");
        Console.WriteLine("a pista esquerda e a pista direita.");
        Console.WriteLine();

        // Exibe os controles do jogo.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("CONTROLES:");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("A ou ←  = Mover para a esquerda");
        Console.WriteLine("D ou →  = Mover para a direita");
        Console.WriteLine("ESC     = Sair da partida");
        Console.WriteLine();

        // Exibe as regras da partida.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("REGRAS:");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("• Você começa com 3 vidas.");
        Console.WriteLine("• Cada obstáculo desviado vale pontos.");
        Console.WriteLine("• A velocidade aumenta conforme o nível.");
        Console.WriteLine("• Ao bater em um obstáculo, você perde uma vida.");
        Console.WriteLine("• Quando as vidas chegam a zero, a partida termina.");
        Console.WriteLine();

        // Exibe os Power-Ups disponíveis.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("POWER-UPS:");

        // Power-Up de vida.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("♥ Vida Extra");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Adiciona +1 vida ao jogador.");
        Console.WriteLine();

        // Power-Up de escudo.
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("🛡 Escudo");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Protege de uma colisão.");
        Console.WriteLine();

        // Power-Up de pontos dobrados.
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("$ Pontos em Dobro");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Dobra os pontos ganhos por 10 segundos.");
        Console.WriteLine();

        // Mensagem para voltar ao menu.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Pressione ENTER para voltar...");

        // Restaura a cor padrão do console.
        Console.ResetColor();

        // Aguarda o jogador pressionar uma tecla.
        Console.ReadKey(true);
    }





    // Método responsável por mostrar informações da última partida.
    void MostrarResultado()
    {
        Console.Clear();


        // Título da tela de resultados.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== ÚLTIMO RESULTADO =====\n");



        // Verifica se existe algum resultado salvo.
        if (!SistemaJogo.ExisteResultado)
        {
            // Caso nenhuma partida tenha sido jogada.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhuma partida foi realizada.");
        }
        else
        {

            // Mostra a pontuação final da última partida.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pontuação........: {SistemaJogo.UltimaPontuacao}");


            // Mostra o nível alcançado.
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Nível............: {SistemaJogo.UltimoNivel}");


            // Mostra quantos obstáculos foram desviados.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Obstáculos.......: {SistemaJogo.UltimosObstaculos}");


            // Mostra o maior recorde alcançado.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Recorde..........: {SistemaJogo.Recorde}");
        }



        // Mensagem para voltar ao menu.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPressione ENTER para voltar...");


        Console.ResetColor();

        Console.ReadKey(true);
    }
    // Método responsável por exibir os créditos do jogo.
void MostrarCreditos()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("============= CRÉDITOS =============\n");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("SPACE RUN");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Desenvolvedores:");

        //estamos utilizando vetores, ó
        string[] equipe =
        {
            "Luiza Triches",
            "Arthur Werlang",
            "Caua Schuh",
            "Caio Carniel"
        };

        Console.ForegroundColor = ConsoleColor.White;

        // Percorre o vetor e exibe cada integrante
        foreach (string integrante in equipe)
        {
            Console.WriteLine($"• {integrante}");
        }

        Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Curso: Técnico em Desenvolvimento de Sistemas");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Técnico em Desenvolvimento de Sistemas - 2026");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Professor:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Alisson Zimmer");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Tecnologias Utilizadas:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("IA Generativa (ChatGPT, Gemini)");
    Console.WriteLine("Programação em C#");
    Console.WriteLine("NAudio (Para utilização de efeitos sonoros)");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Projeto desenvolvido no SENAI");
    Console.WriteLine("Disciplina de Programação em C#");
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Obrigado por jogar!");
    Console.WriteLine();
    Console.WriteLine("Pressione ENTER para voltar ao menu.");

    Console.ResetColor();

    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
    {
    }
}
}