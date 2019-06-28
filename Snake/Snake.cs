using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class Snake {
        private int[,] snake;

        public Snake() {
            snake = new int[2,2];
            snake[0, 0] = 300;
            snake[0, 1] = 300;
            snake[1, 0] = 290;
            snake[1, 1] = 300;
        }

        public int SnakeLength() { return snake.GetLength(0); }
        public int GetPosX(int i) { return snake[i, 0]; }
        public int GetPosY(int i) { return snake[i, 1]; }
        public void ChangePosX(int i, int value) { snake[i, 0] = value; }
        public void ChangePosY(int i, int value) { snake[i, 1] = value; }
        public void IncreasePosX(int i) { snake[i, 0]+= 10; }
        public void IncreasePosY(int i) { snake[i, 1]+= 10; }
        public void DecreasePosX(int i) { snake[i, 0]-= 10; }
        public void DecreasePosY(int i) { snake[i, 1]-= 10; }
        public void IncreaseSnake() {
            int[,] newSnake = new int[snake.GetLength(0) + 1, 2];
            Array.Copy(snake, newSnake, snake.GetLength(0));
            snake = newSnake;
        }
    }
}
