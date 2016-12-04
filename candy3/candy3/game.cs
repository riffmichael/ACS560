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
            setOnClick(b);

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

            if (checkJson(connectServer()) != null)
            {
                this.newBoard = new Board(checkJson(connectServer()));
                System.Diagnostics.Debug.WriteLine("Created Board");
                Board.printBoard();
                displayButtons(newBoard);
            }
            
            }

        private Button[] setOnClick(Button[] button)
        {

            button[0].Click += (sender1, ex) => System.Console.WriteLine("button " + 0 + " pressed");
            button[1].Click += (sender1, ex) => System.Console.WriteLine("button " + 1 + " pressed");
            button[2].Click += (sender1, ex) => System.Console.WriteLine("button " + 2 + " pressed");
            button[3].Click += (sender1, ex) => System.Console.WriteLine("button " + 3 + " pressed");
            button[4].Click += (sender1, ex) => System.Console.WriteLine("button " + 4 + " pressed");
            button[5].Click += (sender1, ex) => System.Console.WriteLine("button " + 5 + " pressed");
            button[6].Click += (sender1, ex) => System.Console.WriteLine("button " + 6 + " pressed");
            button[7].Click += (sender1, ex) => System.Console.WriteLine("button " + 7 + " pressed");
            button[8].Click += (sender1, ex) => System.Console.WriteLine("button " + 8 + " pressed");
            button[9].Click += (sender1, ex) => System.Console.WriteLine("button " + 9 + " pressed");
            button[10].Click += (sender1, ex) => System.Console.WriteLine("button " + 10 + " pressed");
            button[11].Click += (sender1, ex) => System.Console.WriteLine("button " + 11 + " pressed");
            button[12].Click += (sender1, ex) => System.Console.WriteLine("button " + 12 + " pressed");
            button[13].Click += (sender1, ex) => System.Console.WriteLine("button " + 13 + " pressed");
            button[14].Click += (sender1, ex) => System.Console.WriteLine("button " + 14 + " pressed");
            button[15].Click += (sender1, ex) => System.Console.WriteLine("button " + 15 + " pressed");
            button[16].Click += (sender1, ex) => System.Console.WriteLine("button " + 16 + " pressed");
            button[17].Click += (sender1, ex) => System.Console.WriteLine("button " + 17 + " pressed");
            button[18].Click += (sender1, ex) => System.Console.WriteLine("button " + 18 + " pressed");
            button[19].Click += (sender1, ex) => System.Console.WriteLine("button " + 19 + " pressed");
            button[20].Click += (sender1, ex) => System.Console.WriteLine("button " + 20 + " pressed");
            button[21].Click += (sender1, ex) => System.Console.WriteLine("button " + 21 + " pressed");
            button[22].Click += (sender1, ex) => System.Console.WriteLine("button " + 22 + " pressed");
            button[23].Click += (sender1, ex) => System.Console.WriteLine("button " + 23 + " pressed");
            button[24].Click += (sender1, ex) => System.Console.WriteLine("button " + 24 + " pressed");
            button[25].Click += (sender1, ex) => System.Console.WriteLine("button " + 25 + " pressed");
            button[26].Click += (sender1, ex) => System.Console.WriteLine("button " + 26 + " pressed");
            button[27].Click += (sender1, ex) => System.Console.WriteLine("button " + 27 + " pressed");
            button[28].Click += (sender1, ex) => System.Console.WriteLine("button " + 28 + " pressed");
            button[29].Click += (sender1, ex) => System.Console.WriteLine("button " + 29 + " pressed");
            button[30].Click += (sender1, ex) => System.Console.WriteLine("button " + 30 + " pressed");
            button[31].Click += (sender1, ex) => System.Console.WriteLine("button " + 31 + " pressed");
            button[32].Click += (sender1, ex) => System.Console.WriteLine("button " + 32 + " pressed");
            button[33].Click += (sender1, ex) => System.Console.WriteLine("button " + 33 + " pressed");
            button[34].Click += (sender1, ex) => System.Console.WriteLine("button " + 34 + " pressed");
            button[35].Click += (sender1, ex) => System.Console.WriteLine("button " + 35 + " pressed");
            button[36].Click += (sender1, ex) => System.Console.WriteLine("button " + 36 + " pressed");
            button[37].Click += (sender1, ex) => System.Console.WriteLine("button " + 37 + " pressed");
            button[38].Click += (sender1, ex) => System.Console.WriteLine("button " + 38 + " pressed");
            button[39].Click += (sender1, ex) => System.Console.WriteLine("button " + 39 + " pressed");
            button[40].Click += (sender1, ex) => System.Console.WriteLine("button " + 40 + " pressed");
            button[41].Click += (sender1, ex) => System.Console.WriteLine("button " + 41 + " pressed");
            button[42].Click += (sender1, ex) => System.Console.WriteLine("button " + 42 + " pressed");
            button[43].Click += (sender1, ex) => System.Console.WriteLine("button " + 43 + " pressed");
            button[44].Click += (sender1, ex) => System.Console.WriteLine("button " + 44 + " pressed");
            button[45].Click += (sender1, ex) => System.Console.WriteLine("button " + 45 + " pressed");
            button[46].Click += (sender1, ex) => System.Console.WriteLine("button " + 46 + " pressed");
            button[47].Click += (sender1, ex) => System.Console.WriteLine("button " + 47 + " pressed");
            button[48].Click += (sender1, ex) => System.Console.WriteLine("button " + 48 + " pressed");
            button[49].Click += (sender1, ex) => System.Console.WriteLine("button " + 49 + " pressed");
            button[50].Click += (sender1, ex) => System.Console.WriteLine("button " + 50 + " pressed");
            button[51].Click += (sender1, ex) => System.Console.WriteLine("button " + 51 + " pressed");
            button[52].Click += (sender1, ex) => System.Console.WriteLine("button " + 52 + " pressed");
            button[53].Click += (sender1, ex) => System.Console.WriteLine("button " + 53 + " pressed");
            button[54].Click += (sender1, ex) => System.Console.WriteLine("button " + 54 + " pressed");
            button[55].Click += (sender1, ex) => System.Console.WriteLine("button " + 55 + " pressed");
            button[56].Click += (sender1, ex) => System.Console.WriteLine("button " + 56 + " pressed");
            button[57].Click += (sender1, ex) => System.Console.WriteLine("button " + 57 + " pressed");
            button[58].Click += (sender1, ex) => System.Console.WriteLine("button " + 58 + " pressed");
            button[59].Click += (sender1, ex) => System.Console.WriteLine("button " + 59 + " pressed");
            button[60].Click += (sender1, ex) => System.Console.WriteLine("button " + 60 + " pressed");
            button[61].Click += (sender1, ex) => System.Console.WriteLine("button " + 61 + " pressed");
            button[62].Click += (sender1, ex) => System.Console.WriteLine("button " + 62 + " pressed");
            button[63].Click += (sender1, ex) => System.Console.WriteLine("button " + 63 + " pressed");
            return button;
        }

    }
}
