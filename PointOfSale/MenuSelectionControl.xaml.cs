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
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuSelectionControl.xaml
    /// </summary>
    public partial class MenuSelectionControl : UserControl
    {
        public MenuSelectionControl()
        {
            InitializeComponent();         
        }

       

        private void AddFlyingSaucer(object sender, RoutedEventArgs e)
        {

            FlyingSaucer fs = new FlyingSaucer();
            menuContainer.Child = new FlyingSaucerCustomizationControl() { DataContext = fs};
            if (this.DataContext is Order ord)
            {
                ord.Add(fs);
            }

        }

        private void AddLivestockMutilation(object sender, RoutedEventArgs e)
        {
            LivestockMutilation lsm = new LivestockMutilation();
            menuContainer.Child = new LivestockMutilationCustomizationControl() { DataContext = lsm };
            if (this.DataContext is Order ord)
            {
                ord.Add(lsm);
            }

        }

        private void AddNothingToSeeHere(object sender, RoutedEventArgs e)
        {
            NothingToSeeHere item = new NothingToSeeHere();
            menuContainer.Child = new NothingToSeeHereCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }

        private void AddCrashedSaucer(object sender, RoutedEventArgs e)
        {
            CrashedSaucer item = new CrashedSaucer();
            menuContainer.Child = new CrashedSaucerCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }

        private void AddOuterOmelette(object sender, RoutedEventArgs e)
        {
            OuterOmelette item = new OuterOmelette();
            menuContainer.Child = new OuterOmeletteCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }

        private void AddSpaceScramble(object sender, RoutedEventArgs e)
        {
            SpaceScramble item = new SpaceScramble();
            menuContainer.Child = new SpaceScrambleCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddCropCircleOats(object sender, RoutedEventArgs e)
        {
            CropCircleOats item = new CropCircleOats();
            menuContainer.Child = new CropCircleOatsCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddEvisceratedEggs(object sender, RoutedEventArgs e)
        {
            EvisceratedEggs item = new EvisceratedEggs();
            menuContainer.Child = new EvisceratedEggsCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddGlowingHaystack(object sender, RoutedEventArgs e)
        {
            GlowingHaystack item = new GlowingHaystack();
            menuContainer.Child = new GlowingHaystackCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddMissingLinks(object sender, RoutedEventArgs e)
        {
            MissingLinks item = new MissingLinks();
            menuContainer.Child = new MissingLinksCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddTakenBacon(object sender, RoutedEventArgs e)
        {
            TakenBacon item = new TakenBacon();
            menuContainer.Child = new TakenBaconCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddYoureToast(object sender, RoutedEventArgs e)
        {
            YoureToast item = new YoureToast();
            menuContainer.Child = new YoureToastCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddLiquifiedVegetation(object sender, RoutedEventArgs e)
        {
            LiquifiedVegetation item = new LiquifiedVegetation();
            menuContainer.Child = new LiquifiedVegetationCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddSaucerFuel(object sender, RoutedEventArgs e)
        {
            SaucerFuel item = new SaucerFuel();
            menuContainer.Child = new SaucerFuelCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }
        private void AddWater(object sender, RoutedEventArgs e)
        {
            Water item = new Water();
            menuContainer.Child = new WaterCustomizationControl() { DataContext = item };
            if (this.DataContext is Order ord)
            {
                ord.Add(item);
            }
        }

        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is Button b)
            {
                if(b.Name == "goBackButton")
                {
                    menuContainer.Child = null;
                }
            }
        }

    }
}
