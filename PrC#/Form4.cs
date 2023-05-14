using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
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
    
    public partial class Form4 : Form
    {
        private float average=0;
        private int numberOfEntry = 0;
        public Form4()
        {
            InitializeComponent();
            loadFromFile();
        }

        private void loadFromFile()
        {
            listBox1.Items.Clear();
            List<string> items = new List<string>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Bogdan\\Visual Studio Projects\\PrC#\\PrC#\\rezultate.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split('\t');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        int score;
                        if (int.TryParse(parts[1], out score))
                        {
                            average += score;
                            numberOfEntry++;
                            items.Add($"{name}\t{score}");
                        }
                    }
                }
            }
            items.Sort((x, y) =>
            {
                int xScore = int.Parse(x.Split('\t')[1]);
                int yScore = int.Parse(y.Split('\t')[1]);
                return yScore.CompareTo(xScore);
            });
            listBox1.Items.AddRange(items.ToArray());
            average /= numberOfEntry;
            label2.Text=average.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Visible = false;
            form.Show();
        }
    }
}
