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
        const int BUTTONSIZE = 32;

        public SEWindow window;
        public SECanvas canvas;

        List<SETool> tools;         //tools in the toolbox

        Button currentButton;

        public SEToolBox(SEWindow _window)        
        {
            window = _window;
            canvas = window.easel.canvas;
            InitializeComponent();
            //this.BackColor = Color.LightSteelBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //add tools to the toolbox
            tools = new List<SETool>();

            tools.Add(new PointerTool(window));
            tools.Add(new RectangleTool(window));
            tools.Add(new EllipseTool(window));
            tools.Add(new PolygonTool(window));
            tools.Add(new LineTool(window));
            tools.Add(new PathTool(window));
            tools.Add(new CurveTool(window));
            tools.Add(new TextTool(window));
            tools.Add(new ImageTool(window));

            //build toolbox buttons
            int ypos = 4;
            foreach (SETool tool in tools)
            {
                Button toolButton = new Button();
                toolButton.Image = (Image)Properties.Resources.ResourceManager.GetObject(tool.buttonIcon);
                toolButton.Size = new Size(BUTTONSIZE, BUTTONSIZE);
                toolButton.Padding = new Padding(0, 0, 1, 1);
                toolButton.BackColor = Color.White;
                toolButton.Location = new Point(2, ypos);
                toolButton.FlatStyle = FlatStyle.Flat;
                toolButton.FlatAppearance.BorderColor = Color.Black;
                toolButton.FlatAppearance.BorderSize = 1;
                toolButton.Tag = tool;
                toolButton.Click += new EventHandler(toolButton_Click);
                window.setTooltip(toolButton, tool.tooltip);
                Controls.Add(toolButton);
                ypos += (BUTTONSIZE + 1);
            }
            this.Size = new Size(BUTTONSIZE + 6, ypos);
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
            canvas.setCurrentTool((SETool)toolButton.Tag);
        }
    }
}
