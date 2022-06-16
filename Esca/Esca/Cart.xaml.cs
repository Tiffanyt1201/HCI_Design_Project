using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esca
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>

    public partial class Cart : UserControl
    {
        MainWindow parent;
        public Cart(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            List<CartItem> itemList1 = new List<CartItem>();
            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartAmy.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split("@");
                itemList1.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart1List.ItemsSource = itemList1;

            List<CartItem> itemList2 = new List<CartItem>();
            string[] csvLines1 = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartIvan.csv");
            for (int i = 1; i < csvLines1.Length; i++)
            {
                string[] rowData = csvLines1[i].Split("@");
                itemList2.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart2List.ItemsSource = itemList2;
        }

        public void CartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.Write("Selected a dish item");
            //Add to cart functionality
            //The add to cart pop-up should cover mostly the entire screen and not be draggable/movable, feel free to add lifted effects/overlays, etc
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            List<CartItem> itemList = new List<CartItem>();
            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartDeleteIvan.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split("@");
                itemList.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart2List.ItemsSource = itemList;
            IvanAmount.Content = "32.97";
            parent.CartCounter.Text = "5";
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            List<CartItem> itemList = new List<CartItem>();
            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartEmpty.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split("@");
                itemList.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart1List.ItemsSource = itemList;
            Cart2List.ItemsSource = itemList;

            AmyAmount.Content = "";
            AmyGuest.Content = "";
            AmyTotal.Content = "";

            IvanAmount.Content = "";
            IvanGuest.Content = "";
            IvanTotal.Content = "";
            parent.CartCounter.Text = "0";
            parent.HistoryCounter.Text = "5";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            List<CartItem> itemList1 = new List<CartItem>();
            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartChangeAmy.csv");
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split("@");
                itemList1.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart1List.ItemsSource = itemList1;

            List<CartItem> itemList2 = new List<CartItem>();
            string[] csvLines1 = System.IO.File.ReadAllLines(@".\..\..\..\cart_data\CartChangeIvan.csv");
            for (int i = 1; i < csvLines1.Length; i++)
            {
                string[] rowData = csvLines1[i].Split("@");
                itemList2.Add(new CartItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), Instruction = rowData[3], GuestName = rowData[4] });
            }
            Cart2List.ItemsSource = itemList2;
            IvanAmount.Content = "19.98";
            AmyAmount.Content = "33.97";
        }
    }
}
