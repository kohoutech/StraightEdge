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

using StraightEdge.Shapes;
using StraightEdge.UI;

namespace StraightEdge.Tools
{
    class PointerTool : SETool
    {
        int orgX;
        int orgY;

        public PointerTool(SEWindow window)
            : base(window)
        {
            buttonIcon = "toolboxpointer";
            tooltip = "select and group elements";
            orgX = 0;
            orgY = 0;
        }

        public override void mouseDown(MouseEventArgs e)
        {
            orgX = e.X;
            orgY = e.Y;
            SEShape selected = canvas.hitTest(orgX, orgY);
            canvas.setSelection(selected);
        }

        public override void mouseDrag(MouseEventArgs e)
        {
            int ofsX = e.X - orgX;
            int ofsY = e.Y - orgY;
            if (canvas.selectedShape != null)
            {
                canvas.selectedShape.move(ofsX, ofsY);
            }
            orgX = e.X;
            orgY = e.Y;
        }

        public override void mouseUp(MouseEventArgs e)
        {
        }

    }
}
