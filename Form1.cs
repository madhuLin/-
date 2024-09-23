using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋re
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Board board = new Board();
        private static readonly Game game = new Game();
        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    Piece piece = game.PlacePiece(e.X, e.Y);
        //    if (piece != null)
        //        this.Controls.Add(piece);
        //    if (game.CheckWinner() != PieceType.NONE)
        //        MessageBox.Show($"勝利者為{game.CheckWinner()}");
        //}

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlacePiece(e.X, e.Y);
            if (piece != null)
                this.Controls.Add(piece);
            Piece pieceAi = game.PlacePieceAi();
            this.Controls.Add(pieceAi);
            if (game.CheckWinner() != PieceType.NONE)
                MessageBox.Show($"勝利者為{game.CheckWinner()}");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }


    }
}
