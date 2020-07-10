using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
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
    ///  MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Game TicTacToeGame = new Game(); //Create object TicTacToeGame
        private CurrentPlayer player = CurrentPlayer.CrossPlayer; //Variable storage information about current player
        private Button[,] buttons;

        public MainWindow()
        {
            InitializeComponent();

            //Array with buttons from MianWindow.xaml
            buttons = new Button[,] { { button0_0,button0_1,button0_2},
                                       { button1_0,button1_1,button1_2},
                                        { button2_0,button2_1,button2_2}};
        }

        //Set RedPoints and BluePoints to 0
        private void RestartPoints(object sender, RoutedEventArgs e)
        {
            RedPoints.Text = "0";
            BluePoints.Text = "0";
        }

        //Clear all fields and set value {FieldProperty.Empty} for each of them
        //Set player to CrossPlayer
        private void RestartGame(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < TicTacToeGame.FieldArray.GetLength(0); i++)
            {
                for (int j = 0; j < TicTacToeGame.FieldArray.GetLength(1); j++)
                {
                       buttons[j, i].Background = Brushes.LightBlue;
                       buttons[j, i].Content = " ";
                       TicTacToeGame.FieldArray[i, j] = FieldProperty.Empty;
                }
            }

            player = CurrentPlayer.CrossPlayer;
        }

        //Check win after event(click button)
        //If true -> change color winning fields and set value {FieldProperty.Bloced} for others
        //If false -> change current player
        private void CheckWin()
        {
            if (TicTacToeGame.CurrentPlayerWin())
            {
                for (int i = 0; i < TicTacToeGame.FieldArray.GetLength(0); i++)
                {
                    for (int j = 0; j < TicTacToeGame.FieldArray.GetLength(1); j++)
                    {
                        if (TicTacToeGame.FieldArray[i, j] == FieldProperty.Win)
                            buttons[j, i].Background = Brushes.LightGreen;
                        else
                            TicTacToeGame.FieldArray[i, j] = FieldProperty.Bloced;
                    }
                }

                if (player == CurrentPlayer.CirclePlayer)
                    RedPoints.Text = (int.Parse(RedPoints.Text) + 1).ToString();

                else
                    BluePoints.Text = (int.Parse(BluePoints.Text) + 1).ToString();

                player = CurrentPlayer.CrossPlayer;

            }
            else
            {
                if (player == CurrentPlayer.CirclePlayer)
                    player = CurrentPlayer.CrossPlayer;
                else
                    player = CurrentPlayer.CirclePlayer;
            }

        }

        //If button clicked and current field are empty set button content to right sign for current player
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            var element = (UIElement)e.Source;

            if (TicTacToeGame.FieldArray[Grid.GetRow(element), Grid.GetColumn(element)] == FieldProperty.Empty)
            {
                if (player == CurrentPlayer.CrossPlayer)
                {
                    button.Content = "X";
                    button.Foreground = Brushes.Blue;
                    TicTacToeGame.FieldArray[Grid.GetRow(element), Grid.GetColumn(element)] = FieldProperty.Cross;
                }
                else
                {
                    button.Content = "O";
                    button.Foreground = Brushes.Red;
                    TicTacToeGame.FieldArray[Grid.GetRow(element), Grid.GetColumn(element)] = FieldProperty.Circle;
                }

                CheckWin(); //Check win after event(click button)
            }

        }
    }

}
