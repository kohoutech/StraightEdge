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
        ToolStripTextBox txtX;
        ToolStripTextBox txtY;
        ToolStripTextBox txtW;
        ToolStripTextBox txtH;
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

            buildControlStrip();
            updatingPanel = false;
        }

        public override void setCurrentShape(SEShape shape)
        {
            currentRect = (SERectangle)shape;
            updateControlPanel();
        }

//- control strip -------------------------------------------------------------

        public void buildControlStrip()
        {
            ToolStripLabel lblX = new ToolStripLabel("X: ");
            controlPanel.Add(lblX);
            txtX = new ToolStripTextBox();
            txtX.BorderStyle = BorderStyle.FixedSingle;
            txtX.Leave += new EventHandler(xposTextBox_Leave);
            controlPanel.Add(txtX);
            ToolStripLabel lblY = new ToolStripLabel("Y: ");
            controlPanel.Add(lblY);
            txtY = new ToolStripTextBox();
            txtY.BorderStyle = BorderStyle.FixedSingle;
            txtY.Leave += new EventHandler(yposTextBox_Leave);
            controlPanel.Add(txtY);
            
            ToolStripLabel lblW = new ToolStripLabel("W: ");
            controlPanel.Add(lblW);            
            txtW = new ToolStripTextBox();
            txtW.BorderStyle = BorderStyle.FixedSingle;
            txtW.Leave += new EventHandler(widthTextBox_Leave);
            controlPanel.Add(txtW);
            ToolStripLabel lblH = new ToolStripLabel("H: ");
            controlPanel.Add(lblH);
            txtH = new ToolStripTextBox();
            txtH.BorderStyle = BorderStyle.FixedSingle;
            txtH.Leave += new EventHandler(heightTextBox_Leave);
            controlPanel.Add(txtH);

            ToolStripLabel lblRX = new ToolStripLabel("RX: ");
            controlPanel.Add(lblRX);            
            ToolStripTextBox txtRX = new ToolStripTextBox();
            txtRX.BorderStyle = BorderStyle.FixedSingle;
            controlPanel.Add(txtRX);
            ToolStripLabel lblRY = new ToolStripLabel("RY: ");
            controlPanel.Add(lblRY);
            ToolStripTextBox txtRY = new ToolStripTextBox();
            txtRY.BorderStyle = BorderStyle.FixedSingle;
            controlPanel.Add(txtRY);
        }

        private void xposTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                currentRect.setPos(Single.Parse(txtX.Text), currentRect.ypos);
                canvas.Invalidate();
            }
        }

        private void yposTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                currentRect.setPos(currentRect.xpos, Single.Parse(txtY.Text));
                canvas.Invalidate();
            }
        }

        private void widthTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                currentRect.setWidth(Single.Parse(txtW.Text));
                canvas.Invalidate();
            }
        }

        private void heightTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                currentRect.setHeight(Single.Parse(txtH.Text));
                canvas.Invalidate();
            }
        }

        public override void updateControlPanel()
        {
            updatingPanel = true;
            txtX.Text = currentRect.xpos.ToString();
            txtY.Text = currentRect.ypos.ToString();
            txtW.Text = currentRect.width.ToString();
            txtH.Text = currentRect.height.ToString();
            updatingPanel = false;            
        }

//- mouse handling ------------------------------------------------------------

        //start rectangle
        public override void mouseDown(Point loc)
        {
            orgX = loc.X;
            orgY = loc.Y;
            currentRect = new SERectangle(canvas.graphic);
            currentRect.setPos(orgX, orgY);
            currentRect.setPen(window.statusPanel.penColor, window.statusPanel.penWidth);
            currentRect.setBrush(window.statusPanel.brushColor);
            canvas.graphic.shapes.Add(currentRect);
        }

        //public override void mouseMove(MouseEventArgs e)
        //{
        //}

        public override void mouseDrag(Point loc)
        {
            int ofsX = loc.X - orgX;
            int ofsY = loc.Y - orgY;
            currentRect.setWidth(ofsX);
            currentRect.setHeight(ofsY);
        }

        //finish rectange
        public override void mouseUp(Point loc)
        {
            canvas.setSelection(currentRect);
        }

    }
}
