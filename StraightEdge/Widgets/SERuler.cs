﻿/* ----------------------------------------------------------------------------
StraightEdge : a vector graphics editor
Copyright (C) 1998-2017  George E Greaney

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
----------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StraightEdge.Widgets
{
    public class SERuler : UserControl
    {
        public enum Direction
        {
            VERT,
            HORZ
        }

        Direction dir;

        public SERuler(Direction _dir)
        {
            dir = _dir;
            if (dir == Direction.HORZ)
            {
                this.Size = new Size(500, 20);
            }
            else
            {
                this.Size = new Size(20, 400);
            }
        }

        private void drawVertNumbers(Graphics g, Font font, int num, int ypos)
        {
            if (num == 0)
            {
                g.DrawString("0", font, Brushes.Black, 0, ypos);
                return;
            }

            int i = num;
            List<int> digits = new List<int>();
            while (i > 0)
            {
                digits.Add(i % 10);
                i /= 10;
            }

            for (i = digits.Count - 1; i >= 0; i--)
            {
                g.DrawString(digits[i].ToString(), font, Brushes.Black, 0, ypos);
                ypos += font.Height;
            }
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font tickFont = new Font(FontFamily.GenericSansSerif, 7);
            if (dir == Direction.HORZ)
            {
                for (int i = 0; i < this.Width - 20; i += 5)
                {
                    int tickHeight = (i % 50 == 0) ? 0 : (i % 10 == 0) ? 12 : 16;
                    int xpos = i + 20;
                    g.DrawLine(Pens.Black, xpos, tickHeight, xpos, 20);
                    if (i % 50 == 0)
                    {
                        g.DrawString(i.ToString(), tickFont, Brushes.Black, xpos, -1);
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.Height; i += 5)
                {
                    int tickWidth = (i % 50 == 0) ? 0 : (i % 10 == 0) ? 12 : 16;
                    int ypos = i;
                    g.DrawLine(Pens.Black, tickWidth, ypos, 20, ypos);
                    if (i % 50 == 0)
                    {
                        drawVertNumbers(g, tickFont, i, ypos);
                    }
                }
            }
        }
    }
}