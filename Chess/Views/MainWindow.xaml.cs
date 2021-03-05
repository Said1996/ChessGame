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
using Chess.Models.Game;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button selectedButton;
        Board board = Board.board;
        int[] from;
        List<Button> tempButtons = new List<Button>();
        List<Button> pieces = new List<Button>();
        int[] switcher = new int[] { 0, 8, 7, 6, 5, 4, 3, 2, 1 };

        public MainWindow()
        {
            InitializeComponent();
            pieces = Pieces();
        }
        private List<Button> Pieces()
        {
            foreach(var visualItem in ChessBoard.Children)
            {
                var button = visualItem as Button;
                pieces.Add(button);
            }
            return pieces;
        }

        private void RemovePiece(int row , int col)
        {
            foreach(var item in pieces)
            {
                if(Grid.GetRow(item) == row && Grid.GetColumn(item) == col)
                {
                    ChessBoard.Children.Remove(item);
                }
            }
        }

        private void RemoveButtons()
        {
            foreach (var button in tempButtons)
            {
                ChessBoard.Children.Remove(button);          
            }
        }

        private void AvailableMoves(object sender, RoutedEventArgs e)
        {
            RemoveButtons();
            tempButtons.Clear();
            selectedButton = sender as Button;
            
            from = new int[] { switcher[Grid.GetRow(selectedButton)] , Grid.GetColumn(selectedButton) };
            List<int[]> availableMoves = Move.Select(from);


            foreach (int[] item in availableMoves)
            {
                Button button = new Button();               
                Grid.SetRow(button, switcher[item[0]]);
                Grid.SetColumn(button, item[1]);
                ImageBrush imageBrush = new ImageBrush(new BitmapImage(new Uri("..\\..\\..\\Resources\\canMove.png" , UriKind.Relative)));
                button.Background = imageBrush;
                button.Click += MovePiece;  
                tempButtons.Add(button);
                
                ChessBoard.Children.Add(button);
            }
        }

        private void MovePiece(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);
            RemovePiece(row, column);
            
            Grid.SetRow(selectedButton, row);
            Grid.SetColumn(selectedButton, column);

            int[] to = new int[] { switcher[row], column };
            Move.DoMove(from, to);
            RemoveButtons();

            int rotateAngle;

            if(Move.Turn == "White")
            {
                rotateAngle = 180;
            }
            else
            {
                rotateAngle = 0;
            }

            ChessBoard.RenderTransform = new RotateTransform(rotateAngle);
            foreach(var ui in ChessBoard.Children)
            {
                var uiElement = ui as Button;
                uiElement.RenderTransformOrigin = new Point(0.5, 0.5);
                uiElement.RenderTransform = new RotateTransform(rotateAngle);
            }
           
        }

        private void RevertChanges(object sender, MouseButtonEventArgs e)
        {
            RemoveButtons();
        }
    }
}
