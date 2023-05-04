using Microsoft.VisualBasic.FileIO;
using System.Numerics;
using System.Reflection;

namespace Hangman
{
    internal class Program
    {
        static string name = "";
        static string correctWord = "hangman";
        static int numberOfGuesses = 0;
        static char[] letters;
        static List<char> uniqueGuesses = new List<char>();

        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();

        }
        private static void StartGame()
        {
            letters = new char[correctWord.Length];
            for(int i = 0; i < letters.Length; i++)
                letters[i] = '-';

            AskForUserName();
        }

        static void AskForUserName()
        {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
                if (name.Length <= 1)
                {
                    Console.WriteLine("Invalid name length...please try again\n");
                    AskForUserName();
                }
        }

        static void PlayGame()
        {
            do
            {
                Console.Clear();
                DisplayMaskedWord();
                char guessedLetter = AskForLetter();
                CheckLetter(guessedLetter);
            } while (correctWord != new string(letters));
        }

        private static void CheckLetter(char guessedLetter)
        {
            for(int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetter == correctWord[i])
                    letters[i] = guessedLetter;
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
                Console.Write(c);

            Console.WriteLine(); 
        }

        static char AskForLetter()
        {
            string input;
            do 
            { 
                Console.Write("Enter a letter: ");
                input = Console.ReadLine();
            } while (input.Length != 1);

            char temp = input[0];
            CheckAddUnique(temp);
            numberOfGuesses++;

            return input[0];
        }

        static void EndGame()
        {
            Console.WriteLine("Game over...");
            Console.WriteLine($"Thank you for playing {name}");
            Console.WriteLine($"Total number of guesses: {numberOfGuesses}");
            DisplayUniqueGuesses();
        }

        private static void CheckAddUnique(char potentialToAdd)
        {
            if (uniqueGuesses.Count == 0 || uniqueGuesses.Contains(potentialToAdd) == false)
                uniqueGuesses.Add(potentialToAdd);
            return;
        }
        private static void DisplayUniqueGuesses()
        {
            Console.WriteLine();
            Console.WriteLine("Here are all of your unique guesses: ");
            foreach (char c in uniqueGuesses)
                Console.Write(c + " ");
        }
    }
}