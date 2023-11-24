using System.Drawing;

namespace GridImage
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int rows = 3, cols = 3, thickness = 1;
            if (args.Length >= 3)
            {
                if (!int.TryParse(args[1], out rows) || rows < 0)
                {
                    throw new Exception("Argument 2 (number of rows) must be a positive integer");
                }
                if (!int.TryParse(args[2], out cols) || cols < 0)
                {
                    throw new Exception("Argument 3 (number of columns) must be a positive integer");
                }
                if (args.Length == 4 && (!int.TryParse(args[3], out thickness) || thickness <= 0))
                {
                    throw new Exception("Argument 4 (thickness) must be a positive integer greater than zero");
                }
            }
            else
            {
                Console.WriteLine("Usage: GridGenerator.exe filename rows columns [thickness]");
                Console.WriteLine();
                Console.WriteLine("Generating grid with default values");
                Console.WriteLine();
            }

            var gg = new GridGenerator(args[0], rows, cols, thickness);
            gg.GenerateGrid();
            
        }

        
    }
}
