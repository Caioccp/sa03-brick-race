using System.Collections.Generic;
using NAudio.Wave;

public static class Som
{
    private static WaveOutEvent? musicaSaida;
    private static AudioFileReader? musica;

    // Guarda os sons para eles não serem apagados antes de terminar
    private static List<WaveOutEvent> sons = new List<WaveOutEvent>();


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

        TocarEfeito(arquivo);
    }
        public static void TocarPowerUp()
        {
            TocarEfeito(@"Assets\escudo.wav");
        }
    public static void TocarEscudo()
    {
        TocarEfeito(@"Assets\escudo.wav");
    }


    private static void TocarEfeito(string arquivo)
    {
        var leitor = new AudioFileReader(arquivo);
        var saida = new WaveOutEvent();

        saida.Init(leitor);

        sons.Add(saida);

        saida.Play();

        saida.PlaybackStopped += (s, e) =>
        {
            saida.Dispose();
            leitor.Dispose();

            sons.Remove(saida);
        };
    }
    public static void TocarPontos()
{
    TocarEfeito(@"Assets\pontos.wav");
}
}