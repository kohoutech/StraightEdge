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
using System.Drawing.Drawing2D;
using System.Xml;

using StraightEdge.UI;
using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SEShape
    {

        public SEShape parent;
        public SETool tool;             //tool used to create/modify this shape
        public String xmlShapeName;
        public String id;

        public GraphicsPath path;

        //pos
        public float xpos;
        public float ypos;

        //rendering
        public Pen pen;
        public Brush brush;

//- shape registry -------------------------------------------------------------

        public static Dictionary<String, SEShape> loaders = new Dictionary<string, SEShape>();

        public static void registerShape(String shapename, SEShape shape)
        {
            loaders.Add(shapename, shape);
        }

        public static SEShape getShapeLoader(String shapeName)
        {
            return loaders[shapeName];
        }

//-----------------------------------------------------------------------------

        public SEShape(SEShape _parent)
        {
            parent = _parent;
            id = "id" + 0;
            path = new GraphicsPath(FillMode.Alternate);
            xpos = 0.0f;
            ypos = 0.0f;
            pen = Pens.Black;
            brush = Brushes.White;
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
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

//- loading /saving -----------------------------------------------------------

        public Color colorFromXML(String argb)
        {
            int a = Convert.ToInt32(argb.Substring(0,2), 16);
            int r = Convert.ToInt32(argb.Substring(2, 2), 16);
            int g = Convert.ToInt32(argb.Substring(4, 2), 16);
            int b = Convert.ToInt32(argb.Substring(6, 2), 16);
            return Color.FromArgb(a,r,g,b);
        }

        public virtual SEShape loadShape(XmlNode node, SEShape parent)
        {
            return null;
        }

        public void loadBrush(XmlNode node)
        {
            Color brushColor = colorFromXML(node.Attributes["brushcolor"].Value);       //only use solid brushes for now
            brush = new SolidBrush(brushColor);
        }

        public virtual void loadAttributes(XmlNode node) 
        {
            id = node.Attributes["id"].Value;
            xpos = (float)Convert.ToDouble(node.Attributes["xpos"].Value);
            ypos = (float)Convert.ToDouble(node.Attributes["ypos"].Value);
            Color penColor = colorFromXML(node.Attributes["pencolor"].Value);
            float penwidth = (float)Convert.ToDouble(node.Attributes["penwidth"].Value);
            pen = new Pen(penColor, penwidth);
            loadBrush(node);
        }

        public void saveBrush(XmlWriter xmlWriter)
        {
            if (brush is SolidBrush)
            {
                SolidBrush sb = (SolidBrush)brush;
                xmlWriter.WriteAttributeString("brushcolor", sb.Color.ToArgb().ToString("x8"));
            }
        }

        public virtual void save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteAttributeString("id", id);
            xmlWriter.WriteAttributeString("xpos", xpos.ToString());
            xmlWriter.WriteAttributeString("ypos", ypos.ToString());
            xmlWriter.WriteAttributeString("pencolor", pen.Color.ToArgb().ToString("x8"));
            xmlWriter.WriteAttributeString("penwidth", pen.Width.ToString());
            saveBrush(xmlWriter);
        }
    }
}
