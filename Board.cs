using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋re
{
    class Board
    {
        private static readonly int OFF_SET = 75, NODE_RADIUS = 15, NODE_DISTRANCE = 75, NODE_COUNT = 9;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
        private static readonly Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];
        private Point lostPieceSeat = NO_MATCH_NODE;
        public Point LostPieceSeat { get { return lostPieceSeat; } }
        public Piece PlacePiece(int x, int y, PieceType nextPieceType)
        {
            Point NodeId = new Point(x, y);
            Point boring = GetSeat(x, y);
            //MessageBox.Show($"x={x}, y={y}");
            if (!CanBePlaced(boring.X, boring.Y))
                return null;
            if (pieces[NodeId.X, NodeId.Y] != null)
                return null;
            Point point = GetPointSeat(NodeId.X, NodeId.Y);
            lostPieceSeat = new Point(NodeId.X, NodeId.Y);
            if (nextPieceType == PieceType.BLACE)
            {
                pieces[NodeId.X, NodeId.Y] = new BlackPiece(point.X, point.Y);
                return new BlackPiece(point.X, point.Y);
            }
            else
            {
                pieces[NodeId.X, NodeId.Y] = new WhitePiece(point.X, point.Y);
                return new WhitePiece(point.X, point.Y);
            }
        }
        public Point GetSeat(int x, int y)
        {
            x = x * NODE_DISTRANCE + OFF_SET;
            y = y * NODE_DISTRANCE + OFF_SET;
            return new Point(x, y);
        }
        public Point GetPointSeat(int x, int y)
        {
            return new Point(x * NODE_DISTRANCE + OFF_SET, y * NODE_DISTRANCE + OFF_SET);
        }
        public bool CanBePlaced(int x, int y)
        {
            //int NodeIdX = FindTheCloseNode(x), NodeIdY = FindTheCloseNode(y);
            //找出最近節點(Node)
            Point nodeId = FindTheCloseNode(x, y);
            //如果沒有的話回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;
            //有的話檢查是否有棋子
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;
            return true;
        }
        public Point FindTheCloseNode(int x, int y)
        {
            if (FindTheCloseNode(x) == -1 || FindTheCloseNode(y) == -1)
            {
                return NO_MATCH_NODE;
            }
            return new Point(FindTheCloseNode(x), FindTheCloseNode(y));
        }
        private int FindTheCloseNode(int pos)
        {
            if (pos <= OFF_SET - NODE_RADIUS || pos >= 750 - OFF_SET + NODE_RADIUS)
                return -1;
            pos -= OFF_SET;
            int quotient = pos / NODE_DISTRANCE;
            int remainder = pos % NODE_DISTRANCE;
            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTRANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }
    }
}
