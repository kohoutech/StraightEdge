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
using System.Xml;
using System.Drawing;

using StraightEdge.Shapes;
using StraightEdge.UI;

namespace StraightEdge.Tools
{
    public class RectangleTool : SETool
    {
        SERectangle currentRect;
        int orgX;
        int orgY;

        //control panel
        ToolStripTextBox txtRX;
        ToolStripTextBox txtRY;
        bool updatingPanel;

        static bool registered = false;

        public RectangleTool(SEWindow window)
            : base(window)        
        {
            if (!registered)
            {
                SETool.registerShapeTool("rectangle", this);
                registered = true;
            }

            currentRect = null;

            buttonIcon = "toolboxrect";
            tooltip = "draw squares and rectangles";

            buildControlPanel();
            updatingPanel = false;
        }

        public override void setCurrentShape(SEShape shape)
        {
            currentRect = (SERectangle)shape;
            updateControlPanel();
        }

//- control panel -------------------------------------------------------------

        public void buildControlPanel()
        {
            ToolStripLabel lblRX = new ToolStripLabel("RX: ");
            controlPanel.Add(lblRX);            
            txtRX = new ToolStripTextBox();
            txtRX.BorderStyle = BorderStyle.FixedSingle;
            txtRX.Leave += new EventHandler(rxTextBox_Leave);
            controlPanel.Add(txtRX);
            ToolStripLabel lblRY = new ToolStripLabel("RY: ");
            controlPanel.Add(lblRY);
            txtRY = new ToolStripTextBox();
            txtRY.BorderStyle = BorderStyle.FixedSingle;
            txtRY.Leave += new EventHandler(ryTextBox_Leave);
            controlPanel.Add(txtRY);
        }

        private void rxTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                //currentRect.setPos(Single.Parse(txtX.Text), currentRect.ypos);
                canvas.Invalidate();
            }
        }

        private void ryTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                //currentRect.setPos(currentRect.xpos, Single.Parse(txtY.Text));
                canvas.Invalidate();
            }
        }


        public override void updateControlPanel()
        {
            updatingPanel = true;
            txtRX.Text = currentRect.rx.ToString();
            txtRY.Text = currentRect.ry.ToString();
            updatingPanel = false;            
        }

//- mouse handling ------------------------------------------------------------

        //start drag
        public override void mouseDown(Point loc)
        {
            orgX = loc.X;
            orgY = loc.Y;
            currentRect = new SERectangle(canvas.graphic);
            currentRect.setLeft(orgX);
            currentRect.setTop(orgY);
            currentRect.setPenColor(window.canvasPanel.penColor);
            currentRect.setPenWidth(window.canvasPanel.penWidth);
            currentRect.setBrushColor(window.canvasPanel.brushColor);
            canvas.graphic.shapes.Add(currentRect);
        }

        //public override void mouseMove(MouseEventArgs e)
        //{
        //}

        public override void mouseDrag(Point loc)
        {
            int ofsX = loc.X - orgX;
            int ofsY = loc.Y - orgY;
            if (currentRect != null)
            {
                currentRect.setWidth(ofsX);
                currentRect.setHeight(ofsY);
            }
        }

        //finish rectange
        public override void mouseUp(Point loc)
        {
            //graphic.setSelection(currentRect);
        }
    }
}
