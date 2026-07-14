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
    void MostrarInstrucoes()
    {
        Console.Clear();


        // Título das instruções.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== INSTRUÇÕES =====");


        // Texto explicando como jogar.
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("- Desvie dos obstáculos.");
        Console.WriteLine("- Use A ou ← para mover para a esquerda.");
        Console.WriteLine("- Use D ou → para mover para a direita.");
        Console.WriteLine("- Você possui 3 vidas.");
        Console.WriteLine("- Ao perder todas as vidas, o jogo termina.");



        // Mensagem para retornar ao menu.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPressione ENTER para voltar...");


        Console.ResetColor();

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
}