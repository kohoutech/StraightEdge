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

        public SEGraphic parent;
        public SETool tool;             //tool used to create/modify this shape
        public String xmlShapeName;
        public String id;

        public GraphicsPath path;
        public bool selected;

        //pos
        public float xpos;
        public float ypos;

        //size
        public float width;
        public float height;

        //rendering
        public Color penColor;
        public float penWidth;
        public Color brushColor;

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

        public SEShape(SEGraphic _parent)
        {
            parent = _parent;
            tool = null;
            xmlShapeName = "shape";
            id = "id" + 0;

            path = null;
            selected = false;
            
            xpos = 0.0f;
            ypos = 0.0f;
            width = 1.0f;
            height = 1.0f;

            penColor = Color.Black;
            penWidth = 1.0f;
            brushColor = Color.White;
            path = new GraphicsPath(FillMode.Alternate);
        }

        //build shape specific path
        public virtual void update()
        {
        }        

//- attributes ----------------------------------------------------------------

        public void setLeft(float xofs)
        {
            float diff = xofs - xpos;
            xpos = xofs;
            Matrix matrix = new Matrix();
            matrix.Translate(diff, 0);
            path.Transform(matrix);
        }

        public void setTop(float yofs)
        {
            float diff = yofs - ypos;
            ypos = yofs;
            Matrix matrix = new Matrix();
            matrix.Translate(0, diff);
            path.Transform(matrix);
        }

        public void setWidth(float _width)
        {
            if (_width != 0)
            {
                float xscale = _width / width;
                width = _width;
                Matrix matrix = new Matrix();
                matrix.Translate(-xpos, -ypos);
                path.Transform(matrix);
                matrix.Reset();
                matrix.Scale(xscale, 1);
                path.Transform(matrix);
                matrix.Reset();
                matrix.Translate(xpos, ypos);
                path.Transform(matrix);
            }
        }

        public void setHeight(float _height)
        {
            if (_height != 0)
            {
                float yscale = _height / height;
                height = _height;
                Matrix matrix = new Matrix();
                matrix.Translate(-xpos, -ypos);
                path.Transform(matrix);
                matrix.Reset();
                matrix.Scale(1, yscale);
                path.Transform(matrix);
                matrix.Reset();
                matrix.Translate(xpos, ypos);
                path.Transform(matrix);
            }
        }

//- events ----------------------------------------------------------------

        public virtual bool hitTest(int xpos, int ypos)
        {
            bool result = false;
            if (path != null)
            {
                result = path.IsVisible(xpos, ypos);
            }
            return result;
        }

//- rendering -----------------------------------------------------------------

        public virtual void setPenColor(Color color)
        {
            penColor = color;
        }

        public virtual void setPenWidth(float width)
        {
            penWidth = width;
        }

        public virtual void setBrushColor(Color color)
        {
            brushColor = color;            
        }

        public virtual void render(Graphics g)
        {
            //draw shape
            using (Pen pen = new Pen(penColor, penWidth))
            using (Brush brush = new SolidBrush(brushColor))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }

            //selection frame
            if (selected)
            {
                RectangleF bounds = path.GetBounds();

                Pen outlinePen = new Pen(Color.Red,2.0f);
                outlinePen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(outlinePen, bounds.Left - (penWidth / 2) - 1, bounds.Top - (penWidth / 2) - 1, 
                    bounds.Width + penWidth + 2, bounds.Height + penWidth + 2);
                outlinePen.Dispose();
            }
        }

//- loading / saving ----------------------------------------------------------

        public Color colorFromXML(String argb)
        {
            int a = Convert.ToInt32(argb.Substring(0,2), 16);
            int r = Convert.ToInt32(argb.Substring(2, 2), 16);
            int g = Convert.ToInt32(argb.Substring(4, 2), 16);
            int b = Convert.ToInt32(argb.Substring(6, 2), 16);
            return Color.FromArgb(a,r,g,b);
        }

        public virtual SEShape loadShape(XmlNode node, SEGraphic parent)
        {
            return null;
        }

        public virtual void loadAttributes(XmlNode node) 
        {
            id = node.Attributes["id"].Value;
            xpos = (float)Convert.ToDouble(node.Attributes["xpos"].Value);
            ypos = (float)Convert.ToDouble(node.Attributes["ypos"].Value);
            width = (float)Convert.ToDouble(node.Attributes["width"].Value);
            height = (float)Convert.ToDouble(node.Attributes["height"].Value);
            Color penColor = colorFromXML(node.Attributes["pencolor"].Value);
            float penwidth = (float)Convert.ToDouble(node.Attributes["penwidth"].Value);
            Color brushColor = colorFromXML(node.Attributes["brushcolor"].Value);       //only use solid brushes for now
        }

        public virtual void saveShape(XmlWriter xmlWriter)
        {
            xmlWriter.WriteAttributeString("id", id);
            xmlWriter.WriteAttributeString("xpos", xpos.ToString());
            xmlWriter.WriteAttributeString("ypos", ypos.ToString());
            xmlWriter.WriteAttributeString("width", width.ToString());
            xmlWriter.WriteAttributeString("height", height.ToString());
            xmlWriter.WriteAttributeString("pencolor", penColor.ToArgb().ToString("x8"));
            xmlWriter.WriteAttributeString("penwidth", penWidth.ToString());
            xmlWriter.WriteAttributeString("brushcolor", brushColor.ToArgb().ToString("x8"));
        }
    }
}
