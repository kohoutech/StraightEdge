/* ----------------------------------------------------------------------------
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

using StraightEdge.UI;

namespace StraightEdge.Widgets
{
    public class SEHorzRuler : UserControl
    {
        public SEEasel easel;
        public int startval;
        public int endval;
        public int minval;
        public int maxval;
        public Bitmap bmp;
        Font tickFont;

        public int orgPos;
        public int curpos;

        public SEHorzRuler(SEEasel _easel)
        {
            easel = _easel;
            minval = 0;
            startval = 0;
            endval = 500;
            maxval = 500;
            orgPos = 0;
            curpos = 0;
            this.DoubleBuffered = true;

            this.Size = new Size(maxval, 20);
            drawRuler();
        }

//- positioning ---------------------------------------------------------------

        public void setStart(int start)
        {
            startval = start;
            if (start < minval)
            {
                minval = ((start / 500) - 1) * 500;
                drawRuler();
                Invalidate();
            }
        }

        public void setLength(int len)
        {
            endval = startval + len;
            if (endval > maxval)
            {
                maxval = ((endval / 500) + 1) * 500;
                drawRuler();
                Invalidate();
            }
        }

        public void setOrigin(int org)
        {
            orgPos = org + (startval - minval);
            Invalidate();
        }

        public void setCursorPos(int pos)
        {
            curpos = pos;
            Invalidate();
        }

//- painting ------------------------------------------------------------------

        private void drawRuler()
        {
            if (bmp != null)
            {
                bmp.Dispose();
            }
            int len = maxval - minval;
            bmp = new Bitmap(len, this.Height);
            tickFont = new Font(FontFamily.GenericSansSerif, 7);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int tickval = minval;
            for (int tickpos = 0; tickpos < len; tickpos += 5, tickval += 5)
            {
                int tickHeight = (tickval % 50 == 0) ? 0 : (tickval % 10 == 0) ? 12 : 16;
                g.DrawLine(Pens.Black, tickpos, tickHeight, tickpos, 20);
                if (tickval % 50 == 0)
                {
                    g.DrawString(tickval.ToString(), tickFont, Brushes.Black, tickpos, -1);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle source = new Rectangle((orgPos), 0, this.Width, bmp.Height);
                Rectangle dest = new Rectangle(0,0,this.Width,20);
                g.DrawImage(bmp, dest, source, GraphicsUnit.Pixel);

                if (curpos < this.Width)
                {
                    g.DrawLine(Pens.Red, curpos - startval, 0, curpos - startval, 20);
                }
        }
    }
}
