using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Food
    {
        public class Burgers : Food
        {
            public string Name { get; }
            public string ImagePath { get; }
            public double Price { get; }
            public string[] Size { get; }

            public Burgers(string name,string imagePath, string size, double price)
            {
                Name = name; 
                ImagePath = imagePath;
                Price = price;  
                Size = new string[]{ "Small", "Medium", "Large"};  
            }

        }
    }
}
