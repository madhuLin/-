using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋re
{
    class WhitePiece:Piece
    {
        public WhitePiece(int x, int y) : base(x, y)
        {
            this.Image = Properties.Resources.white;
        }
        public override PieceType GetPieceType()
        {
            return PieceType.WHILE;
        }
    }
}
