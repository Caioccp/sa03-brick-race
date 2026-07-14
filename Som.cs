using System.Collections.Generic;
using NAudio.Wave;


// Classe responsável por controlar todos os sons do jogo.
// Controla música de fundo e efeitos sonoros.
public static class Som
{

    // Guarda o objeto responsável pela reprodução da música.
    private static WaveOutEvent? musicaSaida;


    // Guarda o arquivo da música carregada.
    private static AudioFileReader? musica;



    // Lista que mantém os sons ativos na memória.
    // Evita que os efeitos sejam apagados antes de terminar.
    private static List<WaveOutEvent> sons = new List<WaveOutEvent>();





    // Inicia a música de fundo do jogo.
    public static void Iniciar()
    {

        // Verifica se a música já está tocando.
        // Evita iniciar várias músicas ao mesmo tempo.
        if (musicaSaida != null)
            return;



        // Carrega o arquivo da música.
        musica = new AudioFileReader(@"Assets\musicadefundo.wav");


        // Cria o objeto responsável pela saída do áudio.
        musicaSaida = new WaveOutEvent();



        // Coloca a música dentro do LoopStream.
        // Isso faz ela repetir automaticamente.
        musicaSaida.Init(new LoopStream(musica));



        // Começa a reprodução.
        musicaSaida.Play();
    }





    // Para a música de fundo.
    public static void Parar()
    {

        // Para a reprodução da música.
        musicaSaida?.Stop();


        // Libera a memória usada pelo áudio.
        musicaSaida?.Dispose();
        musica?.Dispose();



        // Limpa as referências.
        musicaSaida = null;
        musica = null;
    }





    // Toca o som quando o jogador bate em um obstáculo.
    public static void TocarColisao(int danosRecebidos)
    {

        // Guarda o arquivo de som que será usado.
        string arquivo;



        // Escolhe o som baseado na quantidade de danos.
        switch (danosRecebidos)
        {

            // Caso seja o primeiro dano.
            case 1:

                arquivo = @"Assets\vida2.wav";

                break;



            // Outros casos usam o som padrão.
            default:

                arquivo = @"Assets\vida1.wav";

                break;
        }



        // Executa o efeito sonoro escolhido.
        TocarEfeito(arquivo);
    }





    // Toca o som de pegar um PowerUp.
    public static void TocarPowerUp()
    {
        TocarEfeito(@"Assets\recuperarVida.wav");
    }





    // Toca o som específico do escudo.
    public static void TocarEscudo()
    {
        TocarEfeito(@"Assets\escudo.wav");
    }





    // Método privado responsável por executar qualquer efeito sonoro.
    private static void TocarEfeito(string arquivo)
    {

        // Carrega o arquivo de áudio.
        var leitor = new AudioFileReader(arquivo);



        // Cria um novo reprodutor de áudio.
        var saida = new WaveOutEvent();



        // Inicializa o áudio.
        saida.Init(leitor);



        // Adiciona o som na lista para manter ele ativo.
        sons.Add(saida);



        // Começa a reprodução.
        saida.Play();




        // Quando o som terminar:
        // - libera memória
        // - remove da lista de sons ativos
        saida.PlaybackStopped += (s, e) =>
        {

            // Libera o reprodutor.
            saida.Dispose();


            // Libera o arquivo de áudio.
            leitor.Dispose();



            // Remove o som finalizado da lista.
            sons.Remove(saida);
        };
    }





    // Toca o som quando o jogador recebe pontos.
    public static void TocarPontos()
    {
        TocarEfeito(@"Assets\pontos.wav");
    }

    // Toca o som de Game Over.
    public static void TocarGameOver()
    {
        TocarEfeito(@"Assets\gameover.wav");
    }
}