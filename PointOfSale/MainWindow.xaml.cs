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
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Sides;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            currentOrder = new Order();
            this.DataContext = currentOrder;
            
        }

        /// <summary>
        /// The current order
        /// </summary>
        public Order currentOrder;

        private void MenuSelectionControl_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Loaded = menuSelect;
        }
        private void OrderControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// When item is clicked, opens up edit screen
        /// </summary>
        /// <param name="item"></param>
        public void MenuSelectionClick(IOrderItem item)
        {

            if (item is FlyingSaucer fs)
            {
                menuSelection.menuContainer.Child = new FlyingSaucerCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is CrashedSaucer cs)
            {
                menuSelection.menuContainer.Child = new CrashedSaucerCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is CropCircleOats cco)
            {
                menuSelection.menuContainer.Child = new CropCircleOatsCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is EvisceratedEggs ee)
            {
                menuSelection.menuContainer.Child = new EvisceratedEggsCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is GlowingHaystack gh)
            {
                menuSelection.menuContainer.Child = new GlowingHaystackCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is LiquifiedVegetation lv)
            {
                menuSelection.menuContainer.Child = new LiquifiedVegetationCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is MissingLinks ml)
            {
                menuSelection.menuContainer.Child = new MissingLinksCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is NothingToSeeHere ntsh)
            {
                menuSelection.menuContainer.Child = new NothingToSeeHereCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is OuterOmelette oo)
            {
                menuSelection.menuContainer.Child = new OuterOmeletteCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is SaucerFuel sf)
            {
                menuSelection.menuContainer.Child = new SaucerFuelCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is SpaceScramble ss)
            {
                menuSelection.menuContainer.Child = new SpaceScrambleCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is TakenBacon)
            {
                menuSelection.menuContainer.Child = new TakenBaconCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is Water )
            {
                menuSelection.menuContainer.Child = new WaterCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
            else if (item is YoureToast yt)
            {
                menuSelection.menuContainer.Child = new YoureToastCustomizationControl();
                menuSelection.menuContainer.DataContext = item;
            }
        }

        /// <summary>
        /// Updates order number when new order button pressed, or creates a new order when the transaction is fully processed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewOrder(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button b)
            {
                if (b.Name == "newOrderButton")
                {
                    currentOrder = new Order();
                    this.DataContext = currentOrder;
                }
                else if(b.Name == "cardButton")
                {
                    if (this.DataContext is Order ord)
                    {
                        if (RoundRegister.CardReader.RunCard((double)ord.Total) == RoundRegister.CardTransactionResult.Approved)
                        {
                            
                            foreach(IOrderItem item in ord)
                            {
                                RoundRegister.RecieptPrinter.PrintLine(item.ToString());
                            }
                            RoundRegister.RecieptPrinter.PrintLine(ord.Subtotal.ToString());
                            RoundRegister.RecieptPrinter.PrintLine(ord.Tax.ToString());
                            RoundRegister.RecieptPrinter.PrintLine(ord.Total.ToString());
                            RoundRegister.RecieptPrinter.PrintLine("Payed with card");
                            RoundRegister.RecieptPrinter.CutTape();

                            currentOrder = new Order();
                            this.DataContext = currentOrder;
                            orderControl.orderContainer.Child = null;
                            //print reciept

                        }
                        else if(RoundRegister.CardReader.RunCard((double)ord.Total) == RoundRegister.CardTransactionResult.Declined){
                            MessageBox.Show("Error: Card Declined.");
                        }

                    }
                }
               

            }

        }

        /// <summary>
        /// Updates order number when new order button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrder(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button b)
            {
                if (b.Name == "completeButton")
                {
                  // this.AddChild 
                }
            }
        }


        private void AddOrder(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button b)
            {
                if (b.Name == "goBackButton")
                {

                    CrashedSaucerCustomizationControl cscc = new CrashedSaucerCustomizationControl();
                    DependencyObject depObj = menuContainer.Child as DependencyObject;
                    if (depObj != null)
                    {
                        if (LogicalTreeHelper.GetChildren(depObj).GetType() == cscc.GetType())
                        {
                            currentOrder.Add(new CrashedSaucer());
                            
                        }

                    }
                    else throw new Exception(); 
                  
                }
            }
        }

        private void PaymentOptions_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
