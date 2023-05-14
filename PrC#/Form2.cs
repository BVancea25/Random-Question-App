using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PrC_
{
    public partial class Form2 : Form
    {
        private string[] allQuestions;
        private string[] selectedQuestions = new string[10];
        private Dictionary<string, string> questionAnswerPairs = new Dictionary<string, string>();
        private int score;
        private string name="";
        public Form2()
        {
            InitializeComponent();


            allQuestions = File.ReadAllLines("C:\\Users\\Bogdan\\Visual Studio Projects\\PrC#\\PrC#\\questions.txt");

            for (int i = 0; i < 10; i++)
            {

                int index = checkRandomQuestion(selectedQuestions, allQuestions);
                string[] questionAndAnswer = allQuestions[index].Split('?');
                selectedQuestions[i] = questionAndAnswer[0];
                questionAnswerPairs.Add(questionAndAnswer[0], questionAndAnswer[1]);

            }

           

            displayQuestions();
        }

        private int checkRandomQuestion(string[] selectedQuestions, string[] allQuestions)
        {
            Random rand = new Random();
            int index = rand.Next(allQuestions.Length);
            while (selectedQuestions.Contains(allQuestions[index].Split('?')[0]))
            {
                index = rand.Next(allQuestions.Length);
            }
            return index;
        }

        private void displayQuestions()
        {
            label1.Text = selectedQuestions[0];
            label2.Text = selectedQuestions[1];
            label3.Text = selectedQuestions[2];
            label4.Text = selectedQuestions[3];
            label5.Text = selectedQuestions[4];
            label6.Text = selectedQuestions[5];
            label7.Text = selectedQuestions[6];
            label8.Text = selectedQuestions[7];
            label9.Text = selectedQuestions[8];
            label10.Text = selectedQuestions[9];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TextBox> raspunsuri = new List<TextBox>
            {
                textBox1,
                textBox2,
                textBox3,
                textBox4,
                textBox5,
                textBox6,
                textBox7,
                textBox8,
                textBox9,
                textBox10
            };
            int i = 0;
            foreach (TextBox textBox in raspunsuri)
            { 
                Console.WriteLine(questionAnswerPairs.GetValueOrDefault(selectedQuestions[i]));
                if (textBox.Text == questionAnswerPairs.GetValueOrDefault(selectedQuestions[i])){
                    score++;
                }
                
                i++;
            }
            name=textBox11.Text;
            Form3 result= new Form3(name,score);
            Visible = false;
            result.Show();
            
        }
    }
}
