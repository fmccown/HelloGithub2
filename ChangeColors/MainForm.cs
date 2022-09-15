using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChangeColors
{
    public partial class MainForm : Form
    {
        private ColorsForm colorsForm;

        public MainForm()
        {
            InitializeComponent();

            this.BackColor = Color.Red;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            // Comment
            if (colorsForm == null || colorsForm.IsDisposed)
            {
                colorsForm = new ColorsForm();
                colorsForm.SelectedColor = this.BackColor;

                colorsForm.ColorChange += ColorChanged;
                colorsForm.Show();
            }
            else
            {
                colorsForm.BringToFront();
            }                                 

            // Position the dialog close to the center of this window
            colorsForm.Left = this.Left + 40;
            colorsForm.Top = this.Top + 40;
        }

        public void ColorChanged(Color color)
        {
            this.BackColor = color;
        }
    }
}
