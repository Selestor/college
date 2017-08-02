using System;
using System.Collections.Generic;
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

namespace Perceptron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[] siatka_input = new double[36];
        private Class_Perceptron p0 = new Class_Perceptron();
        private Class_Perceptron p1 = new Class_Perceptron();
        private Class_Perceptron p2 = new Class_Perceptron();
        private Class_Perceptron p3 = new Class_Perceptron();
        private Class_Perceptron p4 = new Class_Perceptron();
        private Class_Perceptron p5 = new Class_Perceptron();
        private Class_Perceptron p6 = new Class_Perceptron();
        private Class_Perceptron p7 = new Class_Perceptron();
        private Class_Perceptron p8 = new Class_Perceptron();
        private Class_Perceptron p9 = new Class_Perceptron();

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

        public MainWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            Random ran = new Random();
            for (int i = 0; i < 35; i++)
                siatka_input[i] = 0.0;

            p0.Cyfra = 0; 
            double[] przykl = new double[71] { 0, 0, 0, 0, 0, 
                                               0, 1, 1, 1, 0,
                                               0, 1, 0, 1, 0,
                                               0, 1, 0, 1, 0,
                                               0, 1, 0, 1, 0,
                                               0, 1, 1, 1, 0,
                                               0, 0, 0, 0, 0,

                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0,

                                               1};
            double[] tablica_dft = new double[35];
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i-35];
            p0.ListaUczaca.Add(przykl);
           
            p1.Cyfra = 1;
            przykl = new double[71] { 0, 0, 0, 0, 0,
                                      0, 0, 1, 0, 0,
                                      0, 0, 1, 0, 0,
                                      0, 0, 1, 0, 0,
                                      0, 0, 1, 0, 0,
                                      0, 0, 1, 0, 0,
                                      0, 0, 0, 0, 0,

                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0,

                                      1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p1.ListaUczaca.Add(przykl);
           
            p2.Cyfra = 2;
            przykl = new double[71] {    0, 0, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p2.ListaUczaca.Add(przykl);
            
            p3.Cyfra = 3;
            przykl = new double[71] {    0, 0, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p3.ListaUczaca.Add(przykl);

            p4.Cyfra = 4;
            przykl = new double[71] {    0, 0, 0, 0, 0, 
                                         0, 1, 0, 1, 0,
                                         0, 1, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p4.ListaUczaca.Add(przykl); 

            p5.Cyfra = 5;
            przykl = new double[71] {    0, 0, 0, 0, 0, 
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p5.ListaUczaca.Add(przykl);

            p6.Cyfra = 6;
            przykl = new double[71] {    0, 0, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 0, 0,
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p6.ListaUczaca.Add(przykl); 

            p7.Cyfra = 7;
            przykl = new double[71] {    0, 0, 0, 0, 0, 
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p7.ListaUczaca.Add(przykl);

            p8.Cyfra = 8;
            przykl = new double[71] {    0, 0, 0, 0, 0, 
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p8.ListaUczaca.Add(przykl); 

            p9.Cyfra = 9;
            przykl = new double[71] {    0, 0, 0, 0, 0, 
                                         0, 1, 1, 1, 0,
                                         0, 1, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 1, 0,
                                         0, 1, 1, 1, 0,
                                         0, 0, 0, 0, 0,

                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,
                                         0, 0, 0, 0, 0,

                                         1};
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = przykl[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                przykl[i] = tablica_dft[i - 35];
            p9.ListaUczaca.Add(przykl); 

            for (int i = 0; i < 70; i++)
            {
                double a = 100.0;
                double b = 0.005;
                p0.Wagi[i] = (ran.NextDouble() / a) - b;
                p1.Wagi[i] = (ran.NextDouble() / a) - b;
                p2.Wagi[i] = (ran.NextDouble() / a) - b;
                p3.Wagi[i] = (ran.NextDouble() / a) - b;
                p4.Wagi[i] = (ran.NextDouble() / a) - b;
                p5.Wagi[i] = (ran.NextDouble() / a) - b;
                p6.Wagi[i] = (ran.NextDouble() / a) - b;
                p7.Wagi[i] = (ran.NextDouble() / a) - b;
                p8.Wagi[i] = (ran.NextDouble() / a) - b;
                p9.Wagi[i] = (ran.NextDouble() / a) - b;
            }
            p0.Koryguj_Wagi(p0.ListaUczaca);
            p1.Koryguj_Wagi(p1.ListaUczaca);
            p2.Koryguj_Wagi(p2.ListaUczaca);
            p3.Koryguj_Wagi(p3.ListaUczaca);
            p4.Koryguj_Wagi(p4.ListaUczaca);
            p5.Koryguj_Wagi(p5.ListaUczaca);
            p6.Koryguj_Wagi(p6.ListaUczaca);
            p7.Koryguj_Wagi(p7.ListaUczaca);
            p8.Koryguj_Wagi(p8.ListaUczaca);
            p9.Koryguj_Wagi(p9.ListaUczaca);
        }

        private void klik(object sender, MouseButtonEventArgs e)
        {
            Rectangle source = sender as Rectangle;
            Brush czarny = new SolidColorBrush(Colors.Black);
            Brush bialy = new SolidColorBrush(Colors.Transparent);
            string nazwa = source.Name;
            string dziesiatki = nazwa[3].ToString();
            string jednosci = nazwa[4].ToString();
            int nr = (Int32.Parse(dziesiatki)) * 10 + Int32.Parse(jednosci);
            if (siatka_input[nr] == 0)
            {
                source.Fill = czarny;
                siatka_input[nr] = 1;
            }
            else
            {
                source.Fill = bialy;
                siatka_input[nr] = 0;
            }
        }

        private void Button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Random szansa = new Random();
            int do_ktorego = Int32.Parse(comboBox.Text);
            double ostatni;
            if (correct.IsChecked == true) ostatni = 1.0;
            else ostatni = -1.0;
            //siatka_input[35] = ostatni;
            double[] kopia = new Double[71];
            siatka_input.CopyTo(kopia,0);

            double[] tablica_dft = new double[35];
            for (int i = 0; i < 35; i++)
                tablica_dft[i] = kopia[i];
            tablica_dft = dft(tablica_dft);
            for (int i = 35; i < 70; i++)
                kopia[i] = tablica_dft[i - 35];

            kopia[71] = ostatni;

            for (int i =0; i < 35; i++)
            {
                if(szansa.NextDouble() < 0.1)
                {
                    if (kopia[i] == 1) kopia[i] = 0;
                    else kopia[i] = 1;
                }
            }
            switch (do_ktorego)
            {
                case 0:
                    p0.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 0");
                    break;
                case 1:
                    p1.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 1");
                    break;
                case 2:
                    p2.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 2");
                    break;
                case 3:
                    p3.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 3");
                    break;
                case 4:
                    p4.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 4");
                    break;
                case 5:
                    p5.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 5");
                    break;
                case 6:
                    p6.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 6");
                    break;
                case 7:
                    p7.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 7");
                    break;
                case 8:
                    p8.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 8");
                    break;
                case 9:
                    p9.ListaUczaca.Add(kopia);
                    MessageBox.Show("Dodano nowy przyklad do zbioru uczacego 9");
                    break;
            }
        }

        private void Button_Ucz_Click(object sender, RoutedEventArgs e)
        {
            int do_ktorego = Int32.Parse(comboBox.Text);
            switch (do_ktorego)
            {
                case 0:
                    p0.Koryguj_Wagi(p0.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 0");
                    break;
                case 1:
                    p1.Koryguj_Wagi(p1.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 1");
                    break;
                case 2:
                    p2.Koryguj_Wagi(p2.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 2");
                    break;
                case 3:
                    p3.Koryguj_Wagi(p3.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 3");
                    break;
                case 4:
                    p4.Koryguj_Wagi(p4.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 4");
                    break;
                case 5:
                    p5.Koryguj_Wagi(p5.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 5");
                    break;
                case 6:
                    p6.Koryguj_Wagi(p6.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 6");
                    break;
                case 7:
                    p7.Koryguj_Wagi(p7.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 7");
                    break;
                case 8:
                    p8.Koryguj_Wagi(p8.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 8");
                    break;
                case 9:
                    p9.Koryguj_Wagi(p9.ListaUczaca);
                    MessageBox.Show("Zaktualizowano wagi dla 9");
                    break;
            }
        }

        private void Button_Przewiduj_Click(object sender, RoutedEventArgs e)
        {
            List<double> klasyfikacja = new List<double>();
            /*if (p0.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p0.Cyfra);
            if (p1.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p1.Cyfra);
            if (p2.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p2.Cyfra);
            if (p3.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p3.Cyfra);
            if (p4.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p4.Cyfra);
            if (p5.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p5.Cyfra);
            if (p6.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p6.Cyfra);
            if (p7.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p7.Cyfra);
            if (p8.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p8.Cyfra);
            if (p9.Przypisz_Kategorie(siatka_input)) klasyfikacja.Add(p9.Cyfra);*/
            klasyfikacja.Add(p0.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p1.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p2.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p3.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p4.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p5.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p6.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p7.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p8.Przypisz_Kategorie(siatka_input));
            klasyfikacja.Add(p9.Przypisz_Kategorie(siatka_input));
            double max = 0;
            int counter = 0;
            int max_counter = 0;
            foreach ( Double element in klasyfikacja)
            {
                if (element > max)
                {
                    max = element;
                    max_counter = counter;
                }
                counter++;
            }
            var message = string.Join(Environment.NewLine, max_counter);
            MessageBox.Show(message);
        }


    }
}
