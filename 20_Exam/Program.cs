﻿using _20_Exam;
using System.Text;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Game game = new Game();
        game.Run();
    }
}
