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
        private Bitmap preview;

        public ColorBand()
        {
            InitializeComponent();
            currColor = Color.Black;
            preview = new Bitmap(4, 4);
            colorPrev.SizeMode = PictureBoxSizeMode.StretchImage;
            colorPrev.Refresh();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            dlg_colorSelector.ShowDialog();
            currColor = dlg_colorSelector.Color;

            for (int x = 0; x < preview.Width; x++)
            {
                for (int y = 0; y < preview.Height; y++)
                {
                    preview.SetPixel(x, y, currColor);
                }
            }
            colorPrev.Image = preview;
            colorPrev.Refresh();
        }

        private void updown_min_ValueChanged(object sender, EventArgs e)
        {
            if (updown_max.Value < updown_min.Value)
            {
                updown_max.Value = updown_min.Value;
            }

            updown_max.Minimum = updown_min.Value;
        }

        private void updown_max_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
