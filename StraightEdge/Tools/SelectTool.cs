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

using StraightEdge.Shapes;
using StraightEdge.UI;

namespace StraightEdge.Tools
{
    class SelectTool : SETool
    {
        SEShape selectedShape;
        int orgX;       //init mouse pos for calc dragging offset
        int orgY;

        //control panel
        ToolStripTextBox txtX;
        ToolStripTextBox txtY;
        ToolStripTextBox txtW;
        ToolStripTextBox txtH;
        bool updatingPanel;

        public SelectTool(SEWindow window)
            : base(window)
        {
            selectedShape = null;

            buttonIcon = "toolboxpointer";
            tooltip = "select and group elements";

            orgX = 0;
            orgY = 0;

            buildControlPanel();
            updatingPanel = false;

        }

        public override void setCurrentShape(SEShape shape)
        {
            selectedShape = (SERectangle)shape;
            updateControlPanel();
        }


//- control panel -------------------------------------------------------------

        public void buildControlPanel()
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
        }

        private void xposTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                selectedShape.setLeft(Single.Parse(txtX.Text));
                canvas.Invalidate();
            }
        }

        private void yposTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                selectedShape.setTop(Single.Parse(txtY.Text));
                canvas.Invalidate();
            }
        }

        private void widthTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                selectedShape.setWidth(Single.Parse(txtW.Text));
                canvas.Invalidate();
            }
        }

        private void heightTextBox_Leave(object sender, EventArgs e)
        {
            if (!updatingPanel)
            {
                selectedShape.setHeight(Single.Parse(txtH.Text));
                canvas.Invalidate();
            }
        }

        public override void updateControlPanel()
        {
            updatingPanel = true;
            txtX.Text = selectedShape.xpos.ToString();
            txtY.Text = selectedShape.ypos.ToString();
            txtW.Text = selectedShape.width.ToString();
            txtH.Text = selectedShape.height.ToString();
            updatingPanel = false;
        }

//- mouse handling ------------------------------------------------------------

        public override void mouseDown(Point loc)
        {
            orgX = loc.X;
            orgY = loc.Y;
            SEShape selected = canvas.graphic.findShape(orgX, orgY);
            canvas.graphic.setSelection(selected);
        }

        public override void mouseDrag(Point loc)
        {
            int ofsX = loc.X - orgX;
            int ofsY = loc.Y - orgY;
            if (selectedShape != null)
            {
                selectedShape.setLeft(selectedShape.xpos + ofsX);
                selectedShape.setTop(selectedShape.ypos + ofsY);
            }
            orgX = loc.X;
            orgY = loc.Y;
        }

        public override void mouseUp(Point loc)
        {
        }

    }
}
