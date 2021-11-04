using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get => width; private set => width = value; }
        public int Height { get => height; private set => height = value; }

        public void Draw()
        {
            DrawLine('*', '*');

            for (int i = 0; i < this.Height - 2; i++)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');
        }

        private void DrawLine(char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < Width - 2; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
