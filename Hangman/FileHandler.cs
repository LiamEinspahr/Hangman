using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    internal class FileHandler
    {
        private string path = @"C:\Users\WesEi\source\repos\Hangman\hangman_words.txt";
        public string handleFile()
        {
            string[]? fileInput;
            try //Try to open a file at a path
            {
                fileInput = File.ReadAllLines(path); //read file inputs into string array
                Random rnd = new Random(); //create a new random var
                int randomIndex = rnd.Next(0, fileInput.Length - 1); //pick a random index within bounds
                string ret = fileInput[randomIndex]; //acquire the random word
                return (ret); //return the random word
            }
            catch //If it fails, we use a preset list of words
            {
                fileInput = new string[] { "red", "orange", "yellow", "green", "blue", "indigo", "violet" };
                Random rnd = new Random(); //create a new random var
                int randomIndex = rnd.Next(0, fileInput.Length - 1); //pick a random index within bounds
                string ret = fileInput[randomIndex]; //acquire the random word
                return (ret); //return the random word
            }



            
        }
    }
}
