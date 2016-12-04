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
        public static Button[] b = new Button[64];
        public game(string loginst, string pass, string indo)
        {
            this.newPlayer = new Player(loginst, pass, indo);
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("game constructor complete");
        }

        private void displayButtons(Board newBoard)
        {
            Point newLoc = new Point(5, 5);
            //Button[] b = Controls.OfType<Button>().OrderBy(button => button.TabIndex).ToArray();
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

        public Int64[] checkJson(Newtonsoft.Json.Linq.JObject jObject)
        {
            if (jObject.First.ToString().Substring(1, 5) != "Error".ToString())
            {
                Int64[] tempboard = new Int64[64];
                for (int i = 0; i < tempboard.Length; i++)
                {
                    tempboard[i] = (Int64)jObject.Root["Board"][i];
                } //end for loop

                return tempboard;
            } //end good user/password
            else
            {
                this.Close();
                MessageBox.Show("Bad user name or password");
            }

            return null;
        }

        private void game_Load(object sender, EventArgs e)
        {
            if (checkJson(connectServer()) != null)
            {
                this.newBoard = new Board(checkJson(connectServer()));
                displayButtons(newBoard);
            }
        }

        private Button[] setOnClick(Button[] button)
        {
            button[0].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(0).getValue().ToString());
            button[1].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(1).getValue().ToString());
            button[2].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(2).getValue().ToString());
            button[3].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(3).getValue().ToString());
            button[4].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(4).getValue().ToString());
            button[5].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(5).getValue().ToString());
            button[6].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(6).getValue().ToString());
            button[7].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(7).getValue().ToString());
            button[8].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(8).getValue().ToString());
            button[9].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(9).getValue().ToString());
            button[10].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(10).getValue().ToString());
            button[11].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(11).getValue().ToString());
            button[12].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(12).getValue().ToString());
            button[13].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(13).getValue().ToString());
            button[14].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(14).getValue().ToString());
            button[15].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(15).getValue().ToString());
            button[16].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(16).getValue().ToString());
            button[17].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(17).getValue().ToString());
            button[18].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(18).getValue().ToString());
            button[19].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(19).getValue().ToString());
            button[20].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(20).getValue().ToString());
            button[21].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(21).getValue().ToString());
            button[22].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(22).getValue().ToString());
            button[23].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(23).getValue().ToString());
            button[24].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(24).getValue().ToString());
            button[25].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(25).getValue().ToString());
            button[26].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(26).getValue().ToString());
            button[27].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(27).getValue().ToString());
            button[28].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(28).getValue().ToString());
            button[29].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(29).getValue().ToString());
            button[30].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(30).getValue().ToString());
            button[31].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(31).getValue().ToString());
            button[32].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(32).getValue().ToString());
            button[33].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(33).getValue().ToString());
            button[34].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(34).getValue().ToString());
            button[35].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(35).getValue().ToString());
            button[36].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(36).getValue().ToString());
            button[37].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(37).getValue().ToString());
            button[38].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(38).getValue().ToString());
            button[39].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(39).getValue().ToString());
            button[40].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(40).getValue().ToString());
            button[41].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(41).getValue().ToString());
            button[42].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(42).getValue().ToString());
            button[43].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(43).getValue().ToString());
            button[44].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(44).getValue().ToString());
            button[45].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(45).getValue().ToString());
            button[46].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(46).getValue().ToString());
            button[47].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(47).getValue().ToString());
            button[48].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(48).getValue().ToString());
            button[49].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(49).getValue().ToString());
            button[50].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(50).getValue().ToString());
            button[51].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(51).getValue().ToString());
            button[52].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(52).getValue().ToString());
            button[53].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(53).getValue().ToString());
            button[54].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(54).getValue().ToString());
            button[55].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(55).getValue().ToString());
            button[56].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(56).getValue().ToString());
            button[57].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(57).getValue().ToString());
            button[58].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(58).getValue().ToString());
            button[59].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(59).getValue().ToString());
            button[60].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(60).getValue().ToString());
            button[61].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(61).getValue().ToString());
            button[62].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(62).getValue().ToString());
            button[63].Click += (sender1, ex) => System.Console.WriteLine(newBoard.getCandy(63).getValue().ToString());
            return button;
        }
    }
}