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
    public partial class Form7 : Form
    {
        public string pic = "";
        private string eatText;

        public Form7(string eatText, string paymentmethod)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.pic = paymentmethod;
            this.Height = 1050;
            this.Width = 748;
            this.AutoScroll = false;

            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;

            this.MaximizeBox = false;

            Methods.RoundBorders(panel2, 20);
            Methods.RoundBorders(panel3, 20);
            Methods.RoundBorders(pictureBox5, 10);
            Methods.RoundBorders(pictureBox3, 10); 
            Methods.InheritEvent(panel2, panel2_Click);
            Methods.InheritEvent(panel3, panel3_Click);
            this.eatText = eatText;

        }

        private void Form7_Load(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (pic == "")
            {
                pic = "qr";
            }
            Form3 form3 = new Form3(pic);
            form3.eatText = eatText;
            form3.FormClosed += (s, args) => this.Close();
            form3.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (pic == "")
            {
                pic = "credit";
            }
            Form3 form3 = new Form3(pic);
            form3.eatText = eatText;
            form3.FormClosed += (s, args) => this.Close();
            form3.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {

            }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
