﻿using System;
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
        {}

        public Block(string color)
        {
            BackgroundColor = Color.Parse(color);
            MouseEnter += HoverOver;
            MouseLeave += HoverOff;
        }

        public bool Selected { get; set; }
        public Color color = Colors.White;

        public int PosX;
        public int PosY;

        private void HoverOver(object Sender, EventArgs e)
        {
            if (!Selected)
            {
                this.BackgroundColor = Colors.Blue;
                
            }
        }

        private void HoverOff(object Sender, EventArgs e)
        {
            if (!Selected)
            {
                this.BackgroundColor = color;
            }
        }
    }
}
