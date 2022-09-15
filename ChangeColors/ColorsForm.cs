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
    public partial class ColorsForm : Form
    {
        public event ColorEventHandler ColorChange;

        public delegate void ColorEventHandler(Color color);

        public Color SelectedColor
        {
            get
            {
                if (redRadioButton.Checked)
                    return Color.Red;
                else if (blueRadioButton.Checked)
                    return Color.Blue;
                else if (greenRadioButton.Checked)
                    return Color.Green;
                else
                    return colorDialog1.Color;
            }

            set
            {
                if (value == Color.Red)
                    redRadioButton.Select();
                else if (value == Color.Blue)
                    blueRadioButton.Select();
                else if (value == Color.Green)
                    greenRadioButton.Select();
                else
                {
                    colorDialog1.Color = value;
                    otherRadioButton.ForeColor = colorDialog1.Color;
                    otherRadioButton.Select();
                }
            }
        }

        public ColorsForm()
        {
            InitializeComponent();
        }
                
        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // All three radio buttons use the same function
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ColorChange != null)
            {
                RadioButton btn = (RadioButton)sender;
                if (btn.Checked)
                {
                    if (btn.Text == "Red")
                        ColorChange(Color.Red);
                    else if (btn.Text == "Blue")
                        ColorChange(Color.Blue);
                    else if (btn.Text == "Green")
                        ColorChange(Color.Green);
                }
            }
        }

        private void otherRadioButton_Click(object sender, EventArgs e)
        {
            if (ColorChange != null && colorDialog1.ShowDialog() == DialogResult.OK)
            {
                otherRadioButton.ForeColor = colorDialog1.Color;
                ColorChange(colorDialog1.Color);
            }
        }
    }
}
