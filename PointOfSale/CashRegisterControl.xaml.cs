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
    /// Interaction logic for CashRegisterControl.xaml
    /// </summary>
    public partial class CashRegisterControl : UserControl
    {
        /// <summary>
        /// The view for the cash register
        /// </summary>
        public CashRegisterControl()
        {
            InitializeComponent();
           
            
        }

        private void CoinControl_Click(object sender, RoutedEventArgs e)
        {
            /*CashViewModel cvm = new CashViewModel();
            if(this.DataContext is Order ord)
            {
                if (e.OriginalSource is Button b)
                {
                    if (b.Name == "plusButton")
                    {
                        if(b.Parent is CoinControl cc)
                        {
                            if()
                        }
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
            }*/
           
        }
    }
}
