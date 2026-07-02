using System;

public class Carro
{
    public int Pista { get; private set; }

    public Carro()
    {
        Pista = 0;
    }

    public void MoverEsquerda()
    {
        Pista = 0;
    }

    public void MoverDireita()
    {
        Pista = 1;
    }

    public void LerTecla(ConsoleKey tecla)
    {
        if (tecla == ConsoleKey.A || tecla == ConsoleKey.LeftArrow)
        {
            MoverEsquerda();
        }
        else if (tecla == ConsoleKey.D || tecla == ConsoleKey.RightArrow)
        {
            MoverDireita();
        }
    }
}