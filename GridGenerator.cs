using System.Drawing;
using System.Drawing.Imaging;

namespace GridImage
{
    internal class GridGenerator(string path, int rows, int cols, int thickness)
    {
        Bitmap? _image;

        public void GenerateGrid()
        {
            _image = OpenImage(path);
            if (_image != null)
            {
                for (int i = 1; i < rows; i++)
                {
                    CreateHorizontalLine(i);
                }
                for (int i = 1; i < cols; i++)
                {
                    CreateVerticalLine(i);
                }
                SaveFile();
            }
        }

        private void CreateVerticalLine(int col)
        {
            int posX = col * _image.Width / cols;
            for (int j = 0; j < _image.Height; j++)
            {
                for (int k = 0; k < thickness; k++)
                {
                    _image.SetPixel(posX + k, j, Color.OrangeRed);
                }
            }
        }

        private void CreateHorizontalLine(int row)
        {
            int posY = row * _image.Height / rows;
            for (int j = 0; j < _image.Width; j++)
            {
                for (int k = 0; k < thickness; k++)
                {
                    _image.SetPixel(j, posY + k, Color.OrangeRed);
                }
            }
        }

        private static Bitmap? OpenImage(string path)
        {
            try
            {
                return new(Image.FromFile(path));
            }
            catch
            {
                Console.WriteLine("ERROR: Can not open file. Check path and file extension.");
                return null;
            }
        }

        private void SaveFile()
        {
            var newFile = GetNewFileName();
            _image.Save(newFile, ImageFormat.Png);
            Console.WriteLine("Grid image created with name {0}", newFile);
        }

        private string GetNewFileName()
        {
            var imageName = Path.GetFileName(path);
            imageName = imageName.Substring(0, imageName.IndexOf("."));
            imageName += "_grid.png";
            return Path.Combine(Path.GetDirectoryName(path), imageName);
        }
    }
}
