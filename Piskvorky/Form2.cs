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
    public class Form2 : Form {

        private Label lbH1;
        private Label lbH2;
        private Label lbVP;
        private Label lbVP2;
        private Label lbPK;
        private NumericUpDown numVP;
        private NumericUpDown numPK;
        private TextBox tbH1;
        private TextBox tbH2;
        private Button But;
        private int velikost;
        private int pocKam;
        private string h1;
        private string h2;


        public Form2() {
            this.Velikost = 0;
            this.PocKam = 0;
            this.H1 = "";
            this.H2 = "";
            // 
            // lbH1
            // 
            this.lbH1 = new Label();
            this.LbH1.Location = new System.Drawing.Point(26, 31);
            this.LbH1.Name = "lbH1";
            this.LbH1.Size = new System.Drawing.Size(80, 13);
            this.LbH1.TabIndex = 0;
            this.LbH1.Text = "Jméno hráče 1:";
            // 
            // lbH2
            // 
            this.lbH2 = new Label();
            this.LbH2.Location = new System.Drawing.Point(26, 59);
            this.LbH2.Name = "lbH2";
            this.LbH2.Size = new System.Drawing.Size(80, 13);
            this.LbH2.TabIndex = 1;
            this.LbH2.Text = "Jméno hráče 2:";
            // 
            // lbVP
            // 
            this.lbVP = new Label();
            this.LbVP.Location = new System.Drawing.Point(26, 88);
            this.LbVP.Name = "lbVP";
            this.LbVP.Size = new System.Drawing.Size(115, 13);
            this.LbVP.TabIndex = 2;
            this.LbVP.Text = "Velikost pole (max 20):";
            // 
            // lbVP2
            // 
            this.lbVP2 = new Label();
            this.LbVP2.Location = new System.Drawing.Point(270, 88);
            this.LbVP2.Name = "lbVP2";
            this.LbVP2.Size = new System.Drawing.Size(115, 13);
            this.LbVP2.TabIndex = 2;
            this.LbVP2.Text = "x3";
            // 
            // lbPK
            // 
            this.LbPK = new Label();
            this.LbPK.Location = new System.Drawing.Point(26, 117);
            this.LbPK.Name = "lbPK";
            this.LbPK.Size = new System.Drawing.Size(108, 13);
            this.LbPK.TabIndex = 3;
            this.LbPK.Text = "Zadej počet kamenů:";
            // 
            // numVP
            // 
            this.NumVP = new NumericUpDown();
            this.NumVP.Location = new System.Drawing.Point(150, 86);
            this.NumVP.Minimum = 3;
            this.numVP.Maximum = 20;
            this.NumVP.Name = "numVP";
            this.NumVP.Size = new System.Drawing.Size(120, 20);
            this.NumVP.TabIndex = 4;
            this.NumVP.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.NumVP.ValueChanged += new System.EventHandler(this.numVP_ValueChange);

            // 
            // numPK
            // 
            this.NumPK = new NumericUpDown();
            this.NumPK.Location = new System.Drawing.Point(150, 117);
            this.NumPK.Minimum = 3;
            this.numPK.Maximum = 20;
            this.NumPK.Name = "numPK";
            this.NumPK.Size = new System.Drawing.Size(120, 20);
            this.NumPK.TabIndex = 5;
            this.NumPK.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // tbH1
            // 
            this.TbH1 = new TextBox();
            this.TbH1.Location = new System.Drawing.Point(150, 28);
            this.TbH1.Name = "tbH1";
            this.TbH1.Size = new System.Drawing.Size(120, 20);
            this.TbH1.TabIndex = 6;
            // 
            // tbH2
            // 
            this.TbH2 = new TextBox();
            this.TbH2.Location = new System.Drawing.Point(150, 56);
            this.TbH2.Name = "tbH2";
            this.TbH2.Size = new System.Drawing.Size(120, 20);
            this.TbH2.TabIndex = 7;
            // 
            // But
            // 
            this.But = new Button();
            this.But.Location = new System.Drawing.Point(210, 150);
            this.But.Name = "but";
            this.But.Size = new System.Drawing.Size(60, 20);
            this.But.TabIndex = 8;
            this.But.Text = "OK";
            this.But.Click += new System.EventHandler(this.but_Click);

            // 
            // form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 184);
            this.Controls.Add(this.TbH2);
            this.Controls.Add(this.TbH1);
            this.Controls.Add(this.NumPK);
            this.Controls.Add(this.NumVP);
            this.Controls.Add(this.LbPK);
            this.Controls.Add(this.LbVP);
            this.Controls.Add(this.LbVP2);
            this.Controls.Add(this.LbH2);
            this.Controls.Add(this.LbH1);
            this.Controls.Add(this.But);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.CenterToScreen();
            this.Text = "Piškvorky - menu";

        }

        public Label LbH1 { get => lbH1; set => lbH1 = value; }
        public Label LbH2 { get => lbH2; set => lbH2 = value; }
        public Label LbVP { get => lbVP; set => lbVP = value; }
        public Label LbVP2 { get => lbVP2; set => lbVP2 = value; }
        public Label LbPK { get => lbPK; set => lbPK = value; }
        public NumericUpDown NumVP { get => numVP; set => numVP = value; }
        public NumericUpDown NumPK { get => numPK; set => numPK = value; }
        public TextBox TbH1 { get => tbH1; set => tbH1 = value; }
        public TextBox TbH2 { get => tbH2; set => tbH2 = value; }
        public int Velikost { get => velikost; set => velikost = value; }
        public int PocKam { get => pocKam; set => pocKam = value; }
        public string H1 { get => h1; set => h1 = value; }
        public string H2 { get => h2; set => h2 = value; }

        private void but_Click(object sender, EventArgs e) {
            Velikost = (int)this.NumVP.Value;
            PocKam = (int)this.NumPK.Value;
            H1 = this.TbH1.Text;
            H2 = this.TbH2.Text;
            if (H1 == "" || H2 == "") {
                MessageBox.Show("Špatně vyplněné jméno!");
            } else if (PocKam > Velikost) {
                MessageBox.Show("Počet kamenů nesmí být vetší než velikost pole!");
            } else
                this.Close();
        }
        private void numVP_ValueChange(object sender, EventArgs e) {
            this.lbVP2.Text ="x"+this.numVP.Value.ToString();
        }
    }
}
