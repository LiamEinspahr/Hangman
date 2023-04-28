namespace Hangman
{
    internal class Program
    {
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
            Console.WriteLine("Asking user for name...");
        }

        private static void PlayGame()
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
        }

        private static void EndGame()
        {
            Console.WriteLine("Game over...");
        }
    }
}