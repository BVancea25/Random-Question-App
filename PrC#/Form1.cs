namespace PrC_
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 startQuiz = new Form2();
            Visible = false;
            startQuiz.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 statistici= new Form4();
            Visible = false;
            statistici.Show();
        }
    }
}