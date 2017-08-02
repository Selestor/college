using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMAGEENE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string[,] pixels = new string[40 , 40];

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var img = new Bitmap(path + @"\artas.png");

            for (int row = 0; row < 40; row++)
            {
                for (int col = 0; col < 40; col++)
                {
                    Color pixelColor = img.GetPixel(row, col);
                    Color a = new Color();
                    a = Color.Black;
                    if (pixelColor.R == a.R)
                    {
                        pixels[row, col] = "1";
                    }
                    else pixels[row, col] = "0";
                }
            }

            string[] pixels1 = new string[40 * 40];
            for (int row = 0; row < 40; row++)
            {
                for (int col = 0; col < 40; col++)
                {
                    pixels1[row * 40 + col] = pixels[col, row];
                }
            }
                    
            File.WriteAllLines(path + @"\artas.txt", pixels1, Encoding.UTF8);
        }
    }
}
