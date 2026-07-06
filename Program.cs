<<<<<<< HEAD
﻿Console.Beep(1000, 500);

Menu menu = new Menu();
menu.Exibir();
=======
﻿
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
>>>>>>> 2a6c11eb00e6c185bd666c986ccc9f89e1eb45c7
