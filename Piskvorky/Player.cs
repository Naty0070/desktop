using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piskvorky {
    public class Player {

        private string charakter;
        private string name;
        private int clicks;

        public Player(string charakter, string name) {
            this.Charakter = charakter;
            this.Name = name;
            this.Clicks = 0;
        }

        public string Name { get => name; set => name = value; }
        public string Charakter { get => charakter; set => charakter = value; }
        public int Clicks { get => clicks; set => clicks = value; }

        public int switch_Players(int cislo) {
            if (cislo==0) { return 1; } else return 0;
        }
    }
}
