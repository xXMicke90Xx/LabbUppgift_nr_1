using System;
using System.Collections.Generic;

namespace LabbUppgift
{
    class Program
    {
        static void Main(string[] args)
        {
           string NumberInString = "29535123p48723487597645723645";

            List<int> SavedNumbers = new List<int>();




            int TempStartValue = -1;
            int Steps = 0;
            int PlaceInString = 0;


            for (int i = 0; i < NumberInString.Length; i++)
            {
                
                if (Char.IsNumber(NumberInString[i]) && TempStartValue != Convert.ToInt32((NumberInString[i].ToString())))
                {
                    for (int j = i; j < NumberInString.Length - i; j++)
                    {
                        TempStartValue = Convert.ToInt32((NumberInString[i].ToString()));
                        Steps = 0;

                        PlaceInString = i;

                        if (Char.IsNumber(NumberInString[i]) && TempStartValue == Convert.ToInt32((NumberInString[i].ToString())))
                        {

                        }



                    }
                }
               

                Steps++;

            }
            SavedNumbers.Add(Convert.ToInt32(NumberInString[0].ToString()));

        }
    }
}
