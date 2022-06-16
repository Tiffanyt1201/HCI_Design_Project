using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for SystemHelp.xaml
    /// </summary>
    public partial class SystemHelp : UserControl
    {
        string[] title = { "WAITER", "CART", "PAY", "HISTORY", "DISH ROW", "FILTER", "MORE DETAILS", "FAVOURITE", "QUESTION ICON" };
        string[] description = {"Tap to call wait staff for questions, refills, etc.",
                                "Keeps track of your dishes until you are ready to place an order, submitting it to the kitchen. You can submit within the cart page and submit more than once.",
                                "Tap to call wait staff once you are ready to pay for your meal.",
                                "Tap to see orders that have been placed.",
                                "Tap to trigger a dish detail pop-up to add to cart. There, you can specify allergies, payer, etc.",
                                "Tap to filter dishes by various categories including dietary restrictions, etc.",
                                "Tap the \"More Details\" button on the left hand side of the dish row to get more information on the dish. ",
                                "Tap the star button on the right hand side of the a particular dish row to favourite that dish.",
                                "Tap to access this guide." };
        int nextIndex = 1;
        int prevIndex = -1;
        public SystemHelp()
        {
            InitializeComponent();
        }
        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            Description.Width = 650;
            Description.TextAlignment = TextAlignment.Center; 

            Title.Content = title[nextIndex];
            Description.Text = description[nextIndex];
            PageNumber.Content = "Page " + (nextIndex + 1) + " of 9";

            if (nextIndex > 0)
            {
                LeftArrow.IsEnabled = true;
                LeftArrow.Foreground = Brushes.Maroon;
            }
            if (nextIndex == 8)
            {
                RightArrow.IsEnabled = false;
                RightArrow.Foreground = Brushes.Gray;
            }
            nextIndex++;
            prevIndex++;
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            Description.Width = 650;
            Description.TextAlignment = TextAlignment.Center;
            Title.Content = title[prevIndex];
            Description.Text = description[prevIndex];
            PageNumber.Content = "Page " + (prevIndex + 1) + " of 9";
            if (prevIndex < 8)
            {
                RightArrow.IsEnabled = true;
                RightArrow.Foreground = Brushes.Maroon;
            }
            if (prevIndex == 0)
            {
                LeftArrow.IsEnabled = false;
                LeftArrow.Foreground = Brushes.Gray;
            }
            nextIndex--;
            prevIndex--;
        }
    }
}
