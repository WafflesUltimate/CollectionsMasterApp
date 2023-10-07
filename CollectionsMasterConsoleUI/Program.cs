using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] num50 = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(num50);

            //TODO: Print the first number of the array
            Console.WriteLine($"First number: { num50[0]}");

            //TODO: Print the last number of the array            
            Console.WriteLine($"Last number: {num50[49]}");

            Console.WriteLine("All Numbers Original:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(num50);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Reversed:");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Array.Reverse(num50);
            NumberPrinter(num50);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(num50);
            NumberPrinter(num50);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            ThreeKiller(num50);
            NumberPrinter(num50);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");

            Array.Sort(num50);
            NumberPrinter(num50);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List <int> num50List = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"List Capacity before number generation: {num50List.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(num50List);

            //TODO: Print the new capacity
            Console.WriteLine($"List Capacity after number generation: { num50List.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");

            NumberChecker(num50List, 0);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(num50List);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");

            OddKiller(num50List);
            NumberPrinter(num50List);   
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");

            num50List.Sort();
            NumberPrinter(num50List);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            var v = num50List.ToArray();
            
            //TODO: Clear the list
            Array.Clear(v);

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for(int i = 0; i < numbers.Count(); i++){
                if ((double)numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            numberList.RemoveAll(x => x % 2 == 1);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            string userInput = Console.ReadLine();
            int b;
            int.TryParse(userInput, out b);

            while(b == 0) 
            {
                b = 1;
                Console.WriteLine("Please give me a numeric value");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out b);
            }
         
            searchNumber = int.Parse(userInput);
            foreach(int i in numberList)
            {
                if(searchNumber == i){
                    Console.WriteLine("Yes, the list has this value.");
                    break;
                }

                else if(i == numberList[49] && searchNumber != i)
                {
                    Console.WriteLine("The list does not have that number.");
                }
                else
                {
                    Console.WriteLine("Still checking...");
                }  
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            int i = 0;
            while (i < 50)
            {
                numberList.Add(rng.Next(0, 50));
                i++;
            }
           
        }

        private static void Populater(int[] numbers)
        {
            
            Random rng = new Random();
            int i = 0;
            while (i < numbers.Count())
            {
                numbers[i] = rng.Next(0, 50);
                i++;
            }
        }        

        private static void ReverseArray(int[] array)
        {
             array.Reverse();
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
