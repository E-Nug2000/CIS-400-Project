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
using TheFlyingSaucer.Data;


namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for PaymentOptions.xaml
    /// </summary>
    public partial class PaymentOptions : UserControl
    {
        /// <summary>
        /// The payment options screen
        /// </summary>
        public PaymentOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for clicking on the credit/debit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CardButtonClick(object sender, RoutedEventArgs e)
        {
            
            
        }

       
    }
}
