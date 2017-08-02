using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propagacja
{
    class Warstwa
    {
        public Perceptron[] Perceptrony { get; set; }
        public int Rozmiar { get; set; }
        public Warstwa(int rozmiar, Perceptron[] perceptrony)
        {
            Rozmiar = rozmiar;
            Perceptrony = perceptrony;
        }

        public List<double> DodajDoListy(List<double> wejscie)
        {
            List<double> lista = new List<double>();
            double tmp;

            for (int i = 0; i < Perceptrony.Length; i++)
            {
                tmp = Perceptrony[i].Wyjscie(wejscie);
                lista.Add(tmp);
            }
            return lista;
        }

        public List<double> LiczDelte(List<double> wejscie)
        {
            List<double> listaDelt = new List<double>();

            for (int i = 0; i < wejscie.Count; i++)
            {
                double tmp = Perceptrony[i].LiczDelte(wejscie[i]);
                listaDelt.Add(tmp);
            }
            return listaDelt;
        }

        public void DostosujWagi(List<double> wejscie)
        {
            for (int i = 0; i < Perceptrony.Length; i++)
            {
                Perceptrony[i].DostosujWagi(wejscie);
            }
        }
    }
}
