using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

namespace WinForm_Noise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            int octaves = int.Parse(tb_octaves.Text);
            float pers = float.Parse(tb_persistance.Text);
            float lacu = float.Parse(tb_lacunarity.Text);

            Random r = new Random();
            MapDisplayBox.Image = Generator.MapFromPerlinNoise(r.Next(), new int[] { 500, 400 }, octaves, lacu, pers);

        }

        private void btn_process1_Click(object sender, EventArgs e)
        {
            Bitmap buffer = (Bitmap)MapDisplayBox.Image;

            Bands bands = this.ControlToBands();

            MapDisplayBox.Image = Generator.ProcessHeightmap(buffer, bands);
        }

        private string prevOct = "";
        private int prevOctIndex = 0;
        private void tb_octaves_TextChanged(object sender, EventArgs e)
        {
            int dummy;
            if (!int.TryParse(tb_octaves.Text, out dummy))
            {
                tb_octaves.Text = prevOct;
                tb_octaves.SelectionStart = prevOctIndex;
            }
            else
            {
                prevOct = tb_octaves.Text;
                prevOctIndex = tb_octaves.SelectionStart;
            }
        }
        private string prevPer = "";
        private void tb_persistance_TextChanged(object sender, EventArgs e)
        {
            float dummy;
            if (!float.TryParse(tb_persistance.Text, out dummy))
            {
                tb_persistance.Text = prevPer;
            }
            else
            {
                prevPer = tb_persistance.Text;
            }
        }
        private string prevLacu = "";
        private void tb_lacunarity_TextChanged(object sender, EventArgs e)
        {
            float dummy;
            if (!float.TryParse(tb_lacunarity.Text, out dummy))
            {
                tb_lacunarity.Text = prevLacu;
            }
            else
            {
                prevLacu = tb_lacunarity.Text;
            }
        }

        int tableRow = 0;
        List<ColorBand> bands = new List<ColorBand>();
        private void btn_addBand_Click(object sender, EventArgs e)
        {
            ColorBand newBand = new ColorBand();
            newBand.Anchor = AnchorStyles.Top;
            bandTable.Controls.Add(newBand);
            bandTable.SetRow(newBand, tableRow);

            tableRow++;

            bandTable.RowCount++;
            foreach (RowStyle rs in bandTable.RowStyles)
            {
                rs.Height = 30;
            }

            bands.Add(newBand);
        }

        private Bands ControlToBands()
        {
            Bands b = new Bands();
            Stripe s;

            foreach (ColorBand cBand in bands)
            {
                byte min = ((byte)cBand.updown_min.Value);
                byte max = ((byte)cBand.updown_max.Value);
                s = new Stripe(min, max, cBand.currColor);

                b.AddStripe(s);
            }


            return b;
        }

        private void btn_removeBand_Click(object sender, EventArgs e)
        {
            foreach(ColorBand band in bands)
            {
                if(band.chk_selected.Checked)
                {
                    bandTable.Controls.Remove(band);
                    bands.Remove(band);
                }
            }
        }
    }
}
