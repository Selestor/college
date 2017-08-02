using System;
using System.Collections.Generic;
using OxyPlot.Series;
using OxyPlot;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Class_Perceptron
    {
        private int cyfra;
        public int Cyfra
        {
            get
            {
                return cyfra;
            }
            set
            {
                cyfra = value;
            }
        }


        private List<double[]> listaUczaca = new List<double[]>();
        public List<double[]> ListaUczaca
        {
            get
            {
                return listaUczaca;
            }
            set
            {
                listaUczaca = value;
            }
        }

        private double[] wagi = new double[70];
        public double[] Wagi
        {
            get
            {
                return wagi;
            }
            set
            {
                wagi = value;
            }
        }

        private double[] wykres = new double[1000];
        public double[] Wykres
        {
            get
            {
                return wykres;
            }
            set
            {
                wykres = value;
            }
        }

        public void Koryguj_Wagi(List<double[]> input)
        {
            double blad_min = 1;
            double[] wagi_top = new double[70];
            double stala = 0.1;
            double theta = 0.01;

            double ERR = 0;
            double O = 0;

            int epoka = 0;
            int max_epok = 1000;

            while (epoka < max_epok)
            {
                ////////////////////////////////// mieszanie listy
                int n = input.Count;
                Random rng = new Random();
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    double[] a = input[k];
                    input[k] = input[n];
                    input[n] = a;
                }
                //////////////////////////////////

                foreach (double[] tablica in input)
                {
                    double suma = 0;
                    for (int i = 0; i < 70; i++)
                    {
                        suma += tablica[i] * Wagi[i];
                    }
                    O = suma;
                    if (suma < theta) O = - 1;
                    double T = tablica[70];
                    ERR = T - O;
                    if (ERR != 0)
                    {
                        for (int i = 0; i < 70; i++)
                        {
                            Wagi[i] = Wagi[i] + stala * ERR * tablica[i];
                            if (i > 34) Wagi[i] *= Wagi[i];
                        }
                        theta = theta - stala * ERR;
                    }
                }
                double blad = funkcja_bledu();
                if (blad < blad_min)
                {
                    blad_min = blad;
                    wagi_top = Wagi;
                }
                epoka++;
                wykres[epoka-1] = blad;
            }
            Wagi = wagi_top;
        }

        public double funkcja_bledu()
        {
            double wynik = 0;
            foreach (double[] example in ListaUczaca)
            {
                wynik += Math.Pow((Przypisz_Kategorie(example) - example[70]), 2);
            }
            return wynik;
        }

        private double[] dft(double[] data)
        {
            int n = data.Length;
            int m = n;// I use m = n / 2d;
            double[] real = new double[n];
            double[] imag = new double[n];
            double[] result = new double[m];
            double pi_div = 2.0 * Math.PI / n;
            for (int w = 0; w < m; w++)
            {
                double a = w * pi_div;
                for (int t = 0; t < n; t++)
                {
                    real[w] += data[t] * Math.Cos(a * t);
                    imag[w] += data[t] * Math.Sin(a * t);
                }
                result[w] = Math.Sqrt(real[w] * real[w] + imag[w] * imag[w]) / n;
            }
            return result;
        }

        public double Przypisz_Kategorie(double[] input)
        {
            double O;
            double suma = 0;
            double[] tablica_dft = new double[35];
            tablica_dft = dft(input);
            double[] calosc = new double[70];
            for (int i=0; i < 35; i++)
            {
                calosc[i] = input[i];
                calosc[i + 35] = tablica_dft[i];
            }

            for (int i = 0; i < 70; i++)
            {
                suma += calosc[i] * Wagi[i];
            }
            O = suma;
            //O = 0.5 * Math.Pow((1 - suma), 2);
            return O;
        }
    }
}
