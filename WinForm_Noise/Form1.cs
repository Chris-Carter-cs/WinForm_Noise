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
            Random r = new Random();
            MapDisplayBox.Image = Generator.MapFromPerlinNoise(r.Next(), new int[] { 500, 400 });

        }
    }
}
