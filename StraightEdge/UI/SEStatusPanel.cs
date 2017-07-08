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

namespace StraightEdge.UI
{
    public class SEStatusPanel : UserControl
    {
        public SEWindow window;

        //display controls
        private Widgets.SEPalette palette;
        private Label lblBrush;
        private Label lblPen;
        private Label lblPenColor;
        private Label lblBrushColor;
        private Label label1;
        private Label lblOpacity;
        private NumericUpDown nudPenWidth;
        private NumericUpDown nudOpacity;
        private Label lblXpos;
        private Label lblYpos;

        //control values
        public Color penColor;
        public Color brushColor;
        public int penWidth;
        public float brushOpacity;

        public SEStatusPanel(SEWindow _window)        
        {
            window = _window;
            InitializeComponent();

            palette.statusPanel = this;
            penColor = Color.Black;
            brushColor = Color.White;
            penWidth = 1;
            brushOpacity = 1.0f;
        }

        private void InitializeComponent()
        {
            this.lblBrush = new System.Windows.Forms.Label();
            this.lblPen = new System.Windows.Forms.Label();
            this.lblPenColor = new System.Windows.Forms.Label();
            this.lblBrushColor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.nudPenWidth = new System.Windows.Forms.NumericUpDown();
            this.nudOpacity = new System.Windows.Forms.NumericUpDown();
            this.lblXpos = new System.Windows.Forms.Label();
            this.lblYpos = new System.Windows.Forms.Label();
            this.palette = new StraightEdge.Widgets.SEPalette();
            ((System.ComponentModel.ISupportInitialize)(this.nudPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrush
            // 
            this.lblBrush.AutoSize = true;
            this.lblBrush.Location = new System.Drawing.Point(3, 56);
            this.lblBrush.Name = "lblBrush";
            this.lblBrush.Size = new System.Drawing.Size(34, 13);
            this.lblBrush.TabIndex = 1;
            this.lblBrush.Text = "Brush";
            // 
            // lblPen
            // 
            this.lblPen.AutoSize = true;
            this.lblPen.Location = new System.Drawing.Point(8, 36);
            this.lblPen.Name = "lblPen";
            this.lblPen.Size = new System.Drawing.Size(26, 13);
            this.lblPen.TabIndex = 2;
            this.lblPen.Text = "Pen";
            // 
            // lblPenColor
            // 
            this.lblPenColor.BackColor = System.Drawing.Color.Black;
            this.lblPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPenColor.Location = new System.Drawing.Point(40, 32);
            this.lblPenColor.Name = "lblPenColor";
            this.lblPenColor.Size = new System.Drawing.Size(40, 20);
            this.lblPenColor.TabIndex = 3;
            // 
            // lblBrushColor
            // 
            this.lblBrushColor.BackColor = System.Drawing.Color.White;
            this.lblBrushColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrushColor.Location = new System.Drawing.Point(40, 52);
            this.lblBrushColor.Name = "lblBrushColor";
            this.lblBrushColor.Size = new System.Drawing.Size(40, 20);
            this.lblBrushColor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width";
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(88, 56);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(43, 13);
            this.lblOpacity.TabIndex = 6;
            this.lblOpacity.Text = "Opacity";
            // 
            // nudPenWidth
            // 
            this.nudPenWidth.Location = new System.Drawing.Point(132, 32);
            this.nudPenWidth.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPenWidth.Name = "nudPenWidth";
            this.nudPenWidth.Size = new System.Drawing.Size(50, 20);
            this.nudPenWidth.TabIndex = 7;
            this.nudPenWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPenWidth.ValueChanged += new System.EventHandler(this.nudPenWidth_ValueChanged);
            // 
            // nudOpacity
            // 
            this.nudOpacity.Location = new System.Drawing.Point(132, 52);
            this.nudOpacity.Name = "nudOpacity";
            this.nudOpacity.Size = new System.Drawing.Size(50, 20);
            this.nudOpacity.TabIndex = 8;
            this.nudOpacity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOpacity.ValueChanged += new System.EventHandler(this.nudOpacity_ValueChanged);
            // 
            // lblXpos
            // 
            this.lblXpos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblXpos.AutoSize = true;
            this.lblXpos.Location = new System.Drawing.Point(693, 36);
            this.lblXpos.Name = "lblXpos";
            this.lblXpos.Size = new System.Drawing.Size(17, 13);
            this.lblXpos.TabIndex = 10;
            this.lblXpos.Text = "X:";
            // 
            // lblYpos
            // 
            this.lblYpos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblYpos.AutoSize = true;
            this.lblYpos.Location = new System.Drawing.Point(693, 56);
            this.lblYpos.Name = "lblYpos";
            this.lblYpos.Size = new System.Drawing.Size(17, 13);
            this.lblYpos.TabIndex = 9;
            this.lblYpos.Text = "Y:";
            // 
            // palette
            // 
            this.palette.BackColor = System.Drawing.Color.Silver;
            this.palette.Dock = System.Windows.Forms.DockStyle.Top;
            this.palette.Location = new System.Drawing.Point(0, 0);
            this.palette.Name = "palette";
            this.palette.Size = new System.Drawing.Size(750, 30);
            this.palette.TabIndex = 0;
            // 
            // SEStatusPanel
            // 
            this.Controls.Add(this.lblXpos);
            this.Controls.Add(this.lblYpos);
            this.Controls.Add(this.nudOpacity);
            this.Controls.Add(this.nudPenWidth);
            this.Controls.Add(this.lblOpacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBrushColor);
            this.Controls.Add(this.lblPenColor);
            this.Controls.Add(this.lblPen);
            this.Controls.Add(this.lblBrush);
            this.Controls.Add(this.palette);
            this.Name = "SEStatusPanel";
            this.Size = new System.Drawing.Size(750, 75);
            ((System.ComponentModel.ISupportInitialize)(this.nudPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setCursorPos(int x, int y)
        {
            lblXpos.Text = "X: " + x.ToString();
            lblYpos.Text = "Y: " + y.ToString();
        }

        public void clearCursorPos()
        {
            lblXpos.Text = "X: ";
            lblYpos.Text = "Y: ";
        }

        public void setPenColor(Color color)
        {
            penColor = color;
            lblPenColor.BackColor = color;
            this.Invalidate();
        }

        public void setBrushColor(Color color)
        {
            brushColor = color;
            lblBrushColor.BackColor = color;
            this.Invalidate();
        }

        //- rendering -----------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //SolidBrush colorPen = new SolidBrush(penColor);
            //g.FillRectangle(colorPen, 30, 30, 10, 10);

            //SolidBrush colorBrush = new SolidBrush(brushColor);
            //g.FillRectangle(colorBrush, 30, 50, 10, 10);

        }

        private void nudPenWidth_ValueChanged(object sender, EventArgs e)
        {
            penWidth = (int)nudPenWidth.Value;
        }

        private void nudOpacity_ValueChanged(object sender, EventArgs e)
        {
            brushOpacity = ((float)nudOpacity.Value) / 100.0f;
        }
    }
}
