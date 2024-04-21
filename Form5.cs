using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{


    public partial class Form5 : Form
    {
        public string FoodName { get; set; }
        public string ImagePath { get; set; }
        public double Prices { get; set; }
        public int foodSelection { get; set; }
        public int foodIndex { get; set; }
        public bool closed;
        Form6 form6;
        public int quantity;
        public bool editOrder;
        Label qtyLabel = new Label();
        public double extraPrice { get; private set; }
        private int selections = 0;
        List<double> prices;
        List<Panel> dropdownPanels;

        public Form5(Form6 form6instance)
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            form6 = form6instance;
            this.MaximizeBox = false;
            Methods.ShowAds(panel1);
            Methods.MatchParentWidth(panel2);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Height = 1050;
            this.Width = 748;

            this.ControlBox = false;
            Image img = Image.FromFile(Path.Combine(Application.StartupPath, "pictures", "mcdo.png"));
            Icon icon = Icon.FromHandle(((Bitmap)img).GetHicon());
            this.Icon = icon;

            flowLayoutPanel2.AutoScroll = false;
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel3.AutoSize = true;

            prices = new List<double>();
            dropdownPanels = new List<Panel>();



        }
        private void Form5_Load(object sender, EventArgs e)
        {
            prices.Clear();
            storedVals.Clear();
            prcs.Clear();
            // pre defined dictionaries for items with similar customization
            Dictionary<string, double> sizing = new Dictionary<string, double>
                            {
                                { "Small", 0 },
                                { "Medium", 10 },
                                { "Large", 20 },
                            };
            Dictionary<string, double> chicParts = new Dictionary<string, double>
                            {
                                { "Thigh", 0 },
                                { "Leg", 0 },
                                { "Breast", 0 },
                                { "Wing", 0 },
                                {"Any", 0 }
                            };

            Dictionary<string, double> drinks = new Dictionary<string, double>
                            {
                                { "Coke", 50 },
                                { "Coke Float", 50 },
                                { "Iced Tea", 50 },
                                { "Orange Juice", 50 },
                                { "Sprite", 50 },
                                { "Coke Zero", 50 },
                                {"Apple Juice", 50 }
                            };
            Dictionary<string, double> flavor = new Dictionary<string, double>
            {
                { "Original", 0},
                { "Spicy", 5}
            };
            Dictionary<string, double> shakeShakeFlavor = new Dictionary<string, double>
            {
                { "Cheese", 0},
                { "BBQ", 5}
            };

            label2.Text = FoodName;
            label3.Text = Prices.ToString("PHP ###,##0.00");
            pictureBox1.Image = Image.FromFile(ImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            flowLayoutPanel1.Height += 500;
            label4.Text = Prices.ToString("PHP ###,##0.00");

            // assignment of customizations for individual meals
            switch (foodSelection)
            {
                case 0:
                    switch (FoodName)
                    {
                        case "McShareBundle for 3":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Chicken 3", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            addNewSelection("Drink 2", drinks, true);
                            addNewSelection("Drink 3", drinks,true);


                            break;

                        case "McShareBundle for 4":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Chicken 3", chicParts, false);
                            addNewSelection("Chicken 4", chicParts, false);

                            addNewSelection("Drink 1", drinks, true);
                            addNewSelection("Drink 2", drinks, true);
                            addNewSelection("Drink 3", drinks, true);
                            addNewSelection("Drink 4", drinks, true);

                            break;
                        case "6pc Chicken McShareBox":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Chicken 3", chicParts, false);
                            addNewSelection("Chicken 4", chicParts, false);
                            addNewSelection("Chicken 5", chicParts, false);
                            addNewSelection("Chicken 6", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            addNewSelection("Drink 2", drinks, true);
                            addNewSelection("Drink 3", drinks, true);
                            addNewSelection("Drink 4", drinks, true);
                            addNewSelection("Drink 5", drinks, true);
                            addNewSelection("Drink 6", drinks, true);
                            break;
                        case "8pc Chicken McShareBox":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Chicken 3", chicParts, false);
                            addNewSelection("Chicken 4", chicParts, false);
                            addNewSelection("Chicken 5", chicParts, false);
                            addNewSelection("Chicken 6", chicParts, false);
                            addNewSelection("Chicken 7", chicParts, false);
                            addNewSelection("Chicken 8", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            addNewSelection("Drink 2", drinks, true);
                            addNewSelection("Drink 3", drinks, true);
                            addNewSelection("Drink 4", drinks, true);
                            addNewSelection("Drink 5", drinks, true);
                            addNewSelection("Drink 6", drinks, true);
                            addNewSelection("Drink 7", drinks, true);
                            addNewSelection("Drink 8", drinks, true);
                            break;
                        case "BFF ShakeShake & McFloat":
                            addNewSelection("Flavor", shakeShakeFlavor, true);
                            addNewSelection("Drinks Size", sizing, false);
                            break;
                    }
                    break;
                case 1:
                    switch (FoodName)
                    {
                        case "Double Crispy Fish Fillet Sandwich":

                            break;
                        case "Crispy Fish Fillet Sandwich":

                            break;
                        case "Big Mac":

                            break;
                        case "Double Quarter Pounder with Cheese":

                            break;
                        case "Quarter Pounder with Cheese":

                            break;
                        case "Triple Cheeseburger":
                          
                            break;
                        case "Double Cheeseburger":

                            break;
                        case "McChicken":

                            break;
                        case "Cheeseburger":

                            break;
                        case "Crispy Chicken Sandwich":

                            break;
                        case "Burger Mcdo":

                            break;
                    }
                    break;
                case 2:
                    switch (FoodName)
                    {
                        case "1pc Chicken McDo Meal":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            break;


                        case "2pc Chicken McDo Meal":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "1pc Spicy Chicken McDo Meal":
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "2pc Spicy Chicken McDo Meal":
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Chicken 2", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "McCrispy Chicken Fillet":

                            break;
                        case "McCrispy Chicken Fillet Ala King":

                            break;
                        case "6pc Chicken McNuggets":

                            break;
                    }
                    break;
                case 3:
                    switch (FoodName)
                    {
                        case "Chicken Spaghetti":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            break;
                        case "McSpaghetti Solo":

                            break;
                    }
                    break;
                case 4:
                    switch (FoodName)
                    {
                        case "1pc Mushroom PepperSteak w/ Egg":

                            break;
                        case "2pc Mushroom PepperSteak w/ Egg":

                            break;
                    }
                    break;
                case 5:
                    switch (FoodName)
                    {
                        case "McFlurry w/ Oreo":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Hot Fudge Sundae":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Hot Caramel Sundae":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Apple Pie":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Coke McFloat":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Coke":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Coke Zero":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Sprite":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Orange Juice":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Iced Tea":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Apple Juice":
                            addNewSelection("Size", sizing, false);
                            break;
                    }
                    break;
                case 6:
                    switch (FoodName)
                    {
                        case "McCafe Premium Roast Coffee":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "McCafe Coffee Float":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "McCafe Iced Coffee":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "McCafe Iced Coffee Chocolate":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Cafe Latte":
                            addNewSelection("Size", sizing, false);
                            break;
                    }
                    break;
                case 7:
                    switch (FoodName)
                    {
                        case "BFF Fries":
                            
                            break;
                        case "Fries":
                            addNewSelection("Size", sizing, false);
                            break;
                        case "Shake Shake Fries":
                            addNewSelection("Flavor", shakeShakeFlavor, true);
                            break;
                    }
                    break;
                case 8:
                    switch (FoodName)
                    {
                        case "1pc Chicken McDo Happy Meal":
                            addNewSelection("Flavor", flavor, false);
                            addNewSelection("Chicken 1", chicParts, false);
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "4pc Chicken McNuggets Happy Meal":
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "McSpaghetti Happy Meal":
                            addNewSelection("Drink 1", drinks, true);
                            break;
                        case "BurgerMcDo Happy Meal":
                            addNewSelection("Drink 1", drinks, true);
                            break;

                    }
                    break;
                case 9:
                    Dictionary<string, double> cmain = new Dictionary<string, double>
                            {
                                { "BurgerMcdo", 0 },
                                { "Cheeseburger", 0 },
                                { "McSpaghetti", 0 },
                                { "Mushroom Steak", 0 },
                            };
                    Dictionary<string, double> cside= new Dictionary<string, double>
                            {
                                { "Apple Pie", 0 },
                                { "Fries", 0 },
                                { "Coffee", 0 },
                                { "Coke Float", 0 },
                                { "Hot Fudge Sundae", 0 },
                               
                            };
                    addNewSelection("Choose a Main", cmain, false);
                    addNewSelection("Choose a Side", cside, false);
                    break;
                    
            }

            // bottom panel
            FlowLayoutPanel labelFlow2 = new FlowLayoutPanel();
            labelFlow2.AutoSize = true;
            Label labelMinus = new Label();
            Label labelPlus = new Label();

            Panel minusPanel = new Panel();
            Panel plusPanel = new Panel();
            Panel qtyPanel = new Panel();

            labelFlow2.BackColor = Color.Transparent;

            minusPanel.Controls.Add(labelMinus);
            plusPanel.Controls.Add(labelPlus);
            qtyPanel.Controls.Add(qtyLabel);

            labelMinus.Text = "-";
            labelMinus.TextAlign = ContentAlignment.MiddleCenter;
            minusPanel.Size = new Size(50, 50);
            labelMinus.Dock = DockStyle.Fill;
            labelMinus.Font = new Font(labelMinus.Font.FontFamily, 30); 

            labelPlus.Text = "+";
            labelPlus.TextAlign = ContentAlignment.MiddleCenter;
            plusPanel.Size = new Size(50, 50);
            labelPlus.Dock = DockStyle.Fill;
            labelPlus.Font = new Font(labelMinus.Font.FontFamily, 30); 

            qtyLabel.Text = quantity.ToString();
            qtyLabel.TextAlign = ContentAlignment.MiddleCenter;
            qtyPanel.Size = new Size(50, 50);
            qtyLabel.Dock = DockStyle.Fill;
            qtyLabel.Font = new Font(labelMinus.Font.FontFamily, 30);

            plusPanel.Click += add_Click;
            minusPanel.Click += subtract_Click;
            labelMinus.Click += subtract_Click;
            labelPlus.Click += add_Click;

            plusPanel.BackColor = Color.Transparent;
            minusPanel.BackColor = Color.Transparent;
            qtyPanel.BackColor = Color.Transparent;


            labelFlow2.Controls.Add(minusPanel);
            labelFlow2.Controls.Add(qtyPanel);
            labelFlow2.Controls.Add(plusPanel);
            labelFlow2.Height = 50;

            Methods.MatchParentWidth(panel4);
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(labelFlow2);
            Methods.CenterSub(panel4);
            panel4.Margin = new Padding(15, 0, 0, 0);
            
            // add panel to center-===-----

            Methods.MatchParentWidth(panel4);


        }
        // logic for confirming meal, if any of the fields are empty, form cannot confirm
        private void btnClose_Click(object sender, EventArgs e)
        {
            bool closable = true;
            for(int i = 0; i < pcbxs.Count; i++)
            {
                if (pcbxs[i].Image == null)
                {
                    closable = false;
                    break;
                }
            }
            if (closable)
            {
                
                extraPrice = 0;
                for (int i = 0; i < prices.Count; i++)
                {
                    extraPrice += prices[i];
                }

                    form6.AddFood(FoodName, Prices, ImagePath, quantity,
                       foodSelection, foodIndex, extraPrice);
     
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill up all the fields.");
            }
            

        }
        // for loading of individual items/menu
        private void LoadMenu(Dictionary<string, double> menu, Panel dropdown, int panelIndex, PictureBox picbox, Label lbl)
        {
            int counter = 0;
            dropdown.Controls.Clear();
            List<FlowLayoutPanel> flows = new List<FlowLayoutPanel>();
            for (int i = 0; i < menu.Count; i++)
            {

                if (counter < menu.Count)
                {
                    int index = i;
                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.Dock = DockStyle.None; 
                    flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                    flowLayoutPanel.WrapContents = false; 
                    flowLayoutPanel.AutoSize = true;

                    PictureBox pictureBox = new PictureBox();
  
                    pictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "form5", menu.ElementAt(counter).Key + ".png"));
                    
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 50;
                    pictureBox.Height = 50;
              
                    pictureBox.Margin = new Padding(20);
                    pictureBox.Margin = new Padding(27, 20, 20, 20);
              

                    Label label = new Label();
   
                    label.Text = menu.ElementAt(counter).Key;
                    double prc = menu.ElementAt(counter).Value;

                    counter++;
                    Methods.MatchParentWidth(label);
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    label.AutoSize = false;
                    label.AutoEllipsis = true;

                    flowLayoutPanel.Controls.Add(pictureBox);
                    flowLayoutPanel.Controls.Add(label);

                    flowLayoutPanel.Margin = new Padding(0);

                    flows.Add(flowLayoutPanel);
                    

                    flowLayoutPanel.Margin = new Padding(0, 0, 0, 10);
                    int cellIndex = i;
                    flowLayoutPanel.Click += (sender, e) => ChoiceMade(panelIndex, cellIndex, flows, picbox, label.Text,prc, lbl);
                    Methods.InheritEvent(flowLayoutPanel, (sender, e) => ChoiceMade(panelIndex, cellIndex, flows, picbox, label.Text, prc, lbl));
                    dropdown.Controls.Add(flowLayoutPanel);
                    dropdown.Padding = new Padding(10);
                }

            }
        }


        List<double> prcs = new List<double>();
        List<PictureBox> pcbxs = new List<PictureBox>();
        // for individual selection on dropdown
        // ex: Sizes has ( small, medium , large), this is for the logic for selecting from those choices
        private void ChoiceMade(int index, int cellIndex, List<FlowLayoutPanel> flows, PictureBox picbox, string txt, double prc, Label lbl)
        {

            for(int i = 0; i < flows.Count; i++) {
                if (i == cellIndex)
                {
                    flows[i].BackColor = Color.LightGray;
                    picbox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "form5", txt + ".png"));
                    lbl.Text = txt;
                    picbox.SizeMode = PictureBoxSizeMode.Zoom;
                    prcs[index] = prc;
                    prices[index] = prcs[index] * (storedVals[index] + 1);
                    

                }
                else
                {
                    flows[i].BackColor = Color.Transparent;
                }
            }
            showNum();

        }


        //add quantity of item
        private void add_Click(object sender, EventArgs e)
        {
            quantity++;
            showNum();
        }
        //subtract quantity of item
        private void subtract_Click(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                showNum();
            }
        }
        // update label so that it matches quantity
        private void showNum()
        {
            qtyLabel.Text = quantity.ToString();

            double a = 0;
            for(int i = 0; i < prices.Count; i++)
            {
                a += prices[i];
            }
            double q = ((Prices + a) * quantity);
            label4.Text = q.ToString("PHP ###,##0.00");
        }

        private void addNewSelection(string nm, Dictionary<string, double> dc, bool hasSize)
        {
            FlowLayoutPanel container = new FlowLayoutPanel();
            flowLayoutPanel3.Controls.Add(container);
            Methods.MatchParentWidth(container);
            container.FlowDirection = FlowDirection.TopDown;
            container.AutoSize = true;
            container.WrapContents = true;

            Panel panel = new Panel();

            panel.BorderStyle = BorderStyle.FixedSingle;

            Label label = new Label();
            label.AutoSize = true;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Width = 75;
            pictureBox.Height = 75;

           pictureBox.BorderStyle = BorderStyle.FixedSingle;

            label.Text = nm;
            label.Font = new Font(label.Font.FontFamily, 12, label.Font.Style);

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            pictureBox.Location = new Point(25, 15);
            pcbxs.Add(pictureBox);


            Label fselect = new Label();
            panel.Controls.Add(fselect);
            fselect.Location = new Point(125, 40);
            fselect.Font = new Font(label.Font.FontFamily, 8, label.Font.Style);


            label.Location = new Point(125, 15);

            panel.Margin = new Padding(0);
            panel.Width = 728;
            container.Controls.Add(panel);
            Methods.MatchParentWidth(panel);
            


            FlowLayoutPanel dropdown = new FlowLayoutPanel();
            dropdown.Margin = new Padding(0);
            container.Controls.Add(dropdown);
            Methods.MatchParentWidth(dropdown);

            //dropdownPanels.Add(dropdown);


            dropdown.Height = 0;
            dropdown.AutoScroll = true;
            dropdown.WrapContents = false;


            panel.Margin = new Padding(0);
            dropdown.Margin = new Padding(0);

            ////
            //SIZE
            int sizeSel = 0;
            storedVals.Add(0);
            prcs.Add(0);
            prices.Add(0);

            int panelIndex = selections;
            if (hasSize)
            {
                FlowLayoutPanel sizeFlow = new FlowLayoutPanel();
                PictureBox size1 = new PictureBox();
                PictureBox size2 = new PictureBox();
                PictureBox size3 = new PictureBox();
                sizeFlow.Controls.Add(size1);
                sizeFlow.Controls.Add(size2);
                sizeFlow.Controls.Add(size3);

                size1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                size2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                size3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                sizeFlow.Height = 100;
                sizeFlow.Width = 200;
                size1.Size = new Size(55, 50);
                size2.Size = new Size(55, 60);
                size3.Size = new Size(55, 70);
                size1.SizeMode = PictureBoxSizeMode.StretchImage;
                size2.SizeMode = PictureBoxSizeMode.StretchImage;
                size3.SizeMode = PictureBoxSizeMode.StretchImage;

                size1.Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, "form5", "cupEmpty" + ".png"));
                size2.Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, "form5", "cupEmpty" + ".png"));
                size3.Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, "form5", "cupEmpty" + ".png"));



                PictureBox[] sizes = new PictureBox[] { size1, size2, size3 };

                sizeClicked(0, ref sizeSel, sizes, panelIndex);


                size1.Click += (sender, e) => sizeClicked(0, ref sizeSel, sizes, panelIndex);
                size2.Click += (sender, e) => sizeClicked(1, ref sizeSel, sizes, panelIndex);
                size3.Click += (sender, e) => sizeClicked(2, ref sizeSel, sizes, panelIndex);



                panel.Controls.Add(sizeFlow);
                sizeFlow.Location = new Point(500, 15);

            }
            // SIZE
            /////
            panel.Click += (sender, e) => PanelClicked(container, dropdown, dc, panelIndex, pictureBox, fselect);
            container.Click += (sender, e) => PanelClicked(container, dropdown, dc, panelIndex, pictureBox, fselect);
            selections++;


        }

        List<int> storedVals = new List<int>();
        // logic for changing of sizes (if panel is size changeable)
        private void sizeClicked(int chc, ref int sizeSel, PictureBox[] sizes, int index)
        {
            sizeSel = chc;

            for(int i = 0; i < sizes.Length; i++)
            {
                if(i == chc)
                {
                    sizes[i].Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, "form5", "cupFilled" + ".png"));
                }
                else
                {
                    sizes[i].Image = System.Drawing.Image.FromFile(Path.Combine(Application.StartupPath, "form5", "cupEmpty" + ".png"));
                }


            }
            storedVals[index] = chc;
            prices[index] = prcs[index] * (storedVals[index] + 1);

            showNum();

        }
        // for panel dropdown logic
        private void PanelClicked(Panel cont, Panel dropd, Dictionary<string, double> dc, int panelIndex, PictureBox picbox, Label lbl)
        {



            if (dropd.Height == 0)
            {
                for (int i = 0; i < dropdownPanels.Count; i++)
                {
                    dropdownPanels[i].Height = 0;
                }
                dropd.Height = 150;
                LoadMenu(dc, dropd, panelIndex, picbox, lbl/*, sizeSel*/);
            }
            else
            {
                dropd.Height = 0;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            closed = true;
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        // button for additional drinks
        private void button3_Click(object sender, EventArgs e)
        {

            Dictionary<string, double> drinks = new Dictionary<string, double>
                            {
                                { "Coke", 50 },
                                { "Coke Float", 50 },
                                { "Iced Tea", 50 },
                                { "Orange Juice", 50 },
                                { "Sprite", 50 },
                                { "Coke Zero", 50 },
                                {"Apple Juice", 50 },
                                { "Water", 0}
                            };
            addNewSelection("Additional Drinks", drinks, true);
        }

        // button for additional item
        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> additionals = new Dictionary<string, double>
                            {
                                { "Gravy", 5 },
                                { "Rice", 20 },
                                { "Fries", 100 },
                                {"Apple Pie", 50 },
                                { "ShakeShake BBQ", 150 },
                                { "ShakeShake Cheese", 150 },
                                {"Hot Caramel Sundae", 50 },
                                {"Hot Fudge Sundae", 50 },
                                {"Oreo McFlurry", 50 },
                                {"Sugar", 0 },
                                {"Ketchup", 0 },


                            };


            addNewSelection("Additional Item", additionals, true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}