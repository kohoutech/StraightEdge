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

using StraightEdge;
using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SEGraphic : SEShape
    {
        public SEWindow window;
        public SEDocument doc;
        public List<SEShape> shapes;

        public static void registerShapes()
        {
            SEShape.registerShape("rectangle", new SERectangle(null));
        }

//-----------------------------------------------------------------------------

        public SEGraphic() : base(null)
        {
            window = null;
            shapes = new List<SEShape>();
        }

        public override void render(Graphics g)
        {
            foreach (SEShape shape in shapes)           //shapes are stored in order bottom to top
            {
                shape.render(g);
            }
        }

//-----------------------------------------------------------------------------

        public override SEShape loadShape(XmlNode shapeRoot, SEShape parent)
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

        public override void save(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("shapes");

            foreach (SEShape shape in shapes)
            {
                xmlWriter.WriteStartElement(shape.xmlShapeName);
                shape.save(xmlWriter);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }
    }
}
