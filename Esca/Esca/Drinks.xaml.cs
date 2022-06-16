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
using static Esca.MenuItem;

namespace Esca
{
    /// <summary>
    /// Interaction logic for Drinks.xaml
    /// </summary>
    public partial class Drinks : UserControl
    {
        public List<MenuItem> drinkItems = new List<MenuItem>();
        public List<MenuItem> drinkFavouriteItems = new List<MenuItem>();
        public WindowOverlay windowOverlay = new WindowOverlay();
        public string selectedName;
        public Image img1 = new Image();
        public Menu parent;

        public Drinks(Menu m)
        {
            parent = m;

            InitializeComponent();

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\Drinks.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                drinkItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/drinks/" + rowData[4], LongDescription = "" });
            }

            drinkList.ItemsSource = drinkItems;
            drinkFavouriteList.ItemsSource = drinkFavouriteItems;

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

        public void drinkList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            int index = drinkItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = drinkItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 305)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "375ml canned diet Coca-Cola(regular flavour)";

                moreDishInfo.ingredients.Inlines.Add(new Run("Carbonated water"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Caramel colour, "));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Phosphoric and citric acid"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Aspartame (contains phenylalanine)"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Sodium benzoate"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Caffeine"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Acesulfame-potassium"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 0"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Fat 0g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 0.1g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 25mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C 0%"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Carbohydrates 0g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Sugars 0g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/drinks/diet-coca-cola-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
            }
            else if (Convert.ToInt32(button.Tag) == 306)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Fresh sweet lemonade";

                moreDishInfo.ingredients.Inlines.Add(new Run("2 cups granulated sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups fresh lemon juice, about 6-8 lemons"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("4 1/2 - 5 cups water, divided."));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 179"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 46g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium: 1mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium: 56mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar: 44g  "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A: 120IU "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C: 14.9mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Calcium: 9mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron: 0.2mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/drinks/lemonade-2.png", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
            }
            else
            {
                moreDishInfo.description.Text = "Test description";
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
            int index = drinkFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = drinkFavouriteItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 305)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "375ml canned diet Coca-Cola(regular flavour)";

                moreDishInfo.ingredients.Inlines.Add(new Run("Carbonated water"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Caramel colour, "));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Phosphoric and citric acid"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Aspartame (contains phenylalanine)"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Sodium benzoate"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Caffeine"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("Acesulfame-potassium"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 0"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Fat 0g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 0.1g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 25mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C 0%"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Carbohydrates 0g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Sugars 0g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/drinks/diet-coca-cola-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
            }
            else if (Convert.ToInt32(button.Tag) == 306)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Fresh sweet lemonade";

                moreDishInfo.ingredients.Inlines.Add(new Run("2 cups granulated sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups fresh lemon juice, about 6-8 lemons"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("4 1/2 - 5 cups water, divided."));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 179"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 46g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium: 1mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium: 56mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar: 44g  "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A: 120IU "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C: 14.9mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Calcium: 9mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron: 0.2mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/drinks/lemonade-2.png", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
            }
            else
            {
                moreDishInfo.description.Text = "Test description";
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
            int index = drinkFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            int oldIndex = (Convert.ToInt32(button.Tag) % 100) - 1;
            Application.Current.Dispatcher.Invoke(new Action(() => {
                drinkItems.Insert(oldIndex, drinkFavouriteItems[index]);
                drinkFavouriteItems.RemoveAt(index);

            }));
            drinkList.Items.Refresh();
            drinkFavouriteList.Items.Refresh();
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = drinkItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            Application.Current.Dispatcher.Invoke(new Action(() => {
                drinkFavouriteItems.Add(drinkItems[index]);
                drinkItems.RemoveAt(index);
            }));
            drinkList.Items.Refresh();
            drinkFavouriteList.Items.Refresh();
        }
    }
}