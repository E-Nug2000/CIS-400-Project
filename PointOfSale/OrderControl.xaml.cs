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
using TheFlyingSaucer.Data.Entrees;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        /// <summary>
        /// Constructor for the OrderControl
        /// </summary>
        public OrderControl()
        {
            InitializeComponent();
        }

        public Order CurrentOrder;

        /// <summary>
        /// Removes the item 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            IOrderItem removedItem = (IOrderItem)orderListBox.SelectedItem;
            if(this.DataContext is Order ord)
            {
                ord.Remove(removedItem);
            }
            /*
            FlyingSaucer fs = new FlyingSaucer();
            menuContainer.Child = new FlyingSaucerCustomizationControl() { DataContext = fs };
            if (this.DataContext is Order ord)
            {
                ord.Add(fs);
            }*/
        }


        /// <summary>
        /// Creates a new order
        /// </summary>
        public void NewOrder(object sender, RoutedEventArgs e)
        {
            

        }

        /// <summary>
        /// Updates order number when new order button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is Order ord)
            {
                orderContainer.Child = new PaymentOptions()
                { DataContext = ord };

            }
           
        }

        /// <summary>
        /// Calls the MenuSelectionClick method when used, used in editing the item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IOrderItem changedItem = (IOrderItem)orderListBox.SelectedItem;
            DependencyObject parent = this;
            do
            {
                parent = LogicalTreeHelper.GetParent(parent);
            } while (!(parent is null || parent is MainWindow));
            
            if (parent is MainWindow mw)
            {
                mw.MenuSelectionClick(changedItem);
            }
        }

        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button b)
            {
                if (b.Name == "goBackButton")
                {
                    orderContainer.Child = null;
                }
                else if (b.Name == "cashButton")
                {
                    if (this.DataContext is Order ord)
                    {
                        CashRegisterControl crc = new CashRegisterControl();
                        crc.DataContext = ord;
                        orderContainer.Child = crc;

                    }

                }
            }
        }

    }
}
