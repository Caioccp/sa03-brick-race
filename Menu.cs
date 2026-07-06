using System;
// Importa a biblioteca padrão do C#
// Ela permite usar Console, leitura de teclado, escrita na tela, etc.
using System; 

public class Menu
{
    public void Exibir()
    {
        int opcao;

        do
        {

            Console.Clear();

            Console.WriteLine("╔════════════════════════════════════╗");

            Console.WriteLine("║            BRICK RACE              ║");

            Console.WriteLine("╠════════════════════════════════════╣");

            Console.WriteLine("║ 1 - Iniciar jogo                   ║");

            Console.WriteLine("║ 2 - Instruções                     ║");

            Console.WriteLine("║ 3 - Último resultado               ║");

            Console.WriteLine("║ 0 - Sair                           ║");

            Console.WriteLine("╚════════════════════════════════════╝");


            Console.Write("Escolha: ");

            bool ok = int.TryParse(Console.ReadLine()!, out opcao);

            if (!ok)
            {
                Console.WriteLine("Opção inválida!");

                Console.ReadKey();

                continue;
            }

            switch (opcao)
            {

                case 1:

                    Jogo jogo = new Jogo();

                    jogo.Iniciar();

                    break;
                // Finaliza este caso do switch

                case 2:

                    MostrarInstrucoes();

                    break;
                // Encerra este caso

                case 3:

                    MostrarResultado();

                    break;
                // Encerra este caso

                case 0:

                    Console.WriteLine("Saindo...");

                    break;
                // Encerra este caso

                default:

                    Console.WriteLine("Opção inválida!");

                    Console.ReadKey();

                    break;
            }

        } while (opcao != 0);
    }

    void MostrarInstrucoes()
    {

        Console.Clear();

        Console.WriteLine("===== INSTRUÇÕES =====");

        Console.WriteLine("- Desvie dos obstáculos");

        Console.WriteLine("- Use A/D ou ← →");

        Console.WriteLine("- Você começa com 3 vidas");

        Console.WriteLine("- Cada colisão perde 1 vida");

        Console.WriteLine("- 0 vidas = fim de jogo");

        Console.WriteLine("\nPressione qualquer tecla...");

        Console.ReadKey();
    }

    void MostrarResultado()
    {

        Console.Clear();

        Console.WriteLine("===== ÚLTIMO RESULTADO =====");

        Console.WriteLine("Ainda não implementado.");

        Console.ReadKey();
    }
}