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
            Padding = new Padding(5);
            Spacing = new Size(2,2);
            for (int i = 0; i < y; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < x; j++)
                {
                    row.Cells.Add(new Block { Size = new Size(20, 20), PosX = j, PosY = i });

                }
                row.Cells.Add(null);
                Rows.Add( row);
            }
            Rows.Add(null);

        }

        private int X;
        private int Y;
    }
}
