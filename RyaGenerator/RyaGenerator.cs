using MarkovSharp.TokenisationStrategies;
using System;
using System.IO;

namespace RyaGenerator
{
    internal class RyaGenerator
    {
        private StringMarkov stringMarkov;

        private bool isReady = false;

        public bool loadRyaFile()
        {
            stringMarkov = new StringMarkov();

            if (File.Exists("TextFiles/rya.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader("TextFiles/rya.txt");
                    while (sr.Peek() >= 0)
                    {
                        string ryaL = sr.ReadLine().ToLower();
                        if (ryaL.Split().Length > 2)
                            stringMarkov.Learn(ryaL);
                    }

                    sr.Close();

                    isReady = true;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Reading File: " + ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
                return false;
            }
        }

        public string getRandomRya()
        {
            if (isReady)
                return stringMarkov.RebuildPhrase(stringMarkov.Walk());
            else return null;
        }

        public static void hexLogToRya(string filePath)
        {
            StreamWriter writter = new StreamWriter("TextFiles/rya.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    StreamReader sr = new StreamReader(filePath);
                    while (sr.Peek() >= 0)
                    {
                        string ryaL = sr.ReadLine();
                        string[] ryaSplit = ryaL.Split(new char[] { ' ' }, 4);

                        if (ryaSplit.Length > 3 && ryaSplit[3].ToLower().StartsWith("<rya>"))
                        {
                            writter.WriteLine(ryaSplit[3]);
                        }
                    }

                    sr.Close();
                    writter.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Reading File: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }
    }
}