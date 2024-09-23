using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋re
{
    abstract class Piece : PictureBox
    {
        private static readonly int IMAGE_SIDELENGHT = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(IMAGE_SIDELENGHT, IMAGE_SIDELENGHT);
            this.Location = new Point(x - IMAGE_SIDELENGHT / 2, y - IMAGE_SIDELENGHT / 2);
        }
        public abstract PieceType GetPieceType();
    }
}
