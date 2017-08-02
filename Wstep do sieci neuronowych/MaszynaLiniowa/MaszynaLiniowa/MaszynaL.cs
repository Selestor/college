using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaszynaLiniowa
{
    class MaszynaL
    {
        private Perceptron perc_white = new Perceptron();
        public Perceptron Perc_White
        {
            get; set;
        }
        private Perceptron perc_black = new Perceptron();
        public Perceptron Perc_Black
        {
            get; set;
        }

        public bool KorygujWagi(string[] obrazek, int classifier)
        {
            int value;

            double bialy = Perc_White.PoliczSume(obrazek);
            double czarny = Perc_Black.PoliczSume(obrazek);

            if (czarny > bialy)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            if (value != classifier)
            {
                if (value == 0)
                {
                    for (int i = 0; i < 1600; i++)
                    {
                        Perc_White.Wagi[i] -= double.Parse(obrazek[i]);
                        Perc_Black.Wagi[i] += double.Parse(obrazek[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < 1600; i++)
                    {
                        Perc_White.Wagi[i] += double.Parse(obrazek[i]);
                        Perc_Black.Wagi[i] -= double.Parse(obrazek[i]);
                    }
                }
                return false;
            }
            return true;
        }
    }
}
