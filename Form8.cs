using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        private Timer timer;
        private int dotCount = 0;
        private string picTake;

        public Form8(string pic)
        {
            InitializeComponent();
            timer1.Start();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 1050;
            this.Width = 748;

            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;

            Methods.RoundBorders(pictureBox2, 20);
            Methods.RoundBorders(button2, 10);
            Methods.RoundBorders(button1, 10);
            picTake = pic;
        }

        // changes depending on payment method
        private void Form8_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            button1.Visible = false;
            label1.Visible = false;
            Methods.MatchParentWidth(label2);
            label2.TextAlign = ContentAlignment.MiddleCenter;

     
            if(picTake == "cash" )
            {
                label2.Text = "Please pay at the counter";
                pictureBox2.Image = null;
            }
            else if (picTake == "qr")
            {
                pictureBox2.Image = Image.FromFile(Path.Combine(Application.StartupPath, "qrcredit", "qranimation.gif"));
                label2.Text = "Scan the QR code b
            }
            else if (picTake == "credit")
            {
                pictureBox2.Image = Image.FromFile(Path.Combine(Application.StartupPath, "qrcredit", "cardanimation.gif"));
                label2.Text = "Tap you card in the device down below";
            }
            timer = new Timer();
            timer.Interval = 7000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        //timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            pictureBox2.Visible = false;
            label1.Visible = true;
            animate();
        }
        // animate timer
        private void animate()
        {
          
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                button1.Visible = true;
                label1.Visible = false;
            };
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dotCount++;
            if (dotCount > 4)
                dotCount = 0;

            label1.Text = "Processing" + new string('.', dotCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3(picTake);
            form3.FormClosed += (s, args) => this.Close();
            form3.Show();
        }
        // receipt printing
        private void button1_Click(object sender, EventArgs e)
        {
            string a = "\n\n\n\n\n\n==============RECEIPT==============\n";
            a += "-----------------------------------------------------------------\n";
            a += "                        YOUR ORDER NUMBER IS        \n";
            Random random = new Random();
            int randomNumber = random.Next(100);
            string formattedNumber = randomNumber.ToString("00");

            a += "                                         " + formattedNumber + "         ";
            a += "\n----------------------------------------------------------------";
            a += "\n                            MEGA FORTUNE INC.           ";
            a += "\n                                 City Of Manila             ";
            a += "\nFor online delivery,\nvisit mcdelivery.com.ph\nTell us about your McDonald's experience\n";
            a += "www.mcdolistens.com\nSurvey Code: 0478\nwriteus@ph.mcd.com\nOfficial Receipt #000989\n";
            a += "\n===================================\n\n";
            Form6 form6 = Form6.GetInstance();
            foreach(Form6.Items item in form6.items)
            {
                string b = "(x" + item.ItemQuantity + ")" + item.ItemName;
                if (b.Length < 80)
                {
                    b = b.PadRight(80 - b.Length, '.');
                }


                a += "\n" + b + ((item.TotalPrice + item.ExtraPrice) * item.ItemQuantity);

            }
            a += "\n\n\n===================================";
            double z = 0;
            foreach (Form6.Items item in form6.items)
            {
                z += (item.TotalPrice + item.ExtraPrice) * item.ItemQuantity;
            }
            a += "\nTotal Price: " + z;
                a += "\n===================================\n\n";
            a += "Please pick up your order at the claim counter. \nFor table service, kindaly wait for it at your table";
            a += "\nThank you, please come again\nThis serves as an OFFICIAL RECECIPT";
            a += "\n\n===================================\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            MessageBox.Show(a);
        }
    }
}
