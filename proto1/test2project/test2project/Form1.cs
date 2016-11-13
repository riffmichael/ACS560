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

namespace test2project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public class Candy
        {
        
        }

        public class board
        {
            
            int[] myboard = new int[16];
            public board(int[] board)
            {
                //int[,] myboard = new int[4,4];

                for (int i = 0; i < 16; i++)
                {
                        myboard[i] = board[i];
                                 }//init board loop
            }//end board constructor

            public void printBoard()
            {
                for (int i = 0; i < 16; i++)
                {
                    
                        System.Diagnostics.Debug.Write(myboard[i]);

                    if (i%4==3 )
                    System.Diagnostics.Debug.WriteLine("");
                }//init board loop

            }

            public int getvalue(int val)
            {
                return myboard[val];
            }
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {

            
            
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://52.24.237.185/login?user=test&pass=test123123");
            StreamReader reader = new StreamReader(stream);

            Newtonsoft.Json.Linq.JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadLine());

            // instead of WriteLine, 2 or 3 lines of code here using WebClient to download the file


            System.Diagnostics.Debug.WriteLine(jObject.Root["Board"]);


            stream.Close();
            int[] tempboard = new int[16];
            

            for (int i=0; i<16; i++)
            {
                tempboard[i] = (int)jObject.Root["Board"][i];

            }

            
 

            board gameboard = new board(tempboard);
            gameboard.printBoard();

            Button[] buttons = this.Controls.OfType<Button>().ToArray();

            for (int i = 0; i < 16; i++)
            {
                buttons[i].Text = ""+gameboard.getvalue(i);
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
