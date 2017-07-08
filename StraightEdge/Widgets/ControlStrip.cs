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

namespace StraightEdge.Widgets
{
    public class ControlStrip : UserControl
    {
        List<Control> controls;
        int controlPos;

        public ControlStrip()
        {
            InitializeComponent();
            controls = new List<Control>();
            controlPos = 0;
        }

        public void add(Control control)
        {
            control.Location = new Point(controlPos, 2);
            //control.Dock = DockStyle.Right;
            controlPos += control.Width + 2;
            controls.Add(control);
            this.Controls.Add(control);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlStrip
            // 
            this.Name = "ControlStrip";
            this.Size = new System.Drawing.Size(500, 40);
            this.ResumeLayout(false);

        }
    }
}
