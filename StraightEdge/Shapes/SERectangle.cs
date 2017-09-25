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
using System.Drawing;
using System.Xml;

using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SERectangle : SEShape
    {
        public float width;
        public float height;
        public float rx;
        public float ry;

        public SERectangle(SEShape parent)
            : base(parent)
        {
            xmlShapeName = "rectangle";
            tool = (RectangleTool)SETool.getShapeTool("rectangle");
            width = 0;
            height = 0;
            rx = 0;
            ry = 0;
        }

        public void setWidth(float _width) 
        {
            width = _width;
            update();
        }

        public void setHeight(float _height)
        {
            height = _height;
            update();
        }

        public void update()
        {
            path.Reset();
            path.AddLine(xpos, ypos, xpos + width, ypos);
            path.AddLine(xpos + width, ypos, xpos + width, ypos + height);
            path.AddLine(xpos + width, ypos + height, xpos, ypos + height);
            path.CloseFigure();
        }

        public override bool hitTest(int xpos, int ypos)
        {
            return false;
        }

//- loading /saving -----------------------------------------------------------

        public override SEShape loadShape(XmlNode node, SEShape parent)
        {
            SERectangle rect = new SERectangle(parent);
            rect.loadAttributes(node);
            return rect;
        }

        public override void loadAttributes(XmlNode node) 
        {
            base.loadAttributes(node);
            width = (float)Convert.ToDouble(node.Attributes["width"].Value);
            height = (float)Convert.ToDouble(node.Attributes["height"].Value);
            update();
        }

        public override void save(XmlWriter xmlWriter)
        {
            base.save(xmlWriter);
            xmlWriter.WriteAttributeString("width", width.ToString());
            xmlWriter.WriteAttributeString("height", height.ToString());
        }
    }
}
