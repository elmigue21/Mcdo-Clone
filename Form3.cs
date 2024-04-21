using System;
using System.Collections;
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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Food;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public string eatText;
        Form6 form6Instance = Form6.GetInstance();
        int foodSelection = 0;
        private Timer timer;
        private string picTake;
        // individual meals separated by their food groups and with an associated price
        Dictionary<string, double> mcsharebox = new Dictionary<string, double>
        {
            { "McShareBundle for 3", 500 },
            { "McShareBundle for 4", 900},
            { "6pc Chicken McShareBox", 500 },
            { "8pc Chicken McShareBox", 700 },
            { "BFF ShakeShake & McFloat", 300 },
        };
        Dictionary<string, double> burgers = new Dictionary<string, double>
        {
            { "Double Crispy Fish Fillet Sandwich", 125.0 },
            { "Crispy Fish Fillet Sandwich", 100.0 },
            { "Big Mac", 500.0 },
            { "Double Quarter Pounder with Cheese", 200.0 },
            { "Quarter Pounder with Cheese", 400.0 },
            { "Triple Cheeseburger", 300.0 },
            { "Double Cheeseburger", 200.0 },
            { "McChicken", 80.0 },
            { "Cheeseburger", 70.0 },
            { "Crispy Chicken Sandwich", 60.0 },
            { "Burger Mcdo", 50.0 }
        };

        Dictionary<string, double> chickens = new Dictionary<string, double>
        {
            { "1pc Chicken McDo Meal", 90.0 },
            { "2pc Chicken McDo Meal", 120.0 },
            { "McCrispy Chicken Fillet", 70.0 },
            { "McCrispy Chicken Fillet Ala King", 75.0 },
            { "6pc Chicken McNuggets", 110.0 }
        };

        Dictionary<string, double> spaghettis = new Dictionary<string, double>
        {
            { "Chicken Spaghetti", 110.0 },
            { "McSpaghetti Solo", 70.0 }
        };

        Dictionary<string, double> ricebowls = new Dictionary<string, double>
        {
            { "1pc Mushroom PepperSteak w/ Egg", 120.0 },
            { "2pc Mushroom PepperSteak w/ Egg", 120.0 }
        };

        Dictionary<string, double> dessertsNdrinks = new Dictionary<string, double>
        {
            { "McFlurry w/ Oreo", 80.0 },
            { "Hot Fudge Sundae", 80.0 },
            { "Hot Caramel Sundae", 80.0 },
            { "Apple Pie", 60.0 },
            { "Coke McFloat", 30.0 },
            { "Coke", 30.0 },
            { "Coke Zero", 30.0 },
            { "Sprite", 30.0 },
            { "Orange Juice", 20.0 },
            { "Iced Tea", 30.0 },
            { "Apple Juice", 30.0 }
        };

        Dictionary<string, double> mccafes = new Dictionary<string, double>
        {
            { "McCafe Premium Roast Coffee", 40.0 },
            { "McCafe Coffee Float", 40.0 },
            { "McCafe Iced Coffee", 40.0 },
            { "McCafe  Iced Coffee Chocolate", 40.0 },
            { "Cafe Latte", 40.0 }
        };

        Dictionary<string, double> friesNextras = new Dictionary<string, double>
        {
            { "BFF Fries", 120.0 },
            { "Fries", 70.0 },
            { "Shake Shake Fries", 75.0 }
        };

        Dictionary<string, double> happymeals = new Dictionary<string, double>
        {
            { "1pc Chicken Mcdo Happy Meal", 90.0 },
            { "4pc Chicken McNuggets Happy Meal", 90.0 },
            { "McSpaghetti Happy Meal", 90.0 },
            { "BurgerMcDo Happy Meal", 90.0 }
        };
        Dictionary<string, double> mixNmatch = new Dictionary<string, double>
        {
            { "Mix & Match", 75}
        };




        // array storing all the dictionaries
        Dictionary<string, double>[] foodDictionary;

        public Form3(string pic)
        {
            picTake = pic;
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            Methods.MatchParentWidth(panel1);
            Methods.MatchParentWidth(tableLayoutPanel1);
            flowLayoutPanel2.HorizontalScroll.Enabled = false;
            flowLayoutPanel2.HorizontalScroll.Visible = false;

            flowLayoutPanel1.VerticalScroll.Visible = false;

            this.ControlBox = false;
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 1050;
            this.Width = 748;

            foodDictionary = new Dictionary<string, double>[]
            {
                mcsharebox,burgers,chickens,spaghettis,ricebowls,dessertsNdrinks,mccafes,friesNextras,happymeals,mixNmatch
            };         

           // PictureBox[] pictureBoxes = new PictureBox[4];

            // loading of food groups
            string[] menus = { "McShareBox", "Burger", "Chicken", "Spaghetti", "Rice Bowls", "Desserts & Drinks", "McCafe", "Fries & Extras", "Happy Meal", "Mix & Match" };
            for (int i = 0; i < menus.Length; i++)
            {
                int index = i;
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Dock = DockStyle.None; 
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanel.WrapContents = false; 
                flowLayoutPanel.AutoSize = true;
                Methods.MatchParentWidth(flowLayoutPanel);


                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "menu" + (i + 1) + ".jpg"));
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Width = 100;
                pictureBox.Height = 100;

                Label label = new Label();
                label.Text = menus[i]; 

                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                flowLayoutPanel.Controls.Add(pictureBox);
                flowLayoutPanel.Controls.Add(label);

                flowLayoutPanel.Click += (sender, e) => SelectionClicked(index);
                Methods.InheritEvent(flowLayoutPanel, (sender, e) => SelectionClicked(index));


                flowLayoutPanel2.Controls.Add(flowLayoutPanel);
            }

            Methods.ShowAds(panel1);

            flowLayoutPanel3.HorizontalScroll.Enabled = false;
            flowLayoutPanel3.HorizontalScroll.Visible = false;

            timer = new Timer();        
            timer.Interval = 1000;         
            timer.Tick += UpdateText;           
            timer.Start();


        }
        // for the loading of the individual meals of each food group
        private void LoadMenu(Dictionary<string, double> menu, string imageName)
        {
            int counter = 0;
            for (int i = 0; i < menu.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanelB = new FlowLayoutPanel();
                flowLayoutPanelB.Dock = DockStyle.None;
                flowLayoutPanelB.FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelB.WrapContents = false; 
                flowLayoutPanelB.AutoSize = true;
                Methods.MatchParentWidth(flowLayoutPanelB);
                for (int j = 0; j < 3; j++)
                {
                    if (counter < menu.Count)
                    {
                        int local = counter;
                        int index = i;
                        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                        flowLayoutPanel.Dock = DockStyle.None;
                        flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel.WrapContents = false; 
                        flowLayoutPanel.AutoSize = true;

                        PictureBox pictureBox = new PictureBox();
                        string imagePath = Path.Combine(Application.StartupPath, imageName, imageName + (counter + 1) + ".png");

                        pictureBox.Image = Image.FromFile(imagePath);

                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Width = 125;
                        pictureBox.Height = 125;

                        pictureBox.Margin = new Padding(20);

                        Label label = new Label();
                        string menuItemName = menu.ElementAt(counter).Key;
                        label.Text = menuItemName; 
                        Methods.MatchParentWidth(label);
                        label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        label.AutoSize = false;
                        label.Width = 150;
                        label.Height = 50;
                        Methods.MatchParentWidth(label);
                        label.AutoEllipsis = false;

                        flowLayoutPanel.Controls.Add(pictureBox);
                        flowLayoutPanel.Controls.Add(label);

                        flowLayoutPanel.Click += (sender, e) => FoodClicked(local, imagePath);
                        Methods.InheritEvent(flowLayoutPanel, (sender, e) => FoodClicked(local, imagePath));

                        flowLayoutPanelB.Controls.Add(flowLayoutPanel);
                        counter++;
                    }
                }
                flowLayoutPanel3.Controls.Add(flowLayoutPanelB);
            }
        }
        // when a meal is chosen, opens form5 for user to customize meal
        private void FoodClicked(int index, string img)
        {
            this.Enabled = false;
            using (var popupForm = new Form5(form6Instance))
            {
                popupForm.FoodName = foodDictionary[foodSelection].ElementAt(index).Key;
                popupForm.ImagePath = img;
                popupForm.Prices = foodDictionary[foodSelection].ElementAt(index).Value;
                popupForm.quantity = 1;
                popupForm.foodSelection = foodSelection;
                popupForm.foodIndex = index;
                popupForm.editOrder = false;
                popupForm.ShowDialog();
            }
            this.Enabled = true;
        }
        // updates text to match price and also updates form6 price
        public void UpdateText(object sender, EventArgs e)
        {
            //form6Instance.CalcTotalItems();
            label2.Text = form6Instance.toPay.ToString("PHP #,##0.00");
            label3.Text = "Items: " + form6Instance.TotalItems.ToString();
        }

        // when user chooses any of the food groups on the left, it will load its menu
        private void SelectionClicked(int selection)
        {
            flowLayoutPanel3.Controls.Clear();
            foodSelection = selection;
            switch (selection)
            {
                case 0:
                    LoadMenu(mcsharebox, "mcsharebox");
                    break;
                case 1:
                    LoadMenu(burgers, "burger");
                    break;
                case 2:
                    LoadMenu(chickens, "chicken");
                    break;
                case 3:
                    LoadMenu(spaghettis, "spaghetti");
                    break;
                case 4:
                    LoadMenu(ricebowls, "ricebowl");
                    break;
                case 5:
                    LoadMenu(dessertsNdrinks, "dessertNdrinks");
                    break;
                case 6:
                    LoadMenu(mccafes, "coffee");
                    break;
                case 7:
                    LoadMenu(friesNextras, "friesNextras");
                    break;
                case 8:
                    LoadMenu(happymeals, "happymeal");
                    break;
                case 9:
                    LoadMenu(mixNmatch, "mixNmatch");                  
                    break;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        // assign eatText to label
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "My Order - " + eatText;
            form6Instance.eat = eatText;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        // proceed to form 8 if done with order
        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form8 form8 = new Form8(picTake);
            form8.FormClosed += (s, args) => this.Close();
            form8.Show();
        }

        // View my order label click function
        private void label4_Click(object sender, EventArgs e)
        {
            if (form6Instance != null)
            {
                form6Instance.datapass(picTake);
                form6Instance.Show();
            }
            else
            {
                Form6 form6Instance = Form6.GetInstance();
                form6Instance.datapass(picTake);
                form6Instance.Show();
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // close
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}