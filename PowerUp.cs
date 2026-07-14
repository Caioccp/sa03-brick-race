using System;
using System.Collections.Generic;


// Classe responsável pelo controle dos poderes do jogo.
// Ela cria, movimenta, desenha e remove os PowerUps.
public class PowerUp
{

    // Lista que guarda todos os poderes existentes na tela.
    // Cada poder possui:
    // Linha = posição vertical
    // Pista = lado da pista
    // Tipo = efeito do poder
    public List<(int Linha, int Pista, int Tipo)> PowerUps { get; private set; }



    // Usado para gerar valores aleatórios.
    private Random random = new Random();



    // Guarda a altura limite da tela.
    private int alturaTela;




    // Construtor da classe PowerUp.
    public PowerUp(int alturaTela)
    {
        // Salva o tamanho da tela.
        this.alturaTela = alturaTela;


        // Cria uma lista vazia de poderes.
        PowerUps = new List<(int, int, int)>();
    }





    // Método responsável por criar novos poderes.
    public void CriarPowerUp()
    {

        // Impede que apareça mais de um poder ao mesmo tempo.
        if (PowerUps.Count > 0)
            return;



        // Possui apenas 2% de chance de criar um poder.
        // Isso faz os poderes serem mais raros.
        if (random.Next(100) < 2)
        {

            // Escolhe uma pista aleatória.
            // 0 = esquerda
            // 1 = direita
            int pista = random.Next(0, 2);



            // Escolhe o tipo do poder:
            // 0 = vida
            // 1 = escudo
            // 2 = pontos dobrados
            int tipo = random.Next(0, 3);



            // Adiciona o poder na lista.
            // Ele começa no topo da tela.
            PowerUps.Add((0, pista, tipo));
        }
    }





    // Método responsável por movimentar os poderes para baixo.
    public void Atualizar()
    {

        // Percorre todos os poderes existentes.
        for (int i = 0; i < PowerUps.Count; i++)
        {

            // Aumenta a linha para fazer o poder descer.
            PowerUps[i] = (
                PowerUps[i].Linha + 1,
                PowerUps[i].Pista,
                PowerUps[i].Tipo
            );
        }



        // Remove poderes que passaram do limite da tela.
        PowerUps.RemoveAll(p => p.Linha > 18);
    }





    // Método responsável por desenhar os poderes na tela.
    public void Desenhar()
    {

        // Percorre todos os poderes existentes.
        foreach (var power in PowerUps)
        {

            // Define a posição horizontal dependendo da pista.
            // Pista 0 = esquerda
            // Pista 1 = direita
            int x = power.Pista == 0 ? 8 : 26;



            // Posiciona o cursor no local do poder.
            Console.SetCursorPosition(
                x,
                power.Linha
            );



            // Define o desenho e a cor dependendo do tipo.
            switch (power.Tipo)
            {

                // Poder de vida.
                case 0:

                    Console.ForegroundColor = ConsoleColor.Green;

                    // Representado por um coração.
                    Console.Write("[♥]");

                    break;



                // Poder de escudo.
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("[🛡]");
                    break;

                    Console.ForegroundColor = ConsoleColor.Blue;

                    // Representado por um escudo.
                    Console.Write("[🛡️ ]");

                    break;



                // Poder de pontos dobrados.
                case 2:

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    // Representado por dinheiro.
                    Console.Write("[$]");

                    break;
            }
        }



        // Retorna a cor padrão do console.
        Console.ResetColor();
    }
}