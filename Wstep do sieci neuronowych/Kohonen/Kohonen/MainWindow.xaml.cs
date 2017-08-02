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

namespace Kohonen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> listaPunktow = new List<Point>();
        Kohonena kohonen = new Kohonena();
        int ileNeuronow = 1;
        int iteracje = 10000000;
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void klikCanvas(object sender, MouseButtonEventArgs e)
        {
            //mojCanvas.Children.Clear();
            double iks = e.GetPosition(this).X;
            double igrek = e.GetPosition(this).Y;
            Point punkt = new Point();
            punkt.X = iks;
            punkt.Y = igrek;
            listaPunktow.Add(punkt);

            Line linia = new Line();
            linia.X1 = iks;
            linia.Y1 = igrek;
            linia.X2 = iks + 1;
            linia.Y2 = igrek + 1;
            linia.Visibility = Visibility.Visible;
            linia.StrokeThickness = 1;
            linia.Stroke = Brushes.Black;

            mojCanvas.Children.Add(linia);
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Kohonena kohonen = new Kohonena();
            kohonen.iteracje = iteracje;
            kohonen.ListaPunktow = listaPunktow;
            kohonen.Wagi = new List<Point>();
            ileNeuronow = listaPunktow.Count / 1;

            for (int i = 0; i < ileNeuronow; i++)
            {
                Point p = new Point(rand.Next(0, 400), rand.Next(0, 400));
                kohonen.Wagi.Add(p);
            }

            for (int i = 0; i < iteracje; i++)
            {
                kohonen.Ucz(i);
                if (i % 100 == 0)
                {
                    kohonenPolyline.Points.Clear();
                    RysujSiecKohonena(kohonen.Wagi);
                }
            }
        }

        public void LosujWagi()
        {
            for (int i = 0; i < ileNeuronow; i++)
            {
                Point waga = new Point();
                waga.X = rand.Next(0, 400);
                waga.Y = rand.Next(0, 400);

                kohonen.Wagi.Add(waga);
            }
        }

        Action EmptyDelegate = delegate () { };
        private void RysujSiecKohonena(List<Point> wagi)
        {
            PointCollection polygonPoints = new PointCollection();

            foreach (Point waga in wagi)
            {
                polygonPoints.Add(new System.Windows.Point(waga.X, waga.Y));
            }

            kohonenPolyline.StrokeThickness = 2;
            kohonenPolyline.Points = polygonPoints;
            UIElement uiElement = kohonenPolyline;
            uiElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
