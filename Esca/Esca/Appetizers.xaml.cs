using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Esca.MenuItem;

namespace Esca
{
    /// <summary>
    /// Interaction logic for Appetizers.xaml
    /// </summary>
    public partial class Appetizers : UserControl
    {
        public List<MenuItem> appetizerItems = new List<MenuItem>();
        public List<MenuItem> appetizerFavouriteItems = new List<MenuItem>();
        public WindowOverlay windowOverlay = new WindowOverlay();
        public string selectedName;
        public Image img1 = new Image();
        public Image img2 = new Image();
        public Image img3 = new Image();
        public Menu parent;

        public Appetizers(Menu m)
        {
            parent = m;

            InitializeComponent();

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\Appetizers.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                appetizerItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/appetizers/" + rowData[4], LongDescription = "" });
            }

            appetizerList.ItemsSource = appetizerItems;
            appetizerFavouriteList.ItemsSource = appetizerFavouriteItems;

            this.dishPopup.Opened += delegate
            {
                Mouse.Capture(container, CaptureMode.SubTree);
            };

            this.dishPopup.Closed += delegate
            {
                if (Mouse.Captured == container)
                {
                    Mouse.Capture(container, CaptureMode.None);
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    container.Children.Remove(windowOverlay);
                }));
            };

            this.MoreInfoClose.Click += delegate
            {
                dishPopup.IsOpen = false;
            };

            this.atcPopup.Opened += delegate
            {
                Mouse.Capture(container, CaptureMode.SubTree);
            };

            this.atcPopup.Closed += delegate
            {
                if (Mouse.Captured == container)
                {
                    Mouse.Capture(container, CaptureMode.None);
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    container.Children.Remove(windowOverlay);
                }));
            };

            this.atcClose.Click += delegate
            {
                atcPopup.IsOpen = false;
                
            };
            
            this.atc.addToCartButton.Click += delegate
            {
                parent.parent.CartCounter.Text = (Convert.ToInt32(parent.parent.CartCounter.Text) + 1).ToString();
            };
        }

        public Appetizers(List<MenuItem> filter)
        {
            InitializeComponent();

            appetizerItems = filter;

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\FilteredAppetizers.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                appetizerItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/appetizers/" + rowData[4], LongDescription = "" });
            }

            appetizerList.ItemsSource = appetizerItems;
            appetizerFavouriteList.ItemsSource = appetizerFavouriteItems;

            this.dishPopup.Opened += delegate
            {
                Mouse.Capture(container, CaptureMode.SubTree);
            };

            this.dishPopup.Closed += delegate
            {
                if (Mouse.Captured == container)
                {
                    Mouse.Capture(container, CaptureMode.None);
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    container.Children.Remove(windowOverlay);
                }));
            };

            this.MoreInfoClose.Click += delegate
            {
                dishPopup.IsOpen = false;
            };

            this.atcPopup.Opened += delegate
            {
                Mouse.Capture(container, CaptureMode.SubTree);
            };

            this.atcPopup.Closed += delegate
            {
                if (Mouse.Captured == container)
                {
                    Mouse.Capture(container, CaptureMode.None);
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    container.Children.Remove(windowOverlay);
                }));
            };

            this.atcClose.Click += delegate
            {
                atcPopup.IsOpen = false;
            };

            this.atc.addToCartButton.Click += delegate
            {
                parent.parent.CartCounter.Text = (Convert.ToInt32(parent.parent.CartCounter.Text) + 1).ToString();
            };
        }

        public void appetizerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuItem selected = ((ListBox)sender).SelectedItem as MenuItem;
            this.atcDishName.Content = selected.Name;

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                container.Children.Remove(windowOverlay);
                container.Children.Add(windowOverlay);
                atcPopup.IsOpen = true;
                atcPopup.StaysOpen = false;
            }));
        }

        private void More_Info_Click1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = appetizerItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = appetizerItems[index].Name;
            this.dishName.Content = Name;
            
            if(Convert.ToInt32(button.Tag) == 108)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";
                
                moreDishInfo.description.Text = "Fresh white corn chips & pico de gallo served with guacamole";
                
                moreDishInfo.ingredients.Inlines.Add(new Run("3 avocados - peeled, pitted, and mashed"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 lime, juiced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 teaspoon salt"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 cup diced onion"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 tablespoons chopped fresh cilantro"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 roma (plum) tomatoes, diced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 teaspoon minced garlic"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 pinch ground cayenne pepper "));
                
                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 261.5"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein: 3.7g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 18g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Dietary Fiber: 11.4g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugars: 3g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat: 22.2g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat: 3.2g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A: 653.5IU"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin B6: 0.5mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C: 26.2mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Folate: 133.3mcg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron: 1.1mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Magnesium: 51mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium: 866.1mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium: 595.7mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-3.jpg", UriKind.RelativeOrAbsolute));
                //moreDishInfo.imgPanel.Children.Add(img3);
            }
            else
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "Test ingredients";
                moreDishInfo.nutrition.Text = "Test nutritions";
            }

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                container.Children.Remove(windowOverlay);
                container.Children.Add(windowOverlay);
                dishPopup.IsOpen = true;
                dishPopup.StaysOpen = true;
            }));
        }

        private void More_Info_Click2(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = appetizerFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = appetizerFavouriteItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 108)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Fresh white corn chips & pico de gallo served with guacamole";

                moreDishInfo.ingredients.Inlines.Add(new Run("3 avocados - peeled, pitted, and mashed"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 lime, juiced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 teaspoon salt"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 cup diced onion"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 tablespoons chopped fresh cilantro"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 roma (plum) tomatoes, diced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 teaspoon minced garlic"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 pinch ground cayenne pepper "));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 261.5"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein: 3.7g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 18g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Dietary Fiber: 11.4g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugars: 3g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat: 22.2g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat: 3.2g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A: 653.5IU"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin B6: 0.5mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C: 26.2mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Folate: 133.3mcg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron: 1.1mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Magnesium: 51mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium: 866.1mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium: 595.7mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/appetizers/guacamole-3.jpg", UriKind.RelativeOrAbsolute));
                //moreDishInfo.imgPanel.Children.Add(img3);
            }
            else
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "Test ingredients";
                moreDishInfo.nutrition.Text = "Test nutritions";
            }

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                container.Children.Remove(windowOverlay);
                container.Children.Add(windowOverlay);
                dishPopup.IsOpen = true;
                dishPopup.StaysOpen = true;
            }));
        }

        private void Unfavourite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = appetizerFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            int oldIndex = (Convert.ToInt32(button.Tag) % 100) - 1;
            Application.Current.Dispatcher.Invoke(new Action(() => {
                appetizerItems.Insert(oldIndex, appetizerFavouriteItems[index]);
                appetizerFavouriteItems.RemoveAt(index);

            }));
            appetizerList.Items.Refresh();
            appetizerFavouriteList.Items.Refresh();
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = appetizerItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            Application.Current.Dispatcher.Invoke(new Action(() => {
                appetizerFavouriteItems.Add(appetizerItems[index]);
                appetizerItems.RemoveAt(index);
            }));
            appetizerList.Items.Refresh();
            appetizerFavouriteList.Items.Refresh();
        }
    }
}