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
    /// Interaction logic for CropCircleOatsCustomizationControl.xaml
    /// </summary>
    public partial class CropCircleOatsCustomizationControl : UserControl
    {
        /// <summary>
        /// Customization control for CropCircleOats
        /// </summary>
        public CropCircleOatsCustomizationControl()
        {
            InitializeComponent();
            this.DataContext = new CropCircleOats();
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

        /// <summary>
        /// Indicates that order will have butter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkButter(object sender, RoutedEventArgs e)
        {
        }
    }
}
