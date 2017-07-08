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

namespace StraightEdge.Shapes
{
    [Serializable]
    public class SEHandle
    {
        public const int HANDLEWIDTH = 4;
        public float xpos;
        public float ypos;
        public RectangleF rect;

        public SEHandle()
        {
            rect = new RectangleF(0 - (HANDLEWIDTH / 2), 0 - (HANDLEWIDTH / 2), HANDLEWIDTH, HANDLEWIDTH);
        }

        public SEHandle(float x, float y)
        {
            rect = new RectangleF(xpos = x - (HANDLEWIDTH / 2), y - (HANDLEWIDTH / 2), HANDLEWIDTH, HANDLEWIDTH);
        }

        public void setXPos(float x)
        {
            rect.X = x - (HANDLEWIDTH / 2);
        }

        public void setYPos(float y)
        {
            rect.Y = y - (HANDLEWIDTH / 2);
        }

        public void setPos(float x, float y)
        {
            setXPos(x);
            setYPos(y);
        }

        public void move(float x, float y)
        {
            rect.Offset(x, y);
        }

        public void render(Graphics g)
        {
            g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}
