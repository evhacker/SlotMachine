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

        Console.WriteLine("Hello, this is a little slot machine game!");

        //Let user choose mode
        Console.WriteLine(
            "Please choose a mode (enter number of the mode and press enter):\n1 Middle Line\n2 All Horizontal " +
            "\n3 All Vertical \n4 Both Diagonals");
        int mode = Convert.ToInt32(Console.ReadLine());

        //Let user choose machine size
        Console.WriteLine(
            "Please choose the size of the slot machine (enter number of the size and press enter):\n1 3X3\n2 5X5" +
            "\n3 7X7");
        int dim = Convert.ToInt32(Console.ReadLine());

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

        bool bool_win = true;
        int count_wins = 0;

        if (mode == MODE_MIDDLE_LINE)
        {
            int rowToCheck = (size + 1) / 2;

            for (int col = 1; col < size; col++)
            {
                if (array[rowToCheck, col] != array[rowToCheck, col - 1])
                {
                    bool_win = false;
                }
            }

            if (bool_win == true)
            {
                count_wins++;
            }
        }

        if (mode == MODE_ALL_HORIZONTAL)
        {
            for (int row = 0; row < size; row++)
            {
                bool bool_win_row = true;
                for (int col = 1; col < size; col++)
                {
                    if (array[row, col] != array[row, col - 1])
                    {
                        bool_win_row = false;
                    }
                }

                if (bool_win_row == true)
                {
                    count_wins++;
                }
            }
        }

        if (mode == MODE_ALL_VERTICAL)
        {
            for (int col = 0; col < size; col++)
            {
                bool bool_win_col = true;
                for (int row = 1; row < size; row++)
                {
                    if (array[row, col] != array[row - 1, col])
                    {
                        bool_win_col = false;
                    }
                }

                if (bool_win_col == true)
                {
                    count_wins++;
                }
            }
        }

        if (mode == MODE_BOTH_DIAGONALS)
        {
            //Diagonal 1
            bool bool_win_diag = true;
            for (int col = 1; col < size; col++)
            {
                for (int row = 1; row < size; row++)
                {
                    if (row == col)
                    {
                        if (array[row, col] != array[row - 1, col - 1])
                        {
                            bool_win_diag = false;
                        }
                    }
                }

                if (bool_win_diag == true)
                {
                    count_wins++;
                }
            }

            //Diagonal 2
            bool_win_diag = true;
            for (int col = size; col < 0; col--)
            {
                for (int row = size; row < 0; row--)
                {
                    if (row == col)
                    {
                        if (array[row, col] != array[row - 1, col - 1])
                        {
                            bool_win_diag = false;
                        }
                    }
                }

                if (bool_win_diag == true)
                {
                    count_wins++;
                }
            }
        }

        if (count_wins > 0)
        {
            Console.WriteLine("Congrats you win!");
        }
        else
        {
            Console.WriteLine("You loose...");
        }
    }
}