using System;
using System.Collections.Generic;
using System.Numerics;

namespace LabbUppgift
{
    class Program
    {


        static void Main(string[] args)
        {
            string PreDeterment = "29535123p48723487597645723645"; // Default value to be used
            string StringWithNumbers = "29535123p48723487597645723645"; // Will change according to user input



            byte MenuChoice = 0;
            BigInteger Total = 0; // Will contain all numbercombinations added

            int SearchIndex; // Is used to return an index to search for or -1
            string LetterSearch; // Is used to search for letters in the substring

            //--------------------------------------------------------------------------------------
            //----------------------------/MenuChoices/-----------------------------------------
            //--------------------------------------------------------------------------------------
            while (MenuChoice != 4)
            {

                MenuChoice = Menu();
                switch (MenuChoice)
                {
                    case 1: //Predetermend
                        Console.Clear();
                        Console.WriteLine($"Förprogrammerad sträng : {PreDeterment} ");
                        Console.WriteLine();
                        break;
                    case 2://User determend
                        Console.Write("Mata in värde/sträng(OBS decimaltal kommer ej räknas som decimaler): ");
                        StringWithNumbers = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Din sträng blev: {StringWithNumbers}");
                        Console.WriteLine();
                        break;
                    case 3://Randomgenerated
                        StringWithNumbers = RandomGenerator();
                        Console.Clear();
                        Console.WriteLine($"Den slumpgenererade strängen blev: {StringWithNumbers}");
                        Console.WriteLine();
                        break;
                    case 4://Exit Application
                        Environment.Exit(0);
                        break;

                }

                //-------------------------------------------------------------------------------------
                //--------------------/MainProgram/----------------------------------------------------
                //-------------------------------------------------------------------------------------
                
                for (int i = 0; i < StringWithNumbers.Length; i++)
                {

                    if (Char.IsDigit(StringWithNumbers[i]))
                    {
                        SearchIndex = StringWithNumbers.IndexOf(StringWithNumbers[i], i + 1);
                        if (SearchIndex > 0)
                        {
                            LetterSearch = StringWithNumbers.Substring(i, SearchIndex + 1 - i);
                        }
                        else
                        {
                            LetterSearch = "";
                        }

                        if (SearchIndex > 0 && ContainLetter(LetterSearch))
                        {

                            Total += ulong.Parse(StringWithNumbers.Substring(i, SearchIndex + 1 - i));


                            // This will print the currently checked and approved substrings and numbers
                            Console.Write(StringWithNumbers.Substring(0, i));
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(StringWithNumbers.Substring(i, SearchIndex + 1 - i));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(StringWithNumbers.Substring(SearchIndex + 1));

                        }
                    }
                }
                // Prints the added sum of all numbers
                Console.WriteLine("");
                Console.WriteLine($"Om man adderar alla utvalda sifferkombinationer så får man slutsumman: {Total}");
                Console.WriteLine("Vänligen Tryck på en knapp. . .");
                Console.ReadLine();
                Total = 0;
                Console.Clear();

            }




            //------------------------------------------------------------------------------------
            //----------------------------/End of Main program/-------------------------------
            //------------------------------------------------------------------------------------





        }
        //-----------/Search the string for letters/------------
        static bool ContainLetter(string ToSearch)
        {
            for (int i = 0; i < ToSearch.Length; i++)
            {
                int NrTest = 0;
                while (!int.TryParse(ToSearch[i].ToString(), out NrTest))
                {
                    return false;
                }


            }

            return true;
        }

        //-----------/Menu/---------------------
        static byte Menu()
        {

            byte MenuChoice = 20;
           
            do
            {
                Console.WriteLine("Välkommen till AutoSorter 3000\n");
                Console.WriteLine("Vänligen gör ett val\n");
                Console.WriteLine("[1] Använd ett förbestämt värde");
                Console.WriteLine("[2] Ändra förbestämt värde");
                Console.WriteLine("[3] Använd ett slumpgenererat värde");
                Console.WriteLine();
                Console.WriteLine("[4] Avsluta Program");

                while (!byte.TryParse(Console.ReadLine(), out MenuChoice) || MenuChoice >= 5 || MenuChoice <= 0)
                {

                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett korrekt alternativ!");
                    Console.WriteLine("Tryck på en knapp");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                }

                if (MenuChoice > 0 && MenuChoice < 5)
                {
                    break;
                }


            } while (true);



            return MenuChoice;




        }



        //-----------/Will randomgenerate numbers and length och the substrings and also random char caracter/----------
        static string RandomGenerator()
        {
            Console.Write("Vänligen ange den minsta längden du vill ha (Minsta längden är minst 5 oavsett): ");
            byte Length = 0;
            while (!byte.TryParse(Console.ReadLine(), out Length))
            {
                Console.WriteLine("Vänligen använd endast siffror (1-70): ");
            }
            while (Length > 70)
            {
                Console.WriteLine("Vänligen använd inte ett störe tal än 70");
                while (!byte.TryParse(Console.ReadLine(), out Length))
                {
                    Console.WriteLine("Använd ENDAST SIFFROR som är MELLAN 1-70");

                }
            }

            string RandomGeneratedString = "";
            int SubString = 0; // Length of substrings


            Random rnd = new Random();

            do
            {
                SubString = rnd.Next(4, 16); // No use in lowering start value

                for (int i = 0; i < SubString; i++)
                {

                    RandomGeneratedString += rnd.Next(1, 10).ToString();

                }
                RandomGeneratedString += (char)rnd.Next(65, 123); //Will always be added to break of sections of substrings, can be removed if neccecery 

            } while (RandomGeneratedString.Length < Length);
            return RandomGeneratedString;
        }



    }
}
