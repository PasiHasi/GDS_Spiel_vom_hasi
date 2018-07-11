using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private bool left;
        private bool right;
        private bool space;
        private int schusszaehler;
        private int zaehler;
        private int z2;

        List<PictureBox> schuss;
        List<PictureBox> gegner;

        public Form1()
        {
            InitializeComponent();
            schuss = new List<PictureBox>();
            zaehler = 0;
            schusszaehler = 0;
        }

        private void tick(object sender, EventArgs e)
        {
            if(left)
                pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);

            if(right)
                pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);

            if (space && schusszaehler <= 0)
            {
                schussHinzufuegen();
                schusszaehler = 10;
            }

            if (schusszaehler > 0)
                schusszaehler--;
               

            PictureBox rm = null;

            foreach (PictureBox pic in schuss)
            {
                pic.Location = new Point(pic.Location.X, pic.Location.Y - 4);

                if (pic.Location.Y < -100)
                    rm = pic;
            }

            schuss.Remove(rm);
            panel1.Controls.Remove(rm);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                left = true; ;
            if (e.KeyCode == Keys.Right)
                right = true;
            if (e.KeyCode == Keys.Space)
                space = true;
        }

        private void schussHinzufuegen()
        {
            schuss.Add(new PictureBox());
            zaehler = schuss.Count - 1;
            schuss.ElementAt(zaehler).Size = new Size(20, 20);
            schuss.ElementAt(zaehler).Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
            schuss.ElementAt(zaehler).BackColor = Color.Green;
            panel1.Controls.Add(schuss.ElementAt(zaehler));
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
                left = false;

            if (e.KeyCode == Keys.Right)
                right = false;

            if (e.KeyCode == Keys.Space)
                space = false;
        }
    }
}
