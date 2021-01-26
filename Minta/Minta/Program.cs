using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//1 lépés

namespace Minta
{
    class Program
    {
        static List<Epulet> EpuletList;//2 lépés
        static void Main(string[] args)
        {
            Feladat1(); Console.WriteLine("\n---------------------------------\n");
            Feladat2(); Console.WriteLine("\n---------------------------------\n");
            Feladat3(); Console.WriteLine("\n---------------------------------\n");
            Console.ReadKey();

        }

        private static void Feladat3()
        {
            Console.WriteLine("3.Feladat: Európa legmagasabb épületei");
            EpuletList = new List<Epulet>();//3 lépés
            var sr = new StreamReader(@"legmagasabb.txt", Encoding.UTF8);
            int db =0;
            while(!sr.EndOfStream)
            {
                EpuletList.Add(new Epulet(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás, beolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás");
            }
            Console.WriteLine("\n------------------------------------------------------------------\n");
            Console.WriteLine("3.2 feladat: Épületek száma");
            Console.WriteLine("\tÉpületek száma: {0}", EpuletList.Count);
            Console.WriteLine("\n------------------------------------------------------------------\n");
            Console.WriteLine("3.3 feladat: Emeletek összege");
            int OsszEmelet = 0;
            for (int i = 0; i < EpuletList.Count; i++)
            {
                OsszEmelet += EpuletList[i].Emelet;
            }
            Console.WriteLine("\tAz emeletek összege: {0}", OsszEmelet);
            Console.WriteLine("\n------------------------------------------------------------------\n");
            Console.WriteLine("3.4 feladat: a legmagasabb épület adatai");
            double MaxMagassag = double.MinValue;
            string MaxNev = "";
            string MaxVaros = "";
            string MaxOrszag = "";
            int MaxEmelet = 0;
            int MaxEv = 0;
            for (int i = 0; i < EpuletList.Count; i++)
            {
                if(MaxMagassag<EpuletList[i].Magassag)
                {
                    MaxMagassag = EpuletList[i].Magassag;
                    MaxNev = EpuletList[i].Nev;
                    MaxVaros = EpuletList[i].Varos;
                    MaxOrszag= EpuletList[i].Orszag;
                    MaxEmelet = EpuletList[i].Emelet;
                    MaxEv = EpuletList[i].EpulesEve;
                }
            }
            Console.WriteLine("Név: {0}", MaxNev);
            Console.WriteLine("Város : {0}", MaxVaros);
            Console.WriteLine("Orszag : {0}", MaxOrszag);
            Console.WriteLine("Magasság: {0} m", MaxMagassag);
            Console.WriteLine("Emeletek száma : {0} ", MaxEmelet);
            Console.WriteLine("Építés éve: {0}", MaxEv);
            Console.WriteLine("\n------------------------------------------------------------------\n");
            Console.WriteLine("3.5 feladat: van-e olasz épület a listában");
            bool VanNincs = false;
            foreach (var e in EpuletList)
            {
                if(e.Orszag== "Olaszország")
                {
                    VanNincs = true;
                    break;
                }
            }
            if(VanNincs==true)
            {
                Console.WriteLine("\tVan olasz épület");
            }
            else
            {
                Console.WriteLine("\tNincs olasz épület");
            }

        }

        private static void Feladat2()
        {
            Console.WriteLine("2.Feladat: Szökőévek listázása");
            Console.Write("Kérem az egyik évszámot: ");
            int ElsoEvszam = int.Parse(Console.ReadLine());
            Console.Write("Kérem az egy másik évszámot: ");
            int MasodikEvszam = int.Parse(Console.ReadLine());
            int KezdoEv;
            int MegtettEvek = 0;
            if (ElsoEvszam>MasodikEvszam)
            {
                KezdoEv = MasodikEvszam;
                MegtettEvek = ElsoEvszam - MasodikEvszam;
            }
            else
            {
                KezdoEv = ElsoEvszam;
                MegtettEvek = MasodikEvszam-ElsoEvszam;
            }
            int Evek = 0;
            bool IgenNem = false;
            for (int i = 0; i <= MegtettEvek; i++)
            {
                Evek = KezdoEv + i;
                if(Evek%4==0 && Evek % 100 != 0 || Evek % 400 == 0)
                {
                    Console.Write("{0} ;", Evek);
                    IgenNem = true;
                }                
            }
            if(IgenNem==true)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Ebben a tartományban nincs szökőév");
            }    
            
        }

        private static void Feladat1()
        {
            Console.WriteLine("1.Feladat:Kisebb-nagyobb meghatározása ");
            Console.Write("Kérem adja meg az első számot: ");
            int ElsoSzam = int.Parse(Console.ReadLine());
            Console.Write("Kérem adja meg a második számot: ");
            int MasodikSzam = int.Parse(Console.ReadLine());
            if(ElsoSzam>MasodikSzam)
            {
                Console.WriteLine("A nagyobb szám {0}, a kisebb szám {1} ", ElsoSzam, MasodikSzam);
            }
            if(MasodikSzam>ElsoSzam)
            {
                Console.WriteLine("A nagyobb szám {0}, a kisebb szám {1} ",  MasodikSzam, ElsoSzam);
            }
            else
            {
                Console.WriteLine("A két szám egyenlő");
            }
        }
    }
}
