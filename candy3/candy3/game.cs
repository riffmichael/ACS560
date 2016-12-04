using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace candy3
{
    public partial class game : Form
    {
        public Player newPlayer;
        public Board newBoard;
        public Candy[] newCandies;

    


        public game(string loginst, string pass, string indo)
        {
            System.Diagnostics.Debug.WriteLine("Create Player");
            this.newPlayer = new Player(loginst, pass, indo);
            System.Diagnostics.Debug.WriteLine("Created Player");
            System.Diagnostics.Debug.WriteLine("Create Board");
            this.newBoard = new Board(newCandies);
            System.Diagnostics.Debug.WriteLine("Created Board");
            Board.printBoard();

            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("game constructor complete");
        }


        private void displayButtons(Board newBoard) {
            Point newLoc = new Point(5, 5); // Set whatever you want for initial location
            Button[] b = new Button[newBoard.getCandySize()];

            for (int i = 0; i < newBoard.getCandySize(); i++)
            {
                b[i] = new Button();
                b[i].Size = new Size(50, 50);
                b[i].Location = newLoc;
                b[i].TabIndex = i;
                if (i % 8 == 7)
                {
                    newLoc.X = 5;
                    newLoc.Y += b[i].Height + 5;
                }
                else
                {
                    newLoc.Offset(b[i].Width + 5, 0);
                }
                Controls.Add(b[i]);
                b[i].Text = newBoard.getCandy(i).getValue().ToString();
            }
        }




        private void game_Load(object sender, EventArgs e)
        {

            displayButtons(newBoard);


            
            //System.Diagnostics.Debug.WriteLine("game constructor complete");
        }
    }
}
