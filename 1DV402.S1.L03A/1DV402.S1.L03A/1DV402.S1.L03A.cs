using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S1.L03A
{
    class Program
    {
        static void Main(string[] args)
        {

            int count;
            bool goAgain = true;

            do
            {
                //Skriv in antal löner ska skrivas ut och skickas till ReadInt
                count = ReadInt("Ange antal löner att mata in: ");

                //Skicka det returnerade värdet till metoden ProcessSalaries
                ProcessSalaries(count);

                //Programmet börjar om med valfri tangent och avslutas med escape
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("\nTryck på valfri tangent för att göra en ny beräkning - Esc avslutar");
                Console.ResetColor();

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    return;
                }

            } while (goAgain);


        }

        static int ReadInt(string prompt)
        {
            int countSalaries;

            while (true)
            {

                //Felmeddelanden tas om hand
                try
                {
                    Console.Write(prompt);
                    countSalaries = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (countSalaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste ange minst 2 löner för att göra en beräkning.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }

                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste ange ett heltal i siffror.\n");
                    Console.ResetColor();
                }

            }

            return countSalaries;
        }

        private static void ProcessSalaries(int count)
        {
            int median;
            int median1;
            int median2;
            int average;
            int difference;
            int[] salaries = new int[count];

            //Löner skrivs in och lagras
            for (int i = 0; i < salaries.Length; i++)
            {
                Console.Write("Ange lön nummer {0}: ", i + 1);

                salaries[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------");

            //Medellön
            Array.Sort(salaries);
            average = (int)salaries.Average();
            Console.WriteLine("{0,-14} {1,18:c0}", "Medellön: ", average);

            //Löneskillnad
            difference = salaries.Max() - salaries.Min();
            Console.WriteLine("{0,-14} {1,18:c0}", "Löneskillnad: ", difference);

            //Median om den ligger mellan två tal
            if (count % 2 == 0)
            {
                median1 = salaries[(count / 2) - 1];
                median2 = salaries[(count / 2)];
                median = (median1 + median2) / 2;
                Console.WriteLine("{0,-14} {1,18:c0}", "Median: ", median);
            }

            //Median om den inte gör det
            else if (count % 2 == 1)
            {
                median = salaries[(count / 2)];
                Console.WriteLine("{0,-14} {1,18:c0}", "Median: ", median);
            }

            Console.WriteLine("---------------------------------");

            //Formatering
            for (int row = 0; row < count; row++)
            {
                Console.Write("{0,8}", salaries[row]);

                if (2 == row % 3)
                {
                    Console.WriteLine();
                }
            }

        }
    }
}
