using System;
using System.Runtime.InteropServices;

public static class Som
{
    // Importa a função PlaySound da biblioteca do Windows
    [DllImport("winmm.dll")]
    private static extern bool PlaySound(
        string? pszSound,
        IntPtr hmod,
        uint fdwSound);

    // Constantes que dizem como o som deve tocar
    private const uint SND_ASYNC = 0x0001; // Toca sem travar o jogo
    private const uint SND_LOOP = 0x0008;  // Repete infinitamente
    private const uint SND_FILENAME = 0x00020000; // O parâmetro é um arquivo

    // Inicia a música
    public static void Iniciar()
    {
        PlaySound(
            @"Assets\musicadefundo.wav",
            IntPtr.Zero,
            SND_ASYNC | SND_LOOP | SND_FILENAME);
    }

    // Para a música
    public static void Parar()
    {
        // Passando null faz o Windows parar qualquer música iniciada pelo PlaySound
        PlaySound(null, IntPtr.Zero, 0);
    }
}