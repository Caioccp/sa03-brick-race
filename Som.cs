// Importa a biblioteca responsável por tocar sons (.wav)
using System.Media;

// Importa ferramentas para trabalhar com caminhos de arquivos
using System.IO;

// Classe responsável por controlar todos os sons do jogo
public static class Som
{
    // Variável que irá guardar o nosso "tocador de música"
    // O '?' significa que ela pode começar sem nenhum valor (null)
    private static SoundPlayer? musica;

    // Método para iniciar a música de fundo
    public static void IniciarMusica()
    {
        // Monta automaticamente o caminho onde está o arquivo musica.wav
        // Exemplo:
        // C:\Projeto\bin\Debug\net8.0\Assets\musica.wav
        string caminho = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Assets",
            "musica.wav"
        );

        // Cria um novo tocador de música e informa qual arquivo será reproduzido
        musica = new SoundPlayer(caminho);

        // Carrega o arquivo na memória
        // (deixa tudo preparado antes de tocar)
        musica.Load();

        // Começa a tocar a música.
        // Quando ela terminar, ela reinicia automaticamente.
        musica.PlayLooping();
    }

    // Método para parar a música
    public static void PararMusica()
    {
        // Verifica se realmente existe uma música carregada
        // para evitar erros.
        if (musica != null)
        {
            // Para a reprodução imediatamente
            musica.Stop();

            // Libera a memória utilizada pelo SoundPlayer
            musica.Dispose();

            // Remove a referência ao objeto
            // Agora "musica" volta a não guardar nada.
            musica = null;
        }
    }
}