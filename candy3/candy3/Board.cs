using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace candy3
{
    public class Board
    { //board class

        public static int candySize;

        public static int getCandySize() { return candySize; }
        public void setCandySize(int size) { Board.candySize = size; }

        public static Candy[] newCandies;

        public static void printBoard()
        {
            for (int i = 0; i < candySize; i++)
            {
                System.Diagnostics.Debug.Write(newCandies[i].getValue());

                if (i % 8 == 7)
                    System.Diagnostics.Debug.WriteLine("");
            }//init board loop, end for loop


        }//end printBoard method

        public Board(Candy[] board)
        {

            setCandySize(64);
            newCandies = new Candy[getCandySize()];
            

            for (int i = 0; i < candySize; i++)
            {
                newCandies[i] = new Candy(0, false, i);
                System.Diagnostics.Debug.Write(newCandies[i].getLocation()+" ");

                if (i % 8 == 7) { System.Diagnostics.Debug.WriteLine(""); }
            }

            
            
        }//end board constructor

      
 
    }//end board class
}
