using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Definicoes : Form
    {
        public Definicoes()
        {
            InitializeComponent();
        }

        private void Definicoes_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
            label4.Text = "Data: "+dateTimePicker1.Value.DayOfWeek.ToString() 
                +" "+ dateTimePicker1.Value.Day.ToString() 
                +" / "+ dateTimePicker1.Value.Month.ToString() 
                +" / "+ dateTimePicker1.Value.Year.ToString();
            using (StreamReader reader = new StreamReader("HomePage.txt"))
                HomePage.Home = reader.ReadLine();
            label3.Text = HomePage.Home;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(".pt") && !textBox1.Text.Contains(".com") && !textBox1.Text.Contains(".net") && textBox1.TextLength <= 4)
            {
                MessageBox.Show("Não é um endereço web válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Precisa de conter o sufixo '.com','.pt' ou '.net'","Aviso!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("HomePage.txt"))
                    if (textBox1.Text != "")
                    {
                        writer.WriteLine(textBox1.Text);
                    }
                HomePage.Home = textBox1.Text;
                label3.Text = HomePage.Home;
                button2.Enabled = false;
                textBox1.Enabled = false;
                button3.Text = "Fechar";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}