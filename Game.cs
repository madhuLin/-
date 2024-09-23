using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋re
{
    class Game
    {
        private static readonly Board board = new Board();
        private PieceType nextPieceType = PieceType.BLACE;
        public Piece PlacePiece(int x, int y)
        {
            Point point = board.FindTheCloseNode(x, y);
            Piece piece = board.PlacePiece(point.X, point.Y, nextPieceType);
            if (piece != null)
            {
                if (nextPieceType == PieceType.BLACE)
                    nextPieceType = PieceType.WHILE;
                else
                    nextPieceType = PieceType.BLACE;
                return piece;
            }
            return null;
        }
        public Piece PlacePieceAi()
        {
            Computer computer = new Computer();
            Point point = computer.AiChesser(nextPieceType);
            Piece piece = board.PlacePiece(point.X, point.Y, nextPieceType);
            if (piece != null)
            {
                if (nextPieceType == PieceType.BLACE)
                    nextPieceType = PieceType.WHILE;
                else
                    nextPieceType = PieceType.BLACE;
                return piece;
            }
            return null;
        }
        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x,y);
        }
        public PieceType CheckWinner()
        {
            Point point = board.LostPieceSeat;
            int[] deX = new int[] { 1, 0, 1, 1};
            int[] deY = new int[] { 0, 1, 1,-1};
            PieceType type = board.GetPieceType(point.X, point.Y);
            for (int i = 0; i < 4; i++ )
            {
                int count = 1;
                for (int j = -1; j <= 1; j += 2 )
                {
                    int indexX = point.X + deX[i] * j;
                    int indexY = point.Y + deY[i] * j;
                    while (count < 5)
                    {
                        if (indexX < 0 || indexX >= 9 || indexY < 0 || indexY >= 9 || board.GetPieceType(indexX, indexY) != type)
                            break;
                        count++;
                        indexX += deX[i] * j;
                        indexY += deY[i] * j;
                    }
                    if (count >= 5)
                        return type;
                }
            }
            return PieceType.NONE;
        }
    }
}
