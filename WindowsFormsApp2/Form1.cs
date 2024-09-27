using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        double a = 1, b = 0, c = 0;

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glBegin(Gl.GL_TRIANGLES);

            Gl.glColor3d(a, b, c);
            Gl.glVertex2d(5.0, 5.0);

            Gl.glColor3d(c, a, b);  
            Gl.glVertex2d(25.0, 5.0);

            Gl.glColor3d(b, c, a);
            Gl.glVertex2d(5.0, 25.0);

            Gl.glEnd();

            Gl.glFlush();

            anT.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, anT.Width, anT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            //Настройка 2D ортогональной проекции
            if ((float)anT.Width <= (float)anT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Height / (float)anT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Width / (float)anT.Height, 0.0, 30.0);
            }
            Gl.glMatrixMode((Gl.GL_MODELVIEW));
            Gl.glLoadIdentity();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar1.Value / 1000.0;
            label4.Text = a.ToString();
        }


        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar2.Value / 1000.0;
            label5.Text = b.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar3.Value / 1000.0;
            label6.Text = c.ToString();
        }
    }
}
