using System;
using System.Collections.Generic;

public class PowerUp
{
    public List<(int Linha, int Pista, int Tipo)> PowerUps { get; private set; }

    private Random random = new Random();
    private int alturaTela;

    public PowerUp(int alturaTela)
    {
        this.alturaTela = alturaTela;
        PowerUps = new List<(int, int, int)>();
    }

    public void CriarPowerUp()
    {
        if (PowerUps.Count > 0)
            return;

        if (random.Next(100) < 2) 
        {
            int pista = random.Next(0, 2);
            int tipo = random.Next(0, 3);

            PowerUps.Add((0, pista, tipo));
        }
    }

    public void Atualizar()
    {
        for (int i = 0; i < PowerUps.Count; i++)
        {
            PowerUps[i] = (
                PowerUps[i].Linha + 1,
                PowerUps[i].Pista,
                PowerUps[i].Tipo
            );
        }

        PowerUps.RemoveAll(p => p.Linha > 18);
    }

    public void Desenhar()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        foreach (var power in PowerUps)
        {
            int x = power.Pista == 0 ? 8 : 26;

            Console.SetCursorPosition(x, power.Linha);
            switch (power.Tipo)
            {
                case 0:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[♥]");
                break;

                case 1:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("[🛡️ ]");
                break;

                case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[$]");
                break;
            }
        }

        Console.ResetColor();
    }
}