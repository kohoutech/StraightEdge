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

using StraightEdge.Widgets;

namespace StraightEdge.UI
{
    public class SEControlPanel : UserControl
    {
        public SEWindow window;
        public ControlStrip strip;

        public SEControlPanel(SEWindow _window)        
        {
            window = _window;
            strip = null;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SEControlPanel
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "SEControlPanel";
            this.Size = new System.Drawing.Size(598, 38);
            this.ResumeLayout(false);

        }

        public void setControlStrip(ControlStrip _strip)
        {
            Controls.Remove(strip); 
            strip = _strip;
            if (strip != null)
            {
                strip.Dock = DockStyle.Fill;
                Controls.Add(strip);
            }
        }

    }
}
