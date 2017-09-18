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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using StraightEdge.UI;
using StraightEdge.Shapes;
using StraightEdge.Tools;
using StraightEdge.Widgets;

namespace StraightEdge
{
    public partial class SEWindow : Form
    {
        public SEControlPanel controlPanel;
        public SECanvas canvas;
        public SEToolBox toolbox;
        public SEStatusPanel statusPanel;
        public ToolTip SEToolTip;

        public SEDocument currentDoc;

        public SEWindow()
        {
            SEToolTip = new ToolTip();

            canvas = new SECanvas(this);
            canvas.Dock = DockStyle.Fill;
            this.Controls.Add(canvas);

            toolbox = new SEToolBox(this);
            toolbox.Dock = DockStyle.Left;
            this.Controls.Add(toolbox);

            controlPanel = new SEControlPanel(this);
            controlPanel.Dock = DockStyle.Top;
            this.Controls.Add(controlPanel);

            statusPanel = new SEStatusPanel(this);
            statusPanel.Dock = DockStyle.Bottom;
            this.Controls.Add(statusPanel);

            InitializeComponent();

            SEGraphic.registerShapes();

            SEDocument initDoc = new SEDocument(this, "untitled");      //start with a new blank graphic
            setCurrentDocument(initDoc);
        }

        public void setCurrentDocument(SEDocument doc)
        {
            currentDoc = doc;
            canvas.setGraphic(doc.graph);
            Text = "StraightEdge [" + doc.fileName + "]";
        }

//-----------------------------------------------------------------------------

        private void newFileMenuItem_Click(object sender, EventArgs e)
        {
            SEDocument newDoc = new SEDocument(this, "untitled");      //load a new blank graphic
            setCurrentDocument(newDoc);
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            //call get new graphic filename dialog box
            String filename = "";
            SEOpenFileDialog.InitialDirectory = Application.StartupPath;
            SEOpenFileDialog.DefaultExt = "*.rul";
            SEOpenFileDialog.Filter = "StraightEdge Illustration|*.rul|All files|*.*";
            SEOpenFileDialog.ShowDialog();
            filename = SEOpenFileDialog.FileName;
            if (filename.Length != 0)
            {
                SEDocument doc = SEDocument.loadFile(this, filename);
                setCurrentDocument(doc);
            }
        }

        public void saveDocument(bool newName)
        {
            String filename = "";
            if (newName || (currentDoc.fileName == null))
            {
                //call get save project filename dialog box
                SESaveFileDialog.InitialDirectory = Application.StartupPath;
                SESaveFileDialog.DefaultExt = "*.rul";
                SESaveFileDialog.Filter = "StraightEdge Illustration|*.rul|All files|*.*";
                SESaveFileDialog.ShowDialog();
                filename = SESaveFileDialog.FileName;
                if (filename.Length == 0) return;

                currentDoc.saveAs(filename);
            }
            else
            {
                currentDoc.save();
            }

            String msg = "Graphic has been saved as " + filename;
            MessageBox.Show(msg, "Save complete");
            Text = "StraightEdge [" + filename + "]";
        }

        private void saveFileMenuItem_Click(object sender, EventArgs e)
        {
            saveDocument(false);
        }

        private void saveAsFileMenuItem_Click(object sender, EventArgs e)
        {
            saveDocument(true);
        }

        private void exitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

//-----------------------------------------------------------------------------
        
        private void noEditExcuse()
        {
            String msg = "Editing hasn't been implemented yet\n" + "patience, young Grasshopper!\n";
            MessageBox.Show(msg, "About");
        }

        private void undoEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

        private void redoEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

        private void cutEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

        private void copyEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

        private void pasteEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

        private void selectAllEditMenuItem_Click(object sender, EventArgs e)
        {
            noEditExcuse();
        }

//-----------------------------------------------------------------------------

        private void aboutHelpMenuItem_Click(object sender, EventArgs e)
        {
            String msg = "StraightEdge\nversion 0.2.0\n" + "\xA9 Topographics Software 1998-2017\n" + "http://topographics.kohoutech.com";
            MessageBox.Show(msg, "About");
        }

//-----------------------------------------------------------------------------

        public void setTooltip(Control child, String tipText)
        {
            SEToolTip.SetToolTip(child, tipText);
        }

    }
}
