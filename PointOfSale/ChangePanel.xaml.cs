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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for ChangePanel.xaml
    /// </summary>
    public partial class ChangePanel : UserControl
    {
        public static readonly DependencyProperty QuantityProperty =
           DependencyProperty.Register("Quantity", typeof(int), typeof(ChangePanel), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Gets or sets the quantity of coin or dollar
        /// </summary>
        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set => SetValue(QuantityProperty, value);
        }

        /// <summary>
        /// The panel indicating the amount of change needed
        /// </summary>
        public ChangePanel()
        {
            InitializeComponent();
        }
    }
}
