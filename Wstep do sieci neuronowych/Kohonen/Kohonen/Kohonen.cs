using System;
using System.Collections.Generic;
using System.Windows;

namespace Kohonen
{
    class Kohonena
    {
        public List<Point> Wagi
        {
            get;
            set;
        }

        public List<Point> ListaPunktow
        {
            get;
            set;
        }

        public int iteracje
        {
            get;
            set;
        }

        const int promien = 2;
        Random rand = new Random();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Ucz(int i)
        {
            Point przyklad = new Point();

            //krok1
            przyklad = ListaPunktow[rand.Next(0,ListaPunktow.Count - 1)];

            //krok2
            int nrJednostki =  Krok2(przyklad);

            //krok3
            Krok3(przyklad, nrJednostki, i);
        }

        private int Krok2(Point przyklad)
        {
            double min = 1000;
            int wynik = 0;

            for (int i = 0; i < Wagi.Count; i++)
            {
                double odleglosc = Math.Sqrt(Math.Pow(przyklad.X - Wagi[i].X, 2) + Math.Pow(przyklad.Y - Wagi[i].Y, 2));

                if (min > odleglosc)
                {
                    min = odleglosc;
                    wynik = i;
                }
            }
            return wynik;
        }

        private void Krok3(Point punkt, int jednostka, int krok)
        {
            double alfa = 1 - ((krok - 1) / iteracje);
            double iks = Wagi[jednostka].X + alfa * MexicanHat(jednostka, jednostka) * (punkt.X - Wagi[jednostka].X);
            double igrek = Wagi[jednostka].Y + alfa * MexicanHat(jednostka, jednostka) * (punkt.Y - Wagi[jednostka].Y);
            Wagi[jednostka] = new Point(iks, igrek);

            for (int i = 0; i < promien; i++)
            {
                if ((jednostka - i) >= 0)
                {
                    iks = Wagi[jednostka - i].X + alfa * MexicanHat(jednostka - i, jednostka) * (punkt.X - Wagi[jednostka - i].X);
                    igrek = Wagi[jednostka - i].Y + alfa * MexicanHat(jednostka - i, jednostka) * (punkt.Y - Wagi[jednostka - i].Y);
                    Point p = new Point(iks, igrek);
                    Wagi[jednostka - i] = p;
                }
            }

            int iloscNeuronow = Wagi.Count;
            for (int i = 0; i < promien; i++)
            {
                if ((jednostka + i) < iloscNeuronow)
                {
                    iks = Wagi[jednostka + i].X + alfa * MexicanHat(jednostka + i, jednostka) * (punkt.X - Wagi[jednostka + i].X);
                    igrek = Wagi[jednostka + i].Y + alfa * MexicanHat(jednostka + i, jednostka) * (punkt.Y - Wagi[jednostka + i].Y);
                    Point p = new Point(iks, igrek);
                    Wagi[jednostka + i] = p;
                }
            }
        }

        const int lambda1 = 2;
        const int lambda2 = 5;
        private double MexicanHat(int a, int b)
        {
            double c = Math.Abs(a - b);
            double gauss1 = Math.Exp((-1) * Math.Pow(c, 2) / (2 * Math.Pow(lambda1, 2)));
            double gauss2 = Math.Exp((-1) * Math.Pow(c, 2) / (2 * Math.Pow(lambda2, 2)));
            double MH = 2 * gauss1 - gauss2;
            return MH;
        }
    }
}
