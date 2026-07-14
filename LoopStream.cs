using NAudio.Wave;


// Classe responsável por fazer um áudio tocar em repetição.
// Ela herda de WaveStream para criar um fluxo de áudio personalizado.
public class LoopStream : WaveStream
{
    // Guarda o áudio original que será repetido.
    private readonly WaveStream sourceStream;


    // Construtor da classe.
    // Recebe o áudio que será colocado em loop.
    public LoopStream(WaveStream source)
    {
        // Armazena o áudio recebido na variável da classe.
        sourceStream = source;
    }


    // Retorna o formato do áudio original.
    // Mantém as mesmas configurações de som do arquivo original.
    public override WaveFormat WaveFormat => sourceStream.WaveFormat;


    // Retorna o tamanho total do áudio.
    public override long Length => sourceStream.Length;


    // Controla a posição atual da reprodução do áudio.
    public override long Position
    {
        // Retorna a posição atual do áudio.
        get => sourceStream.Position;

        // Define uma nova posição para o áudio.
        set => sourceStream.Position = value;
    }


    // Método responsável por ler os dados do áudio.
    // Ele modifica o comportamento padrão para que o áudio reinicie
    // automaticamente quando chegar ao final.
    public override int Read(byte[] buffer, int offset, int count)
    {
        // Guarda a quantidade de bytes já lidos.
        int totalBytesRead = 0;


        // Continua lendo enquanto ainda faltar dados para preencher o buffer.
        while (totalBytesRead < count)
        {
            // Lê uma parte do áudio original.
            int bytesRead = sourceStream.Read(
                buffer,
                offset + totalBytesRead,
                count - totalBytesRead
            );


            // Verifica se chegou ao final do áudio.
            if (bytesRead == 0)
            {
                // Volta para o início do áudio,
                // fazendo ele começar novamente.
                sourceStream.Position = 0;
            }
            else
            {
                // Soma a quantidade de bytes lidos.
                totalBytesRead += bytesRead;
            }
        }


        // Retorna a quantidade total de dados lidos.
        return totalBytesRead;
    }
}