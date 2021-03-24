using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class RawCommandEditor : Form
    {
        private IContainer components;

        private Button btnOK;

        private Button btnCancel;

        private TextBox txtCmd;

        public string Input => txtCmd.Text;

        public string Content
        {
            set
            {
                txtCmd.Text = value;
            }
        }

        private RawCommandEditor()
        {
            InitializeComponent();
        }

        private void RawCommandEditor_Load(object sender, EventArgs e)
        {
            txtCmd.Select();
        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    btnOK.PerformClick();
                    break;

                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        public static string Show(string content)
        {
            using (RawCommandEditor rawCommandEditor = new RawCommandEditor
            {
                Content = content
            })
            {
                return (rawCommandEditor.ShowDialog() == DialogResult.OK) ? rawCommandEditor.Input : null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RawCommandEditor));
            btnOK = new Button();
            btnCancel = new Button();
            txtCmd = new TextBox();
            SuspendLayout();
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(197, 166);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(116, 166);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            txtCmd.Location = new System.Drawing.Point(12, 12);
            txtCmd.Multiline = true;
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new System.Drawing.Size(260, 148);
            txtCmd.TabIndex = 2;
            txtCmd.KeyDown += new KeyEventHandler(txtCmd_KeyDown);
            AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(284, 201);
            Controls.Add(txtCmd);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "RawCommandEditor";
            Text = "Raw Command Editor";
            TopMost = true;
            Load += new EventHandler(RawCommandEditor_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}