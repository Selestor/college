using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaszynaLiniowa
{
    class Perceptron
    {
        /*
        private List<string[]> listaUczaca = new List<string[]>();
        public List<string[]> ListaUczaca
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
        */

        private double[] wagi = new double[40*40];
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
        
        public double Spin
        {
            get; set;
        }

        /*
        public double PoliczSume(string[] input)
        {
            double suma = 0;
            for (int i = 0; i < rozmiar; i++)
            {
                suma += double.Parse(input[i].ToString()) * Wagi[i];
            }
            return suma;
        }
        */
    }
}
