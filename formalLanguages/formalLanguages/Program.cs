using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace formalLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomataHandler ah = new AutomataHandler();
            string input;
            while(true)
            {
                Console.WriteLine("Enter 1 to check string for int value or 2 to check string for everything");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter string");
                    input = Console.ReadLine();
                    Console.WriteLine("Enter skip");
                    int skip = int.Parse(Console.ReadLine());
                    Tuple<bool, int> result = ah.CheckForIntValue(skip,input);
                    if (!result.Item1)
                    {
                        Console.WriteLine("it's not an int value");
                    }
                    else
                    {
                        Console.WriteLine($"It's an int value with {result.Item2} length");
                    }

                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter string");
                    input = Console.ReadLine();
                    foreach (var item in ah.CheckForEverything(input))
                    {
                        Console.Write($"[{item}] ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
            
            
        }
    }
}
