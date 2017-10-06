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
using System.Xml;

using StraightEdge;
using StraightEdge.UI;
using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SEGraphic : SEShape
    {
        public const int DEFAULTWIDTH = 640;
        public const int DEFAULTHEIGHT = 480;

        public SEWindow window;
        public SECanvas canvas;
        public SEDocument doc;
        public Bitmap bmp;
        public List<SEShape> shapes;
        public SEShape selectedShape;

        public int gxpos;
        public int gypos;
        public int gwidth;
        public int gheight;

        //register all the shapes we have for loading from and saving to .rule files
        public static void registerShapes()
        {
            SEShape.registerShape("rectangle", new SERectangle(null));        
        }

//-----------------------------------------------------------------------------

        public SEGraphic(SECanvas _canvas)
            : base(null)
        {
            canvas = _canvas;
            window = canvas.window;

            gxpos = 0;
            gypos = 0;
            gwidth = DEFAULTWIDTH;
            gheight = DEFAULTHEIGHT;

            bmp = new Bitmap(gwidth, gheight);
            shapes = new List<SEShape>();
            selectedShape = null;            
        }

        public void setPos(int xpos, int ypos)
        {
            gxpos = xpos;
            gypos = ypos;
        }

//- selection -----------------------------------------------------------------

        //find the shape at this cursor pos
        public SEShape findShape(int xpos, int ypos)
        {
            SEShape result = null;
            for (int i = shapes.Count - 1; i >= 0; i--)     //reverse through shapes list to hit topmost first, bottommost last
            {
                if (shapes[i].hitTest(xpos, ypos))
                {
                    result = shapes[i];
                    break;
                }
            }
            return result;
        }

        public void setSelection(SEShape shape)
        {
            if (selectedShape != null)
            {
                selectedShape.selected = false;
            }
            selectedShape = shape;                //select current shape (or no selection)
            if (shape != null)
            {
                shape.selected = true;
                //window.setControlPanel(shape.tool.controlPanel);      //set control panel to shape's type's controls
                //shape.tool.setCurrentShape(shape);                          //and link control strip to THIS shape
                canvas.currentTool.setCurrentShape(shape);                          //and link control strip to THIS shape

                canvas.Cursor = Cursors.SizeAll;            //this may need to be set by the selected shape, for now we're dragging
            }
            else
            {
                window.setControlPanel(null);
                canvas.Cursor = Cursors.Arrow;
            }
        }

//- rendering -----------------------------------------------------------------

        public override void render(Graphics g)
        {
            //draw all shapes to graphic bitmap
            Graphics bg = Graphics.FromImage(bmp);
            bg.Clear(Color.White);
            foreach (SEShape shape in shapes)           //shapes are stored in order bottom to top
            {
                shape.render(bg);
            }

            //now, draw completed bitmap to canvas at cur pos
            g.DrawImage(bmp, gxpos, gypos);
            g.DrawRectangle(Pens.Black, gxpos, gypos, bmp.Width, bmp.Height);       //outline graphic
        }

//- loading & saving ----------------------------------------------------------

        public SEGraphic loadShapes(XmlNode shapeRoot)
        {
            foreach (XmlNode shapenode in shapeRoot.ChildNodes)
            {
                SEShape loader = SEShape.getShapeLoader(shapenode.Name);
                if (loader != null)
                {
                    SEShape shape = loader.loadShape(shapenode, this);
                    shapes.Add(shape);
                }
            }
            return this;
        }

        public void saveShapes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("shapes");

            foreach (SEShape shape in shapes)
            {
                xmlWriter.WriteStartElement(shape.xmlShapeName);
                shape.saveShape(xmlWriter);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }
    }
}
