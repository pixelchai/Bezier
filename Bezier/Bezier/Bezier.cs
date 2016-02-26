using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class Bezier : Form
    {
        public Bezier()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            bezierDisplay1.incr = numericUpDown1.Value;
        }

        private void Bezier_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bezierDisplay1.helperlines = checkBox1.Checked;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            bezierDisplay1.thickness = (float)numericUpDown1.Value;
        }
    }
}
