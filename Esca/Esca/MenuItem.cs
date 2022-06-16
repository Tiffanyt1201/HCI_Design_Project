using System;
using System.Collections.Generic;
using System.Text;

namespace Esca
{
    public class MenuItem
    {
        public int Id { get; set; } //first digit of ID represents type of item (1-appeti, 2-meals, 3-drinks, 4-desserts)
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string PictureSource { get; set; }
        public string LongDescription { get; set; }
        //long description would be for the extensive dish information pop-up
    }
}
