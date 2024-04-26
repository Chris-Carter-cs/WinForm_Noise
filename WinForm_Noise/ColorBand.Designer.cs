namespace WinForm_Noise
{
    partial class ColorBand
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            updown_min = new NumericUpDown();
            updown_max = new NumericUpDown();
            label1 = new Label();
            dlg_colorSelector = new ColorDialog();
            btn_color = new Button();
            chk_selected = new CheckBox();
            colorPrev = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)updown_min).BeginInit();
            ((System.ComponentModel.ISupportInitialize)updown_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colorPrev).BeginInit();
            SuspendLayout();
            // 
            // updown_min
            // 
            updown_min.Location = new Point(65, 3);
            updown_min.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            updown_min.Name = "updown_min";
            updown_min.Size = new Size(50, 23);
            updown_min.TabIndex = 0;
            updown_min.ValueChanged += updown_min_ValueChanged;
            // 
            // updown_max
            // 
            updown_max.Location = new Point(121, 3);
            updown_max.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            updown_max.Name = "updown_max";
            updown_max.Size = new Size(50, 23);
            updown_max.TabIndex = 1;
            updown_max.ValueChanged += updown_max_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 2;
            label1.Text = "Min/Max";
            // 
            // btn_color
            // 
            btn_color.Location = new Point(200, 3);
            btn_color.Name = "btn_color";
            btn_color.Size = new Size(56, 23);
            btn_color.TabIndex = 3;
            btn_color.Text = "Color";
            btn_color.UseVisualStyleBackColor = true;
            btn_color.Click += btn_color_Click;
            // 
            // chk_selected
            // 
            chk_selected.AutoSize = true;
            chk_selected.Location = new Point(260, 7);
            chk_selected.Name = "chk_selected";
            chk_selected.Size = new Size(15, 14);
            chk_selected.TabIndex = 4;
            chk_selected.UseVisualStyleBackColor = true;
            // 
            // colorPrev
            // 
            colorPrev.Location = new Point(175, 3);
            colorPrev.Name = "colorPrev";
            colorPrev.Size = new Size(20, 20);
            colorPrev.TabIndex = 5;
            colorPrev.TabStop = false;
            // 
            // ColorBand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(colorPrev);
            Controls.Add(chk_selected);
            Controls.Add(btn_color);
            Controls.Add(label1);
            Controls.Add(updown_max);
            Controls.Add(updown_min);
            Name = "ColorBand";
            Size = new Size(281, 30);
            ((System.ComponentModel.ISupportInitialize)updown_min).EndInit();
            ((System.ComponentModel.ISupportInitialize)updown_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)colorPrev).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ColorDialog dlg_colorSelector;
        private Button btn_color;
        public CheckBox chk_selected;
        public NumericUpDown updown_min;
        public NumericUpDown updown_max;
        private PictureBox colorPrev;
    }
}
