using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Player
    {
        private string name = "";
        private List<char> uniqueGuesses = new List<char>();
        private int score = 0;

        public Player(string name)
        {
            this.name = name;
        }

        public List<char> getGuesses()
        {
            return (this.uniqueGuesses);
        }

        /* public string getName()
         {
             return (this.name);
         }*/

        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

        public void setList(char c)
        {
            this.uniqueGuesses.Add(c);
        }

        public int getListCount()
        {
            return this.uniqueGuesses.Count; ;
        }

        public bool exists(char c)
        {
            if (this.uniqueGuesses.Contains(c))
                return true;
            return false;
        }

        public char getIndex(int index)
        {
            char tmp = this.uniqueGuesses[index];
            Debug.WriteLine("Current: " + tmp);
            return (tmp);
        }

        /*public void setScore(int pt)
        {
            this.score = this.score + pt;
        }*/

        /*public int getScore()
        {
            return (this.score);
        }*/

        public int Score
        {
            get { return (this.score); }
            set { this.score = value; }
        }

    }
}
