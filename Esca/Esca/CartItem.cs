using System;
using System.Collections.Generic;
using System.Text;

namespace Esca
{
    class CartItem
    {
        private int id;
        private string name;
        private double price;
        private string instruction;
        private string guestName;
        private string numOfItem;

        public CartItem()
        {
        }

        public CartItem(int id, string name, double price, string instruction, string guestName)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.instruction = instruction;
            this.guestName = guestName;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Instruction
        {
            get { return instruction; }
            set { instruction = value; }
        }

        public string GuestName
        {
            get { return guestName; }
            set { guestName = value; }
        }

        private string NumOfItem
        {
            get { return numOfItem; }
            set { numOfItem = value; }
        }
    }
}