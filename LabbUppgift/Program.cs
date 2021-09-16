using System;
using System.Collections.Generic;
using System.Numerics;

namespace LabbUppgift
{
    class Program
    {


        static void Main(string[] args)
        {
            string PreDeterment = "29535123p48723487597645723645";
            string StringWithNumbers = "29535123p48723487597645723645";
           
            
            string MenuChoice = "";
            byte Choice = 0;
            BigInteger Total = 0; //Räknar ihop totalen av allt som hittas
            
            int SearchIndex; // Indexen som blir slutpunkten för sökningen
            string LetterSearch; // Kommer användas för att hitta bokstäver i strängen

            //--------------------------------------------------------------------------------------
            //----------------------------/HuvudProgrammet/-----------------------------------------
            //--------------------------------------------------------------------------------------
            while (Choice != 4) 
            {
                
                Choice = Menu();
                if (Choice == 4)
                    break;
                if(Choice == 1)
                {
                    StringWithNumbers = PreDeterment;
                }
                if (Choice == 2)
                {
                    Console.WriteLine("Vänligen mata in din sträng: ");
                    StringWithNumbers = Console.ReadLine();
                    
                }
                if (Choice == 3)
                {
                    StringWithNumbers = RandomGenerator();
                }
                
                
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



                            Console.Write(StringWithNumbers.Substring(0, i));
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(StringWithNumbers.Substring(i, SearchIndex + 1 - i));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(StringWithNumbers.Substring(SearchIndex + 1));

                        }
                    }




                }

                Console.WriteLine("");
                Console.WriteLine($"Om man adderar alla utvalda sifferkombinationer så får man slutsumman: {Total}");
                Console.WriteLine("Vänligen Tryck på en knapp. . .");
                Console.ReadLine();
                Total = 0;
                Console.Clear();

            } 

        
            

            //------------------------------------------------------------------------------------
            //----------------------------/Slut på huvudprogrammet/-------------------------------
            //------------------------------------------------------------------------------------





        }
        //-----------/Letar efter tecken eller bokstäver i strängen/------------
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

        //-----------/Meny/---------------------
        static byte Menu()
        {
            
            byte MenuChoice = 0;
            Console.WriteLine("Välkommen till AutoSorter 3000\n");
            Console.WriteLine("Vänligen gör ett val");
            do
            {
                
                Console.WriteLine("[1] Använd ett förbestämt värde");
                Console.WriteLine("[2] Ändra förbestämt värde");
                Console.WriteLine("[3] Använd ett slumpgenererat värde");
                Console.WriteLine();
                Console.WriteLine("[4] Avsluta Program");

                while (!byte.TryParse(Console.ReadLine(), out MenuChoice) && MenuChoice > 5 && MenuChoice > 0)
                {
                    
                        Console.Clear();
                        Console.WriteLine("Vänligen ange ett korrekt alternativ!");
                    
                }
                
                    
            } while (MenuChoice == 0);
           


            return MenuChoice;



            
        }
        static string RandomGenerator()
        {
            Console.Write("Vänligen ange den minsta längden du vill ha (Minsta längden är minst 6 oavsett): ");
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
            int RandomNumber = 0; //The numbers in the substring

            Random rnd = new Random();

            do
            {
                SubString = rnd.Next(5, 16);
               
                for (int i = 0; i < SubString; i++)
                {
                    RandomNumber = rnd.Next(1, 10);
                    RandomGeneratedString += RandomNumber.ToString();

                }
                RandomGeneratedString += (char)rnd.Next(65, 123);

            } while (RandomGeneratedString.Length < Length);
            return RandomGeneratedString;
        }



    }
}
