using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propagacja
{
    public class Wejscie
    {
        public double x { get; set; }
        public double y { get; set; }
        public double alfa { get; set; }
        public double beta { get; set; }

        public Wejscie(double x, double y, double alfa, double beta)
        {
            this.x = x;
            this.y = y;
            this.alfa = alfa;
            this.beta = beta;
        }

        public Wejscie() { }
    }
}
