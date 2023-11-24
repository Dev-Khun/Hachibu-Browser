using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebBrowser web = new WebBrowser();
        int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader fav = new StreamReader("Favoritos.txt"))
            {
                while (!fav.EndOfStream)
                {
                    toolStripComboBox2.Items.Add(fav.ReadLine());
                }
            }

            web = new WebBrowser();
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);

            tabControl1.TabPages.Add("Aba");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            i += 1;

            using (StreamReader reader = new StreamReader("HomePage.txt"))
                HomePage.Home = reader.ReadLine();
        }

        void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Stop();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = HomePage.Home;
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(HomePage.Home);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text != "")
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("A caixa de texto está vazia!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void url_Click(object sender, EventArgs e)
        {

        }

        private void url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                toolStripButton6.PerformClick();
            }
        }

        private void WebBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
           
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (i == 7)
            {
                MessageBox.Show("Já tem o numero máximo de abas abertas","Nop!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                web = new WebBrowser();
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);

                tabControl1.TabPages.Add("Nova Aba");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(web);
                i += 1;
                toolStripComboBox1.Text = "";
            }
        }

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            toolStripComboBox1.Text = Convert.ToString(((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Definicoes df = new Definicoes();
            df.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
            else
            {
                MessageBox.Show("Esta tab não pode ser fechada!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            //int num_tabs = tabControl1.TabCount;
            //if (num_tabs <= 1)
            //{
              //  MessageBox.Show("Não há tabs para fechar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else
            //{
              //  tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            //}
        }

        private void webBrowser1_ProgressChanged_1(object sender, WebBrowserProgressChangedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted_2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                toolStripButton6.PerformClick();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click_1(object sender, EventArgs e)
        {
            int num_fav = toolStripComboBox2.Items.Count;
            string favorito = toolStripComboBox1.Text;

            if (toolStripComboBox1.Text != "")
            {
                if (num_fav < 7)
                {
                    if (!toolStripComboBox2.Items.Contains(favorito))
                    {
                        toolStripComboBox2.Items.Add(favorito);
                        MessageBox.Show("Adicionado com sucesso aos favoritos!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Este site já está nos favoritos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Escedeu o número limite de sites nos Favoritos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("A caixa de texto está vazia!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
   
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.Text != "" && toolStripComboBox2.Text != "Favoritos")
            {
                switch (toolStripComboBox2.SelectedIndex)
                {
                    case 0:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 1:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 2:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 3:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 4:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 5:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;

                    case 6:
                        toolStripComboBox1.Text = this.toolStripComboBox2.Text;
                        toolStripButton6.PerformClick();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Não há nada para pesquisar!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                TabPage aba = tabControl1.SelectedTab;
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter fav = new StreamWriter("Favoritos.txt"))
            {
                foreach (object item in toolStripComboBox2.Items)
                {
                    fav.WriteLine(item);
                }
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.Items.Count != 0)
            {
                toolStripComboBox2.Items.Remove(toolStripComboBox2.SelectedItem);
                MessageBox.Show("Os item removido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripComboBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Não há itens para remover","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
    //public partial class BrowserTab : TabPage
    //{
    //  WebBrowser wb = new WebBrowser();

    //public BrowserTab()
    //{
    //  wb.SetBounds(0, 0, 10000, 10000);
    //wb.Url = new Uri("http://www.google.com");

    // this.Controls.Add(wb);
}