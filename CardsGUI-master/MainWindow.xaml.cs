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

namespace CardsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CardTable cardTable = new CardTable();
        // Game game = new Game(cardTable);

        public MainWindow()
        {
            InitializeComponent();
            //CardTable cardTable = new CardTable();
            Game game = new Game(cardTable);
           // while (game.nextTask != Task.GameOver)
          //  {
           //     game.DoNextTask();
          //  }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Cheat_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void TextEntry_KeyDown(object sender, KeyEventArgs e)
        {
            return;
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Fold_Click(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
