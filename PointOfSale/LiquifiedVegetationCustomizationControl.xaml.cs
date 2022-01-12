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
using TheFlyingSaucer.Data.Drinks;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for LiquifiedVegetationCustomizationControl.xaml
    /// </summary>
    public partial class LiquifiedVegetationCustomizationControl : UserControl
    {
        /// <summary>
        /// Customization control for liquified vegetation
        /// </summary>
        public LiquifiedVegetationCustomizationControl()
        {
            InitializeComponent();
            //this.DataContext = new LiquifiedVegetation();
        }

        /// <summary>
        /// Back button, returns to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack(object sender, RoutedEventArgs e)
        {
            itemContainer.Child = new MenuSelectionControl();
        }

    }
}
