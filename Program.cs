using System;
using System.Text;


// Classe principal do programa.
// É o ponto inicial de execução do jogo.
class Program
{

    // Método principal.
    // Tudo começa a partir daqui.
    static void Main()
    {

        // Permite que o console mostre corretamente caracteres especiais.
        // Necessário para símbolos como:
        // ♥  🛡️  ☄  ✦
        Console.OutputEncoding = Encoding.UTF8;


        // Permite receber corretamente entradas com caracteres especiais.
        Console.InputEncoding = Encoding.UTF8;



        // Verifica se o sistema operacional é Windows.
        // As configurações de tamanho da janela só serão aplicadas nesse caso.
        if (OperatingSystem.IsWindows())
        {

            // Define a altura da janela do console.
            Console.WindowHeight = 30;


            // Define a largura da janela do console.
            Console.WindowWidth = 80;


            // Define a altura máxima do buffer.
            // Permite que o console tenha mais linhas disponíveis.
            Console.BufferHeight = 200;


            // Define a largura máxima do buffer.
            Console.BufferWidth = 100;
        }



        // Cria uma nova instância do menu.
        Menu menu = new Menu();



        // Inicia a exibição do menu principal.
        // A partir daqui o jogador escolhe o que fazer.
        menu.Exibir();
    }
}