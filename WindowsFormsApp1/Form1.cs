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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OglC.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, OglC.Width, OglC.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            //Настройка 2D ортогональной проекции
            if ((float)OglC.Width <= (float)OglC.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)OglC.Height / (float)OglC.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)OglC.Width / (float)OglC.Height, 0.0, 30.0);
            }
            Gl.glMatrixMode((Gl.GL_MODELVIEW));
            Gl.glLoadIdentity();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT); //очищаем буффер цвета
            Gl.glLoadIdentity(); //очищаем матрицу
            Gl.glColor3f(255, 0, 0); //цвет - красный

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(8, 7);
            Gl.glVertex2d(15, 27);
            Gl.glVertex2d(17, 27);
            Gl.glVertex2d(23, 7);
            Gl.glVertex2d(21, 7);
            Gl.glVertex2d(19, 14);
            Gl.glVertex2d(12.5, 14);
            Gl.glVertex2d(10, 7);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(13.2, 16);
            Gl.glVertex2d(16, 25);
            Gl.glVertex2d(18.5, 16);

            Gl.glEnd();
            /*Gl.glVertex2d(0, 0);

            if ((float)OglC.Width <= (float)OglC.Height)
            {
                Gl.glVertex2d(30.0f * (float)OglC.Height / (float)OglC.Width, 30);
            }
            else
            {
                Gl.glVertex2d(30.0f * (float)OglC.Width / (float)OglC.Height, 30);
            }

            Gl.glEnd();
*/
            Gl.glFlush();
            OglC.Invalidate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OglC_Load(object sender, EventArgs e)
        {

        }
    }
}
