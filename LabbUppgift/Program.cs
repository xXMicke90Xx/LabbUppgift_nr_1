using System;

using System.Numerics;
using System.Text.RegularExpressions;

namespace LabbUppgift
{
    class Program
    {


        static void Main(string[] args)
        {
            
            Console.SetWindowSize(120, 40);
            

            string _preDefined = "29535123p48723487597645723645"; // Default value to be used
            string _userDefined = "29535123p48723487597645723645"; // Will change according to user input
            byte _menuChoice = 0;
            BigInteger _totalSumOfNumbers = 0; // Will contain all numbercombinations added

            int _searchIndex; // Is used to return an index to search for or -1
            string _letterSearch; // Is used to search for letters in the substring

            //--------------------------------------------------------------------------------------
            //----------------------------/MenuChoices/-----------------------------------------
            //--------------------------------------------------------------------------------------
            while (_menuChoice != 4)
            {

                _menuChoice = Menu();
                switch (_menuChoice)
                {
                    case 1: //Predetermend
                        Console.Clear();
                        _userDefined = _preDefined;
                        Console.WriteLine($"Förprogrammerad sträng : {_preDefined} ");
                        Console.WriteLine();
                        break;
                    case 2://User determend
                        Console.Write("Mata in värde/sträng(OBS decimaltal kommer ej räknas som decimaler): ");
                        _userDefined = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Din sträng blev: {_userDefined}");
                        Console.WriteLine();
                        break;
                    case 3://Randomgenerated
                        _userDefined = RandomGenerator();
                        Console.Clear();
                        Console.WriteLine($"Den slumpgenererade strängen blev: {_userDefined}");
                        Console.WriteLine();
                        break;
                    case 4://Exit Application
                        Environment.Exit(0);
                        break;

                }

                //-------------------------------------------------------------------------------------
                //--------------------/MainProgram/----------------------------------------------------
                //-------------------------------------------------------------------------------------
                
                for (int i = 0; i < _userDefined.Length; i++)
                {

                    if (Char.IsDigit(_userDefined[i])) //First character a number?
                    {
                        _searchIndex = _userDefined.IndexOf(_userDefined[i], i + 1); //Find same number again? Else return -1
                        if (_searchIndex > 0)
                        {
                            _letterSearch = _userDefined.Substring(i, _searchIndex + 1 - i);
                        }
                        else
                        {
                            _letterSearch = "Not Found";
                        }

                        if (_searchIndex > 0 && ContainLetter(_letterSearch)) // 2 numbers found and not a letter inbetween?
                        {

                            _totalSumOfNumbers += BigInteger.Parse(_userDefined.Substring(i, _searchIndex + 1 - i)); //Add accepted numbers to sum


                            // This will print the currently checked and approved substrings and numbers
                            Console.Write(_userDefined.Substring(0, i));
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(_userDefined.Substring(i, _searchIndex + 1 - i));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(_userDefined.Substring(_searchIndex + 1));

                        }
                    }
                }
                // Prints the added sum of all numbers
                Console.WriteLine();
                Console.WriteLine($"Om man adderar alla utvalda sifferkombinationer så får man slutsumman: {_totalSumOfNumbers}");
                Console.WriteLine("Vänligen Tryck på en knapp. . .");
                Console.ReadKey();
                _totalSumOfNumbers = 0;
                Console.Clear();

            }

            //------------------------------------------------------------------------------------
            //----------------------------/End of Main program/-------------------------------
            //------------------------------------------------------------------------------------
            
        }


        //-----------/Search the substring for letters/------------
        public static bool ContainLetter(string toSearch)
        {
            Regex _subString = new Regex("^[0-9]{1,2000000}$");
            bool _IsLetter = _subString.IsMatch(toSearch);
            return _IsLetter;
        }

        //-----------/Menu/---------------------
        public static byte Menu()
        {

            byte _menuChoice = 20;
           
            do
            {
                Console.WriteLine("Välkommen till AutoSorter 3000\n");
                Console.WriteLine("Vänligen gör ett val\n");
                Console.WriteLine("[1] Använd ett förbestämt värde");
                Console.WriteLine("[2] Ange ett eget värde ");
                Console.WriteLine("[3] Använd ett slumpgenererat värde");
                Console.WriteLine();
                Console.WriteLine("[4] Avsluta Program");

                while (!byte.TryParse(Console.ReadLine(), out _menuChoice) || _menuChoice >= 5 || _menuChoice <= 0)
                {

                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett korrekt alternativ!");
                    Console.WriteLine("Tryck på en knapp");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }

                if (_menuChoice > 0 && _menuChoice < 5)
                {
                    break;
                }


            } while (true);
            
            return _menuChoice;
        }

        //-----------/Will randomgenerate numbers and length and the substrings and also random char caracter/----------
        public static string RandomGenerator()
        {
            Console.Write("Vänligen ange den minsta längden du vill ha (Minsta längden är minst 5 oavsett): ");
            byte _Length = 0;
            while (!byte.TryParse(Console.ReadLine(), out _Length))
            {
                Console.Clear();
                Console.WriteLine("Vänligen använd endast siffror (1-70): ");
            }
            while (_Length > 70)
            {
                Console.Clear();
                Console.WriteLine("Vänligen använd inte ett störe tal än 70");
                while (!byte.TryParse(Console.ReadLine(), out _Length))
                {
                    Console.Clear();
                    Console.WriteLine("Använd ENDAST SIFFROR som är MELLAN 1-70");

                }
            }

            string _randomStringGenerated = "";
          


            Random _rnd = new Random();

            do
            {
               int _subString = _rnd.Next(4, 16); // No use in lowering start value

                for (int i = 0; i < _subString; i++)
                {

                    _randomStringGenerated += _rnd.Next(1, 10).ToString();

                }
                _randomStringGenerated += (char)_rnd.Next(65, 123); //Will always be added to break of sections of substrings, can be removed if neccecery 

            } while (_randomStringGenerated.Length < _Length);
            return _randomStringGenerated;
        }
    }
}
