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

        private void game_Load(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("game constructor complete");
        }
    }
}
