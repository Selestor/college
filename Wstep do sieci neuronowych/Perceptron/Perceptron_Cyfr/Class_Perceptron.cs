using System;
using System.Collections.Generic;
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

        private double[] wagi = new double[35];
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


        public void Koryguj_Wagi(List<double[]> input)
        {
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
                    for (int i = 0; i < 35; i++)
                    {
                        suma += tablica[i] * Wagi[i];
                    }
                    if (suma > theta) O = 1;
                    else O = -1;
                    double poprawne = tablica[35];
                    ERR = poprawne - O;
                    if (ERR != 0)
                    {
                        for (int i = 0; i < 35; i++)
                        {
                            Wagi[i] = Wagi[i] + stala * ERR * tablica[i];
                            theta = theta - stala * ERR;
                        }
                    }
                }
                epoka++;
            }
        }

        public double Przypisz_Kategorie(double[] input)
        {
            double O;
            double suma = 0;
            for (int i = 0; i < 35; i++)
            {
                suma += input[i] * Wagi[i];
            }
            O = suma;
            return O;
        }
    }
}
