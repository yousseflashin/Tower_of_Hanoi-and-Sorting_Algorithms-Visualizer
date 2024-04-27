using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace visulizare_project
{
    public partial class bubble_sort : Form
    {
        public bubble_sort()
        {
            InitializeComponent();
        }
        Panel main = new Panel();
        Panel visualize = new Panel();
        TextBox numbers = new TextBox();
        Button compile = new Button();
        Button rest = new Button();
        Button back_to_menue = new Button();
        Label project_name = new Label();
        TextBox recursionlistt = new TextBox();
        RadioButton slow = new RadioButton();
        RadioButton x0_25 = new RadioButton();
        RadioButton x0_50 = new RadioButton();
        RadioButton x0_75 = new RadioButton();
        RadioButton normal = new RadioButton();
        RadioButton x1_25 = new RadioButton();
        RadioButton x1_50 = new RadioButton();
        RadioButton x1_75 = new RadioButton();
        RadioButton instante = new RadioButton();
        FlowLayoutPanel speedlist = new FlowLayoutPanel();
        Button[] arr;
        Button[] ar;
        double t = 1;

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1100, 700);
            main.Size = new Size(this.Width, this.Height);
            back_to_menue.Text = "back to menue";
            back_to_menue.Location = new Point(10, 10);
            back_to_menue.AutoSize = true;
            back_to_menue.Click += new EventHandler(back_to_menue_op);
            main.Controls.Add(back_to_menue);

            project_name.Text = "Bubble Sort";
            project_name.Font = new Font("ALGERIAN", 50);
            project_name.Size = new Size(700, 100);
            project_name.AutoSize = true;
            project_name.Location = new Point(((main.Width - project_name.Width) / 2) + 100, ((main.Height - project_name.Height) / 2) - 300);
            project_name.BackColor = Color.Transparent;
            main.Controls.Add(project_name);
            // main.BackColor = Color.Red;
            visualize.Size = new Size(this.Width / 2, this.Height / 2);
            visualize.BackColor = Color.LightGray;
            visualize.BorderStyle = BorderStyle.Fixed3D;
            visualize.Location = new Point((main.Width - visualize.Width) / 2, (main.Height - visualize.Height) / 2);
            numbers.Size = new Size((this.Width / 2) - 60, (30));
            numbers.Location = new Point(((main.Width - numbers.Width) / 2), ((main.Height - numbers.Height) / 2) + (visualize.Height / 2) + numbers.Height);
            numbers.TextAlign = HorizontalAlignment.Center;
            compile.Text = "compile";
            compile.Size = new Size((this.Width / 4), (20));
            compile.Location = new Point(((main.Width - compile.Width) / 2), (((main.Height - compile.Height) / 2) + (visualize.Height / 2) + numbers.Height + compile.Height + 5));
            compile.Click += new EventHandler(bubble_sort_creation);
            rest.Location = new Point(((main.Width - rest.Width) / 2) + (numbers.Width / 2) + rest.Width, ((main.Height - rest.Height) / 2) + (visualize.Height / 2) + rest.Height);
            rest.Click += new EventHandler(rest_action);
            this.Controls.Add(main);
            main.Controls.Add(numbers);
            main.Controls.Add(compile);
            main.Controls.Add(rest);
            main.Controls.Add(visualize);
            rest.Text = "rest";
            numbers.BringToFront();
            main.Controls.Add(speedlist);
            slow.Text = "slow";
            x0_25.Text = "X0.25";
            x0_50.Text = "X0.50";
            x0_75.Text = "X0.75";
            normal.Text = "normal";
            x1_25.Text = "X1.25";
            x1_50.Text = "X1.50";
            x1_75.Text = "X1.75";
            instante.Text = "instante";
            slow.AutoSize = true;
            x0_25.AutoSize = true;
            x0_50.AutoSize = true;
            x0_75.AutoSize = true;
            normal.AutoSize = true;
            x1_25.AutoSize = true;
            x1_50.AutoSize = true;
            x1_75.AutoSize = true;
            instante.AutoSize = true;
            slow.CheckedChanged += new EventHandler(slow_CheckedChanged);
            x0_25.CheckedChanged += new EventHandler(x0_25_CheckedChanged);
            x0_50.CheckedChanged += new EventHandler(x0_50_CheckedChanged);
            x0_75.CheckedChanged += new EventHandler(x0_75_CheckedChanged);
            normal.CheckedChanged += new EventHandler(normal_CheckedChanged);
            x1_25.CheckedChanged += new EventHandler(x1_25_CheckedChanged);
            x1_50.CheckedChanged += new EventHandler(x1_50_CheckedChanged);
            x1_75.CheckedChanged += new EventHandler(x1_75_CheckedChanged);
            instante.CheckedChanged += new EventHandler(instante_CheckedChanged);
            speedlist.Controls.Add(slow);
            speedlist.Controls.Add(x0_25);
            speedlist.Controls.Add(x0_50);
            speedlist.Controls.Add(x0_75);
            speedlist.Controls.Add(normal);
            speedlist.Controls.Add(x1_25);
            speedlist.Controls.Add(x1_50);
            speedlist.Controls.Add(x1_75);
            speedlist.Controls.Add(instante);
            speedlist.Location = new Point(10, visualize.Location.Y + visualize.Height);
            speedlist.Size = new Size(300, 50);
        }
        public void rest_action(object sender, EventArgs e)
        {
            visualize.Controls.Clear();
        }
        public void bubble_sort_creation(object sender, EventArgs e)
        {
            if (numbers.Text == "" || numbers.Text == "Type the number of bars")
            {
                MessageBox.Show("number required");
            }
            else if (numbers.Text != null)
            {
                bool parsed = int.TryParse(numbers.Text, out int n);

                if (parsed)
                {

                    if (int.Parse(numbers.Text) > 10)
                    {
                        MessageBox.Show("over flow will habben");
                    }
                    else if (int.Parse(numbers.Text) <= 10 && int.Parse(numbers.Text) > 0)
                    {

                        if (slow.Checked == true)
                        {
                            t = 2;
                        }
                        if (x0_25.Checked == true)
                        {
                            t = 1.75;
                        }
                        if (x0_50.Checked == true)
                        {
                            t = 1.50;
                        }
                        if (x0_75.Checked == true)
                        {
                            t = 1.25;
                        }
                        if (normal.Checked == true)
                        {
                            t = 1;
                        }
                        if (x1_25.Checked == true)
                        {
                            t = 0.75;
                        }
                        if (x1_50.Checked == true)
                        {
                            t = 0.50;
                        }
                        if (x1_75.Checked == true)
                        {
                            t = 0.25;
                        }
                        if (instante.Checked == true)
                        {
                            t = 0;
                        }
                        int x = int.Parse(numbers.Text);
                        arr = new Button[x];
                        ar = new Button[x];
                        int q = 34;
                        int z = 50;
                        for (int i = 0; i < x; i++)
                        {
                            arr[i] = new Button();
                            ar[i] = new Button();
                            ar[i].BackColor = Color.LightCoral;
                            arr[i].BackColor = Color.LightCoral;
                            arr[i].Enabled = false;
                            ar[i].Enabled = false;
                            //  arr[i].EnabledChanged += new EventHandler(button_enable);
                            arr[i].FlatStyle = FlatStyle.Flat;
                            ar[i].FlatStyle = FlatStyle.Flat;
                            ar[i].FlatAppearance.BorderColor = Color.Black;
                            ar[i].FlatAppearance.BorderSize = 2;
                            arr[i].FlatAppearance.BorderColor = Color.Black;
                            arr[i].FlatAppearance.BorderSize = 2;
                            arr[i].Size = new Size(30, 30);
                            ar[i].Size = new Size(30, 30);
                            arr[i].ForeColor = Color.Black;
                            arr[i].Location = new Point((((visualize.Width - arr[i].Width) / 2) - (x * 30) / 2) + q, ((visualize.Height - arr[i].Height) / 2));
                            ar[i].Location = new Point((((visualize.Width - ar[i].Width) / 2) - (x * 30) / 2) + q, (visualize.Height - ar[i].Height) / 2);
                            q += 34;
                            arr[i].Text = (z).ToString();
                            visualize.Controls.Add(arr[i]);
                            visualize.Controls.Add(ar[i]);
                            z -= 10;
                        }
                        Task.Factory.StartNew(() => bubble_sort_visulizare(arr, ar, x));
                    }
                }
            }
        }
        public void bubble_sort_visulizare(Button[] arr, Button[] ar, int x)
        {
            int temp;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    //ar[i].SendToBack();
                    if (j != x - 1)
                    {

                        if (int.Parse(arr[j].Text) > int.Parse(arr[j + 1].Text))
                        {
                            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
                            int x1 = arr[j].Location.X, x2 = arr[j + 1].Location.X;
                            arr[j].FlatStyle = FlatStyle.Flat;
                            arr[j].FlatAppearance.BorderColor = Color.LightGray;
                            arr[j].FlatAppearance.BorderSize = 2;
                            arr[j + 1].FlatStyle = FlatStyle.Flat;
                            arr[j + 1].FlatAppearance.BorderColor = Color.LightGray;
                            arr[j + 1].FlatAppearance.BorderSize = 2;
                            arr[j].BackColor = Color.Transparent;
                            arr[j + 1].BackColor = Color.Transparent;
                            arr[j].Location = new Point(arr[j].Location.X, ((visualize.Height - arr[i].Height) / 2) - 40);
                            arr[j + 1].Location = new Point(arr[j + 1].Location.X, ((visualize.Height - arr[i].Height) / 2) + 40);
                            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
                            arr[j].Location = new Point(x2, ((visualize.Height - arr[i].Height) / 2) - 40);
                            arr[j + 1].Location = new Point(x1, ((visualize.Height - arr[i].Height) / 2) + 40);
                            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
                            temp = arr[j].Location.X;
                            arr[j].Location = new Point(x2, (visualize.Height - arr[i].Height) / 2);
                            arr[j + 1].Location = new Point(x1, (visualize.Height - arr[i].Height) / 2);
                            arr[j].BackColor = Color.LightCoral;
                            arr[j + 1].BackColor = Color.LightCoral;
                            arr[j].FlatStyle = FlatStyle.Flat;
                            arr[j + 1].FlatStyle = FlatStyle.Flat;
                            arr[j].FlatAppearance.BorderColor = Color.Black;
                            arr[j].FlatAppearance.BorderSize = 2;
                            arr[j + 1].FlatAppearance.BorderColor = Color.Black;
                            arr[j + 1].FlatAppearance.BorderSize = 2;
                            ar[j + 1] = arr[j];
                            ar[j] = arr[j + 1];
                            arr[j + 1] = ar[j + 1];
                            arr[j] = ar[j];
                            arr[j].BringToFront();
                            arr[j + 1].BringToFront();
                        }
                    }
                }
            }
        }
        Form1 form = new Form1();
        private void back_to_menue_op(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }
        private void slow_CheckedChanged(object sender, EventArgs e)
        {
            t = 2;
        }
        private void x0_25_CheckedChanged(object sender, EventArgs e)
        {
            t = 1.25;
        }
        private void x0_50_CheckedChanged(object sender, EventArgs e)
        {
            t = 1.50;
        }

        private void x0_75_CheckedChanged(object sender, EventArgs e)
        {
            t = 1.75;
        }
        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            t = 1;
        }
        private void x1_25_CheckedChanged(object sender, EventArgs e)
        {
            t = 0.75;
        }
        private void x1_50_CheckedChanged(object sender, EventArgs e)
        {
            t = 0.50;
        }
        private void x1_75_CheckedChanged(object sender, EventArgs e)
        {
            t = 0.25;
        }
        private void instante_CheckedChanged(object sender, EventArgs e)
        {
            t = 0;
        }

        private void bubble_sort_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }
    }
}
