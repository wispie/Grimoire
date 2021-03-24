namespace Grimoire.UI
{
    partial class Set
    {

        public static Set Instance = new Set();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Set));
            this.btnSave = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(10, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(352, 121);
            this.listBox1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(58, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(270, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(250, 355);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(270, 36);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 387);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Set";
            this.Text = "Set";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Set_FormClosing);
            this.Load += new System.EventHandler(this.Set_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;
    }
}