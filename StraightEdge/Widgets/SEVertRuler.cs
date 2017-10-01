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
    public class SEVertRuler : UserControl
    {
        const int MARGIN = 200;

        public SEEasel easel;
        public int startval;
        public int endval;
        public int minval;
        public int maxval;
        public Bitmap bmp;
        Font tickFont;

        public int curpos;
        public int orgPos;

        public SEVertRuler(SEEasel _easel, int len)
        {
            easel = _easel;
            minval = 0;
            startval = 0;
            endval = 500;
            maxval = 500;
            orgPos = 0;
            curpos = 0;
            this.DoubleBuffered = true;

            this.Size = new Size(20, maxval);
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

        private void drawVertNumbers(Graphics g, Font font, int num, int ypos)
        {
            if (num == 0)
            {
                g.DrawString("0", font, Brushes.Black, 0, ypos);
                return;
            }

            if (num < 0)
            {
                g.DrawString("-", font, Brushes.Black, 0, ypos);
                num *= -1;
                ypos += font.Height;
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

        private void drawRuler()
        {
            if (bmp != null)
            {
                bmp.Dispose();
            }
            int len = maxval - minval;
            bmp = new Bitmap(this.Width, len);
            tickFont = new Font(FontFamily.GenericSansSerif, 7);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            int tickval = minval;
            for (int tickpos = 0; tickpos < len; tickpos += 5, tickval += 5)
            {
                int tickWidth = (tickval % 50 == 0) ? 0 : (tickval % 10 == 0) ? 12 : 16;
                g.DrawLine(Pens.Black, tickWidth, tickpos, 20, tickpos);
                if (tickval % 50 == 0)
                {
                    drawVertNumbers(g, tickFont, tickval, tickpos);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle source = new Rectangle(0, orgPos, bmp.Width, this.Height);
                Rectangle dest = new Rectangle(0,0,20,this.Height);
                g.DrawImage(bmp, dest, source, GraphicsUnit.Pixel);

            if (curpos < this.Height)
                {
                    //g.DrawLine(Pens.Red, curpos + 20, 0, curpos + 20, 20);
                    g.DrawLine(Pens.Red, 0, curpos - startval, 20, curpos - startval);

                }
        }

    }
}
