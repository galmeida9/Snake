using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace Snake {
    public class Game {
        private MyForm window;
        private System.Timers.Timer timer;
        private int movement; // {0: up; 1: down; 2: left; 3: right}
        private Boolean playingGame;

        public Game(MyForm form) {
            window = form;
            timer = new System.Timers.Timer();
            movement = 3;
            timer.Interval = 100;
            timer.Elapsed += UpdateGame;
            timer.Start();
            playingGame = false;
        }

        public Boolean GetGameStatus() { return playingGame; }
        public void ChangeGameStatus() {
            if (playingGame) playingGame = false;
            else playingGame = true;
        }
        public void GameStop() { timer.Stop(); }

        public void UpdateMovement(int i) {
            if (i == 0 && movement != 1) movement = i;
            else if (i == 1 && movement != 0) movement = i;
            else if (i == 2 && movement != 3) movement = i;
            else if (i == 3 && movement != 2) movement = i;
        }
        private void UpdateGame(Object source, System.Timers.ElapsedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(move);
            MyPanel panel = window.GetPanel();
            panel.Invalidate();

            Snake snake = panel.GetSnake();

            if (VerifyHit(snake, panel.GetApple())) {
                snake.IncreaseSnake();
                panel.GetApple().ChangePos();
                if (movement == 0) {
                    snake.ChangePosX(snake.SnakeLength() - 1, snake.GetPosX(snake.SnakeLength() - 2) - 10);
                    snake.ChangePosY(snake.SnakeLength() - 1, snake.GetPosY(snake.SnakeLength() - 2));
                }
                if (movement == 1) {
                    snake.ChangePosX(snake.SnakeLength() - 1, snake.GetPosX(snake.SnakeLength() - 2) + 10);
                    snake.ChangePosY(snake.SnakeLength() - 1, snake.GetPosY(snake.SnakeLength() - 2));
                }
                if (movement == 2) {
                    snake.ChangePosX(snake.SnakeLength() - 1, snake.GetPosX(snake.SnakeLength() - 2));
                    snake.ChangePosY(snake.SnakeLength() - 1, snake.GetPosY(snake.SnakeLength() - 2) - 10);
                }
                if (movement == 3) {
                    snake.ChangePosX(snake.SnakeLength() - 1, snake.GetPosX(snake.SnakeLength() - 2));
                    snake.ChangePosY(snake.SnakeLength() - 1, snake.GetPosY(snake.SnakeLength() - 2) + 10);
                }
            }

            for (int i = snake.SnakeLength() - 1; i > 0; i--) {
                if (snake.GetPosX(i) == snake.GetPosX(0) && snake.GetPosY(i) == snake.GetPosY(0)) {
                    timer.Stop();
                    panel.Invalidate();
                    this.GameOver();
                }
                snake.ChangePosX(i, snake.GetPosX(i - 1));
                snake.ChangePosY(i, snake.GetPosY(i - 1));
            }
            if (movement == 0) { snake.DecreasePosY(0); }
            else if (movement == 1) { snake.IncreasePosY(0); }
            else if (movement == 2) { snake.DecreasePosX(0); }
            else { snake.IncreasePosX(0); }

            if (snake.GetPosX(0) == 600) { snake.ChangePosX(0, 0); }
            else if (snake.GetPosX(0) == 0) { snake.ChangePosX(0, 600); }
            else if (snake.GetPosY(0) == 600) { snake.ChangePosY(0, 0); }
            else if (snake.GetPosY(0) == 0) { snake.ChangePosY(0, 600); }
        }

        public Boolean VerifyHit(Snake snake, Apple apple) {
            if ((apple.GetPosx() - 10) <= snake.GetPosX(0) && snake.GetPosX(0) <= (apple.GetPosx() + 10) && (apple.GetPosY() - 10) <= snake.GetPosY(0) && snake.GetPosY(0) <= (apple.GetPosY() + 10)) return true;
            else return false;

        }

        public void GameOver() {
            MyPanel panel = window.GetPanel();
            Label label = window.GetLabel();
            panel.Invoke((MethodInvoker)delegate {
                panel.Dispose();
                panel = new MyPanel(0);
                window.Controls.Add(panel);
                label = new Label();
                label.ForeColor = Color.White;
                label.Size = new Size(400, 100);
                label.Location = new Point(180, 250);
                label.Font = new Font("Arial", 24, FontStyle.Bold);
                label.Text = "GAME OVER";
                label.AutoSize = false;
                panel.Controls.Add(label);
                window.ChangeLabel(label);
                window.ChangePanel(panel);
            });
            this.ChangeGameStatus();
        }
    }
}
