using Microsoft.VisualBasic.FileIO;
using System.Numerics;
using System.Reflection;

namespace Hangman
{
    internal class Program
    {
        
        static string correctWord = "";
        static int numberOfGuesses = 0;
        static char[] letters;
        static Player player;
        

        static void Main(string[] args)
        {
            try
            {
                GenerateRandomWord();
                StartGame();
                PlayGame();
                EndGame();
            }
            catch(Exception e)
            {
                //TODO: Create a log...
                Console.WriteLine("Oops, something went wrong!\n");
            }

        }

        private static void GenerateRandomWord()
        {
            FileHandler fh = new FileHandler(); //create a new FileHandler object
            string random = fh.handleFile(); //acquire a random word
            correctWord = random.ToString(); //assign it as the correct word
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
                string? name = Console.ReadLine();
                if (name.Length <= 1)
                {
                    Console.WriteLine("Invalid name length...please try again\n");
                    AskForUserName();
                }
            player = new Player(name);
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
            bool addPoint = false;

            for(int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetter == correctWord[i])
                {
                    if(addPoint == false)
                        addPoint = true;
                    letters[i] = guessedLetter;
                }
                
            }

            if (addPoint)
                player.Score += 1;

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
            Console.Clear();
            Console.WriteLine("Congrats!");
            Console.WriteLine($"Correct Word: {correctWord}");
            Console.WriteLine($"Thank you for playing {player.Name}");
            Console.WriteLine($"Total number of guesses: {numberOfGuesses}");
            Console.WriteLine($"Total score: {player.Score}");
            DisplayUniqueGuesses();
        }

        private static void CheckAddUnique(char potentialToAdd)
        {
            if (player.getListCount() == 0 || player.exists(potentialToAdd) == false)
            {
                player.setList(potentialToAdd);
            }
                
            return;
        }
        private static void DisplayUniqueGuesses()
        {
            Console.WriteLine();
            Console.WriteLine("Here are all of your unique guesses: ");
            Console.Write("[");
            for(int i = 0; i < player.getGuesses().Count; i++)
            {
                if (i == player.getListCount() - 1)
                {
                    Console.Write(player.getIndex(i));
                }
                else
                {
                    Console.Write(player.getIndex(i));
                    Console.Write(' ');
                }
            }
            Console.Write("]\n");
        }
    }
}