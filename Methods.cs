using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    internal class Methods
    {
        // panel matches it's parents' width
        public static void MatchParentWidth(Control control)
        {
            if (control.Parent != null)
            {
                control.Width = control.Parent.ClientSize.Width;
            }
        }
        // round corner of panel
        public static void RoundBorders(Control control, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, cornerRadius * 2, cornerRadius * 2), 180, 90);
            path.AddArc(new Rectangle(control.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2), 270, 90);
            path.AddArc(new Rectangle(control.Width - cornerRadius * 2, control.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2), 90, 90);
            path.CloseFigure();

            Region region = new Region(path);
            control.Region = region;
        }
        // centers the child controls of panel
        public static void CenterSub(Panel panel)
        {
            foreach (Control control in panel.Controls)
            {
                int newX = (panel.Width - control.Width) / 2;
                int newY = (panel.Height - control.Height) / 2;
                control.Location = new Point(newX, newY);
            }
        }
        // passes the events of parent to its children
        public static void InheritEvent(Control parentControl, EventHandler clickHandler)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                childControl.Click += clickHandler;
                InheritEvent(childControl, clickHandler);
            }
        }
        // showads method
        public static void ShowAds(Control control)
        {
            int currentIndex = 0;
            control.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "ads", $"ad{currentIndex + 1}.jpg"));
            control.BackgroundImageLayout = ImageLayout.Stretch;
            currentIndex++;
            Timer timer = new Timer();
            timer.Interval = 4000;
            timer.Tick += (sender, e) =>
            {
                control.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "ads", $"ad{currentIndex + 1}.jpg"));
                control.BackgroundImageLayout = ImageLayout.Stretch;
                currentIndex = (currentIndex + 1) % 4;
            };
            timer.Start();
        }


    }
}
