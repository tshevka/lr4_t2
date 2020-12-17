using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace lr4_2
{
    class Task2
    {
        private static readonly string defaultFile = $@"{Directory.GetCurrentDirectory()}\pict\";

        public void fileManipulating()
        {
            Regex regex = new Regex("^((.bmp)|(.gif)|(.jpeg)|(.png))$", RegexOptions.IgnoreCase);
            string[] pics = Directory.GetFiles(defaultFile);


            foreach (string pic in pics)
            {
                try
                {
                    if (regex.IsMatch(Path.GetExtension(pic)))
                    {
                        Bitmap bitmap = new Bitmap(pic);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
                        string fileName = Path.GetFileNameWithoutExtension(pic);
                        bitmap.Save(defaultFile + fileName + "-mirrored.png", ImageFormat.Png);
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("File doesn't include an image");
                }
            }
        }
    }
}
