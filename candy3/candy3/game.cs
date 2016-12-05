﻿using System;
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
        public int firstClick, secondClick;
        public game(string loginst, string pass, string indo)
        {
            this.newPlayer = new Player(loginst, pass, indo);
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("game constructor complete");
        }

        private void displayButtons(Board newBoard)
        {
            this.Controls.Clear();
            Point newLoc = new Point(5, 5);
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

        public Candy[] setupBoard(Newtonsoft.Json.Linq.JObject jObject)
        {
            Int64[] tempboard = new Int64[64];
            Candy[] newCandies = new Candy[64];
            for (int i = 0; i < tempboard.Length; i++)
            {
                tempboard[i] = (int)jObject.Root["Board"][i];
                newCandies[i] = new Candy((int)tempboard[i], false, i);
            } //end for loop

            return newCandies;
        }

        public bool checkJson(Newtonsoft.Json.Linq.JObject jObject)
        {
            string errorString = "";
            if (jObject.First.ToString().Substring(1, 5) == "Error".ToString())
            {
                if (newPlayer.getOperation().ToString() == "login")
                {
                    errorString = "bad user name or password";
                }

                if (newPlayer.getOperation().ToString() == "new")
                {
                    errorString = "user: " + newPlayer.getLogin() + " already created";
                }

                this.Close();
                MessageBox.Show(errorString);
                return false;
            }
            else if (jObject.First.ToString().Substring(1, 5) == "Scores".ToString())
            {
                //print high scores
                return true;
            }
            else
            {
                return true;
            }
        }

        private void game_Load(object sender, EventArgs e)
        {
            if (checkJson(connectServer()))
            {
                this.newBoard = new Board(setupBoard(connectServer()));
                displayButtons(newBoard);
            }
        }

        public void gameStep(int buttonNumber)
        {
            if (newBoard.getClickCount() == 0)
            {
                firstClick = buttonNumber;
                System.Console.WriteLine("clicks: " + newBoard.getClickCount() + " firstClick: " + newBoard.getCandy(firstClick).getLocation());
                newBoard.setClickCount(newBoard.getClickCount() + 1);
                newBoard.getCandy(buttonNumber).setClicked();
            }
            else
            {
                secondClick = buttonNumber;
                System.Console.WriteLine("clicks: " + newBoard.getClickCount() + " secondClick: " + newBoard.getCandy(secondClick).getLocation());
                newBoard.getCandy(buttonNumber).setClicked();
                if (newBoard.isAdjacent(newBoard.getCandy(firstClick), newBoard.getCandy(secondClick)))
                {
                    System.Console.WriteLine("isAdjacent");
                    newBoard.swapCandy(newBoard.getCandy(firstClick).getLocation(), newBoard.getCandy(secondClick).getLocation());
                    newBoard.getCandy(firstClick).setLocation(firstClick);
                    newBoard.getCandy(secondClick).setLocation(secondClick);
                }

                newBoard.clearClicks(newCandies);
                newBoard.setClickCount(0);
                firstClick = -1;
                secondClick = -1;
                displayButtons(newBoard);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayButtons(newBoard);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            displayButtons(newBoard);
        }

        private Button[] setOnClick(Button[] button)
        {
            button[0].Click += (sender1, ex) => gameStep(0);
            button[1].Click += (sender1, ex) => gameStep(1);
            button[2].Click += (sender1, ex) => gameStep(2);
            button[3].Click += (sender1, ex) => gameStep(3);
            button[4].Click += (sender1, ex) => gameStep(4);
            button[5].Click += (sender1, ex) => gameStep(5);
            button[6].Click += (sender1, ex) => gameStep(6);
            button[7].Click += (sender1, ex) => gameStep(7);
            button[8].Click += (sender1, ex) => gameStep(8);
            button[9].Click += (sender1, ex) => gameStep(9);
            button[10].Click += (sender1, ex) => gameStep(10);
            button[11].Click += (sender1, ex) => gameStep(11);
            button[12].Click += (sender1, ex) => gameStep(12);
            button[13].Click += (sender1, ex) => gameStep(13);
            button[14].Click += (sender1, ex) => gameStep(14);
            button[15].Click += (sender1, ex) => gameStep(15);
            button[16].Click += (sender1, ex) => gameStep(16);
            button[17].Click += (sender1, ex) => gameStep(17);
            button[18].Click += (sender1, ex) => gameStep(18);
            button[19].Click += (sender1, ex) => gameStep(19);
            button[20].Click += (sender1, ex) => gameStep(20);
            button[21].Click += (sender1, ex) => gameStep(21);
            button[22].Click += (sender1, ex) => gameStep(22);
            button[23].Click += (sender1, ex) => gameStep(23);
            button[24].Click += (sender1, ex) => gameStep(24);
            button[25].Click += (sender1, ex) => gameStep(25);
            button[26].Click += (sender1, ex) => gameStep(26);
            button[27].Click += (sender1, ex) => gameStep(27);
            button[28].Click += (sender1, ex) => gameStep(28);
            button[29].Click += (sender1, ex) => gameStep(29);
            button[30].Click += (sender1, ex) => gameStep(30);
            button[31].Click += (sender1, ex) => gameStep(31);
            button[32].Click += (sender1, ex) => gameStep(32);
            button[33].Click += (sender1, ex) => gameStep(33);
            button[34].Click += (sender1, ex) => gameStep(34);
            button[35].Click += (sender1, ex) => gameStep(35);
            button[36].Click += (sender1, ex) => gameStep(36);
            button[37].Click += (sender1, ex) => gameStep(37);
            button[38].Click += (sender1, ex) => gameStep(38);
            button[39].Click += (sender1, ex) => gameStep(39);
            button[40].Click += (sender1, ex) => gameStep(40);
            button[41].Click += (sender1, ex) => gameStep(41);
            button[42].Click += (sender1, ex) => gameStep(42);
            button[43].Click += (sender1, ex) => gameStep(43);
            button[44].Click += (sender1, ex) => gameStep(44);
            button[45].Click += (sender1, ex) => gameStep(45);
            button[46].Click += (sender1, ex) => gameStep(46);
            button[47].Click += (sender1, ex) => gameStep(47);
            button[48].Click += (sender1, ex) => gameStep(48);
            button[49].Click += (sender1, ex) => gameStep(49);
            button[50].Click += (sender1, ex) => gameStep(50);
            button[51].Click += (sender1, ex) => gameStep(51);
            button[52].Click += (sender1, ex) => gameStep(52);
            button[53].Click += (sender1, ex) => gameStep(53);
            button[54].Click += (sender1, ex) => gameStep(54);
            button[55].Click += (sender1, ex) => gameStep(55);
            button[56].Click += (sender1, ex) => gameStep(56);
            button[57].Click += (sender1, ex) => gameStep(57);
            button[58].Click += (sender1, ex) => gameStep(58);
            button[59].Click += (sender1, ex) => gameStep(59);
            button[60].Click += (sender1, ex) => gameStep(60);
            button[61].Click += (sender1, ex) => gameStep(61);
            button[62].Click += (sender1, ex) => gameStep(62);
            button[63].Click += (sender1, ex) => gameStep(63);
            return button;
        }
    }
}