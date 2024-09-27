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

namespace lab1
{
    public partial class Form1 : Form
    {

        double ScreenW, ScreenH;

        private float devX;
        private float devY;

        private float[,] GrapValuesArray;

        private int elements_count = 0;

        private bool not_calculate = true;

        private int pointPosition = 0;

        private float a_x = -10, a_y = 10, b_x = 0, b_y = 0, c_x = 10, c_y = 10;

        float lineX, lineY;

        bool MauseClick_flag = false;

        enum point
        {
            A,
            B,
            C
        }

        private point Point = point.A;

        float Mcoord_X = 0, Mcoord_Y = 0;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }


        private void AnT_MouseСlick(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Mouse Clicked at: X={e.X}, Y={e.Y}");

            if (!MauseClick_flag)
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                float eps = 3f;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);

                if (Math.Abs(lineX - (a_x + 15)) < eps && Math.Abs(lineY - (a_y + 15)) < eps)
                {
                    Point = point.A;
                    MauseClick_flag = true;
                    Console.WriteLine("A");
                }
                else if (Math.Abs(lineX - (b_x + 15)) < eps && Math.Abs(lineY - (b_y + 15)) < eps)
                {
                    Point = point.B;
                    MauseClick_flag = true;
                    Console.WriteLine("B");
                }
                else if (Math.Abs(lineX - (c_x + 15)) < eps && Math.Abs(lineY - (c_y + 15)) < eps)
                {
                    Point = point.C;
                    MauseClick_flag = true;
                    Console.WriteLine("C");
                }
            }
            else
            {
                Mcoord_X = e.X;
                Mcoord_Y = e.Y;

                lineX = devX * e.X;
                lineY = (float)(ScreenH - devY * e.Y);


                switch (Point)
                {
                    case point.A:
                        a_x = lineX - 15;
                        a_y = lineY - 15;
                        break;
                    case point.B:
                        b_x = lineX - 15;
                        b_y = lineY - 15;
                        break;
                    case point.C:
                        c_x = lineX - 15;
                        c_y = lineY - 15;
                        break;
                    default: break;
                }

                MauseClick_flag = false;
            }
            not_calculate = true;
        }


        private void PrintText2D(float x, float y, string text)
        {
            Gl.glRasterPos2f(x, y);

            foreach (char char_for_draw in text)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }
        }
        private void functionCalculation()
        {
            float x = 0, y = 0, t = 0.25f;

            GrapValuesArray = new float[1000, 2];

            elements_count = 0;

            for (t = 0; t <= 1; t += 0.01f)
            {
                x = (float)Math.Pow(1 - t, 2) * a_x + 2 * (1 - t) * t * b_x + (float)Math.Pow(t, 2) * c_x;

                y = (float)Math.Pow(1 - t, 2) * a_y + 2 * (1 - t) * t * b_y + (float)Math.Pow(t, 2) * c_y;

                
                GrapValuesArray[elements_count, 0] = x;
                GrapValuesArray[elements_count, 1] = y;
                elements_count++;
            }

            not_calculate = false;

        }


        private void DrawDiagram()
        {
            if (not_calculate)
            {
                functionCalculation();
            }

            Gl.glBegin(Gl.GL_LINE_STRIP); //вершины будут соединены линиями
            Gl.glVertex2d(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);

            for (int ax = 1; ax < elements_count; ax += 1)
            {
                Gl.glVertex2d(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }


            Gl.glEnd();

            Gl.glPointSize(5);
            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_POINTS);

            Gl.glVertex2d(a_x, a_y);
            Gl.glVertex2d(b_x, b_y);
            Gl.glVertex2d(c_x, c_y);

            Gl.glEnd();

            Gl.glPointSize(1);
        }

        private void AnT_Load(object sender, EventArgs e)
        {

        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);  //очистка буфера цвета
            Gl.glLoadIdentity(); //очищение текущей матрицы

            Gl.glColor3f(0, 0, 0); //установка черного цвета

            Gl.glPushMatrix(); //помещаем состояние матрицы в стек матриц

            Gl.glTranslated(15, 15, 0); //перемещение по осям x и y

            Gl.glBegin(Gl.GL_POINTS); //рисование по точкам

            //сетка
            for (int ax = -15; ax < 15; ax++)
            {
                for (int bx = -15; bx < 15; bx++)
                {
                    Gl.glVertex2d(ax, bx);
                }
            }

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES); 

            Gl.glVertex2d(0, -15);
            Gl.glVertex2d(0, 15);

            Gl.glVertex2d(-15, 0);
            Gl.glVertex2d(15, 0);

            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(0.1, 14.5);
            Gl.glVertex2d(0, 15);
            Gl.glVertex2d(-0.1, 14.5);

            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, 0.1);
            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(14.5, -0.1);

            Gl.glEnd();

            PrintText2D(15.5f, 0, "x");
            PrintText2D(0.5f, 14.5f, "y");


            DrawDiagram();

            Gl.glPopMatrix();
/*
            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f,
                "[ x: " + (devX * Mcoord_X - 15).ToString() + " ; y: " +
                ((float)ScreenH - devY * Mcoord_Y - 15).ToString() + "]");*/

            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2d(lineX, -15);
            Gl.glVertex2d(lineX, lineY);
            Gl.glVertex2d(-15, lineY);
            Gl.glVertex2d(lineX, lineY);

            Gl.glEnd();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pointPosition == elements_count - 1)
                pointPosition = 0;
            
            Draw();
            pointPosition++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 30.0;
                ScreenH = 30.0 * (float)AnT.Height / (float)AnT.Width;
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 30.0 * (float)AnT.Width / (float)AnT.Height; // отношение ширины на высоту
                ScreenH = 30.0;
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH); //найстойки двумерного просмотра
            }

            // сохранение коэффициентов, которые нам необходимы для перевода координат указателя в оконной системе в координаты, 
            // принятые в OpenGL сцене
            devX = (float)ScreenW / (float)AnT.Width; 
            devY = (float)ScreenH / (float)AnT.Height;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            timer1.Start(); //старт счетчика, отвечающего за визуализацию сцены
        }
    }
}
