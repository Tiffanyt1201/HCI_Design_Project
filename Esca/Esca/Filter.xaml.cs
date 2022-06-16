using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

namespace Esca
{
    /// <summary>
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : UserControl
    {
        public Filter()
        {
            InitializeComponent();
        }

        private async void applyFilter_Click(object sender, RoutedEventArgs e)
        {
            this.afButton.Content = "Applied";
            await Task.Delay(1000);
            this.VeganCheckbox.IsChecked = false;
            this.GlutenCheckbox.IsChecked = false;
            this.afButton.Content = "Apply Filter";
        }
    }
}
