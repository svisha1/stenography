namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public bool check = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pas = "1234";
            if(textBox1.Text == pas)
            {
                check = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль неверный");
            }

        }
    }
}