using System;

namespace TicTacToe
{
    class Program
    {
        // the playfield
        static char[,] playField =
        {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };        

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;            
            
            do
            {
                // Updates the play field to 'X' or 'O'
                #region
                if (player == 2)
                {
                    player = 1;
                    SetPlayerSymbol('X', input);
                }
                else if(player == 1)
                {
                    player = 2;
                    SetPlayerSymbol('O', input);                    
                }

                SetField();
                #endregion

                //  Check if we have a winner or draw and reset the game
                #region 
                char[] playerChars = { 'X', 'O' };

                foreach (char item in playerChars)
                {
                            // Check Horizontal
                    if (   (playField[0, 0] == item && playField[0, 1] == item && playField[0, 2] == item)
                        || (playField[1, 0] == item && playField[1, 1] == item && playField[1, 2] == item)
                        || (playField[2, 0] == item && playField[2, 1] == item && playField[2, 2] == item)

                            // Check Vertical
                        || (playField[0, 0] == item && playField[1, 0] == item && playField[2, 0] == item)
                        || (playField[0, 1] == item && playField[1, 1] == item && playField[2, 1] == item)
                        || (playField[0, 2] == item && playField[1, 2] == item && playField[2, 2] == item)

                            // Check Diagonal
                        || (playField[0, 0] == item && playField[1, 1] == item && playField[2, 2] == item)
                        || (playField[2, 0] == item && playField[1, 1] == item && playField[0, 2] == item)
                        )
                    {
                        if(item == 'X')
                        {
                            Console.WriteLine("Player 2 wins!!!");                            
                        } 
                        else
                        {
                            Console.WriteLine("Player 1 wins!!!");                            
                        }
                        
                        Console.WriteLine("Press any key to reset the game.");
                        Console.ReadKey();

                        ResetField();

                        break;
                    }
                    else if(turns == 10)
                    {
                        Console.WriteLine("We have a draw");

                        Console.WriteLine("Press any key to reset the game.");
                        Console.ReadKey();

                        ResetField();

                        break;
                    }
                }
                #endregion  

                //  this keeps looping while the input is invalid
                #region
                do
                {
                    Console.Write("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number.");
                    } 
                    
                    if(input == 1 && playField[0, 0] == '1')
                    {
                        inputCorrect = true;
                    }
                    else if(input == 2 && playField[0, 1] == '2')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 3 && playField[0, 2] == '3')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 4 && playField[1, 0] == '4')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 5 && playField[1, 1] == '5')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 6 && playField[1, 2] == '6')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 7 && playField[2, 0] == '7')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 8 && playField[2, 1] == '8')
                    {
                        inputCorrect = true;
                    }
                    else if (input == 9 && playField[2, 2] == '9')
                    {
                        inputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("\nPlease use another field.");
                        inputCorrect = false;   
                    }

                } while (!inputCorrect);
                #endregion

            } while (true);            
        }

        public static void SetField()
        {
            Console.Clear();

            turns++;

            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
        }

        public static void ResetField()
        {
            char[,] InitialplayField =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };

            playField = InitialplayField;
            SetField();
            turns = 0;        }

        public static void SetPlayerSymbol(char playerSymbol, int input)
        {           
            switch (input)
            {
                case 1:
                    playField[0, 0] = playerSymbol; break;
                case 2:
                    playField[0, 1] = playerSymbol; break;
                case 3:
                    playField[0, 2] = playerSymbol; break;
                case 4:
                    playField[1, 0] = playerSymbol; break;
                case 5:
                    playField[1, 1] = playerSymbol; break;
                case 6:
                    playField[1, 2] = playerSymbol; break;
                case 7:
                    playField[2, 0] = playerSymbol; break;
                case 8:
                    playField[2, 1] = playerSymbol; break;
                case 9:
                    playField[2, 2] = playerSymbol; break;
            }
        }
    }
}
