using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Noise
{

    public partial class ColorBand : UserControl
    {
        public Color currColor { get; private set; }

        public ColorBand()
        {
            InitializeComponent();
            currColor = Color.Black;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            dlg_colorSelector.ShowDialog();
            currColor = dlg_colorSelector.Color;
        }
    }
}
