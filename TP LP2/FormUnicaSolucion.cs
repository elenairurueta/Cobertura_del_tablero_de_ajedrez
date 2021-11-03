﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LP2
{
    public partial class FormUnicaSolucion : Form
    {
        private PictureBox[,] tableroPiezas;
        private PictureBox[,] tableroAmenazas;
        bool Inicio;
        public FormUnicaSolucion()
        {
            InitializeComponent();
            tableroPiezas = new PictureBox[8, 8];
            tableroAmenazas = new PictureBox[8, 8];
            Inicio = true;
        }

        public string pctBoxNamePiezas = "pctBoxPiezas";
        public string pctBoxNameAmenazas = "pctBoxAmenazas";

        private void FormUnicaSolucion_Load(object sender, EventArgs e)
        {
            int x = 100;
            int y = 50;
            int pctBoxPiezas = 0;
            int pctBoxAmenazas = 0; 

            for (int j = 0; j < 8; j++)
            {
                pctBoxAmenazas++; pctBoxPiezas++;
                for (int i = 0; i < 8; i++)
                {
                    tableroPiezas[i, j] = new PictureBox(); tableroAmenazas[i, j] = new PictureBox();
                    tableroPiezas[i, j].Text = ""; tableroAmenazas[i, j].Text = "";
                    tableroPiezas[i, j].Name = string.Format("{0}{1}{2}", i, j, pctBoxNamePiezas); tableroAmenazas[i, j].Name = string.Format("{0}{1}{2}", i, j, pctBoxNameAmenazas);
                    tableroPiezas[i, j].Tag = pctBoxPiezas; tableroAmenazas[i, j].Tag = pctBoxAmenazas;
                    tableroPiezas[i, j].Location = new Point(x, y); tableroAmenazas[i, j].Location = new Point(x + 500, y);
                    tableroPiezas[i, j].Size = new Size(50, 50); tableroAmenazas[i, j].Size = new Size(50, 50);
                    tableroPiezas[i, j].BackColor = Convert.ToInt32(tableroPiezas[i, j].Tag) % 2 == 0 ? Color.White : Color.Black; tableroAmenazas[i, j].BackColor = Color.White;
                    this.Controls.Add(tableroPiezas[i, j]); this.Controls.Add(tableroAmenazas[i, j]);
                    x += 50;
                    pctBoxAmenazas++; pctBoxPiezas++;
                }
                y += 50;
                x = 100;
            }
        }
        public void setImagen(string imagen, Pos posicion, bool piezas = true)
        {
            Image newImage = Image.FromFile(imagen);
            if (piezas)
            {
                tableroPiezas[posicion.x, posicion.y].Image = newImage;
                tableroPiezas[posicion.x, posicion.y].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                tableroAmenazas[posicion.x, posicion.y].Image = newImage;
                tableroAmenazas[posicion.x, posicion.y].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        public Color getColor(Pos posicion)
        {
            if(tableroPiezas[posicion.x, posicion.y].BackColor == Color.White)
                return Color.White;
            else
                return Color.Black;
        }
        public void setBackgroundColor(Color color, Pos posicion)
        {
            tableroAmenazas[posicion.x, posicion.y].BackColor = color;
        }
        public void vaciarTableros()
        {
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    tableroPiezas[i, j].BackColor = Convert.ToInt32(tableroPiezas[i, j].Tag) % 2 == 0 ? Color.White : Color.Black;
                    tableroAmenazas[i, j].BackColor = Color.White;
                }
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if(Inicio)
                Global.listaPiezas[Global.piezasAgregadas++].colocarPieza();
            //TODO: cómo hacer para que espere a que se apriete el botón para mostrar otras soluciones??
        }
    }
}