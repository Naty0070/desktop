using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mala_Zkouska {
    public interface IPlocha {
        public double SdelPlochu();
    }
    public class Osoba : IPlocha {
        private int vek;
        private int vyska;
        private string pohlavi;

        public int Vek { get => vek; set => vek = value; }
        public int Vyska { get => vyska; set => vyska = value; }
        public string Pohlavi { get => pohlavi; set => pohlavi = value; }

        public Osoba(int vek, int vyska, string pohlavi) {
            this.Vek = vek;
            this.Vyska = vyska;
            this.Pohlavi = pohlavi;
        }

        public double SdelPlochu() {
            double vysledek = 0;
            if (Pohlavi == "zena") {
                vysledek = vyska * 2;
            } else {
                vysledek = vyska * 1.5;
            }

            return vysledek;
        }
    }
    public abstract class Zvire : IPlocha {
        private int vaha;

        protected Zvire(int vaha) {
            this.Vaha = vaha;
        }

        public int Vaha { get => vaha; set => vaha = value; }

        public virtual double SdelPlochu() {
            return 2 * vaha;
        }
    }
    public class Pes : Zvire, IPlocha {
        private int cena;

        public Pes(int cena, int vaha) : base(vaha) {
            this.Cena = cena;
        }
        public int Cena { get => cena; set => cena = value; }

        public override double SdelPlochu() {
            double vysledek = 0;
            vysledek = 2 * Vaha + (cena * 0.1);
            return vysledek;
        }

    }
    public class Dum : IPlocha {
        private int pocetOken;
        private int pudorys;

        public int PocetOken { get => pocetOken; set => pocetOken = value; }
        public int Pudorys { get => pudorys; set => pudorys = value; }

        public Dum(int pocetOken, int pudorys) {
            this.PocetOken = pocetOken;
            this.Pudorys = pudorys;
        }
        public double SdelPlochu() {
            return pudorys;
        }
    }
    public class Auto : IPlocha {
        private int delka;

        public Auto(int delka) {
            this.Delka = delka;
        }

        public int Delka { get => delka; set => delka = value; }

        public double SdelPlochu() {
            return delka * 2;
        }
    }

    public class Test {
        public static void Mainx(string[] args) {
            IPlocha[] pole = new IPlocha[4];
            pole[0] = new Dum(11, 1000);
            pole[1] = new Osoba(60, 150, "zena");
            pole[2] = new Pes(2000, 20);
            pole[3] = new Auto(200);

            double sum = 0;
            int i = 0;

            for (i = 0; i < pole.Length; i++) {
                sum += pole[i].SdelPlochu();
                Console.WriteLine($"{pole[i].GetType().Name} ma plochu {pole[i].SdelPlochu()} m2");
            }
            Console.WriteLine("Dohromady bude treba "+sum+" m2");
            Console.WriteLine("Dum ma pocet oken: " + ((Dum)pole[0]).PocetOken);
            List<IPlocha> plocha2 = new List<IPlocha>();
            plocha2.Add(new Dum(15, 2000));
            plocha2.Add(new Osoba(20, 180, "muz"));
            plocha2.Add(new Pes(2500, 30));
            plocha2.Add(new Auto(250));

            foreach (var x in plocha2) {
                Console.WriteLine($"{x.GetType().Name} ma plochu {x.SdelPlochu()}m2");
            }
        }


    }
}
