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
    /// Interaction logic for NothingToSeeHereCustomizationControl.xaml
    /// </summary>
    public partial class NothingToSeeHereCustomizationControl : UserControl
    {
        public NothingToSeeHereCustomizationControl()
        {
            InitializeComponent();
            this.DataContext = new NothingToSeeHere();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            itemContainer.Child = new MenuSelectionControl();
        }
        private void SubstituteSausage(object sender, RoutedEventArgs e)
        {
        }

    }
}
