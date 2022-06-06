/*
Hangman Program
Rony Richard
1st June, 2021
*/

using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Program{
    internal class Program{
        //Borrowed the Hangman figure off of stackoverflow because I had no idea how to implement a Hangman Drawing in C#
        private static void printHangman(int wrong)
        {
            if(wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");

            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }
        }

        private static int printWord(List<char> guess, String randomFruit)
        {
            int counter = 0;
            int correctLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomFruit)
            {
                if (guess.Contains(c))
                {
                    Console.Write(c + " ");
                    correctLetters += 1;
                }
                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            //Console.Write("\r\n");
            return correctLetters;
        }

        private static void printLines(String randomFruit)
        {
            Console.Write("\r");
            foreach (char c in randomFruit)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("-----------------------------------------");
            //Makes a List of Fruits and Whenever the Game is played, it takes a random fruit off the list for the user to guess
            Random random = new Random();
            List<string> fruits = new List<string> { "apple", "orange", "kiwi", "blueberry", "strawberry", "banana"};
            int index = random.Next(fruits.Count);
            String randomFruit = fruits[index];

            foreach (char x in randomFruit)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomFruit.Length;
            int incorrectAttempts = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (incorrectAttempts != 6 && currentLettersRight != lengthOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // Input
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];
                // Checks for Duplicate Guesses
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\n You have already guessed this letter");
                    printHangman(incorrectAttempts);
                    currentLettersRight = printWord(currentLettersGuessed, randomFruit);
                    printLines(randomFruit);
                }
                else
                {
                    // Checks if the guess is in the spelling of the Fruit
                    bool right = false;
                    for (int i = 0; i < randomFruit.Length; i++) { if (letterGuessed == randomFruit[i]) { right = true; } }

                    // If Letter is Guessed Properly
                    if (right)
                    {
                        printHangman(incorrectAttempts);
                        // Print word
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(currentLettersGuessed, randomFruit);
                        Console.Write("\r\n");
                        printLines(randomFruit);
                    }
                    // IF Letter is Guessed Incorretly
                    else
                    {
                        incorrectAttempts += 1;
                        currentLettersGuessed.Add(letterGuessed);
                        // Adds Limb to HangMan (Also Borrowed from StackOverflow LOL)
                        printHangman(incorrectAttempts);
                        // Prints the word
                        currentLettersRight = printWord(currentLettersGuessed, randomFruit);
                        Console.Write("\r\n");
                        printLines(randomFruit);
                    }
                }
            }
            Console.WriteLine("\r\n Correct! Good Job! Thanks for playing!");
        }
    }
}