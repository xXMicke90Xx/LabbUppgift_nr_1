using System;
using System.Collections.Generic;
using System.Numerics;

namespace LabbUppgift
{
    class Program
    {


        static void Main(string[] args)
        {
            string preDefined = "29535123p48723487597645723645"; // Default value to be used
            string userDefined = "29535123p48723487597645723645"; // Will change according to user input
            byte menuChoice = 0;
            BigInteger totalSumOfNumbers = 0; // Will contain all numbercombinations added

            int searchIndex; // Is used to return an index to search for or -1
            string letterSearch; // Is used to search for letters in the substring

            //--------------------------------------------------------------------------------------
            //----------------------------/MenuChoices/-----------------------------------------
            //--------------------------------------------------------------------------------------
            while (menuChoice != 4)
            {

                menuChoice = Menu();
                switch (menuChoice)
                {
                    case 1: //Predetermend
                        Console.Clear();
                        Console.WriteLine($"Förprogrammerad sträng : {preDefined} ");
                        Console.WriteLine();
                        break;
                    case 2://User determend
                        Console.Write("Mata in värde/sträng(OBS decimaltal kommer ej räknas som decimaler): ");
                        userDefined = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Din sträng blev: {userDefined}");
                        Console.WriteLine();
                        break;
                    case 3://Randomgenerated
                        userDefined = RandomGenerator();
                        Console.Clear();
                        Console.WriteLine($"Den slumpgenererade strängen blev: {userDefined}");
                        Console.WriteLine();
                        break;
                    case 4://Exit Application
                        Environment.Exit(0);
                        break;

                }

                //-------------------------------------------------------------------------------------
                //--------------------/MainProgram/----------------------------------------------------
                //-------------------------------------------------------------------------------------
                
                for (int i = 0; i < userDefined.Length; i++)
                {

                    if (Char.IsDigit(userDefined[i]))
                    {
                        searchIndex = userDefined.IndexOf(userDefined[i], i + 1);
                        if (searchIndex > 0)
                        {
                            letterSearch = userDefined.Substring(i, searchIndex + 1 - i);
                        }
                        else
                        {
                            letterSearch = "";
                        }

                        if (searchIndex > 0 && !ContainLetter(letterSearch))
                        {

                            totalSumOfNumbers += ulong.Parse(userDefined.Substring(i, searchIndex + 1 - i));


                            // This will print the currently checked and approved substrings and numbers
                            Console.Write(userDefined.Substring(0, i));
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(userDefined.Substring(i, searchIndex + 1 - i));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(userDefined.Substring(searchIndex + 1));

                        }
                    }
                }
                // Prints the added sum of all numbers
                Console.WriteLine("");
                Console.WriteLine($"Om man adderar alla utvalda sifferkombinationer så får man slutsumman: {totalSumOfNumbers}");
                Console.WriteLine("Vänligen Tryck på en knapp. . .");
                Console.ReadKey();
                totalSumOfNumbers = 0;
                Console.Clear();

            }

            //------------------------------------------------------------------------------------
            //----------------------------/End of Main program/-------------------------------
            //------------------------------------------------------------------------------------
            
        }


        //-----------/Search the string for letters/------------
        static bool ContainLetter(string toSearch)
        {
            for (int i = 0; i < toSearch.Length; i++)
            {
                int NrTest = 0;
                while (!int.TryParse(toSearch[i].ToString(), out NrTest))
                {
                    return true;
                }


            }

            return false;
        }

        //-----------/Menu/---------------------
        static byte Menu()
        {

            byte menuChoice = 20;
           
            do
            {
                Console.WriteLine("Välkommen till AutoSorter 3000\n");
                Console.WriteLine("Vänligen gör ett val\n");
                Console.WriteLine("[1] Använd ett förbestämt värde");
                Console.WriteLine("[2] Ändra förbestämt värde");
                Console.WriteLine("[3] Använd ett slumpgenererat värde");
                Console.WriteLine();
                Console.WriteLine("[4] Avsluta Program");

                while (!byte.TryParse(Console.ReadLine(), out menuChoice) || menuChoice >= 5 || menuChoice <= 0)
                {

                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett korrekt alternativ!");
                    Console.WriteLine("Tryck på en knapp");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }

                if (menuChoice > 0 && menuChoice < 5)
                {
                    break;
                }


            } while (true);



            return menuChoice;




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

            string randomStringGenerated = "";
            int subString = 0; // Length of substrings


            Random rnd = new Random();

            do
            {
                subString = rnd.Next(4, 16); // No use in lowering start value

                for (int i = 0; i < subString; i++)
                {

                    randomStringGenerated += rnd.Next(1, 10).ToString();

                }
                randomStringGenerated += (char)rnd.Next(65, 123); //Will always be added to break of sections of substrings, can be removed if neccecery 

            } while (randomStringGenerated.Length < Length);
            return randomStringGenerated;
        }



    }
}
