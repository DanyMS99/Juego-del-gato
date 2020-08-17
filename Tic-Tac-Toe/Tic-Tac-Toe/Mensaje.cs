using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Mensaje : Form
    {
        public static string msj = "";
        public static string winner = "El Ganador es: ";
        public Mensaje()
        {
            InitializeComponent();
        }
        int tiempo = 0;
        private void Mensaje_Load(object sender, EventArgs e)
        {
            tiempo = 0;
            timer1.Start();
            switch (msj)
            {
                case "0":
                    this.BackColor = Color.FromArgb(116, 237, 116);
                    ocultarLabels();
                    lbl0.Text = winner;
                    lbl0.Visible = true;
                    break;
                case "1":
                    this.BackColor = Color.FromArgb(255, 57, 57);
                    ocultarLabels();
                    lbl1.Visible = true;
                    break;
                case "2":
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    ocultarLabels();
                    lbl2.Visible = true;
                    break;
                case "3":
                    this.BackColor = Color.FromArgb(116, 237, 116);
                    ocultarLabels();
                    lbl3.Text = winner;
                    lbl3.Visible = true;
                    break;
            }
        }
        void ocultarLabels()
        {
            lbl0.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            if (tiempo == 20)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
