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
            label1 = new Label();
            tb_octaves = new TextBox();
            tb_persistance = new TextBox();
            label2 = new Label();
            tb_lacunarity = new TextBox();
            label3 = new Label();
            btn_process1 = new Button();
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
            btn_generate.Location = new Point(122, 120);
            btn_generate.Name = "btn_generate";
            btn_generate.Size = new Size(104, 23);
            btn_generate.TabIndex = 1;
            btn_generate.Text = "Generate Map";
            btn_generate.UseVisualStyleBackColor = true;
            btn_generate.Click += btn_generate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 27);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Octaves:";
            // 
            // tb_octaves
            // 
            tb_octaves.Location = new Point(126, 24);
            tb_octaves.Name = "tb_octaves";
            tb_octaves.Size = new Size(100, 23);
            tb_octaves.TabIndex = 3;
            tb_octaves.TextChanged += tb_octaves_TextChanged;
            // 
            // tb_persistance
            // 
            tb_persistance.Location = new Point(126, 53);
            tb_persistance.Name = "tb_persistance";
            tb_persistance.Size = new Size(100, 23);
            tb_persistance.TabIndex = 5;
            tb_persistance.TextChanged += tb_persistance_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 56);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 4;
            label2.Text = "Persistance:";
            // 
            // tb_lacunarity
            // 
            tb_lacunarity.Location = new Point(126, 82);
            tb_lacunarity.Name = "tb_lacunarity";
            tb_lacunarity.Size = new Size(100, 23);
            tb_lacunarity.TabIndex = 7;
            tb_lacunarity.TextChanged += tb_lacunarity_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 85);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 6;
            label3.Text = "Lacunarity:";
            // 
            // btn_process1
            // 
            btn_process1.Location = new Point(122, 149);
            btn_process1.Name = "btn_process1";
            btn_process1.Size = new Size(104, 23);
            btn_process1.TabIndex = 8;
            btn_process1.Text = "Process 1";
            btn_process1.UseVisualStyleBackColor = true;
            btn_process1.Click += btn_process1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_process1);
            Controls.Add(tb_lacunarity);
            Controls.Add(label3);
            Controls.Add(tb_persistance);
            Controls.Add(label2);
            Controls.Add(tb_octaves);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox tb_octaves;
        private TextBox tb_persistance;
        private Label label2;
        private TextBox tb_lacunarity;
        private Label label3;
        private Button btn_process1;
    }
}
