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
using System.Xml;
using System.IO;

using StraightEdge.Shapes;
using StraightEdge.Tools;
using StraightEdge.UI;

namespace StraightEdge
{
    public class SEDocument
    {
        public SEWindow window;
        public SEGraphic graph;
        public SECanvas canvas;

        public String filename;

        public static SEDocument loadFile(SEWindow window, String _filename)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_filename);

            SEDocument doc = new SEDocument(window, _filename);
            doc.filename = _filename;

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name.Equals("shapes"))             //only child type we have for now, there may be more
                {
                    doc.graph.loadShape(node, null);
                }
            }

            return doc;
        }

        public SEDocument(SEWindow _window, String _name)
        {
            window = _window;
            canvas = window.easel.canvas;

            filename = _name;

            graph = new SEGraphic(canvas);
        }

        public void save()
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            XmlWriter xmlWriter = XmlWriter.Create(filename, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public void saveAs(String _filename)
        {
            filename = _filename;
            save();
        }
    }
}
