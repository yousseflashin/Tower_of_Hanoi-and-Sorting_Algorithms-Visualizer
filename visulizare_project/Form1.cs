using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visulizare_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool go_to_hanoi = false, go_to_bubble = false, go_to_insertion = false, go_to_selection = false, go_to_main_menu = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hanoi h = new Hanoi();
            h.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bubble_sort h1 = new bubble_sort();
            h1.Show();
            this.Hide();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            selction_sort h2 = new selction_sort();
            h2.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            insertion_sort h3 = new insertion_sort();
            h3.Show();
            this.Hide();
        }
    }
}

