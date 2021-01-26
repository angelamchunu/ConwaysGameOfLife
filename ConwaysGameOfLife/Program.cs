using System;


namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two board size with comma seperating them");
            var size = Console.ReadLine();
            Console.WriteLine("Enter number of generations");
            try
            {
                var numberOfGenerations = Int32.Parse(Console.ReadLine());
                var column = Int32.Parse(size.Substring(0, size.IndexOf(",")));
                var row = Int32.Parse(size.Substring(size.IndexOf(",") + 1));
                ConwaysGameOfLifeSimulation conwaysGameOfLife = new ConwaysGameOfLifeSimulation();
                conwaysGameOfLife.Run(row, column, numberOfGenerations);
            }
            catch (FormatException)
            {
                Console.WriteLine("There is something wrong with your input ");
            }
            
        }
    }
}
