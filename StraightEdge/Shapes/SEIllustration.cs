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

using StraightEdge;
using StraightEdge.Tools;

namespace StraightEdge.Shapes
{
    public class SEIllustration
    {
        public SEWindow window;
        public List<SEShape> shapes;

        public static String curFileName;

        public static Dictionary<String, SETool> tools = new Dictionary<string,SETool>();

        public static void registerShapeTool(String shapename, SETool tool)
        {
            tools.Add(shapename, tool);
        }

        public static SETool getShapeTool(String shapeName)
        {
            return tools[shapeName];
        }

        public static SEIllustration loadFile(SEWindow _window, String illoFileName) 
        {
            curFileName = illoFileName;
            SEIllustration illo = new SEIllustration(_window);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(illoFileName);
            foreach (XmlNode shapeNode in xmlDoc.DocumentElement.ChildNodes)
            {
                SETool shapeTool = getShapeTool(shapeNode.Name);
                shapeTool.loadShape(shapeNode, illo);
            }

            return illo;
        }

//-----------------------------------------------------------------------------

        public SEIllustration()
        {
            window = null;
            shapes = new List<SEShape>();
        }

        public SEIllustration(SEWindow _window)
        {
            window = _window;
            shapes = new List<SEShape>();
        }

        public void save()
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            XmlWriter xmlWriter = XmlWriter.Create(curFileName, settings);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("shapes");

            foreach (SEShape shape in shapes)
            {
                xmlWriter.WriteStartElement(shape.xmlShapeName);
                shape.save(xmlWriter);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public void saveAs(String filename)
        {
            curFileName = filename;
            save();
        }
    }
}
