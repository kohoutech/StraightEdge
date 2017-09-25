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

using StraightEdge;
using StraightEdge.Widgets;

namespace StraightEdge.UI
{
    public class SEEasel : UserControl
    {
        public SEWindow window;
        public SECanvas canvas;
        public SERuler vertRuler;
        public SERuler horzRuler;
        public VScrollBar vertScroller;
        public HScrollBar horzScroller;

        int cursorX;
        int cursorY;
        int canvasWidth;
        int canvasHeight;
        int easelOrgX;
        int easelOrgY;

        public SEEasel(SEWindow _window)
        {
            window = _window;
            canvas = new SECanvas(this);
            canvas.Dock = DockStyle.Fill;
            this.Controls.Add(canvas);

            canvasWidth = 640 * 2;
            canvasHeight = 480 * 2;
            easelOrgX = -300;
            easelOrgY = -250;

            vertScroller = new VScrollBar();
            vertScroller.Dock = DockStyle.Right;
            vertScroller.Minimum = 0;
            vertScroller.Maximum = canvasHeight;
            vertScroller.Scroll += new ScrollEventHandler(vertScroller_Scroll);
            this.Controls.Add(vertScroller);

            horzScroller = new HScrollBar();
            horzScroller.Dock = DockStyle.Bottom;
            horzScroller.Minimum = 0;
            horzScroller.Maximum = canvasWidth;
            horzScroller.Scroll += new ScrollEventHandler(horzScroller_Scroll);
            this.Controls.Add(horzScroller);

            vertRuler = new SERuler(SERuler.Direction.VERT);
            vertRuler.Dock = DockStyle.Left;
            this.Controls.Add(vertRuler);

            horzRuler = new SERuler(SERuler.Direction.HORZ);
            horzRuler.Dock = DockStyle.Top;
            this.Controls.Add(horzRuler);

            cursorX = 0;
            cursorY = 0;
        }

        void horzScroller_Scroll(object sender, ScrollEventArgs e)
        {
            int xpos = (e.NewValue + easelOrgX);
            horzRuler.setOrigin(xpos);
            canvas.graphic.setPosX(xpos * -1);
            canvas.Invalidate();
        }

        void vertScroller_Scroll(object sender, ScrollEventArgs e)
        {
            int ypos = (e.NewValue + easelOrgY);
            vertRuler.setOrigin(ypos);
            canvas.graphic.setPosY(ypos * -1);
            canvas.Invalidate();
        }

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);
        //    horzScroller.Size = new Size(horzScroller.Width - vertScroller.Width, horzScroller.Height);
        //}

        public void setCursorPos(int x, int y)
        {
            cursorX = x;
            cursorY = y;
            window.statusPanel.setCursorPos(cursorX, cursorY);
            //horzRuler.setCursorPos(cursorX);
            //vertRuler.setCursorPos(cursorY);
        }

        public void clearCursorPos()
        {
            window.statusPanel.clearCursorPos();
        }

    }
}
