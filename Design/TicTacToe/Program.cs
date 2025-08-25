/*
 Designing a Tic-Tac-Toe game in C# involves creating a game board, handling player turns, checking for wins, and managing game states. This can be implemented as a console application or a GUI application using Windows Forms or WPF. 
Core Components: 

• Game Board Representation: 
	• A 2D array (e.g., char[,] board = new char[3,3];) or a 1D array of size 9 can represent the 3x3 grid. 
	• Initialize the board with empty markers (e.g., ' '). 

• Player Management: 
	• Keep track of the current player (e.g., 'X' or 'O'). 
	• Alternate turns between players after each valid move. 

• Making a Move: 
	• Prompt the current player for their desired move (e.g., row and column, or a number 1-9 for a 1D array). 
	• Validate the move: ensure the chosen spot is within bounds and is currently empty. 
	• If valid, update the board with the current player's marker. 

• Win Condition Check: 
	• After each move, check if the current player has won. This involves checking: 
		• All three rows for a matching set of markers. 
		• All three columns for a matching set of markers. 
		• Both diagonals for a matching set of markers. 

• Draw Condition Check: 
	• If the board is full and no player has won, the game is a draw. 

• Game Loop: 
	• Continuously repeat the "make a move, check for win/draw" cycle until a win or draw occurs. 

• User Interface (Console or GUI): 
	• Console: Print the board to the console after each move. 
	• GUI (Windows Forms/WPF): Use buttons for each cell of the board. Attach click event handlers to these buttons to register player moves. Update the button's text to display 'X' or 'O'. 

 */

namespace TicTacToe;

internal class Program
{
    private static char[,] board = {
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
};
    private static int currentPlayer = 1; // 1 for Player 1 (X), 2 for Player 2 (O)
    private static bool gameOver = false;

    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine($"Player {currentPlayer}'s turn. Enter a number (1-9):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9)
            {
                int row = (choice - 1) / 3;
                int col = (choice - 1) % 3;

                if (board[row, col] != 'X' && board[row, col] != 'O')
                {
                    board[row, col] = (currentPlayer == 1) ? 'X' : 'O';
                    if (CheckForWin())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (CheckForDraw())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 1) ? 2 : 1; // Switch player
                    }
                }
                else
                {
                    Console.WriteLine("That spot is already taken. Press any key to try again.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9. Press any key to try again.");
                Console.ReadKey();
            }

        } while (!gameOver);

        Console.WriteLine("Game over. Press any key to exit.");
        Console.ReadKey();
    }

    private static void DrawBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
        Console.WriteLine("     |     |     ");
    }

    private static bool CheckForWin()
    {
        char playerSymbol = (currentPlayer == 1) ? 'X' : 'O';

        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == playerSymbol && board[i, 1] == playerSymbol && board[i, 2] == playerSymbol)
                return true;
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == playerSymbol && board[1, i] == playerSymbol && board[2, i] == playerSymbol)
                return true;
        }

        // Check diagonals
        if ((board[0, 0] == playerSymbol && board[1, 1] == playerSymbol && board[2, 2] == playerSymbol) ||
            (board[0, 2] == playerSymbol && board[1, 1] == playerSymbol && board[2, 0] == playerSymbol))
            return true;

        return false;
    }

    private static bool CheckForDraw()
    {
        foreach (char cell in board)
        {
            if (cell != 'X' && cell != 'O')
                return false; // Found an empty spot, not a draw yet
        }
        return true; // All spots filled, no winner
    }

}
