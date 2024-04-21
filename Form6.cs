using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        private static Form6 instance;
        public int TotalItems;
        public double toPay;
        public string picTake{ get; private set; }
        // class for object for each order
        public class Items {
            public string ItemName { get; set; }
            public double TotalPrice { get; set; }
            public string ImagePath { get; set; }
            public int ItemQuantity { get; set; }

            public int foodSelection { get; set; }
            public int index { get; set; }
            public double ExtraPrice { get; set; }
        }
        public string eat;
        // list for all order
        public List<Items> items = new List<Items>();
        public Form6(string pic)
        {
            picTake = pic;
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 1050;
            this.Width = 748;


            this.ControlBox = false;
            this.FormClosing += (sender, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true; 
                }
            };
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;


            Methods.CenterSub(panel1);
            Methods.MatchParentWidth(pictureBox1);
            Methods.MatchParentWidth(panel3);
            Methods.CenterSub(panel3);
            panel3.Width += 5; 

        }

        public static Form6 GetInstance()
        {
            if (instance == null)
            {
                instance = new Form6("");
            }
            return instance;
        }
        // function to create the meal object and add it to the list
        public void AddFood(string itemName, double totalItemPrice, string imageLink, int quantity, int selection, int index , double extra)
        {
            Items item = new Items();
            item.ItemName = itemName;
            item.TotalPrice = totalItemPrice;
            item.ImagePath = imageLink;
            item.ItemQuantity = quantity;
            item.foodSelection = selection;
            item.index= index;
            item.ExtraPrice = extra;
            items.Add(item);

            MakePanel(item);
        }
        // panel creation logic
        private void MakePanel(Items item)
        {
            PictureBox panelPictureBox = new PictureBox();
            Label nameLabel = new Label();
            nameLabel.AutoSize = true;
            Label priceLabel = new Label();
            Label totalLabel = new Label();

            panelPictureBox.Image = Image.FromFile(item.ImagePath);

            panelPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            panelPictureBox.Height = 75;
            panelPictureBox.Width = 75;

            nameLabel.Text = "(" + item.ItemQuantity + "x) " + item.ItemName;
            priceLabel.Text = "Base price: " + (item.TotalPrice + item.ExtraPrice).ToString("PHP #,###.00");
            totalLabel.Text = (item.ItemQuantity * (item.TotalPrice + item.ExtraPrice)).ToString("PHP ###,##0.00");
            totalLabel.AutoSize = true;

            FlowLayoutPanel labelFlow = new FlowLayoutPanel();

            labelFlow.FlowDirection = FlowDirection.TopDown;
            nameLabel.Width = 150;
            nameLabel.Height = 30;
            nameLabel.AutoSize = false;
            nameLabel.Margin = new Padding(0);
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;
            totalLabel.TextAlign = ContentAlignment.MiddleLeft;
            labelFlow.Controls.Add(nameLabel);

            FlowLayoutPanel labelFlow2 = new FlowLayoutPanel();
            labelFlow2.AutoSize = true;
            Label labelMinus = new Label();
            Label labelPlus = new Label();
            Label qtyLabel = new Label();

            Panel minusPanel = new Panel();
            Panel plusPanel = new Panel();
            Panel qtyPanel = new Panel();

            Button minusButton = new Button();
            Button plusButton = new Button();

            minusButton.Text = "-";
            plusButton.Text = "+";

            labelMinus.Margin = new Padding(0);

            minusPanel.Controls.Add(labelMinus);
            plusPanel.Controls.Add(labelPlus);
            
            qtyPanel.Controls.Add(qtyLabel);

            labelMinus.Text = "-";
            labelMinus.TextAlign = ContentAlignment.MiddleCenter;
            minusPanel.Size = new Size(50, 50);
            labelMinus.Dock = DockStyle.Fill;
            minusPanel.BackColor = Color.Red;
            labelMinus.Font = new Font(labelMinus.Font.FontFamily, 12); 

            labelPlus.Text = "+";
            labelPlus.TextAlign = ContentAlignment.MiddleCenter;
            plusPanel.Size = new Size(50, 50);
            labelPlus.Dock = DockStyle.Fill;
            plusPanel.BackColor = Color.Red;
            labelPlus.Font = new Font(labelMinus.Font.FontFamily, 12);
           
            qtyLabel.Text = item.ItemQuantity.ToString();
            qtyLabel.TextAlign = ContentAlignment.MiddleCenter;
            qtyPanel.Size = new Size(50, 50);
            qtyLabel.Dock = DockStyle.Fill;
            qtyLabel.Font = new Font(labelMinus.Font.FontFamily, 12);

            plusPanel.Margin = new Padding(0);
            minusPanel.Margin = new Padding(0);
            qtyPanel.Margin = new Padding(0);
            int q;

            labelPlus.Click += (sender, e) =>
            {
                q = add(item);
                nameLabel.Text = "(" + q + "x) " + item.ItemName;
                totalLabel.Text = (q * (item.TotalPrice + item.ExtraPrice)).ToString("PHP ###,##0.00");
                qtyLabel.Text = q.ToString();

            };
            labelMinus.Click += (sender, e) =>
            {
                q = sub(item);
                nameLabel.Text = "(" + q + "x) " + item.ItemName;
                totalLabel.Text = (q * (item.TotalPrice + item.ExtraPrice)).ToString("PHP ###,##0.00");
                 qtyLabel.Text = q.ToString();
            };
            

           labelFlow2.Controls.Add(minusPanel);
            labelFlow2.Controls.Add(qtyPanel);
            labelFlow2.Controls.Add(plusPanel);

            minusPanel.Margin = new Padding(20, 20, 0, 0);
            qtyPanel.Margin = new Padding(0, 20, 0, 0);
            plusPanel.Margin = new Padding(0, 20, 0, 0);

            minusPanel.BorderStyle = BorderStyle.FixedSingle;
            qtyPanel.BorderStyle = BorderStyle.FixedSingle;
            plusPanel.BorderStyle = BorderStyle.FixedSingle;

            FlowLayoutPanel panelq = new FlowLayoutPanel();
            panelq.FlowDirection= FlowDirection.LeftToRight;
            panelq.Width = 600;
            panelq.Height = 100;
            panelq.BackColor = Color.White;
            panelq.Margin = new Padding(10, 0, 0, 10);

            panelq.Controls.Add(panelPictureBox);
            panelq.Controls.Add(labelFlow);

            FlowLayoutPanel labelFlow3 = new FlowLayoutPanel();
            labelFlow3.FlowDirection = FlowDirection.TopDown;
            Button btn = new Button();
            btn.Text = "Edit";
            btn.Click += (sender, e) =>
            {
                edit(item, panelq);
                //items.Remove(item);

            };
            Button removebtn = new Button();
            removebtn.Margin = new Padding(0, 0, 0, 25);
            removebtn.Text = "Remove";
            removebtn.Click += (sender, e) =>
            {
                panelq.Dispose();
                items.Remove(item);
            };

            labelFlow.FlowDirection = FlowDirection.TopDown;
            labelFlow3.FlowDirection = FlowDirection.TopDown;
            labelFlow.Controls.Add(removebtn);
            panelq.Controls.Add(labelFlow2);
            labelFlow.WrapContents = false;
            
            labelFlow3.Controls.Add(totalLabel);

            totalLabel.AutoSize = false;
            totalLabel.Height = 35;
            
            labelFlow3.Controls.Add(btn);
            panelq.Controls.Add(labelFlow3);

            panelq.WrapContents = false;


            labelFlow.Width = 180;
            labelFlow2.Margin = new Padding(0, 0, 50, 0);

            nameLabel.Margin = new Padding(0, 0, 0, 8);

            btn.ForeColor = Color.White;
            removebtn.ForeColor = Color.White;

            btn.Size = new Size(75, 50);
            removebtn.Size = new Size(75, 50);
            btn.BackColor = Color.Red;
            removebtn.BackColor = Color.Red;


            // EACH PANEL FOR EACH ITEM IS ADDED TO THE FLOW IN SCREEN
            panelq.Padding = new Padding(10);
            flowLayoutPanel2.Controls.Add(panelq);
            Methods.RoundBorders(panelq, 10);
            CalcTotalItems();
            
        }
        // text depending on eat in or take out
        private void Form6_Load(object sender, EventArgs e)
        {
            label3.Text = "Review my " + eat + " order";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        // add quantity of meal
        private int add(Items item)
        {
            item.ItemQuantity++;
            int a = item.ItemQuantity;

            CalcTotalItems();
            return a;
        }
        //reduce quantity of meal
        private int sub(Items item)
        {
            item.ItemQuantity--;
            int a = item.ItemQuantity;

            CalcTotalItems();
            return a;
        }
        // calculation for total to pay
        public void CalcTotalItems()
        {
            int a = 0;
            double b = 0;
            foreach (Items item in items)
            {
                //MessageBox.Show(item.ItemName);
                
                a += item.ItemQuantity;
                b += (item.TotalPrice + item.ExtraPrice) * item.ItemQuantity;
            }
            TotalItems = a;
            toPay = b;
           // MessageBox.Show(toPay.ToString());
            toPayLabel.Text = "Total: " + toPay.ToString("PHP ###,##0.00");
            toPayLabel.ForeColor = Color.White;

        }
        // for editing of order
        private void edit(Items item, Panel panelq)
        {     
            this.Enabled = false;   
            using (var popupForm = new Form5(instance))
            {
                popupForm.FoodName = item.ItemName;
                popupForm.ImagePath = item.ImagePath;
                popupForm.Prices = item.TotalPrice;
                popupForm.quantity = item.ItemQuantity;
                popupForm.foodSelection = item.foodSelection;
                popupForm.foodIndex = item.index;
                popupForm.editOrder = true;
                popupForm.ShowDialog();
                if (!popupForm.closed)
                {               
                    /*item.TotalPrice = popupForm.Prices;
                    item.ItemQuantity = popupForm.quantity;
                    item.ExtraPrice = popupForm.extraPrice;
                    MessageBox.Show(item.ExtraPrice.ToString());*/
                    panelq.Dispose();
                    items.Remove(item);
                    //items.Add(item);
                    
                }
            }
            this.Enabled = true;
            CalcTotalItems();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void datapass(string qrcredit)
        {
            picTake = qrcredit;
        }
        // proceeds to form8
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form8 form8 = new Form8(picTake);
            form8.FormClosed += (s, args) => this.Close();
            form8.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
