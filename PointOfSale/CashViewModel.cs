using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RoundRegister;

namespace PointOfSale
{
    public class CashViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies of property changed events 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private decimal Total = (decimal)CashDrawer.Total;
        /// <summary>
        /// Total current value of the drawer
        /// </summary>
        public decimal DrawerTotal
        {
            get
            {
                return Total;
            }
            set
            {
                Total += (decimal)DrawerPennies/ 100;
                Total += (decimal)DrawerNickels / 20;
                Total += (decimal)DrawerDimes / 10;
                Total += (decimal)DrawerQuarters / 4;
                Total += (decimal)DrawerHalfDollars / 2;
                Total += DrawerDollars;
                Total += DrawerOnes;
                Total += DrawerTwos * 2;
                Total += DrawerFives * 5;
                Total += DrawerTens * 10;
                Total += DrawerTwenties * 20;
                Total += DrawerFifties * 50;
                Total += DrawerHundreds * 100;
            }
        }

        /// <summary>
        /// The total value of the customer's cash
        /// </summary>
        private decimal customerTotal = 0;
        public decimal CustomerTotal
        {
            get => customerTotal;
            set
            {
                Total += (decimal)CustomerPennies / 100;
                Total += (decimal)CustomerNickels / 20;
                Total += (decimal)CustomerDimes / 10;
                Total += (decimal)CustomerQuarters / 4;
                Total += (decimal)CustomerHalfDollars / 2;
                Total += CustomerDollars;
                Total += CustomerOnes;
                Total += CustomerTwos * 2;
                Total += CustomerFives * 5;
                Total += CustomerTens * 10;
                Total += CustomerTwenties * 20;
                Total += CustomerFifties * 50;
                Total += CustomerHundreds * 100;
            }
        }



       
        private decimal totalSale = 0;
        /// <summary>
        /// The total value of the entire sale
        /// </summary>
        public decimal TotalSale
        {
            get => totalSale;
            set
            {
                totalSale = value;
            }
        }

        /// <summary>
        /// The amount of money left to pay from the customer
        /// </summary>
        private decimal totalAmountDue = 0;
        public decimal TotalAmountDue
        {
            get => totalAmountDue;
            set
            {
                totalAmountDue = TotalSale - CustomerTotal;
            }

        }

        /// <summary>
        /// The amount of money left to pay to the customer
        /// </summary>
        private decimal totalChangeOwed = 0;
        public decimal TotalChangeOwed
        {
            get => totalChangeOwed;
            set
            {
                totalChangeOwed =  0 - TotalAmountDue;
                ChangeMaker();
            }

        }


        private void ChangeMaker()
        {
            if(TotalChangeOwed >= 100)
            {
                if(DrawerHundreds >= (int)(TotalChangeOwed / 100))
                {
                    NumHundredsDue = (int)(TotalChangeOwed / 100);
                    TotalChangeOwed = TotalChangeOwed % 100;

                }
            }
            if (TotalChangeOwed >= 50)
            {
                if (DrawerFifties >= (int)(TotalChangeOwed / 50))
                {
                    NumFiftiesDue = (int)(TotalChangeOwed / 50);
                    TotalChangeOwed = TotalChangeOwed % 50;

                }
            }
            if (TotalChangeOwed >= 20)
            {
                if (DrawerTwenties >= (int)(TotalChangeOwed / 20))
                {
                    NumTwentiesDue = (int)(TotalChangeOwed / 20);
                    TotalChangeOwed = TotalChangeOwed % 20;

                }
            }
            if (TotalChangeOwed >= 10)
            {
                if (DrawerTens >= (int)(TotalChangeOwed / 10))
                {
                    NumTensDue = (int)(TotalChangeOwed / 10);
                    TotalChangeOwed = TotalChangeOwed % 10;

                }
            }
            if (TotalChangeOwed >= 5)
            {
                if (DrawerFives >= (int)TotalChangeOwed / 5)
                {
                    NumFivesDue = (int)(TotalChangeOwed / 5);
                    TotalChangeOwed = TotalChangeOwed % 5;

                }
            }
            if (TotalChangeOwed >= 2)
            {
                if (DrawerTwos>= (int)(TotalChangeOwed / 2))
                {
                    NumTwosDue = (int)(TotalChangeOwed / 2);
                    TotalChangeOwed = TotalChangeOwed % 2;

                }
            }
            if (TotalChangeOwed >= 1)
            {
                if (DrawerOnes >= (int)(TotalChangeOwed / 1))
                {
                    NumOnesDue = (int)(TotalChangeOwed / 1);
                    TotalChangeOwed = TotalChangeOwed % 1;

                }
                else if (DrawerDollars >= (int)(TotalChangeOwed / 1))
                {
                    NumDollarsDue = (int)(TotalChangeOwed / 1);
                    TotalChangeOwed = TotalChangeOwed % 1;

                }
            }
            if (TotalChangeOwed >= 0.5m)
            {
                if (DrawerTwos >= TotalChangeOwed / 0.5m)
                {
                    NumHalfDollarsDue = (int)(TotalChangeOwed / 0.5m);
                    TotalChangeOwed = TotalChangeOwed % 0.5m;

                }
            }
            if (TotalChangeOwed >= 0.25m)
            {
                if (DrawerQuarters >= TotalChangeOwed / 0.25m)
                {
                    NumQuartersDue = (int)(TotalChangeOwed / 0.25m);
                    TotalChangeOwed = TotalChangeOwed % 0.25m;

                }
            }
            if (TotalChangeOwed >= 0.1m)
            {
                if (DrawerDimes >= TotalChangeOwed / 0.1m)
                {
                    NumDimesDue = (int)(TotalChangeOwed / 0.1m);
                    TotalChangeOwed = TotalChangeOwed % 0.1m;

                }
            }
            if (TotalChangeOwed >= 0.05m)
            {
                if (DrawerNickels >= TotalChangeOwed / 0.05m)
                {
                    NumNickelsDue = (int)(TotalChangeOwed / 0.05m);
                    TotalChangeOwed = TotalChangeOwed % 0.05m;

                }
            }
            if (TotalChangeOwed >= 0.01m)
            {
                if (DrawerPennies >= TotalChangeOwed / 0.01m)
                {
                    NumPenniesDue = (int)(TotalChangeOwed / 0.01m);
                    TotalChangeOwed = TotalChangeOwed % 0.01m;

                }
            }
        }

        
        private int numHundredsDue = 0;
        /// <summary>
        /// The number of hundred dollar bills that should be given to the customer
        /// </summary>
        public int NumHundredsDue
        {
            get => numHundredsDue;
            set { numHundredsDue = value; }

        }

        private int numFiftiesDue = 0;
        /// <summary>
        /// The number of fifty dollar bills that should be given to the customer
        /// </summary>
        public int NumFiftiesDue
        {
            get => numFiftiesDue;
            set { numFiftiesDue = value; }

        }

        private int numTwentiesDue = 0;
        /// <summary>
        /// The number of  twenty dollar bills that should be given to the customer
        /// </summary>
        public int NumTwentiesDue
        {
            get => numTwentiesDue;
            set { numHundredsDue = value; }

        }

        private int numTensDue = 0;
        /// <summary>
        /// The number of ten dollar bills that should be given to the customer
        /// </summary>
        public int NumTensDue
        {
            get => numTensDue;
            set { numTensDue = value; }

        }

        private int numFivesDue = 0;
        /// <summary>
        /// The number of five dollar bills that should be given to the customer
        /// </summary>
        public int NumFivesDue
        {
            get => numFivesDue;
            set { numFivesDue = value; }

        }


        private int numTwosDue = 0;
        /// <summary>
        /// The number of two dollar bills that should be given to the customer
        /// </summary>
        public int NumTwosDue
        {
            get => numTwosDue;
            set { numTwosDue = value; }

        }

        private int numOnesDue = 0;
        /// <summary>
        /// The number of one dollar bills that should be given to the customer
        /// </summary>
        public int NumOnesDue
        {
            get => numOnesDue;
            set { numHundredsDue = value; }

        }

        private int numDollarsDue = 0;
        /// <summary>
        /// The number of one dollar coins that should be given to the customer
        /// </summary>
        public int NumDollarsDue
        {
            get => numDollarsDue;
            set { numDollarsDue = value; }

        }

        private int numHalfDollarsDue = 0;
        /// <summary>
        /// The number of half dollar coins that should be given to the customer
        /// </summary>
        public int NumHalfDollarsDue
        {
            get => numHalfDollarsDue;
            set { numHalfDollarsDue = value; }

        }
        
        private int numQuartersDue = 0;
        /// <summary>
        /// The number of quarter coins that should be given to the customer
        /// </summary>
        public int NumQuartersDue
        {
            get => numQuartersDue;
            set { numQuartersDue = value; }

        }

        private int numDimesDue = 0;
        /// <summary>
        /// The number of dime coins that should be given to the customer
        /// </summary>
        public int NumDimesDue
        {
            get => numDimesDue;
            set { numDimesDue = value; }

        }

        private int numNickelsDue = 0;
        /// <summary>
        /// The number of nickel coins that should be given to the customer
        /// </summary>
        public int NumNickelsDue
        {
            get => numNickelsDue;
            set { numNickelsDue = value; }

        }

        private int numPenniesDue = 0;
        /// <summary>
        /// The number of penny coins that should be given to the customer
        /// </summary>
        public int NumPenniesDue
        {
            get => numPenniesDue;
            set { numPenniesDue = value; }

        }

        /// <summary>
        /// Property for the number of pennies in the order
        /// </summary>
        public string Pennies = "Pennies";

       
        private int drawerPennies = CashDrawer.Pennies;
        /// <summary>
        /// Number of pennies in the drawer
        /// </summary>
        public int DrawerPennies
        {
            get => drawerPennies;
            set
            {
                if (CashDrawer.Pennies == value || value < 0) return;
                else drawerPennies = value;
                InvokePropertyChanged("DrawerPennies");

            }
        }

       
        private int drawerNickels = CashDrawer.Nickels;
        /// <summary>
        /// Total number of nickels in the drawer
        /// </summary>
        public int DrawerNickels
        {
            get => drawerNickels;
            set
            {
                if (CashDrawer.Nickels== value || value < 0) return;
                else drawerNickels = value;
                InvokePropertyChanged("DrawerNickels");
            }
        }

       
        private int drawerDimes= CashDrawer.Dimes;
        /// <summary>
        /// Total number of dimes in the drawer
        /// </summary>
        public int DrawerDimes
        {
            get => drawerDimes;
            set
            {
                if (CashDrawer.Dimes == value || value < 0) return;
                else drawerDimes = value; 
                InvokePropertyChanged("DrawerDimes");
            }
        }

        private int drawerQuarters = CashDrawer.Quarters;
        /// <summary>
        /// Total number of quarters in the drawer
        /// </summary>
        public int DrawerQuarters
        {
            get => drawerQuarters;
            set
            {
                if (CashDrawer.Quarters == value || value < 0) return;
                else drawerQuarters = value;
                InvokePropertyChanged("DrawerDimes");
            }
        }

        private int drawerDollars = CashDrawer.Dollars;
        /// <summary>
        /// Total number of dollar coins in the drawer
        /// </summary>
        public int DrawerDollars
        {
            get => drawerDollars;
            set
            {
                if (CashDrawer.Dollars == value || value < 0) return;
                else drawerDollars = value;
                InvokePropertyChanged("DrawerDollars");
            }
        }

        private int drawerHalfDollars = CashDrawer.HalfDollars;
        /// <summary>
        /// Total number of half dollars in the drawer
        /// </summary>
        public int DrawerHalfDollars
        {
            get => drawerHalfDollars;
            set
            {
                if (CashDrawer.Nickels == value || value < 0) return;
                else drawerHalfDollars = value;
                InvokePropertyChanged("DrawerHalfDollars");
            }
        }

        private int drawerOnes = CashDrawer.Dimes;
        /// <summary>
        /// Total number of ones in the drawer
        /// </summary>
        public int DrawerOnes
        {
            get => drawerOnes;
            set
            {
                if (CashDrawer.Ones == value || value < 0) return;
                else drawerOnes = value;
                InvokePropertyChanged("DrawerOnes");
            }
        }


        private int drawerTwos = CashDrawer.Twos;
        /// <summary>
        /// Total number of twos in the drawer
        /// </summary>
        public int DrawerTwos
        {
            get => drawerTwos;
            set
            {
                if (CashDrawer.Twos == value || value < 0) return;
                else drawerTwos = value;
                InvokePropertyChanged("DrawerTwos");
            }
        }

        private int drawerFives = CashDrawer.Fives;
        /// <summary>
        /// Total number of fives in the drawer
        /// </summary>
        public int DrawerFives
        {
            get => drawerFives;
            set
            {
                if (CashDrawer.Fives == value || value < 0) return;
                else drawerFives = value;
                InvokePropertyChanged("DrawerFives");
            }
        }

        private int drawerTens = CashDrawer.Tens;
        /// <summary>
        /// Total number of tens in the drawer
        /// </summary>
        public int DrawerTens
        {
            get => drawerTens;
            set
            {
                if (CashDrawer.Tens == value || value < 0) return;
                else drawerTens = value;
                InvokePropertyChanged("DrawerTens");
            }
        }

        private int drawerTwenties = CashDrawer.Twenties;
        /// <summary>
        /// Total number of twenties in the drawer
        /// </summary>
        public int DrawerTwenties
        {
            get => drawerTwenties;
            set
            {
                if (CashDrawer.Twenties == value || value < 0) return;
                else drawerTwenties = value;
                InvokePropertyChanged("DrawerTwenties");
            }
        }

        private int drawerFifties = CashDrawer.Fifties;
        /// <summary>
        /// Total number of fifties in the drawer
        /// </summary>
        public int DrawerFifties
        {
            get => drawerFifties;
            set
            {
                if (CashDrawer.Fifties == value || value < 0) return;
                else drawerFifties = value;
                InvokePropertyChanged("DrawerFifties");
            }
        }

        private int drawerHundreds = CashDrawer.Hundreds;
        /// <summary>
        /// Total number of hundreds in the drawer
        /// </summary>
        public int DrawerHundreds
        {
            get => drawerHundreds;
            set
            {
                if (CashDrawer.Hundreds == value || value < 0) return;
                else drawerHundreds = value;
                InvokePropertyChanged("DrawerHundreds");
            }
        }
        /// <summary>
        /// ////////////////////
        /// </summary>


        private int customerPennies = 0;
        /// <summary>
        /// Number of pennies from the customer
        /// </summary>
        public int CustomerPennies
        {
            get => customerPennies;
            set
            {
                customerPennies = value;
            }
        }


        private int customerNickels = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerNickels
        {
            get => customerNickels;
            set => customerNickels = value;
        }


        private int customerDimes = 0;
        /// <summary>
        /// Total number of dimes from the customer
        /// </summary>
        public int CustomerDimes
        {
            get => customerDimes;
            set => customerDimes = value;
        }


        private int customerQuarters = 0;
        /// <summary>
        /// Total number of quarters from the customer
        /// </summary>
        public int CustomerQuarters
        {
            get => customerQuarters;
            set => customerQuarters = value;
        }

        private int customerHalfDollars = 0;
        /// <summary>
        /// Total number of Half Dollars from the customer
        /// </summary>
        public int CustomerHalfDollars
        {
            get => customerHalfDollars;
            set => customerHalfDollars = value;
        }

        private int customerDollars = 0;
        /// <summary>
        /// Total number of dollar coins from the customer
        /// </summary>
        public int CustomerDollars
        {
            get => customerDollars;
            set => customerDollars = value;
        }

        private int customerOnes = 0;
        /// <summary>
        /// Total number of ones from the customer
        /// </summary>
        public int CustomerOnes
        {
            get => customerOnes;
            set => customerOnes = value;
        }

        private int customerTwos = 0;
        /// <summary>
        /// Total number of twos from the customer
        /// </summary>
        public int CustomerTwos
        {
            get => customerTwos;
            set => customerTwos = value;
        }

        private int customerFives = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerFives
        {
            get => customerFives;
            set => customerFives = value;
        }

        private int customerTens = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerTens
        {
            get => customerTens;
            set => customerTens = value;
        }



        private int customerTwenties = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerTwenties
        {
            get => customerTwenties;
            set => customerTwenties = value;
        }


        private int customerFifties = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerFifties
        {
            get => customerFifties;
            set => customerFifties = value;
        }

        private int customerHundreds = 0;
        /// <summary>
        /// Total number of nickels from the customer
        /// </summary>
        public int CustomerHundreds
        {
            get => customerHundreds;
            set => customerHundreds = value;
        }

        /// <summary>
        /// Helper method for trigerring PropertyChanged events
        /// </summary>
        /// <param name="property"></param>
        void InvokePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DrawerTotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
        }
        

    }
}
