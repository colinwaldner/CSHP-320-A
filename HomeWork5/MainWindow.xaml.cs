/******************************************
 * 
 * CSHP 320 A
 * Assignment 5
 * Colin Waldner
 * May 25, 2021
 * 
 ****************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HomeWork5
{

    public partial class MainWindow : Window
    {
        private string[,] board = new string[3, 3];
        private string turn;
        private int move;

        public MainWindow()
        {
            InitializeComponent();
            move = 0;
            turn = "X";
            uxTurn.Text = $"{turn}'s turn";
        }        

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            turn = "X";
            move = 0;
            uxTurn.Text = $"{turn}'s turn";
            board = new string[3, 3];
            var buttons = uxGrid.Children.OfType<Button>().ToList();

            foreach (var button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
        }
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] cell = (sender as Button).Tag.ToString().Split(",");

            UpdateBoard(int.Parse(cell[0]), int.Parse(cell[1]));
        }
        private void UpdateBoard(int row, int col)
        {
            if (string.IsNullOrEmpty(board[row,col]))
            {
                var button = uxGrid.Children.OfType<Button>().Where(x => x.Tag.Equals(row + "," + col)).FirstOrDefault();
                button.Content = turn;
                board[row, col] = turn;                
                move++;

                if (CheckWinner())
                {
                    uxTurn.Text = $"{turn} is the winner";
                    DisableButtons();
                }
                else
                {
                    if (move == 9)
                    {
                        uxTurn.Text = $"Game is a draw";
                        DisableButtons();
                    }
                    else
                    {
                        turn = turn.Equals("X") ? "O" : "X";
                        uxTurn.Text = $"{turn}'s turn";
                    }

                }
            }
        }
        private void DisableButtons()
        {
            var buttons = uxGrid.Children.OfType<Button>().ToList();

            foreach(var button in buttons)
            {
                button.IsEnabled = false;
            }
        }    
        private bool CheckWinner()
        {
            bool result = false;

            //across
            if (!string.IsNullOrEmpty(board[0, 0]) &&
                    (string.Compare(board[0, 0], board[0, 1]) == 0 &&
                     string.Compare(board[0, 0], board[0, 2]) == 0)) { result = true; }
            else if (!string.IsNullOrEmpty(board[1, 0]) &&
                    (string.Compare(board[1, 0], board[1, 1]) == 0 &&
                     string.Compare(board[1, 0], board[1, 2]) == 0)) { result = true; }
            else if (!string.IsNullOrEmpty(board[2, 0]) &&
                    (string.Compare(board[2, 0], board[2, 1]) == 0 &&
                     string.Compare(board[2, 0], board[2, 2]) == 0)) { result = true; }
            //up & down
            else if (!string.IsNullOrEmpty(board[0, 0]) &&
                    (string.Compare(board[0, 0], board[1, 0]) == 0 &&
                     string.Compare(board[0, 0], board[2, 0]) == 0)) { result = true; }
            else if (!string.IsNullOrEmpty(board[0, 1]) &&
                    (string.Compare(board[0, 1], board[1, 1]) == 0 &&
                     string.Compare(board[0, 1], board[2, 1]) == 0)) { result = true; }
            else if (!string.IsNullOrEmpty(board[0, 2]) &&
                    (string.Compare(board[0, 2], board[1, 2]) == 0 &&
                     string.Compare(board[0, 2], board[2, 2]) == 0)) { result = true; }
            //diagonal
            else if (!string.IsNullOrEmpty(board[0, 0]) &&
                    (string.Compare(board[0, 0], board[1, 1]) == 0 &&
                     string.Compare(board[0, 0], board[2, 2]) == 0)) { result = true; }
            else if (!string.IsNullOrEmpty(board[2, 0]) &&
                    (string.Compare(board[2, 0], board[1, 1]) == 0 &&
                     string.Compare(board[2, 0], board[0, 2]) == 0)) { result = true; }

            return result;
        }
    }
}
