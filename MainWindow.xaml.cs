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

namespace Matei_Bianca_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
        }

        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;
        private bool glazedToolStripMenuItem_IsChecked;
        private bool sugarToolStripMenuItem_IsChecked;

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem_IsChecked = true;
            sugarToolStripMenuItem_IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem_IsChecked = false;
            sugarToolStripMenuItem_IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void DoughtnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                        txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                        txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.DoughnutComplete+= new DoughnutMachine.DoughnutCompleteDelegate(DoughtnutCompleteHandler);
        }
       
        private void StopToolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if(!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Se pot introduce numai cifre", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
