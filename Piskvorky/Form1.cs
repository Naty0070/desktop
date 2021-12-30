using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piskvorky {
    public class Form1 : Form {
        private List<Player> players = new List<Player>();
        private Button[,] Buttons;
        private int startPosWidth;
        private int startPosHeight;
        private int width;
        private int height;
        private int cislo;
        private int vpole;
        private int pocKam;
        private int body;
        private int rada;
        private int sloupec;
        private DialogResult result;
        private MessageBoxButtons resume;

        public Form1(Player a, Player b, int vp, int pK) {
            Body = 0;
            Rada = 0;
            Sloupec = 0;
            vpole = vp;
            pocKam = pK;
            Buttons = new Button[vp, vp];
            StartPosWidth = 0;
            StartPosHeight = 0;
            Width1 = 50;
            Height1 = 50;
            Cislo = 0;
            Result = DialogResult.None;
            Resume = MessageBoxButtons.RetryCancel;
            a = new Player(a.Charakter, a.Name);
            b = new Player(b.Charakter, b.Name);
            Players.Add(a); Players.Add(b);
            int i, y;
            for (i = 0; i < vp; i++) {
                for (y = 0; y < vp; y++) {
                    this.Buttons[i, y] = new Button();
                    this.Buttons[i, y].Location = new System.Drawing.Point(StartPosWidth + (Width1 * y), StartPosHeight + (Height1 * i));
                    this.Buttons[i, y].Name = "picBox" + i + y;
                    this.Buttons[i, y].Size = new System.Drawing.Size(Width1, Height1);
                    this.Controls.Add(this.Buttons[i, y]);
                    this.Buttons[i, y].BackColor = Color.White;
                    this.Buttons[i, y].Click += new System.EventHandler(this.button_Click);

                }
            }
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(vp * Width1, vp * Height1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
            this.Name = "Form1";
            this.Text = "Piškvorky";
        }


        public List<Player> Players { get => players; set => players = value; }
        public Button[,] Buttons1 { get => Buttons; set => Buttons = value; }
        public int StartPosWidth { get => startPosWidth; set => startPosWidth = value; }
        public int StartPosHeight { get => startPosHeight; set => startPosHeight = value; }
        public int Width1 { get => width; set => width = value; }
        public int Height1 { get => height; set => height = value; }
        public DialogResult Result { get => result; set => result = value; }
        public MessageBoxButtons Resume { get => resume; set => resume = value; }
        public int Cislo { get => cislo; set => cislo = value; }
        public int Body { get => body; set => body = value; }
        public int Rada { get => rada; set => rada = value; }
        public int Sloupec { get => sloupec; set => sloupec = value; }

        private void button_Click(object sender, EventArgs e) {
            System.Drawing.Font f = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
            if (((Button)sender).Text == "") {
                ((Button)sender).Font = f;
                ((Button)sender).Text = Players[Cislo].Charakter;
                Players[Cislo].Clicks++;
                ((Button)sender).BackColor = Color.Violet;

                if (Players[Cislo].Clicks >= pocKam) {
                    FieldCheck1();
                    FieldCheck2();
                    Body = 0;
                    FieldCheck3();
                    Body = 0;
                    FieldCheck4();

                    if (Players[0].Clicks + Players[1].Clicks == vpole * vpole) {
                        Result = MessageBox.Show("Nikdo nevyhral, chcete restartovat hru?", "Nikdo nevyhral", Resume);
                        this.Close(); this.Dispose();
                    }
                }
                Cislo = Players[cislo].switch_Players(cislo);

            } else MessageBox.Show("Toto tlačítko je obsazené!");
        }

        private void Winner(int x) {
            Result = MessageBox.Show(("Vyhral hrac: " + Players[Cislo].Name + " se znakem: " + Players[Cislo].Charakter), "Vyhral/a", Resume);
            this.Close(); this.Dispose();
        }

        private void FieldCheck1() {
            for (Rada = 0; Rada <= vpole - 1; Rada++) {
                for (Sloupec = 0; Sloupec <= vpole - 2; Sloupec++) {
                    if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada, Sloupec + 1].Text == Players[Cislo].Charakter)) {
                        Body++; if (Body >= pocKam - 1) { Winner(Body); }
                    } else Body = 0;
                }
                Body = 0;
            }
        }
        private void FieldCheck2() {
            for (Sloupec = 0; Sloupec <= vpole - 1; Sloupec++) {
                for (Rada = 0; Rada <= vpole - 2; Rada++) {
                    if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada + 1, Sloupec].Text == Players[Cislo].Charakter)) {
                        body++; if (body >= pocKam - 1) { Winner(body); }
                    } else body = 0;
                }
                body = 0;
            }
        }
        private void FieldCheck3() {
            for (Rada = 0; Rada <= vpole - pocKam; Rada++) {
                for (Sloupec = 0; Sloupec <= vpole - pocKam; Sloupec++) {
                    if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada + 1, (Sloupec + 1)].Text == Players[Cislo].Charakter)) {
                        for (int i = 0; i < pocKam - 1; i++, Rada++, Sloupec++) {
                            if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada + 1, (Sloupec + 1)].Text == Players[Cislo].Charakter)) {
                                body++; if (body == pocKam - 1) Winner(body);
                            } else body = 0;
                        }
                    }

                }
            }
        }
        private void FieldCheck4() {
            for (Rada = 0; Rada <= vpole - pocKam; Rada++) {
                for (Sloupec = vpole - 1; Sloupec >=pocKam-1; Sloupec--) {
                    if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada + 1, (Sloupec - 1)].Text == Players[Cislo].Charakter)) {
                        for (int i = 0; i < pocKam - 1; i++, Rada++, Sloupec--) {
                            if ((Buttons1[Rada, Sloupec].Text == Players[Cislo].Charakter) && (Buttons1[Rada + 1, (Sloupec - 1)].Text == Players[Cislo].Charakter)) {
                                body++; if (body == pocKam - 1) Winner(body);
                            } else body = 0;
                        }
                    }
                }
            }
        }


    }

}






