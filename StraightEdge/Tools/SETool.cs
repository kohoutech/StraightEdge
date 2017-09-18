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
using System.Windows.Forms;
using System.Xml;

using StraightEdge.Shapes;
using StraightEdge.UI;
using StraightEdge.Widgets;

namespace StraightEdge.Tools
{
    public class SETool
    {
        public SEWindow window;
        public SECanvas canvas;

        //toolbox
        public String buttonText;
        public String tooltip;

        //control panel
        public ControlStrip strip;

//- tool registry -------------------------------------------------------------

        public static Dictionary<String, SETool> tools = new Dictionary<string, SETool>();

        public static void registerShapeTool(String shapename, SETool tool)
        {
            tools.Add(shapename, tool);
        }

        public static SETool getShapeTool(String shapeName)
        {
            return tools[shapeName];
        }

//-----------------------------------------------------------------------------

        public SETool(SEWindow _window)
        {
            window = _window;
            canvas = window.canvas;
            buttonText = "none";
            tooltip = "none";
            strip = new ControlStrip();
        }

        public virtual void setCurrentShape(SEShape shape) 
        {
        }

        public virtual void updateControlStrip()
        {
        }

//- event handlers ------------------------------------------------------------

        public virtual void mouseDown(MouseEventArgs e)
        {
        }

        public virtual void mouseMove(MouseEventArgs e)
        {
        }

        public virtual void mouseDrag(MouseEventArgs e)
        {
        }

        public virtual void mouseUp(MouseEventArgs e)
        {
        }

    }
}
