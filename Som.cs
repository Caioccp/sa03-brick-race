using System;
using System.Runtime.InteropServices;

public static class Som
{
    [DllImport("winmm.dll")]
    private static extern bool PlaySound(
        string? pszSound,
        IntPtr hmod,
        uint fdwSound);

    private const uint SND_ASYNC = 0x0001;
    private const uint SND_LOOP = 0x0008;
    private const uint SND_FILENAME = 0x00020000;

    public static void Iniciar()
    {
        PlaySound(
            @"Assets\musicadefundo.wav",
            IntPtr.Zero,
            SND_ASYNC | SND_LOOP | SND_FILENAME);
    }

    public static void Parar()
    {
        PlaySound(null, IntPtr.Zero, 0);
    }

    public static void TocarColisao(int danosRecebidos)
    {
        string arquivo;

        switch (danosRecebidos)
        {
            case 1:
                arquivo = @"Assets\vida3.wav";
                break;

            case 2:
                arquivo = @"Assets\vida2.wav";
                break;

            default:
                arquivo = @"Assets\vida1.wav";
                break;
        }

        // Toca o efeito sonoro
        PlaySound(
            arquivo,
            IntPtr.Zero,
            SND_ASYNC | SND_FILENAME);
    }
}