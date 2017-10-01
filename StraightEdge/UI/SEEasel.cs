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
        const int FRAMEWIDTH = 20;

        public SEWindow window;
        public SECanvas canvas;
        public SEVertRuler vertRuler;
        public SEHorzRuler horzRuler;
        public VScrollBar vertScroller;
        public HScrollBar horzScroller;

        int cursorX;
        int cursorY;
        int canvasWidth;
        int canvasHeight;
        int easelOrgX;
        int easelOrgY;
        int expos;
        int eypos;

        public SEEasel(SEWindow _window)
        {
            window = _window;
            BackColor = Color.BlueViolet;
            this.DoubleBuffered = true;

            canvas = new SECanvas(this);
            canvas.Location = new Point(FRAMEWIDTH, FRAMEWIDTH);
            this.Controls.Add(canvas);

            canvasWidth = canvas.minWidth;
            canvasHeight = canvas.minHeight;
            easelOrgX = canvas.HORZMARGIN * -1;
            easelOrgY = canvas.VERTMARGIN * -1;
            expos = 0;
            eypos = 0;

            horzRuler = new SEHorzRuler(this);
            horzRuler.Location = new Point(FRAMEWIDTH, 0);
            this.Controls.Add(horzRuler);

            vertRuler = new SEVertRuler(this, canvas.minHeight);
            vertRuler.Location = new Point(0, FRAMEWIDTH);
            this.Controls.Add(vertRuler);

            vertScroller = new VScrollBar();
            vertScroller.Minimum = 0;
            vertScroller.Scroll += new ScrollEventHandler(vertScroller_Scroll);
            this.Controls.Add(vertScroller);

            horzScroller = new HScrollBar();
            horzScroller.Minimum = 0;
            horzScroller.Scroll += new ScrollEventHandler(horzScroller_Scroll);
            this.Controls.Add(horzScroller);

            //init positions
            horzRuler.setStart(easelOrgX);
            horzRuler.setOrigin(expos);
            horzRuler.setLength(canvas.minWidth + FRAMEWIDTH);
            canvas.setStartX(easelOrgX);
            canvas.setOrgX(expos);
            horzScroller.Maximum = canvas.minWidth;
            horzScroller.Value = expos;

            vertRuler.setStart(easelOrgY);
            vertRuler.setOrigin(eypos);
            vertRuler.setLength(canvas.minHeight + FRAMEWIDTH);
            canvas.setStartY(easelOrgY);
            canvas.setOrgY(eypos);
            vertScroller.Maximum = canvas.minHeight;
            vertScroller.Value = eypos;

            cursorX = 0;
            cursorY = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //horz position
            int easelWidth = this.Width - (FRAMEWIDTH * 2);
            if (easelWidth > canvas.minWidth) {
                canvasWidth = easelWidth;
                easelOrgX = (canvas.HORZMARGIN  + (canvasWidth - canvas.minWidth) / 2) * -1;
                canvas.setStartX(easelOrgX);
                canvas.setOrgX(0);
                horzRuler.setStart(easelOrgX);
                horzRuler.setOrigin(0);
                horzRuler.setLength(canvasWidth + FRAMEWIDTH);
                horzScroller.Enabled = false;
            } else {
                canvasWidth = canvas.minWidth;
                int diff = canvasWidth - easelWidth;                //width of canvas not visible
                if (diff < expos) expos = diff;                     //move horz thumb to match diff
                easelOrgX = canvas.HORZMARGIN * -1;
                canvas.setStartX(easelOrgX);
                canvas.setOrgX(expos);
                horzRuler.setStart(easelOrgX);
                horzRuler.setOrigin(expos);
                horzRuler.setLength(canvasWidth + FRAMEWIDTH);
                horzScroller.Enabled = true;
                horzScroller.Maximum = diff + (horzScroller.LargeChange - 1);
                horzScroller.Value = expos;
            }

            //vert position
            int easelHeight = this.Height - (FRAMEWIDTH * 2);
            if (easelHeight > canvas.minHeight)
            {
                canvasHeight = easelHeight;
                easelOrgY = (canvas.VERTMARGIN + (canvasHeight - canvas.minHeight) / 2) * -1;
                canvas.setStartY(easelOrgY);
                canvas.setOrgY(0);
                vertRuler.setStart(easelOrgY);
                vertRuler.setOrigin(0);
                vertRuler.setLength(canvasHeight + FRAMEWIDTH);
                vertScroller.Enabled = false;
            }
            else
            {
                canvasHeight = canvas.minHeight;
                int diff = canvasHeight - easelHeight;              //height of canvas not visible
                if (diff < eypos) eypos = diff;                     //move vert thumb to match diff
                easelOrgY = canvas.VERTMARGIN * -1;
                canvas.setStartY(easelOrgY);
                canvas.setOrgY(eypos);
                vertRuler.setStart(easelOrgY);
                vertRuler.setOrigin(eypos);
                vertRuler.setLength(canvasHeight + FRAMEWIDTH);
                vertScroller.Enabled = true;
                vertScroller.Maximum = diff + (vertScroller.LargeChange - 1);
                vertScroller.Value = eypos;
            }
            
            //resizing
            if (canvas != null) canvas.Size = new Size(easelWidth, easelHeight);
            if (horzRuler != null) horzRuler.Size = new Size(this.Width - FRAMEWIDTH, FRAMEWIDTH);
            if (vertRuler != null) vertRuler.Size = new Size(20, this.Height - FRAMEWIDTH);
            if (vertScroller != null)
            {
                vertScroller.Size = new Size(FRAMEWIDTH, easelHeight);
                vertScroller.Location = new Point(this.Width - FRAMEWIDTH, FRAMEWIDTH);
            }
            if (horzScroller != null)
            {
                horzScroller.Size = new Size(easelWidth, FRAMEWIDTH);
                horzScroller.Location = new Point(FRAMEWIDTH, this.Height - FRAMEWIDTH);
            }
            Invalidate();
        }

        void horzScroller_Scroll(object sender, ScrollEventArgs e)
        {
            expos = (e.NewValue);
            horzRuler.setOrigin(expos);
            canvas.setOrgX(expos);
            Invalidate();
        }

        void vertScroller_Scroll(object sender, ScrollEventArgs e)
        {
            eypos = (e.NewValue);
            vertRuler.setOrigin(eypos);
            canvas.setOrgY(eypos);
            Invalidate();
        }

        public void setCursorPos(int x, int y)
        {
            cursorX = x;
            cursorY = y;
            window.statusPanel.setCursorPos(cursorX, cursorY);
            horzRuler.setCursorPos(cursorX);
            vertRuler.setCursorPos(cursorY);
        }

        public void clearCursorPos()
        {
            window.statusPanel.clearCursorPos();
        }

    }
}
