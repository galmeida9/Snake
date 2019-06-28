using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Snake {
    public class MyForm : System.Windows.Forms.Form {
        private MyPanel panel;
        private Label label;
        private Game game;

        public MyForm(){
            this.Size = new Size(600, 600);
            this.BackColor = Color.Black;
            this.Text = "Snake";
            panel = new MyPanel(0);
            this.Controls.Add(panel);
            label = new Label();
            label.ForeColor = Color.White;
            label.Size = new Size(400, 100);
            label.Location = new Point(130, 250);
            label.Font = new Font("Arial", 24, FontStyle.Bold);
            label.Text = "Press Enter to Start";
            label.AutoSize = false;
            panel.Controls.Add(label);
            this.KeyDown += new KeyEventHandler(this.MyForm_KeyDown);
            CenterToScreen();
            game = new Game(this);
        }

        public MyPanel GetPanel() { return panel; }
        public Label GetLabel() { return label; }
        public void ChangeLabelText(string txt) {
            label.Text = txt;
        }
        public void ChangePanel(MyPanel pan) { panel = pan; }
        public void ChangeLabel(Label lbl) { label = lbl; }

        private void MyForm_KeyDown(object sender, KeyEventArgs e) {
            if ((e.KeyCode == Keys.Enter) && !(game.GetGameStatus())) {
                label.Dispose();
                panel.Dispose();
                panel = new MyPanel(1);
                this.Controls.Add(panel);
                game.GameStop();
                game = new Game(this);
                game.ChangeGameStatus();
            }
            else if (e.KeyCode == Keys.Up) {
                game.UpdateMovement(0);
            }
            else if (e.KeyCode == Keys.Down) {
                game.UpdateMovement(1);
            }
            else if (e.KeyCode == Keys.Left) {
                game.UpdateMovement(2);
            }
            else if (e.KeyCode == Keys.Right) {
                game.UpdateMovement(3);
            }
        }
    }
}
