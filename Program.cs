namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        const int DIM_3X3 = 1;
        const int DIM_5X5 = 2;
        const int DIM_7X7 = 3;
        const int SIZE_3X3 = 3;
        const int SIZE_5X5 = 5;
        const int SIZE_7X7 = 7;
        const int MODE_MIDDLE_LINE = 1;
        const int MODE_ALL_HORIZONTAL = 2;
        const int MODE_ALL_VERTICAL = 3;
        const int MODE_BOTH_DIAGONALS = 4;
        const int INITIAL_BALANCE = 25;
        const int WAGER_PER_LINE = 1;
        const int WIN_PER_LINE = 3;

        int balance = INITIAL_BALANCE;

        Console.WriteLine(
            $"Hello, this is a little slot machine game! Wager is $1 per line. You start with {INITIAL_BALANCE} Dollars");

        while (balance > 0)
        {
            //Let user choose mode
            int mode;
            while (true)
            {
                Console.WriteLine(
                    "Please choose a mode (enter number of the mode and press enter):\n1 Middle Line\n2 All Horizontal " +
                    "\n3 All Vertical \n4 Both Diagonals");
                bool success = int.TryParse(Console.ReadLine(), out mode);
                if (success)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a number...");
                }
            }

            //Let user choose machine size
            int dim;
            while (true)
            {
                Console.WriteLine(
                    "Please choose the size of the slot machine (enter number of the size and press enter):\n1 3X3\n2 5X5" +
                    "\n3 7X7");
                bool success = int.TryParse(Console.ReadLine(), out dim);
                if (success)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is not a number...");
                }
            }

            int size = 0;

            if (dim == DIM_3X3)
            {
                size = SIZE_3X3;
            }

            if (dim == DIM_5X5)
            {
                size = SIZE_5X5;
            }

            if (dim == DIM_7X7)
            {
                size = SIZE_7X7;
            }

            //While loop over tries
            //Initialize Array
            int[,] array = new int [size, size];

            //Declare random
            Random rng = new Random();

            //Populate array
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    array[row, col] = rng.Next(0, 3);
                }
            }

            //Print array
            Console.Write("\n");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(array[row, col] + " ");
                }

                Console.Write("\n");
            }

            //Evaluation

            bool boolWin = true;
            int countWins = 0;

            if (mode == MODE_MIDDLE_LINE)
            {
                balance -= WAGER_PER_LINE;
                int rowToCheck = (size + 1) / 2;

                for (int col = 1; col < size; col++)
                {
                    if (array[rowToCheck, col] != array[rowToCheck, col - 1])
                    {
                        boolWin = false;
                    }
                }

                if (boolWin)
                {
                    countWins++;
                }
            }

            if (mode == MODE_ALL_HORIZONTAL)
            {
                balance -= WAGER_PER_LINE * size;
                for (int row = 0; row < size; row++)
                {
                    bool boolWinRow = true;
                    for (int col = 1; col < size; col++)
                    {
                        if (array[row, col] != array[row, col - 1])
                        {
                            boolWinRow = false;
                        }
                    }

                    if (boolWinRow)
                    {
                        countWins++;
                    }
                }
            }

            if (mode == MODE_ALL_VERTICAL)
            {
                balance -= WAGER_PER_LINE * size;
                for (int col = 0; col < size; col++)
                {
                    bool boolWinCol = true;
                    for (int row = 1; row < size; row++)
                    {
                        if (array[row, col] != array[row - 1, col])
                        {
                            boolWinCol = false;
                        }
                    }

                    if (boolWinCol)
                    {
                        countWins++;
                    }
                }
            }

            if (mode == MODE_BOTH_DIAGONALS)
            {
                balance -= WAGER_PER_LINE * 2;
                //Diagonal 1
                bool boolWinDiag = true;
                int row = 1;
                for (int col = 1; col < size; col++)
                {
                    if (array[row, col] != array[row - 1, col - 1])
                    {
                        boolWinDiag = false;
                    }

                    row++;
                }

                if (boolWinDiag)
                {
                    countWins++;
                }

                //Diagonal 2
                boolWinDiag = true;
                row = 1;
                for (int col = size - 2; col >= 0; col--)
                {
                    if (array[row, col] != array[row - 1, col + 1])
                    {
                        boolWinDiag = false;
                    }

                    row++;
                }

                if (boolWinDiag)
                {
                    countWins++;
                }
            }

            if (countWins > 0)
            {
                Console.WriteLine($"Congrats you win {countWins * WIN_PER_LINE} Dollars!");
                balance += countWins * WIN_PER_LINE;
            }
            else
            {
                Console.WriteLine($"You loose...");
                balance -= countWins * WIN_PER_LINE;
            }

            Console.WriteLine($"Your balance is: {balance}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        Console.WriteLine("No more money left... Game ends!");
    }
}