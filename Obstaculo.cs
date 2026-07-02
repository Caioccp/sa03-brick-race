using System;
using System.Collections.Generic;

public class Obstaculo
{
    // Linha, pista e tipo do obstáculo
    public List<(int Linha, int Pista, int Tipo)> Obstaculos { get; private set; }

    private Random random = new Random();

    private int alturaTela;

    // Não repetir o mesmo obstáculo
    private int ultimoTipo = -1;

    // Alternar entre as pistas
    private int ultimaPista = -1;

    public Obstaculo(int alturaTela)
    {
        this.alturaTela = alturaTela;
        Obstaculos = new List<(int, int, int)>();
    }

    // Cria um novo obstáculo
    public void CriarObstaculo()
    {
        // Só cria outro quando o último já desceu um pouco
        foreach (var obstaculo in Obstaculos)
        {
            if (obstaculo.Linha < 5)
                return;
        }

        // Alterna as pistas para nunca bloquear as duas
        int pista;

        do
        {
            pista = random.Next(0, 2);
        }
        while (pista == ultimaPista);

        ultimaPista = pista;

        // Escolhe um obstáculo diferente do último
        int tipo;

        do
        {
            tipo = random.Next(0, 4);
        }
        while (tipo == ultimoTipo);

        ultimoTipo = tipo;

        Obstaculos.Add((0, pista, tipo));
    }

    // Faz os obstáculos descerem
    public void Atualizar()
    {
        for (int i = 0; i < Obstaculos.Count; i++)
        {
            Obstaculos[i] =
            (
                Obstaculos[i].Linha + 1,
                Obstaculos[i].Pista,
                Obstaculos[i].Tipo
            );
        }

        // Remove quando sair da tela
        Obstaculos.RemoveAll(o => o.Linha > alturaTela);
    }

    // Desenha os obstáculos
    public void Desenhar()
    {
        foreach (var obstaculo in Obstaculos)
        {
            int x = obstaculo.Pista == 0 ? 5 : 15;

            Console.SetCursorPosition(x, obstaculo.Linha);

            switch (obstaculo.Tipo)
            {
                // Meteoro
                case 0:
                    Console.Write("[☄]");
                    break;

                // Nave alienígena
                case 1:
                    Console.Write("<^>");
                    break;

                // Estrela
                case 2:
                    Console.Write("<✦>");
                    break;

                // Buraco negro
                case 3:
                    Console.Write("(◉)");
                    break;
            }
        }
    }
}