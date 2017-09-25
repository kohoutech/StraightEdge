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

using StraightEdge.UI;

namespace StraightEdge.Widgets
{
    public class SEPalette : UserControl
    {
        public const int COLORRECTSIZE = 30;

        public SECanvasPanel statusPanel;
        public List<Color> colors;        
        
        public SEPalette()
        {
            InitializeComponent();

            statusPanel = null;
            this.Height = COLORRECTSIZE;

            colors = new List<Color>(){Color.Black, Color.Blue, Color.Green, Color.Cyan, 
                Color.Red, Color.Magenta, Color.Brown, Color.LightGray, 
                Color.DarkGray, Color.DarkBlue, Color.DarkGreen, Color.DarkCyan, 
                Color.DarkRed, Color.DarkMagenta, Color.Yellow, Color.White
            };
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SEPalette
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Name = "SEPalette";
            this.Size = new System.Drawing.Size(582, 47);
            this.ResumeLayout(false);

        }

        //- mouse events --------------------------------------------------------------

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int colorIdx = e.X / COLORRECTSIZE;
            if (colorIdx < colors.Count)
            {
                if (e.Button == MouseButtons.Left)
                {
                    statusPanel.setPenColor(colors[colorIdx]);
                }
                else
                {
                    statusPanel.setBrushColor(colors[colorIdx]);
                }
            }            
        }

        //- rendering -----------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle colorRect = new Rectangle(0, 0, COLORRECTSIZE, COLORRECTSIZE);
            for (int i = 0; i < colors.Count; i++)
            {
                Brush colorBrush = new SolidBrush(colors[i]);
                g.FillRectangle(colorBrush, colorRect);
                colorRect.Offset(COLORRECTSIZE, 0);
            }
        }

    }
}
