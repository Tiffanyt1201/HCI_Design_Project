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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        Appetizers appetizersPage;
        Meals mealsPage;
        Drinks drinksPage;
        Desserts dessertsPage;
        WindowOverlay windowOverlay = new WindowOverlay();
        bool appetizerButtonClicked = false;
        bool mealButtonClicked = false;

        public MainWindow parent;

        public Menu(MainWindow m)
        {
            parent = m;
            appetizersPage = new Appetizers(this);
            mealsPage = new Meals(this);
            drinksPage = new Drinks(this);
            dessertsPage = new Desserts(this);

            InitializeComponent();
            menuUserControls.Children.Add(appetizersPage);
            AppetizerButton.Foreground = Brushes.Maroon;

            //this.container.LostKeyboardFocus += delegate
            //{
            //    FilterPopup.IsOpen = false;
            //    Application.Current.Dispatcher.Invoke(new Action(() =>
            //    {
            //        menuUserControls.Children.Remove(windowOverlay);
            //    }));
            //};

            this.FilterPopup.Opened += delegate
            {
                Mouse.Capture(container, CaptureMode.SubTree);
            };

            this.FilterPopup.Closed += delegate
            {
                if (Mouse.Captured == container)
                {
                    Mouse.Capture(container, CaptureMode.None);
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    menuUserControls.Children.Remove(windowOverlay);
                }));
            };

            this.FilterClose.Click += delegate
            {
                if (appetizerButtonClicked == true)
                {
                    menuUserControls.Children.Clear();
                    menuUserControls.Children.Add(new Appetizers(new List<MenuItem>()));
                    AppetizerButton.Foreground = Brushes.Maroon;
                    MealButton.Foreground = Brushes.White;
                    DrinkButton.Foreground = Brushes.White;
                    DessertButton.Foreground = Brushes.White;
                }

                if (mealButtonClicked == true)
                {
                    menuUserControls.Children.Clear();
                    menuUserControls.Children.Add(new Meals(new List<MenuItem>()));
                    AppetizerButton.Foreground = Brushes.Maroon;
                    MealButton.Foreground = Brushes.White;
                    DrinkButton.Foreground = Brushes.White;
                    DessertButton.Foreground = Brushes.White;
                }

                FilterPopup.IsOpen = false;
            };
        }

        private void Appetizers_Click(object sender, RoutedEventArgs e)
        {
            appetizerButtonClicked = true;
            mealButtonClicked = false;

            menuUserControls.Children.Clear();
            menuUserControls.Children.Add(appetizersPage);
            AppetizerButton.Foreground = Brushes.Maroon;
            MealButton.Foreground = Brushes.White;
            DrinkButton.Foreground = Brushes.White;
            DessertButton.Foreground = Brushes.White;
        }

        private void Meals_Click(object sender, RoutedEventArgs e)
        {
            appetizerButtonClicked = false;
            mealButtonClicked = true;

            menuUserControls.Children.Clear();
            menuUserControls.Children.Add(mealsPage);
            MealButton.Foreground = Brushes.Maroon;
            AppetizerButton.Foreground = Brushes.White;
            DrinkButton.Foreground = Brushes.White;
            DessertButton.Foreground = Brushes.White;
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            menuUserControls.Children.Clear();
            menuUserControls.Children.Add(drinksPage);
            DrinkButton.Foreground = Brushes.Maroon;
            MealButton.Foreground = Brushes.White;
            AppetizerButton.Foreground = Brushes.White;
            DessertButton.Foreground = Brushes.White;
        }

        private void Desserts_Click(object sender, RoutedEventArgs e)
        {
            menuUserControls.Children.Clear();
            menuUserControls.Children.Add(dessertsPage);
            DessertButton.Foreground = Brushes.Maroon;
            MealButton.Foreground = Brushes.White;
            DrinkButton.Foreground = Brushes.White;
            AppetizerButton.Foreground = Brushes.White;
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                menuUserControls.Children.Remove(windowOverlay);
                menuUserControls.Children.Add(windowOverlay);
                FilterPopup.IsOpen = true;
                FilterPopup.StaysOpen = false;
            }));
        }
    }
}