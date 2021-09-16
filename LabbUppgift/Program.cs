using System;
using System.Collections.Generic;
using System.Numerics;

namespace LabbUppgift
{
    class Program
    {


        static void Main(string[] args)
        {
            string NumberInString = "29535123p48723487597645723645";

            List<ulong> SavedNumbers = new List<ulong>();
            BigInteger Total = 0;
            Console.ForegroundColor = ConsoleColor.White;


            int SearchNumber;
            int Steps = 0;

            string LetterSearch;


            for (int i = 0; i < NumberInString.Length; i++)
            {

                if (Char.IsDigit(NumberInString[i]))
                {
                    SearchNumber = NumberInString.IndexOf(NumberInString[i], i + 1);
                    if (SearchNumber > 0)
                    {
                        LetterSearch = NumberInString.Substring(i, SearchNumber + 1 - i);
                    }
                    else
                    {
                        LetterSearch = "";
                    }

                    if (SearchNumber > 0 && ContainLetter(LetterSearch))
                    {
                        SavedNumbers.Add(ulong.Parse(NumberInString.Substring(i, SearchNumber + 1 - i)));
                        Total += ulong.Parse(NumberInString.Substring(i, SearchNumber + 1 - i));



                        Console.Write(NumberInString.Substring(0, i));
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(NumberInString.Substring(i, SearchNumber + 1 - i));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(NumberInString.Substring(SearchNumber + 1));








                    }







                }


                Steps++;

            }




            Console.WriteLine($"Om man adderar alla utvalda sifferkombinationer så får man slutsumman: {Total}");
            Console.ReadLine();





        }

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




    }
}
