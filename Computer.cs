using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋re
{
    class Computer
    {
        private static readonly int OFF_SET = 75, NODE_RADIUS = 15, NODE_DISTRANCE = 75, NODE_COUNT = 9;
        int[] inX = new int[4] { 1, 0, 1, 1 };
        int[] inY = new int[4] { 0, 1, 1, -1 };
        int[,] Score = new int[3, 6]{
                {0,0,0,0,0, 10000 },//防守2子
                {0,0,20,100,500,10000 },//防守1子
                {0,20,100,500,2500,10000 }//防守0子
            };
        Board board = new Board();
        private int GetScore(int x, int y, PieceType n_Type)
        {
            int re = 0;
            PieceType s_Type = board.GetPieceType(x, y);
            for (int i = 0; i < 4; i++)
            {
                int count = 1;
                int k = 0;
                for (int j = -1; j <= 1; j += 2)
                {
                    int dx = x + j * inX[i];
                    int dy = y + j * inY[i];
                    while (dx >= 0 && dx < NODE_COUNT && dy >= 0 && dy < NODE_COUNT)
                    {
                        if (board.GetPieceType(dx, dy) == n_Type && board.GetPieceType(dx, dy) != PieceType.NONE)
                        {
                            count++;
                        }
                        else
                        {
                            if (board.GetPieceType(dx, dy) == PieceType.NONE) k++; // 放外面會不會比較好????
                            break;
                        }
                        dx += j * inX[i];
                        dy += j * inY[i];
                    }
                }
                if (count >= 5)
                    count = 5;
                re += Score[k, count];
            }
            return re;
        }//end GetScore
        public Point AiChesser(PieceType Ai_Type)
        {
            //List<int> X = new List<int>();
            //List<int> Y = new List<int>();
            int maxX = -1, maxY = -1;
            int max = -100;
            //int c = 0;
            PieceType pe_Type;
            if (Ai_Type == PieceType.BLACE)
                pe_Type = PieceType.WHILE;
            else
                pe_Type = PieceType.BLACE;
            for (int i = 0; i < NODE_COUNT; i++)
            {
                for (int j = 0; j < NODE_COUNT; j++)
                {

                    if (board.GetPieceType(i, j) == PieceType.NONE)
                    {
                        int peScore = GetScore(i, j, pe_Type);
                        int AiScore = GetScore(i, j, Ai_Type);
                        int score = Math.Max(AiScore, peScore);
                        if (score > max)
                        {
                            maxX = i;
                            maxY = j;
                            max = score;
                        }
                    }
                }
            }
            return new Point(maxX, maxY);
        }
    }
}
