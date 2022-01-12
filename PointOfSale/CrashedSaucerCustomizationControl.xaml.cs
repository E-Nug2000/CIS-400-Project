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
using TheFlyingSaucer.Data.Entrees;


namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for CrashedSaucerCustomizationControl.xaml
    /// </summary>
    public partial class CrashedSaucerCustomizationControl : UserControl
    {
        public CrashedSaucer cs = new CrashedSaucer();
        /// <summary>
        /// Customization control for the Crashed Saucer item
        /// </summary>
        public CrashedSaucerCustomizationControl()
        {
            InitializeComponent();
            CrashedSaucer cs = new CrashedSaucer();
            this.DataContext = cs;
            
        }

        /// <summary>
        /// Button to return to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack(object sender, RoutedEventArgs e)
        {
            
            //itemContainer.Child = new MenuSelectionControl();
        }


        /// <summary>
        /// Mark the item as half-stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkHalfStack(object sender, RoutedEventArgs e)
        {
            //cs.HalfStack = true;
        }
    }
}
