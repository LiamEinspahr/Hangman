namespace Hangman
{
    internal class Program
    {
        static string? name;
        static int numberOfGuesses = 0;
        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();

        }
        private static void StartGame()
        {
            Console.WriteLine("Starting the game...");
            AskForUserName();
        }

        static void AskForUserName()
        {
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();
        }

        static void PlayGame()
        {
            Console.WriteLine("Playing the game...");
            DisplayMaskedWord();
            AskForLetter();
        }

        static void DisplayMaskedWord()
        {
            Console.WriteLine("Displaying masked word...");
        }

        static void AskForLetter()
        {
            Console.WriteLine("Asking for letter...");
            numberOfGuesses++;
        }

        static void EndGame()
        {
            Console.WriteLine("Game over...");
            Console.WriteLine($"Thank you for playing {name}");
            Console.WriteLine($"Total number of guesses: {numberOfGuesses}");
        }
    }
}