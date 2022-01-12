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
using TheFlyingSaucer.Data.Entrees;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OuterOmeletteCustomizationControl.xaml
    /// </summary>
    public partial class OuterOmeletteCustomizationControl : UserControl
    {
        public OuterOmeletteCustomizationControl()
        {
            InitializeComponent();
            this.DataContext = new OuterOmelette();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            itemContainer.Child = new MenuSelectionControl();
        }

        private void HoldPeppers(object sender, RoutedEventArgs e)
        {

        }

        private void HoldSourCream(object sender, RoutedEventArgs e)
        {

        }

        private void HoldCheese(object sender, RoutedEventArgs e)
        {

        }

        private void HoldHam(object sender, RoutedEventArgs e)
        {

        }

        private void HoldMushrooms(object sender, RoutedEventArgs e)
        {

        }

        private void HoldTomatoes(object sender, RoutedEventArgs e)
        {

        }

        private void HoldSpinach(object sender, RoutedEventArgs e)
        {

        }
        private void HoldOnions(object sender, RoutedEventArgs e)
        {

        }

    }
}
