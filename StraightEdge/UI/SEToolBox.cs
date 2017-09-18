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

using StraightEdge.Tools;

namespace StraightEdge.UI
{
    public class SEToolBox : UserControl
    {
        const int BUTTONSIZE = 42;

        public SEWindow window;
        public SECanvas canvas;

        List<SETool> tools;

        Button currentButton;
        Rectangle selectedRect;

        public SEToolBox(SEWindow _window)        
        {
            InitializeComponent();
            window = _window;
            canvas = window.canvas;

            tools = new List<SETool>();

            PointerTool pointerTool = new PointerTool(window);
            tools.Add(pointerTool);
            RectangleTool rectTool = new RectangleTool(window);
            tools.Add(rectTool);
            //EllipseTool ellipseTool = new EllipseTool(window);
            //tools.Add(ellipseTool);
            PolygonTool polygonTool = new PolygonTool(window);
            tools.Add(polygonTool);
            TextTool textTool = new TextTool(window);
            tools.Add(textTool);
            LineTool lineTool = new LineTool(window);
            tools.Add(lineTool);
            PathTool pathTool = new PathTool(window);
            tools.Add(pathTool);
            CurveTool curveTool = new CurveTool(window);
            tools.Add(curveTool);
            ImageTool imageTool = new ImageTool(window);
            tools.Add(imageTool);

            int ypos = 0;
            foreach (SETool tool in tools)
            {
                Button toolButton = new Button();
                toolButton.Text = tool.buttonText;
                toolButton.Size = new Size(BUTTONSIZE, BUTTONSIZE);
                toolButton.Location = new Point(2, ypos);
                toolButton.FlatStyle = FlatStyle.Flat;
                toolButton.FlatAppearance.BorderColor = Color.Black;
                toolButton.FlatAppearance.BorderSize = 1;
                toolButton.Tag = tool;
                toolButton.Click += new EventHandler(toolButton_Click);
                window.setTooltip(toolButton, tool.tooltip);
                Controls.Add(toolButton);
                ypos += BUTTONSIZE;
            }
            this.Size = new Size(BUTTONSIZE + 4, ypos);
            currentButton = null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SEToolBox
            // 
            this.Name = "SEToolBox";
            //this.Size = new System.Drawing.Size(52, 267);
            this.ResumeLayout(false);
        }

        void toolButton_Click(object sender, EventArgs e)
        {
            Button toolButton = (Button)sender;
            if (currentButton != null)
            {
                currentButton.FlatAppearance.BorderColor = Color.Black;
                currentButton.FlatAppearance.BorderSize = 1;
            }
            toolButton.FlatAppearance.BorderColor = Color.Red;
            toolButton.FlatAppearance.BorderSize = 2;
            currentButton = toolButton;
            window.canvas.setCurrentTool((SETool)toolButton.Tag);
        }
    }
}
