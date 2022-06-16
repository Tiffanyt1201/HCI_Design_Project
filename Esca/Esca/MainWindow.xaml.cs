using Esca;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {

        Menu menuPage;
        Cart cartPage;
        History historyPage = new History();
        WindowOverlay windowOverlay = new WindowOverlay();
        //References (passing list of guest names from landing page to main window) Share ArrayList Between Classes in c# with Code https://www.interviewsansar.com/share-arraylist-between-classes-in-c-with-code/
        private List<String> guestNamesList;
        public MainWindow(List<String> guestNames)
        {
            cartPage = new Cart(this);
            menuPage = new Menu(this);
            InitializeComponent();
            pageUserControls.Children.Add(menuPage);
            MenuButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            //Passing the list of guest names entered on the landing page to the main window 
            this.guestNamesList = guestNames;
        }


        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                overlayUserControls.Children.Add(windowOverlay);
                PayPopup.IsOpen = true;
                PayPopup.StaysOpen = true;
            }));

            if (PayPopup.IsOpen == true)
            {
                PayButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
                MenuButton.Background = Brushes.White;
                WaiterButton.Background = Brushes.White;
                CartButton.Background = Brushes.White;
                HistoryButton.Background = Brushes.White;
                HelpButton.Background = Brushes.White;
            }
        }

        private void Pay_Popup_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                overlayUserControls.Children.Remove(windowOverlay);
                PayPopup.IsOpen = false;
                PayPopup.StaysOpen = false;
                PayClose.IsChecked = false;
            }));
        }
        private void Pay_Close_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            PayPopup.IsOpen = false;
            PayPopup.StaysOpen = false;
            PayClose.IsChecked = false;
            if (PayPopup.IsOpen == false)
            {
                PayButton.Background = Brushes.White;
            }
        }

        private void Waiter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                overlayUserControls.Children.Add(windowOverlay);
                WaiterAlertPopup.IsOpen = true;
                WaiterAlertPopup.StaysOpen = true;
            }));

            if (WaiterAlertPopup.IsOpen == true)
            {
                WaiterButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
                MenuButton.Background = Brushes.White;
                PayButton.Background = Brushes.White;
                CartButton.Background = Brushes.White;
                HistoryButton.Background = Brushes.White;
                HelpButton.Background = Brushes.White;
            }
        }

        private void Waiter_Popup_Exit_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            WaiterAlertPopup.IsOpen = false;
            WaiterAlertPopup.StaysOpen = false;
            WaiterClose.IsChecked = false;
        }
        private void Waiter_Close_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            WaiterAlertPopup.IsOpen = false;
            WaiterAlertPopup.StaysOpen = false;
            WaiterClose.IsChecked = false;

            if (WaiterAlertPopup.IsOpen == false)
            {
                WaiterButton.Background = Brushes.White;
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            pageUserControls.Children.Clear();
            pageUserControls.Children.Add(menuPage);
            MenuButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            PayButton.Background = Brushes.White;
            WaiterButton.Background = Brushes.White;
            CartButton.Background = Brushes.White;
            HistoryButton.Background = Brushes.White;
            HelpButton.Background = Brushes.White;
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            pageUserControls.Children.Clear();
            pageUserControls.Children.Add(cartPage);
            CartButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            PayButton.Background = Brushes.White;
            WaiterButton.Background = Brushes.White;
            MenuButton.Background = Brushes.White;
            HistoryButton.Background = Brushes.White;
            HelpButton.Background = Brushes.White;
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            pageUserControls.Children.Clear();
            pageUserControls.Children.Add(historyPage);
            HistoryButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            PayButton.Background = Brushes.White;
            WaiterButton.Background = Brushes.White;
            CartButton.Background = Brushes.White;
            MenuButton.Background = Brushes.White;
            HelpButton.Background = Brushes.White;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                overlayUserControls.Children.Remove(windowOverlay);
                overlayUserControls.Children.Add(windowOverlay);
                HelpPopup.IsOpen = true;
                HelpPopup.StaysOpen = true;
            }));

            if (HelpPopup.IsOpen == true)
            {
                HelpButton.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
                MenuButton.Background = Brushes.White;
                PayButton.Background = Brushes.White;
                CartButton.Background = Brushes.White;
                HistoryButton.Background = Brushes.White;
                WaiterButton.Background = Brushes.White;
            }
        }

        private void HelpClose_Exit_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            HelpPopup.IsOpen = false;
            HelpPopup.StaysOpen = false;
            HelpClose.IsChecked = false;
        }

        private void HelpClose_MouseLeave(object sender, MouseEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            HelpPopup.IsOpen = false;
            HelpPopup.StaysOpen = false;
            HelpClose.IsChecked = false;

            if (HelpPopup.IsOpen == false)
            {
                HelpButton.Background = Brushes.White;
            }
        }
    }
}
