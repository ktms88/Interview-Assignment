using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int correct_answer = 42;
            int guess = 0;
            bool Correct = false;

            while (!Correct)
            {
                Console.WriteLine("Guess the answer?");
                string Uservalue = Console.ReadLine();
                int Userval = int.Parse(Uservalue);

                if (int.TryParse(Uservalue, out guess))
                {
                    if (Userval < 1)
                    {
                        Console.WriteLine("Please enter a number between 1 and 100");
                    }
                    else if (Userval > 100)
                    {
                        Console.WriteLine("Please enter a number between 1 and 100");
                    }
                    else if (Userval != correct_answer)
                    {
                        Console.WriteLine("Incorrect");
                    }
                    else
                    {
                        Console.WriteLine("Correct");
                        Environment.Exit(0);

                    }
                }
                else
                {
                    Console.WriteLine("Invaid Number");
                    continue;
                }

                //while (Guess != returnValue)
                //{
                //    Guess = Convert.ToInt32(Console.Read());

                //    if (Guess < 1)
                //    {
                //        Console.WriteLine("Please enter a number between 1 and 100");
                //    }
                //    else if (Guess > 100)
                //    {
                //        Console.WriteLine("Please enter a number between 1 and 100");
                //    }

                //}
            }
        }
    }
}
