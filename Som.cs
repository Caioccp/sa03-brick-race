using NAudio.Wave;

public static class Som
{
    // Responsável por enviar o áudio para as caixas de som
    private static WaveOutEvent? saida;

    // Responsável por ler o arquivo .wav
    private static AudioFileReader? musica;

    public static void Iniciar()
    {
        // Abre o arquivo da música
        musica = new AudioFileReader("Assets/musica.wav");

        // Cria o reprodutor
        saida = new WaveOutEvent();

        // Liga a música ao reprodutor
        saida.Init(musica);

        // Quando a música terminar...
        saida.PlaybackStopped += ReiniciarMusica;

        // Começa a tocar
        saida.Play();
    }

    private static void ReiniciarMusica(object? sender, StoppedEventArgs e)
    {
        if (musica != null && saida != null)
        {
            // Volta para o início do arquivo
            musica.Position = 0;

            // Toca novamente
            saida.Play();
        }
    }

    public static void Parar()
    {
        saida?.Stop();

        musica?.Dispose();
        saida?.Dispose();

        musica = null;
        saida = null;
    }
}