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
    /// Interaction logic for Meals.xaml
    /// </summary>
    public partial class Meals : UserControl
    {
        public List<MenuItem> mealItems = new List<MenuItem>();
        public List<MenuItem> mealFavouriteItems = new List<MenuItem>();
        public WindowOverlay windowOverlay = new WindowOverlay();
        public string selectedName;
        public Image img1 = new Image();
        public Image img2 = new Image();
        public Image img3 = new Image();
        public Menu parent;

        public Meals(Menu m)
        {
            parent = m;

            InitializeComponent();

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\Meals.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                mealItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/meals/" + rowData[4], LongDescription = "" });
            }

            mealList.ItemsSource = mealItems;
            mealFavouriteList.ItemsSource = mealFavouriteItems;

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

        public Meals(List<MenuItem> filter)
        {
            InitializeComponent();

            mealItems = filter;

            string[] csvLines = System.IO.File.ReadAllLines(@".\..\..\..\menu_data\FilteredMeals.csv");

            for (int i = 1; i < csvLines.Length; i++)
            {
                //the csvs are @ delimited as , caused a lot of problems in the descriptions
                string[] rowData = csvLines[i].Split("@");
                mealItems.Add(new MenuItem() { Id = Convert.ToInt32(rowData[0]), Name = rowData[1], Price = Convert.ToDouble(rowData[2]), ShortDescription = rowData[3], PictureSource = @"/pictures/meals/" + rowData[4], LongDescription = "" });
            }

            mealList.ItemsSource = mealItems;
            mealFavouriteList.ItemsSource = mealFavouriteItems;

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

        public void mealList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            int index = mealItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = mealItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 204)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Marinated tofu, shiitake mushrooms and fresh vegetables with spicy mayo and sesame avocado";
                
                moreDishInfo.ingredients.Inlines.Add(new Run("3 Tablespoons + 2 teaspoons olive oil, divided"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 teaspoon cumin"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 lb sweet potato, peeled and chopped into chunks"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 oz chopped curly kale"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup diced red onion"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup canned chickpeas"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 Tablespoon brown sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 teaspoon chili powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup cannellini beans"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 Tablespoon apple cider vinegar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 teaspoon ground pepper, divided"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/4 teaspoon sea salt, divided"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 585"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar: 15g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat: 27g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 80g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fiber: 19g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein: 14g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-3.jpg", UriKind.RelativeOrAbsolute));
                //moreDishInfo.imgPanel.Children.Add(img3);
            }
            else if(Convert.ToInt32(button.Tag) == 208)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Panko crusted chicken breast, iceberg lettuce, dill pickles & cheddar cheese on a potato bun";

                moreDishInfo.ingredients.Inlines.Add(new Run("medium chicken breasts boneless, skinless"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups low-fat buttermilk"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 Tbsp hot sauce "));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp salt"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp black pepper"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp onion powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp garlic powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups all-purpose flour"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 burger buns buttered and toasted"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 green lettuce leaves"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 large tomato sliced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 dill pickles sliced into rings"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp Mayonnaise"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 485 "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat 19g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat 12g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Cholesterol 73mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates 46g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fiber 3g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar 5g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 32g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A 1516IU"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C 7mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Calcium 160mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron 4mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium 733mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 1368mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-2.jpg", UriKind.RelativeOrAbsolute));
                //moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-3.jpg", UriKind.RelativeOrAbsolute));
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
            int index = mealFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            var Name = mealFavouriteItems[index].Name;
            this.dishName.Content = Name;

            if (Convert.ToInt32(button.Tag) == 204)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Marinated tofu, shiitake mushrooms and fresh vegetables with spicy mayo and sesame avocado";

                moreDishInfo.ingredients.Inlines.Add(new Run("3 Tablespoons + 2 teaspoons olive oil, divided"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 teaspoon cumin"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 lb sweet potato, peeled and chopped into chunks"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3 oz chopped curly kale"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/4 cup diced red onion"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup canned chickpeas"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 Tablespoon brown sugar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 teaspoon chili powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("3/4 cup cannellini beans"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 Tablespoon apple cider vinegar"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1/2 teaspoon ground pepper, divided"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/4 teaspoon sea salt, divided"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories: 585"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar: 15g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat: 27g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates: 80g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fiber: 19g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein: 14g"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/meals/power-bowl-3.jpg", UriKind.RelativeOrAbsolute));
                //moreDishInfo.imgPanel.Children.Add(img3);
            }
            else if (Convert.ToInt32(button.Tag) == 208)
            {
                moreDishInfo.description.Text = "";
                moreDishInfo.ingredients.Text = "";
                moreDishInfo.nutrition.Text = "";

                moreDishInfo.description.Text = "Panko crusted chicken breast, iceberg lettuce, dill pickles & cheddar cheese on a potato bun";

                moreDishInfo.ingredients.Inlines.Add(new Run("medium chicken breasts boneless, skinless"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups low-fat buttermilk"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 Tbsp hot sauce "));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp salt"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp black pepper"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp onion powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp garlic powder"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 1/2 cups all-purpose flour"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 burger buns buttered and toasted"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 green lettuce leaves"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 large tomato sliced"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("2 dill pickles sliced into rings"));
                moreDishInfo.ingredients.Inlines.Add(new LineBreak());
                moreDishInfo.ingredients.Inlines.Add(new Run("1 tsp Mayonnaise"));

                moreDishInfo.nutrition.Inlines.Add(new Run("Calories 485 "));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fat 19g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Saturated Fat 12g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Cholesterol 73mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Carbohydrates 46g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Fiber 3g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sugar 5g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Protein 32g"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin A 1516IU"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Vitamin C 7mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Calcium 160mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Iron 4mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Potassium 733mg"));
                moreDishInfo.nutrition.Inlines.Add(new LineBreak());
                moreDishInfo.nutrition.Inlines.Add(new Run("Sodium 1368mg"));

                moreDishInfo.imgPanel.Children.Clear();
                img1.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-1.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img1);
                img2.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-2.jpg", UriKind.RelativeOrAbsolute));
                moreDishInfo.imgPanel.Children.Add(img2);
                //img3.Source = new BitmapImage(new Uri("/pictures/meals/crispy-chicken-sandwich-3.jpg", UriKind.RelativeOrAbsolute));
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
            int index = mealFavouriteItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            int oldIndex = (Convert.ToInt32(button.Tag) % 100) - 1;
            Application.Current.Dispatcher.Invoke(new Action(() => {
                mealItems.Insert(oldIndex, mealFavouriteItems[index]);
                mealFavouriteItems.RemoveAt(index);

            }));
            mealList.Items.Refresh();
            mealFavouriteList.Items.Refresh();
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = mealItems.FindIndex(x => x.Id == Convert.ToInt32(button.Tag));
            Application.Current.Dispatcher.Invoke(new Action(() => {
                mealFavouriteItems.Add(mealItems[index]);
                mealItems.RemoveAt(index);
            }));
            mealList.Items.Refresh();
            mealFavouriteList.Items.Refresh();
        }
    }
}