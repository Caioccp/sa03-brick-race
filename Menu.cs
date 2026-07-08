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
        Console.WriteLine("║            BRICK RACE              ║");

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

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Escolha: ");
        Console.ResetColor();

        bool ok = int.TryParse(Console.ReadLine()!, out opcao);

        if (!ok)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida!");
            Console.ResetColor();
            Console.ReadKey();
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
                Console.WriteLine("Opção inválida!");
                Console.ResetColor();
                Console.ReadKey();
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
    Console.WriteLine("- Desvie dos obstáculos");
    Console.WriteLine("- Use A/D ou ← →");
    Console.WriteLine("- Você começa com 3 vidas");
    Console.WriteLine("- Cada colisão perde 1 vida");
    Console.WriteLine("- 0 vidas = fim de jogo");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nPressione qualquer tecla...");

    Console.ResetColor();
    Console.ReadKey();
}
   
    void MostrarResultado()
{
  Console.Clear();

    Console.WriteLine("===== ÚLTIMO RESULTADO =====");
    Console.WriteLine();

    if (!SistemaJogo.ExisteResultado)
    {
        Console.WriteLine("Nenhuma partida foi realizada.");
    }
    else
    {
        Console.WriteLine($"Pontuação........: {SistemaJogo.UltimaPontuacao}");
        Console.WriteLine($"Nível............: {SistemaJogo.UltimoNivel}");
        Console.WriteLine($"Obstáculos.......: {SistemaJogo.UltimosObstaculos}");
    }

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para voltar...");
    Console.ReadKey();
}
}