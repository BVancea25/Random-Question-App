using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrC_
{
    public partial class Form3 : Form
    {
        public Form3(string name, int score)
        {
            InitializeComponent();
            writeToFile(name, score);
            label1.Text = $"Bravo {name}, ai obtinut nota {score}";

        }

        private void writeToFile(string name, int score)
        {
            string output = $"{name}\t{score}\n";
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Bogdan\\Visual Studio Projects\\PrC#\\PrC#\\rezultate.txt", true))
            {
                Console.WriteLine(output);
                sw.Write(output);
                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            Visible = false;
            menu.Show();
        }
    }
}
