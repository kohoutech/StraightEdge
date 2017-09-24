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
//        int orgX;
//        int orgY;

        //control strip
//        TextBox txtX;
//        TextBox txtY;
//        TextBox txtW;
//        TextBox txtH;
//        bool updatingStrip;

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

            //buildControlStrip();
            //updatingStrip = false;
        }

//        public override void setCurrentShape(SEShape shape)
//        {
//            currentRect = (SERectangle)shape;
//            updateControlStrip();
//        }

//        public override void loadShape(XmlNode shapeNode, SEGraphic illo)
//        {
//            //load shape values from xml node
//            String id = shapeNode.Attributes["id"].Value;
//            float orgX = Single.Parse(shapeNode.Attributes["xpos"].Value);
//            float orgY = Single.Parse(shapeNode.Attributes["ypos"].Value);
//            int pencolor = Convert.ToInt32(shapeNode.Attributes["pencolor"].Value,16);
//            float penwidth = Single.Parse(shapeNode.Attributes["penwidth"].Value);
//            int brushcolor = Convert.ToInt32(shapeNode.Attributes["brushcolor"].Value,16);
//            float brushopacity = Single.Parse(shapeNode.Attributes["brushopacity"].Value);
//            float width = Single.Parse(shapeNode.Attributes["width"].Value);
//            float height = Single.Parse(shapeNode.Attributes["height"].Value);

//            //create new rect shape & add it to canvas
//            currentRect = new SERectangle(canvas.curGraphic.shapes.Count, orgX, orgY);
//            currentRect.id = id;
//            currentRect.penColor = Color.FromArgb(pencolor);
//            currentRect.penWidth = penwidth;
//            currentRect.brushColor = Color.FromArgb(brushcolor);
//            currentRect.brushOpacity = brushopacity;
//            currentRect.setWidth(width);
//            currentRect.setHeight(height);
//            currentRect.tool = this;

//            illo.shapes.Add(currentRect);
//        }

////- control strip -------------------------------------------------------------

//        public void buildControlStrip()
//        {
//            Label lblX = new Label();
//            lblX.Width = 20;
//            lblX.Text = "X: ";

//            strip.add(lblX);

//            txtX = new TextBox();
//            txtX.Width = 50;
//            txtX.Leave += xposTextBox_Leave; 
//            strip.add(txtX);

//            Label lblY = new Label();
//            lblY.Width = 20;
//            lblY.Text = "Y: ";
//            strip.add(lblY);

//            txtY = new TextBox();
//            txtY.Width = 50;
//            txtY.Leave += yposTextBox_Leave; 
//            strip.add(txtY);

//            Label lblW = new Label();
//            lblW.Width = 20;
//            lblW.Text = "W: ";
//            strip.add(lblW);

//            txtW = new TextBox();
//            txtW.Width = 50;
//            txtW.Leave += widthTextBox_Leave;
//            strip.add(txtW);

//            Label lblH = new Label();
//            lblH.Width = 20;
//            lblH.Text = "H: ";
//            strip.add(lblH);

//            txtH = new TextBox();
//            txtH.Width = 50;
//            txtH.Leave += heightTextBox_Leave;
//            strip.add(txtH);
//        }

//        private void xposTextBox_Leave(object sender, EventArgs e)
//        {
//            if (!updatingStrip)
//            {
//                currentRect.setPos(Single.Parse(txtX.Text), currentRect.ypos);
//                canvas.Invalidate();
//            }
//        }

//        private void yposTextBox_Leave(object sender, EventArgs e)
//        {
//            if (!updatingStrip)
//            {
//                currentRect.setPos(currentRect.xpos, Single.Parse(txtY.Text));
//                canvas.Invalidate();
//            }
//        }

//        private void widthTextBox_Leave(object sender, EventArgs e)
//        {
//            if (!updatingStrip)
//            {
//                currentRect.setWidth(Single.Parse(txtW.Text));
//                canvas.Invalidate();
//            }
//        }

//        private void heightTextBox_Leave(object sender, EventArgs e)
//        {
//            if (!updatingStrip)
//            {
//                currentRect.setHeight(Single.Parse(txtH.Text));
//                canvas.Invalidate();
//            }
//        }

//        public override void updateControlStrip()
//        {
//            updatingStrip = true;
//            txtX.Text = currentRect.xpos.ToString();
//            txtY.Text = currentRect.ypos.ToString();
//            txtW.Text = currentRect.rect.Width.ToString();
//            txtH.Text = currentRect.rect.Height.ToString();
//            updatingStrip = false;            
//        }

////- mouse handling ------------------------------------------------------------

//        //start rectangle
//        public override void mouseDown(MouseEventArgs e)
//        {
//            orgX = e.X;
//            orgY = e.Y;
//            currentRect = new SERectangle(canvas.curGraphic.shapes.Count, orgX, orgY);
//            currentRect.penColor = window.statusPanel.penColor;
//            currentRect.penWidth = (float)window.statusPanel.penWidth;
//            currentRect.brushColor = window.statusPanel.brushColor;
//            currentRect.brushOpacity = (float) window.statusPanel.brushOpacity;
//            currentRect.tool = this;
//            canvas.curGraphic.shapes.Add(currentRect);
//        }

//        public override void mouseMove(MouseEventArgs e)
//        {
//        }

//        public override void mouseDrag(MouseEventArgs e)
//        {
//            int ofsX = e.X - orgX;
//            int ofsY = e.Y - orgY;
//            currentRect.setWidth(ofsX);
//            currentRect.setHeight(ofsY);
//        }

//        //finish rectange
//        public override void mouseUp(MouseEventArgs e)
//        {
//            canvas.setSelection(currentRect);
//        }

    }
}
