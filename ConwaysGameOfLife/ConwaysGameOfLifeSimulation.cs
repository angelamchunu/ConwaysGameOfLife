using System;
using System.Security.Cryptography;

namespace ConwaysGameOfLife
{
    public class ConwaysGameOfLifeSimulation
    {
        public void Run(int row, int column, int numberOfGenerations)
        {
            Console.WriteLine("Initial Gen");
            var previousGeneration = GenerateInitialState(row, column);
           PrintGrid(row, column, previousGeneration);
            for (int i = 0; i <= numberOfGenerations; i++)
            {
                var nextGen = GenerateNextGeneration(previousGeneration, row, column);
                Console.WriteLine("Generation number " + (i+1));
                PrintGrid(row, column, previousGeneration);
                previousGeneration = nextGen;
            }
        }

        private int[,] GenerateInitialState(int row, int column)
        {
            int[,] initial = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    // randomly generate initial board 
                    initial[i, j] = RandomNumberGenerator.GetInt32(0, 2);
                }
            }
            return initial;
        }

         public int[,] GenerateNextGeneration(int[,] grid, int row, int column)
        {
            int[,] nextGen = new int[row, column];

            // Loop through every cell z
            for (int l = 1; l < row - 1; l++)
            {
                for (int m = 1; m < column - 1; m++)
                {

                    // finding no Of Neighbours 
                    // that are alive 
                    int aliveNeighbours = 0;
                    for (int i = -1; i <= 1; i++)             
                        for (int j = -1; j <= 1; j++)
                            aliveNeighbours += grid[l + i, m + j];

                            // The cell needs to be subtracted from its neighbours as it was counted before 
                            aliveNeighbours -= grid[l, m];
                            
                            // Satisfies first rule:  Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                            if (IsCellInUnderPopulatedArea(grid[l, m], aliveNeighbours))
                            {
                                nextGen[l, m] = 0;
                            }

                            // Satisfies third rule: Any live cell with more than three live neighbours dies, as if by overpopulation.
                            else if (IsCellInOverPopulatedArea(grid[l, m], aliveNeighbours))
                            {
                                nextGen[l, m] = 0;
                            }

                            // Satisfies 4th rule: Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                            else if (CanCellBeResurrected(grid[l, m], aliveNeighbours))
                            {
                                nextGen[l, m] = 1;
                            }

                            //  Satisfies 2nd rule : Any live cell with two or three live neighbours lives on to the next generation.
                            else
                                nextGen[l, m] = grid[l, m];                  
                }
            }
            return nextGen;
        }
         

            private bool IsCellInUnderPopulatedArea(int cell, int numberOfAliveNeighbours)
        {
            return (cell == 1) && (numberOfAliveNeighbours < 2);
        }

        private bool IsCellInOverPopulatedArea(int cell, int numberOfAliveNeighbours)
        {
            return (cell == 1) && (numberOfAliveNeighbours > 3);
        }

        private bool CanCellBeResurrected(int cell, int numberOfAliveNeighbours)
        {
            return (cell == 0) && (numberOfAliveNeighbours == 3);
        }

        private void PrintGrid(int row, int column, int[,] grid)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
