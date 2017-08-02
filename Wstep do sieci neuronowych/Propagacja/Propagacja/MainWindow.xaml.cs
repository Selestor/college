using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Propagacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double StalaUczaca = 0.1;
        Siec SiecNeuronowa;
        int DlugoscRamienia = 120;
        public List<double[]> ListaPrzykladow = new List<double[]>();
        Point Poczatek = new Point(250, 150);
        Point WW = new Point();

        public MainWindow()
        {
            InitializeComponent();
            StworzSiec();

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"test.jpg", UriKind.Relative));
            canvas.Background = ib;
        }

        public void GenerujPrzyklady()
        {
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                double[] przyklad = new double[4];
                double alfa = rand.NextDouble() * 180;
                double beta = rand.NextDouble() * 180;
                Point p = getPointXY(alfa, beta);
                /*
                while (p.X < 0)
                {
                    alfa = rand.NextDouble() * 180;
                    beta = rand.NextDouble() * 180;
                    p = getPointXY(alfa, beta);
                }
                */
                double x = (p.X / 150) * 0.8 + 0.1;
                double y = (p.Y / 300) * 0.8 + 0.1;
                alfa = ((alfa / 180.0) * 0.8 + 0.1);
                beta = ((beta / 180.0) * 0.8 + 0.1);
                przyklad[0] = x;
                przyklad[1] = y;
                przyklad[2] = alfa;
                przyklad[3] = beta;
                ListaPrzykladow.Add(przyklad);
            }
        }

        public void StworzSiec()
        {
            int[] siecNeuronowa = new int[] { 2 ,15,10, 2 };
            Random random = new Random();
            Warstwa[] warstwy = new Warstwa[siecNeuronowa.Length];
            Perceptron[] perceptronyWW = new Perceptron[siecNeuronowa[0]];


            //warstwa wejsciowa
            for (int i = 0; i < siecNeuronowa[0]; i++)
            {
                double[] wagi = new double[2];

                for (int j = 0; j < wagi.Length; j++)
                {
                    wagi[j] = random.NextDouble();
                }

                double wagaBiasu = random.NextDouble();
                Perceptron tmp = new Perceptron(wagi, wagaBiasu, StalaUczaca);
                perceptronyWW[i] = tmp;
            }
            Warstwa w0 = new Warstwa(siecNeuronowa[0], perceptronyWW);
            warstwy[0] = w0;

            //warstwy ukryte
            for (int i = 1; i < siecNeuronowa.Length; i++)
            {
                Perceptron[] perceptronyWU = new Perceptron[siecNeuronowa[i]];
                double wagaBiasu = random.NextDouble();

                // perceptrony warstwy ukrytej
                for (int j = 0; j < siecNeuronowa[i]; j++)
                {
                    double[] wagi = new double[siecNeuronowa[i - 1]];

                    // wagi perceptronu x z warstwy ulrytej
                    for(int k = 0; k < siecNeuronowa[i-1]; k++)
                    {
                        wagi[k] = random.NextDouble();
                    }
                    Perceptron tmp = new Perceptron(wagi, wagaBiasu, StalaUczaca);
                    perceptronyWU[j] = tmp;
                }
                Warstwa wn = new Warstwa(siecNeuronowa[i], perceptronyWU);
                warstwy[i] = wn;
            }

            SiecNeuronowa = new Siec(siecNeuronowa.Length, warstwy);
            GenerujPrzyklady();
            SiecNeuronowa.Ucz(ListaPrzykladow);
            //tu moglby sie pouczyc :<

        }

        private void Klik(object sender, MouseButtonEventArgs e)
        {
            canvas.Children.Clear();
            Wejscie wejscie = SiecNeuronowa.CzytajWejscie((int)e.GetPosition(this).X, (int)e.GetPosition(this).Y);
            Point p = Mouse.GetPosition(canvas);
            WW = p;
            Point reka1 = PunktZaczepu(wejscie.alfa);
            Point reka2 = getPointXY(wejscie.alfa, wejscie.beta);

            Line linia1 = new Line();
            Line linia2 = new Line();

            linia1.StrokeThickness = 10;
            linia1.Stroke = Brushes.Black;
            linia1.Visibility = Visibility.Visible;

            linia2.StrokeThickness = 10;
            linia2.Stroke = Brushes.Red;
            linia2.Visibility = Visibility.Visible;

            linia1.X1 = Poczatek.X;
            linia1.Y1 = Poczatek.Y;
            linia1.X2 = reka1.X;
            linia1.Y2 = reka1.Y;
            
            linia2.X1 = linia1.X2;
            linia2.Y1 = linia1.Y2;
            linia2.X2 = reka2.X;
            linia2.Y2 = reka2.Y;

            canvas.Children.Add(linia1);
            canvas.Children.Add(linia2);
        }

        public Point getPointXY(double alfa, double beta)
        {
            beta -= 180;
            Point firstArm = translateXY(new Point(Poczatek.X, Poczatek.Y - DlugoscRamienia), Poczatek, alfa);
            Point tempPoint = translateXY(new Point(Poczatek.X, Poczatek.Y - 2 * DlugoscRamienia), Poczatek, alfa);
            Point secondPoint = translateXY(new Point(tempPoint.X, tempPoint.Y), new Point(firstArm.X, firstArm.Y), beta);

            return secondPoint;
        }

        public Point PunktZaczepu(double alfa)
        {
            Point tmp = translateXY(new Point(Poczatek.X, Poczatek.Y - DlugoscRamienia), Poczatek, alfa);
            return tmp;
        }

        private Point translateXY(Point pointXY, Point pocz, double alfa)
        {
            double rad = alfa * (Math.PI / 180);
            double cosRadial = Math.Cos(rad);
            double sinRadial = Math.Sin(rad);

            int x = (int)(cosRadial * (pointXY.X - pocz.X) - sinRadial * (pointXY.Y - pocz.Y) + pocz.X);
            int y = (int)(sinRadial * (pointXY.X - pocz.X) + cosRadial * (pointXY.Y - pocz.Y) + pocz.Y);
            Point point = new Point(x, y);

            return point;
        }
    }
}
