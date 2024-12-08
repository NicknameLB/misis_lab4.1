using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter the size of the matrix (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Invalid input. Please enter a positive integer for the size of the matrix: ");
        }

        int chance = 500 / (n * n);
        Random rnd = new Random();

        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {   
                if (rnd.Next(0, 100) < chance)
                {
                    matrix[i, j] = 0;
                } 
                else
                {
                    matrix[i, j] = 1;
                }
            }
        }

        Console.WriteLine("\nThe matrix is:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = matrix[i, j] == 1 ? matrix[i - 1, j] + 1 : 0;
            }
        }

        int maxArea = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int minWidth = matrix[i, j];
                for (int k = j; k >= 0 && matrix[i, k] > 0; k--)
                {
                    minWidth = Math.Min(minWidth, matrix[i, k]);
                    maxArea = Math.Max(maxArea, minWidth * (j - k + 1));
                }
            }
        }

        // Print the maximum value
        Console.WriteLine("The maximum value in the list is: " + maxArea);
    }
}