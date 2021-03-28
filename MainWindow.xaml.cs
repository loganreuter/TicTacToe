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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool Playing;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Home();
            Playing = false;
        }

        private void Frame_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Console.WriteLine(Playing);
            if(!Playing)
            {
                (e.Content as Home).Tag = this;
            }
            else
            {
                (e.Content as Game).Tag = this;
            }
        }

        public void PassData(Boolean data)
        {
            //MessageBox.Show(data.ToString());
            if (data)
            {
                Main.Content = new Game();
                Playing = data;
            }
        }
    }
}
