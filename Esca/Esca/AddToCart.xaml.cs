using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for AddToCart.xaml
    /// </summary>
    public partial class AddToCart : UserControl
    {
        public AddToCart()
        {
            InitializeComponent();
        }

        private async void atc_Click(object sender, RoutedEventArgs e)
        {
            this.addToCartButton.Content = "Added";
            await Task.Delay(1000);
            this.addToCartButton.Content = "Add to cart";
            this.allergiesBox.Text = "please list any allergies you may encounter";
            this.specialInstructionBox.Text = "please leave any special instructions to our kitchen staff";
            this.guestNameBox.Text = "";
        }
    }
}
