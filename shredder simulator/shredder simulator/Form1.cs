using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace shredder_simulator
{
    public partial class shredsimForm : Form
    {

        public shredsimForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileTextbox.Text = dlg.FileName;
                }
            }
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    folderTextbox.Text = dlg.SelectedPath;
                }
            }
        }

        private void shredButton_Click(object sender, EventArgs e)
        {
            Shredder shredder = new Shredder(this);
            shredder.makeSliceMap();
            shredder.separateSliceMap();
        }

        public string getImageLocation()
        {
            return this.fileTextbox.Text;
        }

        public string getFolderDest()
        {
            return this.folderTextbox.Text;
        }

        public int getVertSlice()
        {
            return (int)vertUpDown.Value;
        }

        public int getHorSlice()
        {
            return (int)horUpDown.Value;
        }
    }
}
