using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    public class Apple {
        private int posx;
        private int posy;

        public Apple() {
            Random random = new Random();
            posx = random.Next(50, 550);
            posy = random.Next(50, 550);
        }

        public int GetPosx() { return posx; }
        public int GetPosY() { return posy; }
        public void ChangePos() {
            Random random = new Random();
            posx = random.Next(50, 550);
            posy = random.Next(50, 550);
        }
    }
}
