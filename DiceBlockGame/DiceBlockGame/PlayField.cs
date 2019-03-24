using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiceBlockGame
{

    public class PlayField : TableLayout
    {
        public PlayField(int x, int y)
        {
            X = x;
            Y = y;
            Blocks = new Block[x,y];
            Padding = new Padding(5);
            Spacing = new Size(2,2);
            for (int i = 0; i < y; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < x; j++)
                {
                    Block block = new Block
                    {
                        Size = new Size(20, 20),
                        PosX = j,
                        PosY = i,
                        Color = Colors.White
                    };
                    row.Cells.Add(block);
                    Blocks[j, i] = block;
                    Blocks[j, i].MouseEnter += HoverOver;
                    Blocks[j, i].MouseLeave += HoverOff;
                    Blocks[j, i].MouseDown += Block_Click;

                }
                row.Cells.Add(null);
                Rows.Add( row);
            }
            Rows.Add(null);
        }

        public Color Hovercolor = Colors.Black;
        public int[] Dice = new int[2]; 

        private int X;
        private int Y;

        public bool TurnTaken = false;

        public Block[,] Blocks;

        private void HoverOver(object Sender, EventArgs e)
        {
            if (!TurnTaken)
            {
                Block ob = (Block)Sender;

                ReColor(ob, Dice[0], Dice[1], Hovercolor);
            }

        }

        private void HoverOff(object Sender, EventArgs e)
        {
            if (!TurnTaken)
            {
                Block ob = (Block)Sender;
                ReColor(ob, Dice[0], Dice[1], Colors.White);
            }
        }

        private void ReColor(Block block, int x, int y, Color newColor)
        {
            // Is box available on playfield
            bool canBox = block.PosX + x <= this.X && block.PosY + y <= this.Y;

            if (canBox)
            {
                bool noSelect = true;
                for (int i = 0; i<x; i++)
                {
                    for (int j = 0; j<y; j++)
                    {
                        if (Blocks[block.PosX + i, block.PosY + j].Selected)
                        {
                            noSelect = false;
                        }
                    }
                }
                if (noSelect)
                {
                    //Recolor blocks
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            Blocks[block.PosX + i, block.PosY + j].BackgroundColor = newColor;
                        }
                    }
                }
            }
        }

        private void Block_Click(object sender, MouseEventArgs e)
        {

        }

    }
}
