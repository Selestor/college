using System;
using System.Collections.Generic;
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

namespace MaszynaLiniowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int cols = 40;
        private int rows = 40;
        private string[] siatka_input = new string[40*40];
        private string[] siatka_output = new string[40 * 40];
        private Hopfield hopfield = new Hopfield(40*40);
        
        private List<string[]> lista_obrazkow = new List<string[]>();

        private string[] obrazek_pikachu;
        private string[] obrazek_sans;
        private string[] obrazek_artas;
        private string[] obrazek_twilight;
        private string[] obrazek_mario;

        public MainWindow()
        {
            InitializeComponent();
            
            GenerujSiatke(siatka);
            GenerujPixele(siatka, true);

            GenerujSiatke(siatka2);
            GenerujPixele(siatka2, false);

            WczytajObrazki();


            lista_obrazkow.Add(obrazek_sans);
            lista_obrazkow.Add(obrazek_mario);
            lista_obrazkow.Add(obrazek_artas);
            lista_obrazkow.Add(obrazek_pikachu);
            lista_obrazkow.Add(obrazek_twilight);


            Random ran = new Random();
            for (int i = 0; i < 40 * 40; i++)
            {
                for(int j = 0; j < 40 * 40; j++)
                    hopfield.ListaPerceptronow[i].Wagi[j] = ran.NextDouble();
                siatka_input[i] = "1";
                siatka_output[i] = "1";
            }

            hopfield.KorygujWagi(lista_obrazkow);
        }

        private void WczytajObrazki()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            obrazek_pikachu = File.ReadAllLines(path + @"\pikachu.txt");
            obrazek_mario = File.ReadAllLines(path + @"\mario.txt");
            obrazek_artas = File.ReadAllLines(path + @"\artas.txt");
            obrazek_sans = File.ReadAllLines(path + @"\sans.txt");
            obrazek_twilight = File.ReadAllLines(path + @"\twilight.txt");
        }

        private string NazwaPixela(int wiersz, int kolumna, bool isInput)
        {
            string name;
            string przedrostek;
            if (isInput) przedrostek = "i";
            else przedrostek = "o";
            if (wiersz < 10 && kolumna < 10) name = przedrostek + "0" + wiersz + "_0" + kolumna;
            else
            {
                if (wiersz < 10 && kolumna >= 10) name = przedrostek + "0" + wiersz + "_" + kolumna;
                else name = przedrostek + wiersz + "_0" + kolumna;
            }
            return name;
        }
        
        private void RedrawPixels(bool isInput)
        {
            Brush czarny = new SolidColorBrush(Colors.Black);
            Brush bialy = new SolidColorBrush(Colors.White);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    string name = NazwaPixela(row, column, isInput);
                    Rectangle a = FindChild<Rectangle>(Application.Current.MainWindow, name);
                    if (isInput)
                    {
                        if (siatka_input[row * 40 + column] == "1") a.Fill = czarny;
                        if (siatka_input[row * 40 + column] == "0") a.Fill = bialy;
                    }
                    else
                    {
                        if (siatka_output[row * 40 + column] == "1") a.Fill = czarny;
                        if (siatka_output[row * 40 + column] == "0") a.Fill = bialy;
                    }
                }
            }
        }

        private void GenerujSiatke(Grid siatka)
        {
            for (int column = 0; column < cols; column++)
            {
                ColumnDefinition c = new ColumnDefinition();
                c.Width = new GridLength(16);
                siatka.ColumnDefinitions.Add(c);
            }

            for (int row = 0; row < rows; row++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(16);
                siatka.RowDefinitions.Add(r);
            }
            
        }

        private void GenerujPixele(Grid siatka, bool czyKlik)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Rectangle field = new Rectangle();
                    Brush czarny = new SolidColorBrush(Colors.Black);
                    Brush bialy = new SolidColorBrush(Colors.White);
                    if (czyKlik) field.Name = NazwaPixela(row, column, true);
                    else field.Name = NazwaPixela(row, column, false);

                    field.VerticalAlignment = VerticalAlignment.Top;
                    field.HorizontalAlignment = HorizontalAlignment.Left;
                    field.Height = 15;
                    field.Width = 15;
                    field.Margin = new Thickness(-5);
                    if (czyKlik) field.MouseLeftButtonDown += klik;
                    field.Fill = czarny;

                    Grid.SetColumn(field, column);
                    Grid.SetRow(field, row);

                    siatka.Children.Add(field);
                }
            }
        }

        private void klik(object sender, MouseButtonEventArgs e)
        {
            Rectangle source = sender as Rectangle;
            Brush czarny = new SolidColorBrush(Colors.Black);
            Brush bialy = new SolidColorBrush(Colors.White);
            string nazwa = source.Name;
            int ktory_row = Int32.Parse(nazwa[1].ToString()) * 10 + Int32.Parse(nazwa[2].ToString());
            int ktory_col = Int32.Parse(nazwa[4].ToString()) * 10 + Int32.Parse(nazwa[5].ToString());
            int nr = ktory_col + ktory_row * 40;
            if (siatka_input[nr] == "0")
            {
                source.Fill = czarny;
                siatka_input[nr] = "1";
            }
            else
            {
                source.Fill = bialy;
                siatka_input[nr] = "0";
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName)
   where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }


        //wczytaj dany obrazek
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] readText = obrazek_pikachu;
            switch (((Button)sender).Name)
            {
                case "Mario":
                    readText = obrazek_mario;
                    break;
                case "Twilight":
                    readText = obrazek_twilight;
                    break;
                case "Artas":
                    readText = obrazek_artas;
                    break;
                case "Sans":
                    readText = obrazek_sans;
                    break;
                case "Pikachu":
                    readText = obrazek_pikachu;
                    break;
            }
            Brush czarny = new SolidColorBrush(Colors.Black);
            Brush bialy = new SolidColorBrush(Colors.White);
            for (int row = 0; row< 40; row++)
            {
                for (int column = 0; column < 40; column++)
                {
                    string name = NazwaPixela(row, column, true);
                    Rectangle a = FindChild<Rectangle>(Application.Current.MainWindow, name);

                    if (readText[row * 40 + column] == "1")
                    {
                        siatka_input[row * 40 + column] = "1";
                    }
                    if (readText[row * 40 + column] == "0")
                    {
                        siatka_input[row * 40 + column] = "0";
                    }
                }
            }
            RedrawPixels(true);
        }

        //zaszumienie
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random szansa = new Random();
            Brush czarny = new SolidColorBrush(Colors.Black);
            Brush bialy = new SolidColorBrush(Colors.White);
            for (int row = 0; row < 40; row++)
            {
                for (int column = 0; column < 40; column++)
                {
                    double b = szansa.NextDouble();
                    if (b < 0.1)
                    {
                        string name = NazwaPixela(row, column, true);
                        Rectangle a = FindChild<Rectangle>(Application.Current.MainWindow, name);
                        if (siatka_input[row * 40 + column] == "1")
                        {
                            siatka_input[row * 40 + column] = "0";
                        }
                        else
                        {
                            siatka_input[row * 40 + column] = "1";
                        }
                    }
                }
            }
            RedrawPixels(true);
        }

        private void Odgadnij_Button_Click(object sender, RoutedEventArgs e)
        {
            double[] wyjscie = hopfield.Wyjscie(siatka_input);
            for (int i = 0; i < 1600; i++)
            {
                string output;
                if (wyjscie[i] == -1) output = "0";
                else output = "1";
                siatka_output[i] = output;
            }
            RedrawPixels(false);
        }

        private void Podstaw_Button_Click(object sender, RoutedEventArgs e)
        {
            siatka_input = siatka_output;
            RedrawPixels(true);
            RedrawPixels(false);
        }
    }
}
