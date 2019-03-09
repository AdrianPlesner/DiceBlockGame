using System;
using Eto.Forms;
using Eto.Drawing;
using System.Collections.ObjectModel;
using System.Linq;

namespace DiceBlockGame
{
    public class Block : Drawable
    {
        public Block()
            : this("White")
        {

        }
        public Block(string color)
        {
            BackgroundColor = Color.Parse(color);
            MouseEnter += HoverOver;
            MouseLeave += HoverOff;


        }


        private void HoverOver(object Sender, EventArgs e)
        {

            this.BackgroundColor = Colors.Blue;
        }

        private void HoverOff(object Sender, EventArgs e)
        {
            this.BackgroundColor = Colors.White;
        }
    }
}
