using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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
            /*
            System.Diagnostics.Debug.WriteLine("Create Board");
            this.newBoard = new Board(newCandies);
            System.Diagnostics.Debug.WriteLine("Created Board");
            Board.printBoard();
            */
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

        public Newtonsoft.Json.Linq.JObject connectServer()
        {
            string urlstring = "http://52.24.237.185/" + newPlayer.getOperation().ToString() + "?user=" + newPlayer.getLogin() + "&pass=" + newPlayer.getPass();

            //urlstring +=


            WebClient client = new WebClient();
            Stream stream = client.OpenRead(urlstring);
            StreamReader reader = new StreamReader(stream);

            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());
            stream.Close();
            return jObject;
        }






        public Int64[] checkJson(Newtonsoft.Json.Linq.JObject jObject) { 
            if (jObject.First.ToString().Substring(1, 5) != "Error".ToString())
            {
                System.Diagnostics.Debug.WriteLine("Close form");


                Int64[] tempboard = new Int64[64];

                for (int i = 0; i < tempboard.Length; i++)
                {

                    //this creates a problem as it invalid operation exception in Newtonsoft.Json.dll
                    tempboard[i] = (Int64)jObject.Root["Board"][i];
                    System.Diagnostics.Debug.Write(jObject.Root["Board"][i]);
                }//end for loop

                return tempboard;

            }//end good user/password
            else
            {

                this.Close();
                MessageBox.Show("Bad user name or password");
            }
            return null;
        }


        private void game_Load(object sender, EventArgs e)
        {

            
            System.Diagnostics.Debug.WriteLine("Create Board");
            this.newBoard = new Board(checkJson(connectServer()));
            System.Diagnostics.Debug.WriteLine("Created Board");
            Board.printBoard();
            displayButtons(newBoard);
            }
    }
}
