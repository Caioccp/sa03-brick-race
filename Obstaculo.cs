using System;
using System.Collections.Generic;


// Classe responsável pelo controle dos obstáculos do jogo.
// Ela cria, movimenta, desenha e remove os obstáculos da pista.
public class Obstaculo
{

    // Lista que guarda todos os obstáculos existentes na tela.
    // Cada obstáculo possui:
    // Linha = posição vertical
    // Pista = lado da pista (0 esquerda / 1 direita)
    // Tipo = aparência do obstáculo
    public List<(int Linha, int Pista, int Tipo)> Obstaculos { get; private set; }


    // Gerador de números aleatórios usado para escolher pistas e tipos.
    private Random random = new Random();


    // Guarda a altura limite da tela do jogo.
    private int alturaTela;


    // Guarda o último tipo de obstáculo criado.
    // Usado para evitar repetição seguida.
    private int ultimoTipo = -1;


    // Guarda a última pista utilizada.
    // Usado para variar a posição dos obstáculos.
    private int ultimaPista = -1;




    // Construtor da classe Obstaculo.
    // Recebe o tamanho vertical da tela.
    public Obstaculo(int alturaTela)
    {
        // Salva a altura da tela.
        this.alturaTela = alturaTela;


        // Cria uma nova lista vazia de obstáculos.
        Obstaculos = new List<(int, int, int)>();
    }




    // Método responsável por criar novos obstáculos.
    public void CriarObstaculo()
    {

        // Verifica se já existe algum obstáculo muito próximo.
        // Caso exista, evita criar outro para não ficar impossível.
        foreach (var obstaculo in Obstaculos)
        {
            if (obstaculo.Linha < 11)
                return;
        }



        // Variável que vai guardar a pista escolhida.
        int pista;



        // Caso seja o primeiro obstáculo criado,
        // escolhe uma pista aleatória.
        if (ultimaPista == -1)
        {
            pista = random.Next(0, 2);
        }

        else
        {

            // 75% de chance de trocar de pista.
            // Isso deixa os obstáculos mais variados.
            if (random.Next(100) < 75)
                pista = 1 - ultimaPista;


            // 25% de chance de continuar na mesma pista.
            else
                pista = ultimaPista;
        }


        // Guarda a última pista utilizada.
        ultimaPista = pista;




        // Variável que guarda o tipo do obstáculo.
        int tipo;



        // Escolhe um tipo aleatório de obstáculo.
        // O loop impede que o mesmo tipo apareça duas vezes seguidas.
        do
        {
            tipo = random.Next(0, 4);

        }
        while (tipo == ultimoTipo);



        // Salva o último tipo criado.
        ultimoTipo = tipo;




        // Calcula se existe espaço suficiente para criar outro obstáculo.
        int espaco = CalcularEspacoLivre(0);



        // Só cria o obstáculo se houver espaço suficiente.
        if (espaco > 5)
        {

            // Adiciona o novo obstáculo na lista.
            // Ele começa na linha 3 da pista escolhida.
            Obstaculos.Add((3, pista, tipo));
        }
    }





    // Método responsável por movimentar os obstáculos para baixo.
    public void Atualizar()
    {

        // Percorre todos os obstáculos existentes.
        for (int i = 0; i < Obstaculos.Count; i++)
        {

            // Atualiza a posição vertical do obstáculo.
            // Aumenta a linha para ele descer.
            Obstaculos[i] = (
                Obstaculos[i].Linha + 1,
                Obstaculos[i].Pista,
                Obstaculos[i].Tipo
            );
        }



        // Remove obstáculos que saíram da tela.
        Obstaculos.RemoveAll(o => o.Linha > alturaTela);
    }





    // Método responsável por desenhar os obstáculos na tela.
    public void Desenhar()
    {

        // Define a cor vermelha dos obstáculos.
        Console.ForegroundColor = ConsoleColor.Red;



        // Percorre todos os obstáculos existentes.
        foreach (var obstaculo in Obstaculos)
        {

            // Define a coluna dependendo da pista.
            // Pista 0 = esquerda
            // Pista 1 = direita
            int x = obstaculo.Pista == 0 ? 8 : 26;



            // Posiciona o cursor no local do obstáculo.
            Console.SetCursorPosition(
                x,
                obstaculo.Linha
            );



            // Escolhe qual desenho será usado.
            switch (obstaculo.Tipo)
            {

                // Tipo 0.
                case 0:
                    Console.Write("[☄]");
                    break;


                // Tipo 1.
                case 1:
                    Console.Write("<^>");
                    break;


                // Tipo 2.
                case 2:
                    Console.Write("<✦>");
                    break;


                // Tipo 3.
                case 3:
                    Console.Write("(◉)");
                    break;
            }
        }



        // Retorna a cor padrão do console.
        Console.ResetColor();
    }





    // Método recursivo que calcula o espaço livre da pista.
    // Ele conta quantas linhas ainda estão disponíveis.
    public int CalcularEspacoLivre(int linha)
    {

        // Quando chega no final da tela,
        // retorna 0 porque não existe mais espaço.
        if (linha >= alturaTela)
            return 0;



        // Soma 1 e chama o método novamente
        // passando a próxima linha.
        return 1 + CalcularEspacoLivre(linha + 1);
    }
}