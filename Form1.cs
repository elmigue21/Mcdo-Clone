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

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();


            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 1050;
            this.Width = 748;


            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;


            this.MaximizeBox = false;
            Methods.CenterSub(panel1);
            Methods.CenterSub(panel2);
            Methods.RoundBorders(panel2, 20);
            Methods.RoundBorders(panel4, 20);
            Methods.MatchParentWidth(label1);
            Methods.MatchParentWidth(label2);
            Methods.InheritEvent(panel2, panel2_Click);
            Methods.InheritEvent(panel4, panel4_Click);


        }
        private void panel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2("Eat in");
            form2.FormClosed += (s, args) => this.Close();
            form2.Show();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2("Take out");
            form2.FormClosed += (s, args) => this.Close();
            form2.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {


        }

        private void label1_Click_1(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void flowLayoutPanel3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
