using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake {
    public class MyPanel : Panel {

        private Snake snake;
        private Apple apple;
        private int drawApple;

        public MyPanel(int mode) {
            this.Size = new Size(600, 600);
            this.Paint += new PaintEventHandler(MyPanel_Paint);
            snake = new Snake();
            apple = new Apple();
            drawApple = mode;
        }

        public Snake GetSnake() { return snake; }
        public Apple GetApple() { return apple; }

        private void MyPanel_Paint(object sender, PaintEventArgs e) {
            int radius = 5;

            Pen myPen = new Pen(Color.Green, 5);
            SolidBrush myBrush = new SolidBrush(Color.Green);
            Graphics graphics = e.Graphics;

            for (int i = 0; i < snake.SnakeLength(); i++) {
                graphics.DrawEllipse(myPen, snake.GetPosX(i) - radius, snake.GetPosY(i) - radius, radius + radius, radius + radius);
                graphics.FillEllipse(myBrush, snake.GetPosX(i) - radius, snake.GetPosY(i) - radius, radius + radius, radius + radius);
            }

            myPen = new Pen(Color.Red, 5);
            myBrush = new SolidBrush(Color.Red);
            if (drawApple == 1) {
                graphics.DrawEllipse(myPen, apple.GetPosx() - radius, apple.GetPosY() - radius, radius + radius, radius + radius);
                graphics.FillEllipse(myBrush, apple.GetPosx() - radius, apple.GetPosY() - radius, radius + radius, radius + radius);
            }

            graphics.Dispose();
            myBrush.Dispose();
        }
    }
}
