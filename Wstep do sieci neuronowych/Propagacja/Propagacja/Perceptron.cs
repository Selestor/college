using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propagacja
{
    class Perceptron
    {
        public double Delta { get; set; }
        public double Suma { get; set; }
        public double[] Wagi { get; set; }
        double WagaBiasu { get; set; }

        double StalaUczaca { get; set; }

        public Perceptron(double[] wagi, double wagaBiasu, double stala)
        {
            this.Wagi = wagi;
            this.WagaBiasu = wagaBiasu;
            this.StalaUczaca = stala;
        }

        public Perceptron() { }

        private double Sigma(double x)
        {
            double r;
            r = (1 / (1 + Math.Pow(Math.E, -x)));
            return r;
        }

        public double Wyjscie(List<double> wejscie)
        {
            double suma = 0;
            double wynik = 0;

            for (int i = 0; i < Wagi.Length; i++)
            {
                suma += wejscie[i] * Wagi[i];
            }

            suma += WagaBiasu;
            wynik = Sigma(suma);
            Suma = wynik;

            return wynik;
        }

        public double LiczDelte(double wynik)
        {
            double tmp = (Suma - wynik) * Suma * (1 - Suma);
            Delta = tmp;
            return tmp;
        }

        public void DostosujWagi(List<double> wejscie)
        {
            for (int i = 0; i < Wagi.Length; i++)
            {
                Wagi[i] = Wagi[i] - StalaUczaca * Delta * wejscie[i];
            }
            WagaBiasu = WagaBiasu - StalaUczaca * Delta * 1;
        }
    }
}
