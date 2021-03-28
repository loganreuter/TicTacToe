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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();
        }

        public void BtnClick (object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var location = button.Tag;
            Console.WriteLine(location.GetType());
            string[] value = App.Move(Convert.ToChar(location));
            if(value[0] == "Error")
            {
                MessageBox.Show("Someone already went there");
            }
            else
            {
                button.Content = value[0];
                string y = value[2];
                Button txt = board.FindName("_" + y) as Button;
                txt.Content = "O";
                Console.WriteLine("Y Value is: "+ y);

            }
            
            if(value[1] != "false")
            {
                string txt = "Game Over";
                string msgtext;
                if (value[1] == "true")
                {
                    msgtext = "Game Over " + value[0] + "'s Won!";
                }
                else
                {
                    msgtext = "Game Over, it is a draw.";
                }

                MessageBoxButton buttons = MessageBoxButton.YesNoCancel;
                MessageBoxResult result = MessageBox.Show(msgtext, txt, buttons);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        foreach (Button btn in FindVisualChildren<Button>(board))
                        {
                            // do something with tb here
                            btn.Content = "";
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
