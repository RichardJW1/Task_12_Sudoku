using System;
using Library;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static int[][] board;
        static IntSet[][] suggestions;
        static IntSet uSet;
        static void Main(string[] args)
        {
            
            board = initialiseBoard();
            uSet = new IntSet(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            updateSuggestions();
            Console.ReadLine();

        }

        static void loop()
        {
            Console.Clear();
            printBoard(board);
            int row = getRow();
            int col = getCol();
            int value = getValue();
            place(row, col, value);
        }

        static int getRow()
        {           
            bool isValid = false;
            string input = "";
            while (!isValid)
                {
                Console.WriteLine("\nchoose row: ");
                input = Console.ReadLine();
                switch (input)
                    {
                        case "0": case "1": case "2": case "3": case "4": case "5": case "6": case "7": case "8":
                        isValid = true;
                        break;
                        default:
                            Console.WriteLine("invalid. Press any key to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            printBoard(board);
                            break;
                    }
                }
            return Convert.ToInt32(input);
        }
        static int getCol()
        {

            bool isValid = false;
            string input = "";
            while (!isValid)
            {
                Console.WriteLine("\nchoose col: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "0": case "1": case "2": case "3": case "4": case "5": case "6": case "7": case "8":
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("invalid. Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        printBoard(board);
                        break;
                }
            }
            return Convert.ToInt32(input);
        }
        static int getValue()
        {
            bool isValid = false;
            string input = "";
            while (!isValid)
            {
                Console.WriteLine("\nchoose value: ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "0": case "1": case "2": case "3": case "4": case "5": case "6": case "7": case "8":
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("invalid. Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        printBoard(board);
                        break;
                }
            }
            return Convert.ToInt32(input);
        }


        static IntSet getRow(int row)
        {
            IntSet newIntset = new IntSet(board[row]);
            newIntset.Excl(0);
            return newIntset;
        }

        static bool CheckRow(int i, IntSet[] row)
        {
            if (row[i].Members() == 1) return true;
            for (int n = 0; n < row.Length; n++)
            {
                if (n == i) continue;
                

            }
        }

        static IntSet getCol(int col)
        {
            IntSet newInset = new IntSet();

            for(int i = 0; i < 9; i++)
            {
                if(board[i][col] != 0)
                newInset.Incl(board[i][col]);
            }
            return newInset;
        }

        static IntSet getBlock(int row, int col)
        {
            int blockRow =-1;
            int blockCol = -1;
            if (row >= 0 && row <= 2) blockRow = 0;
            else if (row > 2 && row < 6) blockRow = 1;
            else blockRow = 2;

            if (col >= 0 && col <= 2) blockCol = 0;
            else if (col > 2 && col < 6) blockCol = 1;
            else blockCol = 2;

            IntSet blockNums = new IntSet();

            for (int i = 3*blockRow; i < (3 * blockRow)+3; i++)
            {
                for (int j = 3*blockCol; j < (3*blockCol)+3; j++)
                {
                    if(board[i][j] != 0) { blockNums.Incl(board[i][j]); }
                }
            }
            return blockNums;
        }
        static void isValidValue(int row, int col, int value)
        {
            IntSet rowNums = new IntSet(getRow(row));
            IntSet colNums = new IntSet(getCol(col));
            IntSet blockNums = getBlock(row, col);

            return;
        }

        static IntSet[][] updateSuggestions()
        {
            IntSet[][] result = new IntSet[9][];
            for (int i = 0; i < 9; i++)
            {
                result[i] = new IntSet[9];
                for (int j = 0; j < 9; j++)
                {
                    IntSet R = getRow(i);
                    IntSet C = getCol(j);
                    IntSet B = getBlock(i, j);

                    IntSet union = R.Union(C).Union(B);
                    IntSet suggestion = uSet.Difference(union);
                    result[i][j] = suggestion;
                    Console.WriteLine($"({i},{j}) -- " + suggestion.ToString());
                }
            }
            return result;
        }

        static void solveBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    


                }
            }
        }

        static void place(int row, int col, int value)
        {
            board[row][col] = value;
        }
        static void printBoard(int[][] board)
        {
            foreach (int[] a in board)
            {
                foreach (int b in a)
                {
                    Console.Write(Convert.ToString(b));
                }
                Console.WriteLine();
            }
        }
        static int[][] initialiseBoard()
        {
            InFile data = new InFile("sample.txt");
            int[][] board = new int[9][];

            for (int j = 0; j < 9; j++)
            {
                board[j] = new int[9];

                for (int k = 0; k < 9; k++)
                {
                    board[j][k] = data.ReadInt();
                }
            }
            return board;
        }

    }
}
