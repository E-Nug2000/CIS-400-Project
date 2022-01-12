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
using TheFlyingSaucer.Data.Sides;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for GlowingHaystackCustomizationControl.xaml
    /// </summary>
    public partial class GlowingHaystackCustomizationControl : UserControl
    {
        /// <summary>
        /// The customization control for the GlowingHaystack side
        /// </summary>
        public GlowingHaystackCustomizationControl()
        {
            InitializeComponent();
            this.DataContext = new GlowingHaystack();
        }

        /// <summary>
        /// Button returns to main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack(object sender, RoutedEventArgs e)
        {
            itemContainer.Child = new MenuSelectionControl();
        }

        /// <summary>
        /// Adds sauce to order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSauce(object sender, RoutedEventArgs e)
        {

        }
    }
}
