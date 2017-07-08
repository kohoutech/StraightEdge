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
using System.Drawing;
using System.Xml;

using StraightEdge.UI;
using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SEShape
    {
        public String id;
        public bool selected;           //if shape is current selection on canvas

        public SETool tool;             //tool used to create/modify this shape

        public String xmlShapeName;

        //pos
        public float xpos;
        public float ypos;

        //rendering
        public Pen pen;
        public Color penColor;
        public float penWidth;

        public Brush brush;
        public Color brushColor;
        public float brushOpacity;

        public SEShape()
        {
            id = "id" + 0;
            selected = false;
            xpos = 0.0f;
            ypos = 0.0f;
            penColor = Color.Black;
            penWidth = 1.0f;
            brushColor = Color.White;
            brushOpacity = 100.0f;
        }


        public SEShape(int idNum, float _x, float _y)
        {
            id = "id" + idNum;
            selected = false;
            xpos = _x;
            ypos = _y;
            penColor = Color.Black;
            penWidth = 1.0f;
            brushColor = Color.White;
            brushOpacity = 100.0f;
            xmlShapeName = "shape";
        }

        public virtual bool hitTest(int xpos, int ypos)
        {
            return false;
        }

        public virtual void setPos(float xOfs, float yOfs)
        {
        }

        public virtual void move(float xOfs, float yOfs)
        {            
        }

        public virtual void render(Graphics g)
        {
        }

        public virtual void save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteAttributeString("id", id);
            xmlWriter.WriteAttributeString("xpos", xpos.ToString());
            xmlWriter.WriteAttributeString("ypos", ypos.ToString());
            xmlWriter.WriteAttributeString("pencolor", penColor.ToArgb().ToString("x8"));
            xmlWriter.WriteAttributeString("penwidth", penWidth.ToString());
            xmlWriter.WriteAttributeString("brushcolor", brushColor.ToArgb().ToString("x8"));
            xmlWriter.WriteAttributeString("brushopacity", brushOpacity.ToString());
        }
    }
}
