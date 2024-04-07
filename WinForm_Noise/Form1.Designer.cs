namespace WinForm_Noise
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            MapDisplayBox = new PictureBox();
            btn_generate = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MapDisplayBox).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(MapDisplayBox);
            groupBox1.Location = new Point(288, 12);
            groupBox1.MinimumSize = new Size(500, 400);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 400);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // MapDisplayBox
            // 
            MapDisplayBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MapDisplayBox.Location = new Point(3, 3);
            MapDisplayBox.Name = "MapDisplayBox";
            MapDisplayBox.Size = new Size(475, 375);
            MapDisplayBox.TabIndex = 0;
            MapDisplayBox.TabStop = false;
            // 
            // btn_generate
            // 
            btn_generate.Location = new Point(157, 389);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(104, 23);
            btn_generate.TabIndex = 1;
            btn_generate.Text = "Generate Map";
            btn_generate.UseVisualStyleBackColor = true;
            btn_generate.Click += btn_generate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_generate);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MapDisplayBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox MapDisplayBox;
        private Button btn_generate;
    }
}
