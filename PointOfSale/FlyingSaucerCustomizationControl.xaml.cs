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
    /// Interaction logic for FlyingSaucerCustomizationControl.xaml
    /// </summary>
    public partial class FlyingSaucerCustomizationControl : UserControl
    {
        /// <summary>
        /// Customization control for the Flying Saucer Object
        /// </summary>
        public FlyingSaucerCustomizationControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Button marks Half-Stack on order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkHalfStack(object sender, RoutedEventArgs e)
        {

        }
    }
}
