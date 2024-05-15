using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UygPaint
{
    public partial class Form1 : Form
    {
        int ts = 0;
        int[] xler = new int[4];
        int[] yler = new int[4];
        Pen varsayılanKalem = new Pen(Color.Black, 4);

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {



            Graphics cizimalanı = panel1.CreateGraphics();
            varsayılanKalem = new Pen(colorDialog1.Color, (float)numericUpDown1.Value);
            
            if (comboBox1.SelectedIndex == 0)
            {
                cizimalanı.DrawEllipse(varsayılanKalem, e.X, e.Y, 20, 20);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                xler[ts] = e.X;
                yler[ts] = e.Y;
                ts++;

                if (ts == 3)
                {

                    Graphics cizimalan = panel1.CreateGraphics();
                    cizimalan.DrawLine(varsayılanKalem, xler[0], yler[0], xler[1], yler[1]);
                    cizimalan.DrawLine(varsayılanKalem, xler[1], yler[1], xler[2], yler[2]);
                    cizimalan.DrawLine(varsayılanKalem, xler[2], yler[2], xler[0], yler[0]);
                    ts = 0;
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                cizimalanı.DrawRectangle(varsayılanKalem, e.X, e.Y, 10, 30);
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (comboBox1.SelectedIndex == 3 && e.Button == MouseButtons.Left)
            {
                Graphics cizimalanı = panel1.CreateGraphics();
                varsayılanKalem = new Pen(colorDialog1.Color, (float)numericUpDown1.Value);
                cizimalanı.DrawEllipse(varsayılanKalem, e.X, e.Y, 5, 5);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                varsayılanKalem.Color = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            varsayılanKalem.Width = (float)numericUpDown1.Value;
        }

     
    }
}
