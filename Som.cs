using NAudio.Wave;

public static class Som
{
    private static WaveOutEvent? musicaSaida;
    private static AudioFileReader? musica;

    public static void Iniciar()
    {
        if (musicaSaida != null)
            return;

        musica = new AudioFileReader(@"Assets\musicadefundo.wav");
        musicaSaida = new WaveOutEvent();

        musicaSaida.Init(new LoopStream(musica));
        musicaSaida.Play();
    }

    public static void Parar()
    {
        musicaSaida?.Stop();
        musicaSaida?.Dispose();
        musica?.Dispose();

        musicaSaida = null;
        musica = null;
    }

    public static void TocarColisao(int danosRecebidos)
    {
        string arquivo;

        switch (danosRecebidos)
        {
            case 1:
                arquivo = @"Assets\vida2.wav";
                break;

            default:
                arquivo = @"Assets\vida1.wav";
                break;
        }

        var leitor = new AudioFileReader(arquivo);
        var saida = new WaveOutEvent();

        saida.Init(leitor);
        saida.Play();

        saida.PlaybackStopped += (s, e) =>
        {
            saida.Dispose();
            leitor.Dispose();
        };
    }
}