namespace Grimoire.UI
{
    partial class CommandColorForm
    {

        public static CommandColorForm Instance = new CommandColorForm();
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandColorForm));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSetColor = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRandomColors = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtRGB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSetColor
            // 
            this.btnSetColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSetColor.Location = new System.Drawing.Point(20, 57);
            this.btnSetColor.Name = "btnSetColor";
            this.btnSetColor.Size = new System.Drawing.Size(209, 21);
            this.btnSetColor.TabIndex = 4;
            this.btnSetColor.Text = "Set Color of Selected";
            this.btnSetColor.UseVisualStyleBackColor = true;
            this.btnSetColor.Click += new System.EventHandler(this.btnLabelColor_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(54, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Set Selected to Centered";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.Location = new System.Drawing.Point(20, 114);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(210, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 60;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(20, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(209, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Size";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRandomColors
            // 
            this.btnRandomColors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRandomColors.Location = new System.Drawing.Point(20, 182);
            this.btnRandomColors.Name = "btnRandomColors";
            this.btnRandomColors.Size = new System.Drawing.Size(209, 23);
            this.btnRandomColors.TabIndex = 7;
            this.btnRandomColors.Text = "Random Colors based on RGB";
            this.btnRandomColors.UseVisualStyleBackColor = true;
            this.btnRandomColors.Click += new System.EventHandler(this.btnRandomColors_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(209, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(20, 21);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtRGB
            // 
            this.txtRGB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRGB.Location = new System.Drawing.Point(20, 210);
            this.txtRGB.Name = "txtRGB";
            this.txtRGB.Size = new System.Drawing.Size(209, 20);
            this.txtRGB.TabIndex = 9;
            this.txtRGB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CommandColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 256);
            this.Controls.Add(this.txtRGB);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRandomColors);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnSetColor);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommandColorForm";
            this.Text = "Colors";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandColorForm_FormClosing);
            this.Load += new System.EventHandler(this.CommandColorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSetColor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRandomColors;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtRGB;
    }
}