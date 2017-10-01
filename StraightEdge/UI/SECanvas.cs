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

using StraightEdge.Shapes;
using StraightEdge.Tools;

namespace StraightEdge.UI
{
    public class SECanvas : UserControl
    {
        public int HORZMARGIN = 50;
        public int VERTMARGIN = 50;

        public SEEasel easel;
        public SEWindow window;
        public SEGraphic graphic;

        public SEShape selectedShape;
        public SETool currentTool;

        int startx;
        int starty;
        int cxorg;
        int cyorg;
        public int minWidth;
        public int minHeight;
        bool isDragging;

        public SECanvas(SEEasel _easel)
        {
            easel = _easel;
            window = easel.window;
            minWidth = SEGraphic.DEFAULTWIDTH + (HORZMARGIN) * 2;
            minHeight = SEGraphic.DEFAULTHEIGHT + (VERTMARGIN) * 2;
            startx = 0;
            starty = 0;
            cxorg = 0;
            cyorg = 0;

            InitializeComponent();

            setGraphic(new SEGraphic(this));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SECanvas
            // 
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.DoubleBuffered = true;
            this.Name = "SECanvas";
            this.ResumeLayout(false);
        }

        public void setGraphic(SEGraphic _graphic)
        {
            graphic = _graphic;
            graphic.setPos(0, 0);
            int minWidth = graphic.gwidth + HORZMARGIN + HORZMARGIN;
            int minHeight = graphic.gheight + VERTMARGIN + VERTMARGIN;

            selectedShape = null;
            currentTool = null;
            isDragging = false;
            Invalidate();
        }

//- positioning ---------------------------------------------------------------

        public void setStartX(int _startX)
        {
            startx = _startX;
        }

        public void setOrgX(int orgX)
        {
            cxorg = startx + orgX;
            graphic.setPos(-(cxorg), -(cyorg));
            Invalidate();
        }

        public void setStartY(int _startY)
        {
            starty = _startY;
        }

        public void setOrgY(int orgY)
        {
            cyorg = starty + orgY;
            graphic.setPos(-(cxorg), -(cyorg));
            Invalidate();
        }

//-----------------------------------------------------------------------------

        public void setCurrentTool(SETool tool)
        {
            currentTool = tool;
            ToolStrip controlPanel = window.controlPanel();
            controlPanel.Items.Clear();
            controlPanel.Items.AddRange(tool.controlPanel.ToArray());       //put this tool's controls on control panel
        }

        //find the shape at this cursor pos
        public SEShape hitTest(int xpos, int ypos)
        {
            SEShape result = null;
            for (int i = graphic.shapes.Count - 1; i >= 0; i--)     //reverse through shapes list to hit topmost first, bottommost last
            {
                if (graphic.shapes[i].hitTest(xpos, ypos))
                {
                    result = graphic.shapes[i];
                    break;
                }
            }
            return result;
        }

        public void setSelection(SEShape shape)
        {
            if (selectedShape != null)
            {
                //selectedShape.selected = false;      //deselect any prev shape
            }
            selectedShape = shape;                //select current shape (or no selection)
            if (shape != null)
            {
                //shape.selected = true;                                      //let shape know its selected
                //window.controlPanel.setControlStrip(shape.tool.strip);      //set control panel to shape's type's controls
                shape.tool.setCurrentShape(shape);                          //and link control strip to THIS shape

                this.Cursor = Cursors.SizeAll;            //this may need to be set by the selected shape, for now we're dragging
            }
            else
            {
                //window.controlPanel.setControlStrip(null);
                this.Cursor = Cursors.Arrow;
            }
        }

//- mouse events --------------------------------------------------------------


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (currentTool != null)
            {
                currentTool.mouseDown(e);
            }
            isDragging = true;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int xpos = e.X + cxorg;
            int ypos = e.Y + cyorg;
            easel.setCursorPos(xpos, ypos);
            if (currentTool != null)
            {
                if (isDragging)
                    currentTool.mouseDrag(e);
                else
                    currentTool.mouseMove(e);
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (currentTool != null)
            {
                currentTool.mouseUp(e);
            }
            isDragging = false;
            Invalidate();
        }

        protected override void  OnMouseLeave(EventArgs e)
        {
 	        base.OnMouseLeave(e);
            easel.clearCursorPos();
        }

//- key events --------------------------------------------------------------

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                if (selectedShape != null)
                {
                    graphic.shapes.Remove(selectedShape);
                }
            }
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

//- rendering -----------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            graphic.render(g);          //paint the graphic which in turn will paint all its shapes & groups
        }
    }
}
