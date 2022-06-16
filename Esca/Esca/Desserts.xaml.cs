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
    /// Interaction logic for Desserts.xaml
    /// </summary>
    public partial class Desserts : UserControl
    {
        public List<MenuItem> dessertItems = new List<MenuItem>();
        public List<MenuItem> dessertFavouriteItems = new List<MenuItem>();
        public WindowOverlay windowOverlay = new WindowOverlay();
        public string selectedName;
        public Image img1 = new Image();
        public Image img2 = new Image();
        public Menu parent;

        public Desserts(Menu m)
        {
            parent = m;

            InitializeComponent();

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\Desserts.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                dessertItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/desserts/" + rowData[4], LongDescription = "" });
            }

            dessertList.ItemsSource = dessertItems;
            dessertFavouriteList.ItemsSource = dessertFavouriteItems;

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

        public void dessertList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            int index = dessertItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = dessertItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 402)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Fresh cheesecake served with pecans, french vanilla ice cream and caramel drizzle";

                moreDishInfo.ingredients.Inlines.Add(new Run("1 3/4 cups graham cracker crumbs (about 28 squares)"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup packed brown sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 cup butter, melted"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 packages (8 oz each) cream cheese, softened"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 eggs"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup whipping cream"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup caramel-flavored coffee syrup"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 teaspoons flaked sea salt"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 510"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Fat 34g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat 20g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Trans Fat 1g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Cholesterol 140mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 520mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium 150mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrate 47g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugars 41g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 5g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/desserts/salted-caramel-cheesecake-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/desserts/salted-caramel-cheesecake-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
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
            int index = dessertFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = dessertFavouriteItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 402)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Fresh cheesecake served with pecans, french vanilla ice cream and caramel drizzle";

                moreDishInfo.ingredients.Inlines.Add(new Run("1 3/4 cups graham cracker crumbs (about 28 squares)"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup packed brown sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 cup butter, melted"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 packages (8 oz each) cream cheese, softened"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 eggs"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup whipping cream"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup caramel-flavored coffee syrup"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 teaspoons flaked sea salt"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 510"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Total Fat 34g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat 20g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Trans Fat 1g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Cholesterol 140mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 520mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium 150mg "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrate 47g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugars 41g "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 5g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/desserts/salted-caramel-cheesecake-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/desserts/salted-caramel-cheesecake-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
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
            int index = dessertFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            int oldIndex = (Convert.ToInt32(button.Tag) % 100) - 1;
            Application.Current.Dispatcher.Invoke(new Action(() => {
                dessertItems.Insert(oldIndex, dessertFavouriteItems[index]);
                dessertFavouriteItems.RemoveAt(index);

            }));
            dessertList.Items.Refresh();
            dessertFavouriteList.Items.Refresh();
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = dessertItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            Application.Current.Dispatcher.Invoke(new Action(() => {
                dessertFavouriteItems.Add(dessertItems[index]);
                dessertItems.RemoveAt(index);
            }));
            dessertList.Items.Refresh();
            dessertFavouriteList.Items.Refresh();
        }
    }
}