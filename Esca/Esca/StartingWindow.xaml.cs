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
using System.Windows.Shapes;

namespace Esca
{
    /// <summary>
    /// Interaction logic for StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        public List<String> guestNames = new List<String>();
        WindowOverlay windowOverlay = new WindowOverlay();
        public StartingWindow()
        {
            InitializeComponent();
            //References (passing list of guest names from landing page to main window) Share ArrayList Between Classes in c# with Code https://www.interviewsansar.com/share-arraylist-between-classes-in-c-with-code/
            MainWindow mW = new MainWindow(guestNames);
        }

        private void enterNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Detecting when enter key is pressed https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-detect-when-the-enter-key-pressed?view=netframeworkdesktop-4.8
            if (Key.Return == e.Key)
            {
                Button newGuestBtn = new Button();
                newGuestBtn.Background = Brushes.Maroon;
                //Removing border https://stackoverflow.com/questions/15665153/hide-or-remove-border-of-wpf-button-in-c-sharp-code
                newGuestBtn.BorderThickness = new Thickness(0);

                newGuestBtn.Foreground = Brushes.White;
                newGuestBtn.FontFamily = new FontFamily("Meiryo UI");
                newGuestBtn.FontSize = 20.0;
                newGuestBtn.FontWeight = FontWeights.Bold;

                if (String.IsNullOrEmpty(enterNameBox.Text))
                {
                    string autoTag = "Guest" + (guestNames.Count + 1) + "    x";
                    newGuestBtn.Content = autoTag;
                    guestNames.Add("Guest" + (guestNames.Count + 1));
                }
                else
                {
                    newGuestBtn.Content = enterNameBox.Text + "    x";
                    guestNames.Add(enterNameBox.Text);
                }

                //double.NaN meand "Auto" in xaml https://stackoverflow.com/questions/1497921/how-to-say-xaml-button-height-auto-in-code-behind
                newGuestBtn.Width = double.NaN;
                newGuestBtn.MinWidth = 80;
                newGuestBtn.Height = 32;
                newGuestBtn.Margin = new Thickness(10, 0, 10, 0);
                newGuestBtn.Padding = new Thickness(8, 2, 8, 2);
                newGuestBtn.HorizontalAlignment = HorizontalAlignment.Center;
                //Adding a button when event happend https://stackoverflow.com/questions/24136458/adding-a-textbox-on-button-click-in-c-sharp-wpf
                guestTagPanel.Children.Add(newGuestBtn);
                enterNameBox.Clear();

                //Adding event handler for button https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/how-to-add-an-event-handler-using-code?view=netframeworkdesktop-4.8
                newGuestBtn.Click += new RoutedEventHandler(this.nameTagClicked);
            }
        }

        /*References: 
    - https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.button.click?view=netframework-4.8 */
        private void nameTagClicked(Object sender, RoutedEventArgs e)
        {
            Button nameTagClicked = (Button)sender;
            guestTagPanel.Children.Remove(nameTagClicked);
            string name1 = (nameTagClicked.Content).ToString();
            string name2 = name1.Substring(0, name1.IndexOf(' '));
            guestNames.Remove(name2);
        }

        private void ToSystem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(guestNames);
            this.Content = mainWindow.Content;    
        }

        private void QIcon_Btn_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Add(windowOverlay); 
            QIconPopup.IsOpen = true;
            QIconPopup.StaysOpen = true;

            if (QIconPopup.IsOpen == true)
            {
               QIconBtn.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            }
        }
        private void QIconClose_Exit_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            QIconPopup.IsOpen = false;
            QIconPopup.StaysOpen = false;
            QIconClose.IsChecked = false; 
        }

        private void QIconClose_MouseLeave(object sender, MouseEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            QIconPopup.IsOpen = false;
            QIconPopup.StaysOpen = false;
            QIconClose.IsChecked = false;

            if (QIconPopup.IsOpen == false)
            {
                QIconBtn.Background = Brushes.Maroon;
            }
        }

        private void WaiterOrder_Btn_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Add(windowOverlay);
            WaiterOrderPopup.IsOpen = true;
            WaiterOrderPopup.StaysOpen = true;

            if (WaiterOrderPopup.IsOpen == true)
            {
                WaiterOrderBtn.Background = new SolidColorBrush(Color.FromArgb(0x66, 0x80, 0x00, 0x00));
            }
        }

        private void WaiterOrderClose_Exit_Click(object sender, RoutedEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            WaiterOrderPopup.IsOpen = false;
            WaiterOrderPopup.StaysOpen = false;
            WaiterOrderClose.IsChecked = false;
        }

        private void WaiterOrderClose_MouseLeave(object sender, MouseEventArgs e)
        {
            overlayUserControls.Children.Remove(windowOverlay);
            WaiterOrderPopup.IsOpen = false;
            WaiterOrderPopup.StaysOpen = false;
            WaiterOrderClose.IsChecked = false;

            if (WaiterOrderPopup.IsOpen == false)
            {
                WaiterOrderBtn.Background = Brushes.Black;
            }
        }
    }
}
