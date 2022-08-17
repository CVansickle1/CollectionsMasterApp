using System;
using System.Collections;
using System.Collections.Generic;

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

            var myArray = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            
            Populater(myArray);
            //TODO: Print the first number of the array
            Console.WriteLine(myArray[0]);
            //TODO: Print the last number of the array            
            Console.WriteLine(myArray[myArray.Length-1]);
            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(myArray);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");

            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(myArray);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(myArray);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(myArray);
            NumberPrinter(myArray);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            var myList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine("The amount of Items in this list is " + myList.Capacity);

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this
            
            Populater(myList);
            
            //TODO: Print the new capacity
            Console.WriteLine("The amount of items in this list is " + myList.Count);

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            NumberChecker(myList, GetInput() );


            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(myList);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(myList);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            myList.Sort();
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            var newArray = myList.ToArray();

            //TODO: Clear the list
            myList.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            foreach (var i in numbers)
            {
                if (i % 3 == 0 && i != 0)
                {
                   Console.WriteLine(i);
                }
                else
                {
                    continue;
                }

            }

        }

        private static void OddKiller(List<int> numberList)
        {
            for(int i = 0; i < numberList.Count-1; i++)
            {
                if(numberList[i] % 2 != 0)
                {
                    numberList.RemoveAt(i);
                }
                else
                {
                    Console.WriteLine(numberList[i]);
                }
                
            }


        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
             

            while (!numberList.Contains(searchNumber))
            {
                Console.WriteLine("That number is not in the list. Try again");
                searchNumber = GetInput();
            }

            int location = numberList.IndexOf(searchNumber);
            Console.WriteLine($"{searchNumber} found in list! It is in Index {location}");
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i <= 49; i++)
            {
                numberList.Add(rng.Next(51));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for(int i = 0; i <= numbers.Length-1; i++)
            {
                numbers[i] = rng.Next(51);
            }
        }        

        private static void ReverseArray(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int tmp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = tmp;
            }
            NumberPrinter(array);
        }

        private static void myReverseArray(int[] array)
        {


            //this is what i created first, didnt want to lose a reference to it!

            var tempArray = new int[array.Length];
            int x = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                tempArray[x] = array[i];
                x++;

            }
            x = 0;
            for (int i = 0; i <= array.Length - 1; i++)
            {
                array[x] = tempArray[i];
                x++;
            }
            NumberPrinter(array);
        }
        public static int GetInput()
        {
            bool numCheck;
            numCheck = int.TryParse(Console.ReadLine(), out int num);

            while (!numCheck)
            {
                Console.WriteLine("Please enter a number: ");
                numCheck = int.TryParse(Console.ReadLine(), out num);
            }

            return num;
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
