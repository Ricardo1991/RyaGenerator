using System;

namespace RyaGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RyaGenerator ryaGenerator = null;
            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("1 - Create rya file from HexChat log");
                Console.WriteLine("2 - Load rya file");
                Console.WriteLine("3 - Generate rya saying");
                Console.WriteLine("4 - Exit");
                Console.Write("\nOption: ");

                string result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                        Console.Write("File Path: ");
                        result = Console.ReadLine();
                        RyaGenerator.hexLogToRya(result);
                        break;

                    case "2":
                        ryaGenerator = new RyaGenerator();
                        bool loaded = ryaGenerator.loadRyaFile();
                        if (loaded) Console.WriteLine("File Loaded!");
                        break;

                    case "3":
                        if (ryaGenerator != null)
                        {
                            string ryaS = ryaGenerator.getRandomRya();
                            Console.WriteLine("\n" + ryaS);
                        }
                        break;

                    case "4":
                        exit = true;
                        break;
                }

                Console.Write("\n");
            }
        }
    }
}