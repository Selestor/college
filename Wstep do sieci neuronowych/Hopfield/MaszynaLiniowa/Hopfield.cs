using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaszynaLiniowa
{
    class Hopfield
    {
        public List<Perceptron> ListaPerceptronow
        {
            get;
            set;
        }

        public int IloscPerceptronow
        {
            get;
            set;
        }

        public Hopfield(int N)
        {
            IloscPerceptronow = N;
            ListaPerceptronow = new List<Perceptron>();

            for (int i = 0; i < IloscPerceptronow; i++)
            {
                Perceptron perc = new Perceptron();
                perc.Spin = 0;
                ListaPerceptronow.Add(perc);
            }
        }

        public void KorygujWagi(List<string[]> wejscie)
        {
            /*
            double[] konwerted = new double[1600];
            for (int k = 0; k < 1600; k++)
            {
                if (przyklad[k] == "0") konwerted[k] = 0;
                else konwerted[k] = 1;
            }
            */


            for (int i = 0; i < IloscPerceptronow; i++)
            {
                for (int j = 0; j < IloscPerceptronow; j++)
                {
                    foreach (string[] przyklad in wejscie)
                    {
                        if (i != j)
                        {
                            ListaPerceptronow[i].Wagi[j] += double.Parse(przyklad[i]) * double.Parse(przyklad[j]);
                            //ListaPerceptronow[i].Wagi[j] /= IloscPerceptronow;
                        }
                        ListaPerceptronow[i].Wagi[j] /= IloscPerceptronow;
                    }
                }
            }
        }

        public double[] Wyjscie(string[] pixels)
        {
            double[] wynik = new double[IloscPerceptronow];

            for (int i = 0; i < IloscPerceptronow; i++)
            {
                if (pixels[i] == "0") ListaPerceptronow[i].Spin = -1;
                else ListaPerceptronow[i].Spin = 1;
            }

            for (int i = 0; i < IloscPerceptronow; i++)
            {
                //int index = i % IloscPerceptronow;
                double suma = 0;
                for (int j = 0; j < IloscPerceptronow; j++)
                {
                    suma += ListaPerceptronow[j].Spin * ListaPerceptronow[i].Wagi[j];
                }
                if (suma >= 0)
                {
                    ListaPerceptronow[i].Spin = 1;
                }
                else
                {
                    ListaPerceptronow[i].Spin = -1;
                }
            }

            for (int i = 0; i < IloscPerceptronow; i++)
            {
                wynik[i] = ListaPerceptronow[i].Spin;
            }
            return wynik;
        }
    }
}
