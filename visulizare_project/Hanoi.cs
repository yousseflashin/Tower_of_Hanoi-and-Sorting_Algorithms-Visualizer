using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace visulizare_project
{
    public partial class Hanoi : Form
    {
        public Hanoi()
        {
            InitializeComponent();
        }
        Panel main = new Panel();
        Panel visualize = new Panel();
        TextBox numbers = new TextBox();
        Button compile = new Button();
        Button rest = new Button();
        Button back_to_menue = new Button();
        public FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel4 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel5 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel6 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel7 = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanel8 = new FlowLayoutPanel();
        public FlowLayoutPanel speedlist = new FlowLayoutPanel();
        RadioButton slow = new RadioButton();
        RadioButton x0_25 = new RadioButton();
        RadioButton x0_50 = new RadioButton();
        RadioButton x0_75 = new RadioButton();
        RadioButton normal = new RadioButton();
        RadioButton x1_25 = new RadioButton();
        RadioButton x1_50 = new RadioButton();
        RadioButton x1_75 = new RadioButton();
        RadioButton instante = new RadioButton();
        Button[] bars;
        Stack<Button> apanel = new Stack<Button>();
        Stack<Button> bpanel = new Stack<Button>();
        Stack<Button> cpanel = new Stack<Button>();
        Stopwatch sw = new Stopwatch();
        Stack<string> recursionStack = new Stack<string>();
        TextBox recursionlistt = new TextBox();
        double t = 1;
        Label moves = new Label();
        Label project_name = new Label();
        public static bool go_to_menue = true;
        private void Hanoi_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1100, 700);
            main.Size = new Size(this.Width, this.Height);
            back_to_menue.Text = "back to menue";
            back_to_menue.Location = new Point(10, 10);
            back_to_menue.Click += new EventHandler(back_to_menue_op);
            main.Controls.Add(back_to_menue);

            project_name.Text = "Tower of  Hanoi";
            project_name.Font = new Font("ALGERIAN", 50);
            project_name.Size = new Size(700, 100);
            project_name.AutoSize = true;
            project_name.Location = new Point(((main.Width - project_name.Width) / 2) + 100, ((main.Height - project_name.Height) / 2) - 300);
            project_name.BackColor = Color.Transparent;
            main.Controls.Add(project_name);
            // main.BackColor = Color.Red;
            visualize.Size = new Size((this.Width / 2) + 300, (this.Height / 2) + 100);
            visualize.BackColor = Color.LightGray;
            visualize.BorderStyle = BorderStyle.Fixed3D;
            visualize.Location = new Point(((main.Width - visualize.Width) / 2), (main.Height - visualize.Height) / 2);
            numbers.Size = new Size((this.Width / 2) - 60, (30));
            numbers.Location = new Point(((main.Width - numbers.Width) / 2), ((main.Height - numbers.Height) / 2) + (visualize.Height / 2) + numbers.Height);
            numbers.TextAlign = HorizontalAlignment.Center;
            compile.Text = "compile";
            compile.Click += new EventHandler(hanoi_opreations);
            compile.Size = new Size((this.Width / 4), (20));
            compile.Location = new Point(((main.Width - compile.Width) / 2), (((main.Height - compile.Height) / 2) + (visualize.Height / 2) + numbers.Height + compile.Height + 5));
            //  compile.Click += new EventHandler(insertion_sort_creation);
            rest.Location = new Point(((main.Width - rest.Width) / 2) + (numbers.Width / 2) + rest.Width, ((main.Height - rest.Height) / 2) + (visualize.Height / 2) + rest.Height);
            rest.Click += new EventHandler(rest_action);
            this.Controls.Add(main);
            main.Controls.Add(numbers);
            main.Controls.Add(compile);
            main.Controls.Add(rest);
            main.Controls.Add(visualize);
            numbers.BringToFront();
            //
            flowLayoutPanel1.Size = new Size(10, 250);
            flowLayoutPanel1.BackColor = Color.Black;
            flowLayoutPanel2.Size = new Size(200, 10);
            flowLayoutPanel2.BackColor = Color.Black;
            flowLayoutPanel2.Location = new Point(20, visualize.Height - flowLayoutPanel2.Height - 10);
            flowLayoutPanel1.Location = new Point(115, flowLayoutPanel2.Location.Y - flowLayoutPanel1.Height);
            flowLayoutPanel1.SendToBack();
            flowLayoutPanel2.SendToBack();
            visualize.Controls.Add(flowLayoutPanel1);
            visualize.Controls.Add(flowLayoutPanel2);
            //
            flowLayoutPanel3.Size = new Size(10, 250);
            flowLayoutPanel3.BackColor = Color.Black;
            flowLayoutPanel4.Size = new Size(200, 10);
            flowLayoutPanel4.BackColor = Color.Black;
            flowLayoutPanel4.Location = new Point(300, visualize.Height - flowLayoutPanel4.Height - 10);
            flowLayoutPanel3.Location = new Point(400, flowLayoutPanel4.Location.Y - flowLayoutPanel3.Height);
            flowLayoutPanel4.SendToBack();
            flowLayoutPanel3.SendToBack();
            visualize.Controls.Add(flowLayoutPanel3);
            visualize.Controls.Add(flowLayoutPanel4);
            //
            flowLayoutPanel5.Size = new Size(10, 250);
            flowLayoutPanel5.BackColor = Color.Black;
            flowLayoutPanel6.Size = new Size(200, 10);
            flowLayoutPanel6.BackColor = Color.Black;
            flowLayoutPanel6.Location = new Point(580, visualize.Height - flowLayoutPanel6.Height - 10);
            flowLayoutPanel5.Location = new Point(680, flowLayoutPanel6.Location.Y - flowLayoutPanel5.Height);
            flowLayoutPanel6.SendToBack();
            flowLayoutPanel5.SendToBack();
            visualize.Controls.Add(flowLayoutPanel5);
            visualize.Controls.Add(flowLayoutPanel6);
            //
            flowLayoutPanel7.Size = new Size(10, 200);
            flowLayoutPanel7.BackColor = Color.Black;
            flowLayoutPanel7.Location = new Point(255, flowLayoutPanel1.Location.Y);
            flowLayoutPanel8.Size = new Size(10, 200);
            flowLayoutPanel8.BackColor = Color.Black;
            flowLayoutPanel8.Location = new Point(535, flowLayoutPanel1.Location.Y);
            visualize.Controls.Add(flowLayoutPanel7);
            visualize.Controls.Add(flowLayoutPanel8);
            flowLayoutPanel7.Hide();
            flowLayoutPanel8.Hide();
            //
            moves.Location = new Point((visualize.Width / 2) - 40, 30);
            moves.AutoSize = true;
            moves.Text = "Moves";
            visualize.Controls.Add(moves);
            recursionlistt.Location = new Point(5, visualize.Location.Y);
            recursionlistt.Size = new Size(115, visualize.Height);
            recursionlistt.Multiline = true;
            recursionlistt.ReadOnly = true;
            main.Controls.Add(recursionlistt);
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
            rest.Text = "rest";
            back_to_menue.AutoSize = true;
        }
        public void hanoi_opreations(object sender, EventArgs e)
        {
            bars_generator();
            Task.Factory.StartNew(() => tower_of_hanoi(bars.Length, flowLayoutPanel1.Location.X.ToString(), flowLayoutPanel3.Location.X.ToString(), flowLayoutPanel5.Location.X.ToString(), recursionStack));
        }
        public void bars_generator()
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
                        normal.AutoCheck = true;
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
                        int y = 10;
                        int x = 20;
                        int z = int.Parse(numbers.Text);
                        bars = new Button[z];
                        for (int i = 0; i < z; i++)
                        {
                            bars[i] = new Button();
                            bars[i].Size = new Size(75 + y, 25);
                            bars[i].BackColor = Color.White;
                            bars[i].ForeColor = Color.Black;
                            bars[i].Enabled = false;
                            bars[i].FlatStyle = FlatStyle.Flat;
                            bars[i].FlatAppearance.BorderColor = Color.Black;
                            bars[i].FlatAppearance.BorderSize = 2;
                            bars[i].TextAlign = ContentAlignment.TopCenter;
                            bars[i].Text = (i + 1).ToString();
                            y += 10;
                        }
                        int q;
                        for (int i = 0; i < z; i++)
                        {
                            q = (visualize.Height - 25) - x;
                            bars[z - i - 1].Location = new Point((flowLayoutPanel1.Location.X - bars[z - i - 1].Width / 2) + 5, q);
                            x += 25;
                            visualize.Controls.Add(bars[i]);
                            bars[i].BringToFront();
                            apanel.Push(bars[i]);

                        }
                    }
                }
            }
        }
        public void move_farr(string start, string end, string mid, string between, string mid2, int n, Stack<Button> panel)
        {
            bars[n - 1].Location = new Point((int.Parse(start)) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(mid.ToString()), 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(between.ToString()) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(mid2.ToString()) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(end.ToString()) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point((int.Parse(end)) - (bars[n - 1].Width / 2) + 5, (flowLayoutPanel2.Location.Y - 25) - (panel.Count * 25));

        }
        public void move_near(string start, string end, string mid, int n, Stack<Button> panel)
        {
            //MessageBox.Show(panel.Count.ToString());
            bars[n - 1].Location = new Point((int.Parse(start)) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(mid.ToString()) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(end.ToString()) - (bars[n - 1].Width / 2) + 5, 120);
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            bars[n - 1].Location = new Point(int.Parse(end) - (bars[n - 1].Width / 2) + 5, (flowLayoutPanel2.Location.Y - 25) - (panel.Count * 25));
            //  bars[n - 1].BringToFront();
        }
        public void rest_action(object sender, EventArgs e)
        {
            bool b = true;

            /* while (b == true)
             {
                 b = false;
                 foreach (Button p in ((Panel)visualize).Controls.OfType<Button>())
                 {
                     b = true;
                     // visualize.Controls.Remove(p);
                     // MessageBox.Show(i.ToString());
                 }
             }*/
            visualize.Controls.Clear();
            bars = new Button[0];
            cpanel.Clear();
            apanel.Clear();
            bpanel.Clear();
            visualize.Controls.Add(flowLayoutPanel1);
            visualize.Controls.Add(flowLayoutPanel2);
            visualize.Controls.Add(flowLayoutPanel3);
            visualize.Controls.Add(flowLayoutPanel4);
            visualize.Controls.Add(flowLayoutPanel5);
            visualize.Controls.Add(flowLayoutPanel6);
            visualize.Controls.Add(flowLayoutPanel7);
            visualize.Controls.Add(flowLayoutPanel8);
            visualize.Controls.Add(moves);




        }
        string p1 = "start", e1 = "end";
        public void tower_of_hanoi(int n, string start, string temp, string end, Stack<string> recursionStack)
        {
            sw.Start();
            if (n == 0)
            {
                Task.Delay(TimeSpan.FromSeconds(t)).Wait();
                recursionlistt.Clear();
                foreach (string item in recursionStack)
                {
                    recursionlistt.Text = recursionlistt.Text + '\n' + item;
                }
                return;
            }
            recursionStack.Push((n) + " go from  " + p1 + " to " + e1 + " ");
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            recursionlistt.Clear();
            foreach (string item in recursionStack)
            {
                recursionlistt.Text = recursionlistt.Text + '\n' + item;
            }
            tower_of_hanoi(n - 1, start, end, temp, recursionStack);
            recursionStack.Pop();
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            recursionlistt.Clear();
            foreach (string item in recursionStack)
            {
                recursionlistt.Text = recursionlistt.Text + '\n' + item;
            }
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            if (start == flowLayoutPanel1.Location.X.ToString() && end == flowLayoutPanel5.Location.X.ToString())
            {
                // ittir[f - 1].Text = n + " : from " + start + " to " + end;
                p1 = "start"; e1 = "end";
                moves.Text = (n) + " go from  " + p1 + " to " + e1 + " ";
                if (apanel.Count > 0)
                    apanel.Pop();
                move_farr(start, end, flowLayoutPanel7.Location.X.ToString(), flowLayoutPanel3.Location.X.ToString(), flowLayoutPanel8.Location.X.ToString(), n, cpanel);
                cpanel.Push(bars[n - 1]);
                // flowLayoutPanel10.Controls.Add(ittir);
            }
            if (start == flowLayoutPanel1.Location.X.ToString() && end == flowLayoutPanel3.Location.X.ToString())
            {

                p1 = "start"; e1 = "temp";
                moves.Text = (n) + " go from  " + p1 + " to " + e1 + " ";
                // ittir.Text = n + " : from " + start + " to " + end;
                //itiration[n - 1].Text = n + " : from " + start + " to " + end;
                if (apanel.Count > 0)
                    apanel.Pop();
                move_near(start, end, flowLayoutPanel7.Location.X.ToString(), n, bpanel);
                bpanel.Push(bars[n - 1]);
            }
            if (start == flowLayoutPanel3.Location.X.ToString() && end == flowLayoutPanel1.Location.X.ToString())
            {
                //ittir.Text = n + " : from " + start + " to " + end;
                // itiration[n - 1].Text = n + " : from " + start + " to " + end;
                p1 = "temp"; e1 = "start";
                moves.Text = (n) + " go from  " + p1 + " to " + e1 + " ";
                if (bpanel.Count > 0)
                    bpanel.Pop();
                move_near(start, end, flowLayoutPanel7.Location.X.ToString(), n, apanel);
                apanel.Push(bars[n - 1]);
            }
            if (start == flowLayoutPanel3.Location.X.ToString() && end == flowLayoutPanel5.Location.X.ToString())
            {
                //ittir.Text = n + " : from " + start + " to " + end;
                // itiration[n - 1].Text = n + " : from " + start + " to " + end;
                p1 = "temp"; e1 = "end";
                moves.Text = (n) + " go from  " + p1 + " to " + e1 + " ";
                if (bpanel.Count > 0)
                    bpanel.Pop();
                move_near(start, end, flowLayoutPanel8.Location.X.ToString(), n, cpanel);
                cpanel.Push(bars[n - 1]);
            }
            if (start == flowLayoutPanel5.Location.X.ToString() && end == flowLayoutPanel1.Location.X.ToString())
            {
                //ittir.Text = n + " : from " + start + " to " + end;
                // itiration[n - 1].Text = n + " : from " + start + " to " + end;
                p1 = "end"; e1 = "start";
                moves.Text = (n) + " go from  " + p1 + " to " + e1 + " ";
                if (cpanel.Count > 0)
                    cpanel.Pop();
                move_farr(start, end, flowLayoutPanel8.Location.X.ToString(), flowLayoutPanel3.Location.X.ToString(), flowLayoutPanel7.Location.X.ToString(), n, apanel);
                apanel.Push(bars[n - 1]);
            }
            if (start == flowLayoutPanel5.Location.X.ToString() && end == flowLayoutPanel3.Location.X.ToString())
            {
                // ittir.Text = n + " : from " + start + " to " + end;
                //itiration[n - 1].Text = n + " : from " + start + " to " + end;
                p1 = "end"; e1 = "temp";
                moves.Text = (n) + "go from  " + p1 + " to " + e1 + " ";
                if (cpanel.Count > 0)
                    cpanel.Pop();
                move_near(start, end, flowLayoutPanel8.Location.X.ToString(), n, bpanel);
                bpanel.Push(bars[n - 1]);
            }
            recursionStack.Push(n + " go from  " + p1 + " to " + e1 + " ");
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            recursionlistt.Clear();
            foreach (string item in recursionStack)
            {
                recursionlistt.Text = recursionlistt.Text + '\n' + item;
            }
            tower_of_hanoi(n - 1, temp, start, end, recursionStack);
            recursionStack.Pop();
            Task.Delay(TimeSpan.FromSeconds(t)).Wait();
            recursionlistt.Clear();
            foreach (string item in recursionStack)
            {
                recursionlistt.Text = recursionlistt.Text + '\n' + item;
            }
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
        Form1 form = new Form1();

        private void Hanoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void back_to_menue_op(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }
    }
}
