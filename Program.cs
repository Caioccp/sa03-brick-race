using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
            Console.WindowHeight = 30; 
            Console.WindowWidth = 80;
            Console.BufferHeight = 200;
            Console.BufferWidth = 100;
        Menu menu = new Menu();
        menu.Exibir();
    }
}
