using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy3
{
    public class Player
    {
        string playerlogin;
        string password;
        string operation;
        int score;
        int NumberMatches;

        public Player(string newLogin, string newPassword, string indo)
        {
            this.playerlogin = newLogin;
            this.password = newPassword;
            this.operation = indo;
            this.NumberMatches = 0;
        }//end Player constructor

        public void setNumberMatches(int matches)
        {
            this.NumberMatches = matches;
        }

        public int getNumberMatches()
        {
            return this.NumberMatches;
        }


        public void printPlayer()
        {
            System.Diagnostics.Debug.Write(playerlogin);
        }

        public int getScore()
        {
            return this.score;
        }

        public void setScore(int inScore)
        {
            this.score = inScore;
        }

        public void setOperation(string inop)
        {
            this.operation = inop;
        }

        public string getOperation()
        {
            return this.operation;
        }

        public string getLogin()
        {
            return this.playerlogin;
        }

        public string getPass()
        {
            return this.password;
        }
    }//end Player class
}
