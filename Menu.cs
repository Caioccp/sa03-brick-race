using System;

public class Menu
{
    public void Exibir()
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║             SPACE RUN              ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╠════════════════════════════════════╣");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║ 1 - Iniciar jogo                   ║");
            Console.WriteLine("║ 2 - Instruções                     ║");
            Console.WriteLine("║ 3 - Último resultado               ║");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ 0 - Sair                           ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚════════════════════════════════════╝");

            Console.ResetColor();

            Console.Write("\nEscolha: ");

            string? entrada = Console.ReadLine();


            if (!int.TryParse(entrada, out opcao))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida!");
                Console.ResetColor();

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Jogo jogo = new Jogo();
                    jogo.Iniciar();
                    break;

                case 2:
                    MostrarInstrucoes();
                    break;

                case 3:
                    MostrarResultado();
                    break;

                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Saindo...");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida!");
                    Console.ResetColor();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadKey(true);
                    break;
            }

        } while (opcao != 0);
    }

    void MostrarInstrucoes()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== INSTRUÇÕES =====");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("- Desvie dos obstáculos.");
        Console.WriteLine("- Use A ou ← para mover para a esquerda.");
        Console.WriteLine("- Use D ou → para mover para a direita.");
        Console.WriteLine("- Você possui 3 vidas.");
        Console.WriteLine("- Ao perder todas as vidas, o jogo termina.");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPressione ENTER para voltar...");

        Console.ResetColor();
        Console.ReadKey(true);
    }

    void MostrarResultado()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===== ÚLTIMO RESULTADO =====\n");

        if (!SistemaJogo.ExisteResultado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhuma partida foi realizada.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Pontuação........: {SistemaJogo.UltimaPontuacao}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Nível............: {SistemaJogo.UltimoNivel}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Obstáculos.......: {SistemaJogo.UltimosObstaculos}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Recorde..........: {SistemaJogo.Recorde}");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPressione ENTER para voltar...");

        Console.ResetColor();
        Console.ReadKey(true);
    }
}