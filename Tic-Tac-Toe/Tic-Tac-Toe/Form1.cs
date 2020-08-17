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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[,] TicTac = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
        Random r = new Random();
        int count = 0;
        bool win = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string x = ((PictureBox)sender).Tag.ToString();
            if (!win)
            {
                if (!comprobar(TicTac, x))
                {
                    switch (x)
                    {
                        case "1":
                            pictureBox7.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[2, 0] = "X";
                            count++;
                            break;
                        case "2":
                            pictureBox8.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[2, 1] = "X";
                            count++;
                            break;
                        case "3":
                            pictureBox9.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[2, 2] = "X";
                            count++;
                            break;
                        case "4":
                            pictureBox4.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[1, 0] = "X";
                            count++;
                            break;
                        case "5":
                            pictureBox5.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[1, 1] = "X";
                            count++;
                            break;
                        case "6":
                            pictureBox6.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[1, 2] = "X";
                            count++;
                            break;
                        case "7":
                            pictureBox1.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[0, 0] = "X";
                            count++;
                            break;
                        case "8":
                            pictureBox2.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[0, 1] = "X";
                            count++;
                            break;
                        case "9":
                            pictureBox3.BackgroundImage = Properties.Resources.cerrar;
                            TicTac[0, 2] = "X";
                            count++;
                            break;
                    }
                    //CheckWinnerX
                    if (checkWin("X"))
                    {
                        win = true;
                        count = 0;
                        Mensaje m = new Mensaje();
                        Mensaje.msj = "0";
                        Mensaje.winner += "Jugador 1";
                        m.ShowDialog();
                    }
                    if (count == 9 && !win)
                    {
                        Mensaje m = new Mensaje();
                        Mensaje.msj = "2";
                        m.ShowDialog();
                    }
                    else if (!win)
                    {
                        //Turno Inteligencia
                        int pos;
                        bool IA = false;
                        do
                        {
                            pos = r.Next(1, 10);
                            if (!comprobar(TicTac, pos.ToString()))
                            {
                                IA = true;
                                switch (pos.ToString())
                                {
                                    case "1":
                                        pictureBox7.BackgroundImage = Properties.Resources.punto;
                                        TicTac[2, 0] = "O";
                                        count++;
                                        break;
                                    case "2":
                                        pictureBox8.BackgroundImage = Properties.Resources.punto;
                                        TicTac[2, 1] = "O";
                                        count++;
                                        break;
                                    case "3":
                                        pictureBox9.BackgroundImage = Properties.Resources.punto;
                                        TicTac[2, 2] = "O";
                                        count++;
                                        break;
                                    case "4":
                                        pictureBox4.BackgroundImage = Properties.Resources.punto;
                                        TicTac[1, 0] = "O";
                                        count++;
                                        break;
                                    case "5":
                                        pictureBox5.BackgroundImage = Properties.Resources.punto;
                                        TicTac[1, 1] = "O";
                                        count++;
                                        break;
                                    case "6":
                                        pictureBox6.BackgroundImage = Properties.Resources.punto;
                                        TicTac[1, 2] = "O";
                                        count++;
                                        break;
                                    case "7":
                                        pictureBox1.BackgroundImage = Properties.Resources.punto;
                                        TicTac[0, 0] = "O";
                                        count++;
                                        break;
                                    case "8":
                                        pictureBox2.BackgroundImage = Properties.Resources.punto;
                                        TicTac[0, 1] = "O";
                                        count++;
                                        break;
                                    case "9":
                                        pictureBox3.BackgroundImage = Properties.Resources.punto;
                                        TicTac[0, 2] = "O";
                                        count++;
                                        break;
                                }
                            }
                        } while (!IA);
                        //CheckWinnerO
                        if (checkWin("O"))
                        {
                            win = true;
                            count = 0;
                            Mensaje m = new Mensaje();
                            Mensaje.winner += "IA";
                            Mensaje.msj = "3";
                            m.ShowDialog();
                        }
                    }
                }
                else
                {
                    Mensaje m = new Mensaje();
                    Mensaje.msj = "1";
                    m.ShowDialog();
                }
            }
        }
        bool checkWin(string symbol)
        {
            if (TicTac[0, 0] == symbol && TicTac[0, 1] == symbol && TicTac[0, 2] == symbol)
                return true;
            else if (TicTac[1, 0] == symbol && TicTac[1, 1] == symbol && TicTac[1, 2] == symbol)
                return true;
            else if (TicTac[2, 0] == symbol && TicTac[2, 1] == symbol && TicTac[2, 2] == symbol)
                return true;
            else if (TicTac[0, 0] == symbol && TicTac[1, 0] == symbol && TicTac[2, 0] == symbol)
                return true;
            else if (TicTac[0, 1] == symbol && TicTac[1, 1] == symbol && TicTac[2, 1] == symbol)
                return true;
            else if (TicTac[0, 2] == symbol && TicTac[1, 2] == symbol && TicTac[2, 2] == symbol)
                return true;
            else if (TicTac[0, 0] == symbol && TicTac[1, 1] == symbol && TicTac[2, 2] == symbol)
                return true;
            else if (TicTac[2, 0] == symbol && TicTac[1, 1] == symbol && TicTac[0, 2] == symbol)
                return true;
            else
                return false;
        }
        bool comprobar(string[,] gato, string posicion)
        {
            bool band = false;
            switch (posicion)
            {
                case "1":
                    if (gato[2, 0] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "2":
                    if (gato[2, 1] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "3":
                    if (gato[2, 2] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "4":
                    if (gato[1, 0] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "5":
                    if (gato[1, 1] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "6":
                    if (gato[1, 2] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "7":
                    if (gato[0, 0] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "8":
                    if (gato[0, 1] != "")
                        band = true;
                    else
                        band = false;
                    break;
                case "9":
                    if (gato[0, 2] != "")
                        band = true;
                    else
                        band = false;
                    break;
            }
            return band;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mensaje.winner = "El Ganador es: ";
            win = false;
            count = 0;
            r = new Random();
            for (int i = 0; i < TicTac.GetLength(0); i++)
                for (int j = 0; j < TicTac.GetLength(1); j++)
                    TicTac[i, j] = "";
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                    c.BackgroundImage = null;
            }
        }
    }
}
