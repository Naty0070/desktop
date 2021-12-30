using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2 f2 = new Form2();
            Application.Run(f2);
            int velikost = f2.Velikost;
            int pocKam= f2.PocKam;
            string h1 = f2.H1;
            string h2 = f2.H2;

            if (h1 != "" && h2 != "" && pocKam<=velikost) {
                Player player1 = new Player("X", h1);
                Player player2 = new Player("O", h2);
                Form1 f1 = Play(player1, player2, velikost, pocKam);
                Application.Run(f1);
                while (f1.Result == DialogResult.Retry) {
                    f1 = Play(player1, player2, velikost, pocKam); Application.Run(f1);
                }
            }
        }

        public static Form1 Play(Player player1, Player player2, int velikost, int pocKam) {
            int t = DateTime.Now.Second;string s = "";
            if (t % 2 == 0) {
                s = "Hra zacina, jako prvni zacina: " + player2.Name+" se znakem "+player2.Charakter;
                MessageBox.Show(s);
                return new Form1(player2, player1, velikost, pocKam);
               
            } else {
                s = "Hra zacina, jako prvni zacina: " + player1.Name + " se znakem " + player1.Charakter;
                MessageBox.Show(s);
                return new Form1(player1, player2, velikost, pocKam);
            }
        }
    }
}
