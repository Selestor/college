using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Propagacja
{
    class Siec
    {
        Warstwa[] Warstwy { get; set; }
        int IloscPerceptronow { get; set; }
        List<List<Double>> Przyklady = new List<List<double>>();
        int iteracjeNauki = 1000000;

        public Siec(int iloscperc, Warstwa[] warstwy)
        {
            Warstwy = warstwy;
            IloscPerceptronow = iloscperc;
        }

        public void Ucz(List<Double[]> przyklady)
        {
            int r = 1;
            Random rand = new Random();

            for (int i = 0; i < iteracjeNauki; i++)
            {
                r = rand.Next(przyklady.Count - 1) + 0;
                Wejscie wejscie  = new Wejscie(przyklady[r][0], przyklady[r][1], przyklady[r][2], przyklady[r][3]);
                ForwardPass(wejscie);
                BackwardsPass(wejscie);
                DostosujWagi(wejscie);
            }
        }

        private void ForwardPass(Wejscie przyklad)
        {
            List<double> input = new List<double>();
            input.Add(przyklad.x);
            input.Add(przyklad.y);
            for (int i = 0; i < Warstwy.Length; i++)
            {
                input = Warstwy[i].DodajDoListy(input);
            }
        }

        private void BackwardsPass(Wejscie przyklad)
        {
            List<double> listDelta = new List<double>();
            List<double> listResult = new List<double>();
            listResult.Add(przyklad.alfa);
            listResult.Add(przyklad.beta);
            listDelta = Warstwy[Warstwy.Length - 1].LiczDelte(listResult);

            //warstwt
            for (int i = Warstwy.Length - 2; i >= 0; i--)
            {
                //perceptrony
                for (int j = 0; j < Warstwy[i].Perceptrony.Length; j++)
                {
                    //warstwa i+1
                    for (int k = 0; k < Warstwy[i + 1].Perceptrony.Length; k++)
                    {
                        Warstwy[i].Perceptrony[j].Delta += Warstwy[i + 1].Perceptrony[k].Delta * Warstwy[i + 1].Perceptrony[k].Wagi[j];
                    }
                    Warstwy[i].Perceptrony[j].Delta *= Warstwy[i].Perceptrony[j].Suma * (1 - Warstwy[i].Perceptrony[j].Suma);
                }
            }
        }

        private void DostosujWagi(Wejscie przyklad)
        {
            List<double> listaSum = new List<double>();
            listaSum.Add(przyklad.x);
            listaSum.Add(przyklad.y);

            for (int i = 0; i < Warstwy.Length; i++)
            {
                Warstwy[i].DostosujWagi(listaSum);
                listaSum.Clear();
                for (int j = 0; j < Warstwy[i].Perceptrony.Length; j++)
                {
                    listaSum.Add(Warstwy[i].Perceptrony[j].Suma);
                }
            }
        }

        public Wejscie CzytajWejscie(int x, int y)
        {
            double tx = ((double)x / 150) * 0.8 + 0.1;
            double ty = ((double)y / 300) * 0.8 + 0.1;

            Wejscie test = new Wejscie();
            test.x = tx;
            test.y = ty;

            ForwardPass(test);
            double alfa = Warstwy[Warstwy.Length - 1].Perceptrony[0].Suma;
            double beta = Warstwy[Warstwy.Length - 1].Perceptrony[1].Suma;

            alfa = (alfa - 0.1) / 0.8 * 180;
            beta = (beta - 0.1) / 0.8 * 180;
            test.alfa = alfa;
            test.beta = beta;
            return test;
        }

    }
}
