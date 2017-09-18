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

namespace StraightEdge.Shapes
{
    class SEEllipse //: SEShape
    {
    //    public RectangleF rect;

    //    public SEHandle leftHandle;
    //    public SEHandle topHandle;
    //    public SEHandle rightHandle;
    //    public SEHandle bottomHandle;

    //    public SEEllipse(int idNum, float xpos, float ypos)
    //        : base(idNum, xpos, ypos)
    //    {
    //        rect = new RectangleF(xpos, ypos, 0, 0);
    //        leftHandle = new SEHandle(xpos,ypos);
    //        topHandle = new SEHandle(xpos,ypos);
    //        rightHandle = new SEHandle(xpos,ypos);
    //        bottomHandle = new SEHandle(xpos,ypos);
    //        xmlShapeName = "ellipse";
    //    }

    //    public override void setPos(float xOfs, float yOfs)
    //    {
    //        rect.Location = new PointF(xOfs, yOfs);
    //        xpos = rect.X;
    //        ypos = rect.Y;
    //        leftHandle.setPos(xpos, ypos + rect.Height / 2);
    //        topHandle.setPos(xpos + rect.Width / 2, yOfs);
    //        rightHandle.setPos(xpos + rect.Width, ypos + rect.Height / 2);
    //        bottomHandle.setPos(xpos + rect.Width / 2, ypos + rect.Height);         
    //    }

    //    public override void move(float xOfs, float yOfs)
    //    {
    //        rect.Offset(xOfs, yOfs);
    //        xpos = rect.X;
    //        ypos = rect.Y;
    //        leftHandle.move(xOfs, yOfs);
    //        topHandle.move(xOfs, yOfs);
    //        rightHandle.move(xOfs, yOfs);
    //        bottomHandle.move(xOfs, yOfs);
    //        tool.updateControlStrip();
    //    }

    //    public void setWidth(float width)
    //    {
    //        rect.Width = width;
    //        topHandle.setXPos(xpos + width / 2);
    //        rightHandle.setXPos(xpos + width);
    //        bottomHandle.setXPos(xpos + width / 2);
    //    }

    //    public void setHeight(float height)
    //    {
    //        rect.Height = height;
    //        leftHandle.setYPos(ypos + height / 2);
    //        bottomHandle.setYPos(ypos + height);
    //        rightHandle.setYPos(ypos + height / 2);
    //    }

    //    //use height/width ratio to stretch ellipse coords to circular shape, 
    //    //then find if distance from coords to center is less than circle circumference
    //    public override bool hitTest(int xpos, int ypos)
    //    {
    //        float centx = rect.X + (rect.Width / 2);
    //        float circum = (rect.Height / 2);
    //        float centy = rect.Y + circum;
    //        float ratio = rect.Height / rect.Width;
    //        float distx = ratio * (xpos - centx);
    //        float disty = (ypos - centy);
    //        float dist = (float)Math.Sqrt(distx * distx + disty * disty);
    //        return (dist <= circum);
    //    }

    //    public override void render(Graphics g)
    //    {
    //        pen = new Pen(penColor, penWidth);
    //        int alpha = (int)(255 * brushOpacity);
    //        brush = new SolidBrush(Color.FromArgb(alpha, brushColor));
    //        g.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
    //        g.FillEllipse(brush, rect);
    //        if (selected)
    //        {
    //            leftHandle.render(g);
    //            topHandle.render(g);
    //            rightHandle.render(g);
    //            bottomHandle.render(g);
    //        }
    //    }

    //    public override void save(XmlWriter xmlWriter)
    //    {
    //        base.save(xmlWriter);
    //        xmlWriter.WriteAttributeString("width", rect.Width.ToString());
    //        xmlWriter.WriteAttributeString("height", rect.Height.ToString());
    //    }
    }
}
