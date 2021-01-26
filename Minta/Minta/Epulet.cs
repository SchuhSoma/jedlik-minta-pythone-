using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minta
{
    class Epulet
    {
        //név;város;ország;magasság;emelet;épült
        public string Nev;
        public string Varos;
        public string Orszag;
        public double Magassag;
        public int Emelet;
        public int EpulesEve;

        public Epulet (string sor)
        {
            var dbok = sor.Split(';');
            this.Nev = dbok[0];
            this.Varos = dbok[1];
            this.Orszag = dbok[2];
            this.Magassag = double.Parse(dbok[3]);
            this.Emelet = int.Parse(dbok[4]);
            this.EpulesEve = int.Parse(dbok[5]);
        }

    }
}
