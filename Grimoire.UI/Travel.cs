using Grimoire.Botting;
using Grimoire.Botting.Commands.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grimoire.UI
{
    public class Travel : Form
    {
        private IContainer components;

        private Button btnDage;

        private Button btnEscherion;

        private Button btnNulgath;

        private Button btnSwindle;

        private Button btnTaro;

        private Button btnTwins;

        private Button btnTercess;

        private GroupBox grpTravel;

        private NumericUpDown numPriv;

        private CheckBox chkPriv;
        private Button btnPolish;
        private Button btnLae;
        private Button btnCarnage;
        private Button btnBinky;

        public static Travel Instance
        {
            get;
        }

        private Travel()
        {
            InitializeComponent();
        }

        private void Travel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void chkPriv_CheckedChanged(object sender, EventArgs e)
        {
            numPriv.Enabled = chkPriv.Checked;
        }

        private void btnTercess_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim")
            });
        }

        private void btnTwins_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Twins", "Left")
            });
        }

        private void btnTaro_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Taro", "Left")
            });
        }

        private void btnSwindle_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Swindle", "Left")
            });
        }

        private void btnNulgath_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "Boss2", "Right")
            });
        }

        private void btnEscherion_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("escherion", "Boss", "Left")
            });
        }

        private void btnDage_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("underworld", "s1", "Left")
            });
        }

        private CmdTravel CreateJoinCommand(string map, string cell = "Enter", string pad = "Spawn")
        {
            return new CmdTravel
            {
                Map = chkPriv.Checked ? (map + $"-{numPriv.Value}") : map,
                Cell = cell,
                Pad = pad
            };
        }

        private async void ExecuteTravel(List<IBotCommand> cmds)
        {
            grpTravel.Enabled = false;
            foreach (IBotCommand cmd in cmds)
            {
                await cmd.Execute(null);
                await Task.Delay(1000);
            }
            if (InvokeRequired)
            {
                Invoke((Action)delegate
                {
                    grpTravel.Enabled = true;
                });
            }
            else
            {
                grpTravel.Enabled = true;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Travel));
            this.btnDage = new Button();
            this.btnEscherion = new Button();
            this.btnBinky = new Button();
            this.btnNulgath = new Button();
            this.btnSwindle = new Button();
            this.btnTaro = new Button();
            this.btnTwins = new Button();
            this.btnTercess = new Button();
            this.grpTravel = new GroupBox();
            this.numPriv = new NumericUpDown();
            this.chkPriv = new CheckBox();
            this.btnCarnage = new Button();
            this.btnLae = new Button();
            this.btnPolish = new Button();
            this.grpTravel.SuspendLayout();
            ((ISupportInitialize)this.numPriv).BeginInit();
            this.SuspendLayout();
            // 
            // btnDage
            // 
            this.btnDage.Location = new System.Drawing.Point(6, 305);
            this.btnDage.Name = "btnDage";
            this.btnDage.Size = new System.Drawing.Size(152, 23);
            this.btnDage.TabIndex = 0;
            this.btnDage.Text = "Dage";
            this.btnDage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDage.UseVisualStyleBackColor = true;
            this.btnDage.Click += new EventHandler(this.btnDage_Click);
            // 
            // btnEscherion
            // 
            this.btnEscherion.Location = new System.Drawing.Point(6, 334);
            this.btnEscherion.Name = "btnEscherion";
            this.btnEscherion.Size = new System.Drawing.Size(152, 23);
            this.btnEscherion.TabIndex = 1;
            this.btnEscherion.Text = "Escherion";
            this.btnEscherion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEscherion.UseVisualStyleBackColor = true;
            this.btnEscherion.Click += new EventHandler(this.btnEscherion_Click);
            // 
            // btnBinky
            // 
            this.btnBinky.Location = new System.Drawing.Point(6, 276);
            this.btnBinky.Name = "btnBinky";
            this.btnBinky.Size = new System.Drawing.Size(152, 23);
            this.btnBinky.TabIndex = 2;
            this.btnBinky.Text = "Binky (doomvault)";
            this.btnBinky.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBinky.UseVisualStyleBackColor = true;
            this.btnBinky.Click += new EventHandler(this.btnBinky_Click);
            // 
            // btnNulgath
            // 
            this.btnNulgath.Location = new System.Drawing.Point(6, 160);
            this.btnNulgath.Name = "btnNulgath";
            this.btnNulgath.Size = new System.Drawing.Size(152, 23);
            this.btnNulgath.TabIndex = 3;
            this.btnNulgath.Text = "Nulgath / Skew (tercess)";
            this.btnNulgath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNulgath.UseVisualStyleBackColor = true;
            this.btnNulgath.Click += new EventHandler(this.btnNulgath_Click);
            // 
            // btnSwindle
            // 
            this.btnSwindle.Location = new System.Drawing.Point(6, 131);
            this.btnSwindle.Name = "btnSwindle";
            this.btnSwindle.Size = new System.Drawing.Size(152, 23);
            this.btnSwindle.TabIndex = 4;
            this.btnSwindle.Text = "Swindle (tercess)";
            this.btnSwindle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwindle.UseVisualStyleBackColor = true;
            this.btnSwindle.Click += new EventHandler(this.btnSwindle_Click);
            // 
            // btnTaro
            // 
            this.btnTaro.Location = new System.Drawing.Point(6, 102);
            this.btnTaro.Name = "btnTaro";
            this.btnTaro.Size = new System.Drawing.Size(152, 23);
            this.btnTaro.TabIndex = 5;
            this.btnTaro.Text = "VHL/Taro/Zee (tercess)";
            this.btnTaro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaro.UseVisualStyleBackColor = true;
            this.btnTaro.Click += new EventHandler(this.btnTaro_Click);
            // 
            // btnTwins
            // 
            this.btnTwins.Location = new System.Drawing.Point(6, 73);
            this.btnTwins.Name = "btnTwins";
            this.btnTwins.Size = new System.Drawing.Size(152, 23);
            this.btnTwins.TabIndex = 6;
            this.btnTwins.Text = "Twins (tercess)";
            this.btnTwins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTwins.UseVisualStyleBackColor = true;
            this.btnTwins.Click += new EventHandler(this.btnTwins_Click);
            // 
            // btnTercess
            // 
            this.btnTercess.Location = new System.Drawing.Point(6, 44);
            this.btnTercess.Name = "btnTercess";
            this.btnTercess.Size = new System.Drawing.Size(152, 23);
            this.btnTercess.TabIndex = 7;
            this.btnTercess.Text = "Oblivion (tercess)";
            this.btnTercess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTercess.UseVisualStyleBackColor = true;
            this.btnTercess.Click += new EventHandler(this.btnTercess_Click);
            // 
            // grpTravel
            // 
            this.grpTravel.Controls.Add(this.numPriv);
            this.grpTravel.Controls.Add(this.btnPolish);
            this.grpTravel.Controls.Add(this.btnLae);
            this.grpTravel.Controls.Add(this.btnCarnage);
            this.grpTravel.Controls.Add(this.btnDage);
            this.grpTravel.Controls.Add(this.btnEscherion);
            this.grpTravel.Controls.Add(this.btnBinky);
            this.grpTravel.Controls.Add(this.btnNulgath);
            this.grpTravel.Controls.Add(this.btnSwindle);
            this.grpTravel.Controls.Add(this.btnTaro);
            this.grpTravel.Controls.Add(this.btnTwins);
            this.grpTravel.Controls.Add(this.btnTercess);
            this.grpTravel.Controls.Add(this.chkPriv);
            this.grpTravel.Location = new System.Drawing.Point(13, 13);
            this.grpTravel.Name = "grpTravel";
            this.grpTravel.Size = new System.Drawing.Size(164, 365);
            this.grpTravel.TabIndex = 8;
            this.grpTravel.TabStop = false;
            this.grpTravel.Text = "Fast travels";
            // 
            // numPriv
            // 
            this.numPriv.Enabled = false;
            this.numPriv.Location = new System.Drawing.Point(64, 18);
            this.numPriv.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPriv.Name = "numPriv";
            this.numPriv.Size = new System.Drawing.Size(94, 20);
            this.numPriv.TabIndex = 1;
            this.numPriv.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // chkPriv
            // 
            this.chkPriv.AutoSize = true;
            this.chkPriv.Location = new System.Drawing.Point(6, 19);
            this.chkPriv.Name = "chkPriv";
            this.chkPriv.Size = new System.Drawing.Size(59, 17);
            this.chkPriv.TabIndex = 0;
            this.chkPriv.Text = "Private";
            this.chkPriv.UseVisualStyleBackColor = true;
            this.chkPriv.CheckedChanged += new EventHandler(this.chkPriv_CheckedChanged);
            // 
            // btnCarnage
            // 
            this.btnCarnage.Location = new System.Drawing.Point(6, 218);
            this.btnCarnage.Name = "btnCarnage";
            this.btnCarnage.Size = new System.Drawing.Size(152, 23);
            this.btnCarnage.TabIndex = 0;
            this.btnCarnage.Text = "Carnage / Ninja (tercess)";
            this.btnCarnage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCarnage.UseVisualStyleBackColor = true;
            this.btnCarnage.Click += new EventHandler(this.btnCarnage_Click);
            // 
            // btnLae
            // 
            this.btnLae.Location = new System.Drawing.Point(6, 247);
            this.btnLae.Name = "btnLae";
            this.btnLae.Size = new System.Drawing.Size(152, 23);
            this.btnLae.TabIndex = 0;
            this.btnLae.Text = "Lae (tercess)";
            this.btnLae.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLae.UseVisualStyleBackColor = true;
            this.btnLae.Click += new EventHandler(this.btnLae_Click);
            // 
            // btnPolish
            // 
            this.btnPolish.Location = new System.Drawing.Point(6, 189);
            this.btnPolish.Name = "btnPolish";
            this.btnPolish.Size = new System.Drawing.Size(152, 23);
            this.btnPolish.TabIndex = 0;
            this.btnPolish.Text = "Polish (tercess)";
            this.btnPolish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPolish.UseVisualStyleBackColor = true;
            this.btnPolish.Click += new EventHandler(this.btnPolish_Click);
            // 
            // Travel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 390);
            this.Controls.Add(this.grpTravel);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Travel";
            this.Text = "Fast travels";
            this.TopMost = true;
            this.FormClosing += new FormClosingEventHandler(this.Travel_FormClosing);
            this.grpTravel.ResumeLayout(false);
            this.grpTravel.PerformLayout();
            ((ISupportInitialize)this.numPriv).EndInit();
            this.ResumeLayout(false);

        }

        static Travel()
        {
            Instance = new Travel();
        }

        private void btnBinky_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("doomvault", "r5", "Left")
            });
        }

        private void btnCarnage_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "m4", "Top")
            });
        }

        private void btnLae_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "m5", "Top")
            });
        }

        private void btnPolish_Click(object sender, EventArgs e)
        {
            ExecuteTravel(new List<IBotCommand>
            {
                CreateJoinCommand("citadel", "m22", "Left"),
                CreateJoinCommand("tercessuinotlim", "m12", "Top")
            });
        }
    }
}