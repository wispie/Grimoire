namespace Grimoire.UI
{
    partial class CosmeticForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CosmeticForm));
            this.cbPlayer = new System.Windows.Forms.ComboBox();
            this.btnGrabCosm = new System.Windows.Forms.Button();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnCopyAll = new System.Windows.Forms.Button();
            this.btnEquipSelected = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.linkHelm = new System.Windows.Forms.LinkLabel();
            this.linkArmor = new System.Windows.Forms.LinkLabel();
            this.linkWeapon = new System.Windows.Forms.LinkLabel();
            this.linkPet = new System.Windows.Forms.LinkLabel();
            this.linkCape = new System.Windows.Forms.LinkLabel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.linkClass = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArmor1 = new System.Windows.Forms.TextBox();
            this.txtHelm1 = new System.Windows.Forms.TextBox();
            this.txtWeapon1 = new System.Windows.Forms.TextBox();
            this.txtClass1 = new System.Windows.Forms.TextBox();
            this.txtCape1 = new System.Windows.Forms.TextBox();
            this.txtPet1 = new System.Windows.Forms.TextBox();
            this.btnHelmSet = new System.Windows.Forms.Button();
            this.btnArmorSet = new System.Windows.Forms.Button();
            this.btnClassSet = new System.Windows.Forms.Button();
            this.btnWeaponSet = new System.Windows.Forms.Button();
            this.btnPetSet = new System.Windows.Forms.Button();
            this.btnCapeSet = new System.Windows.Forms.Button();
            this.txtHelm2 = new System.Windows.Forms.TextBox();
            this.txtArmor2 = new System.Windows.Forms.TextBox();
            this.txtClass2 = new System.Windows.Forms.TextBox();
            this.txtWeapon2 = new System.Windows.Forms.TextBox();
            this.txtPet2 = new System.Windows.Forms.TextBox();
            this.txtCape2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtOff2 = new System.Windows.Forms.TextBox();
            this.txtOff1 = new System.Windows.Forms.TextBox();
            this.btnSetOffhand = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveSet = new System.Windows.Forms.Button();
            this.btnLoadSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPlayer
            // 
            this.cbPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlayer.FormattingEnabled = true;
            this.cbPlayer.Location = new System.Drawing.Point(42, 14);
            this.cbPlayer.Name = "cbPlayer";
            this.cbPlayer.Size = new System.Drawing.Size(220, 21);
            this.cbPlayer.TabIndex = 0;
            // 
            // btnGrabCosm
            // 
            this.btnGrabCosm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabCosm.Location = new System.Drawing.Point(264, 13);
            this.btnGrabCosm.Name = "btnGrabCosm";
            this.btnGrabCosm.Size = new System.Drawing.Size(94, 23);
            this.btnGrabCosm.TabIndex = 1;
            this.btnGrabCosm.Text = "Grab";
            this.btnGrabCosm.UseVisualStyleBackColor = true;
            this.btnGrabCosm.Click += new System.EventHandler(this.btnGrabCosm_Click);
            // 
            // lbItems
            // 
            this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(12, 245);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(466, 199);
            this.lbItems.TabIndex = 2;
            this.lbItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbItems_KeyDown);
            this.lbItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbItems_MouseDoubleClick);
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopyAll.Location = new System.Drawing.Point(3, 3);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(110, 23);
            this.btnCopyAll.TabIndex = 4;
            this.btnCopyAll.Text = "Equip All";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // btnEquipSelected
            // 
            this.btnEquipSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEquipSelected.Location = new System.Drawing.Point(119, 3);
            this.btnEquipSelected.Name = "btnEquipSelected";
            this.btnEquipSelected.Size = new System.Drawing.Size(110, 23);
            this.btnEquipSelected.TabIndex = 5;
            this.btnEquipSelected.Text = "Equip Selected";
            this.btnEquipSelected.UseVisualStyleBackColor = true;
            this.btnEquipSelected.Click += new System.EventHandler(this.btnEquipSelected_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnCopyAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEquipSelected, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 448);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 29);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(235, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(351, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(112, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // linkHelm
            // 
            this.linkHelm.AutoSize = true;
            this.linkHelm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkHelm.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkHelm.Location = new System.Drawing.Point(3, 0);
            this.linkHelm.Name = "linkHelm";
            this.linkHelm.Size = new System.Drawing.Size(70, 14);
            this.linkHelm.TabIndex = 8;
            this.linkHelm.TabStop = true;
            this.linkHelm.Text = "Grab Helm";
            this.linkHelm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkHelm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // linkArmor
            // 
            this.linkArmor.AutoSize = true;
            this.linkArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkArmor.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkArmor.Location = new System.Drawing.Point(79, 0);
            this.linkArmor.Name = "linkArmor";
            this.linkArmor.Size = new System.Drawing.Size(71, 14);
            this.linkArmor.TabIndex = 8;
            this.linkArmor.TabStop = true;
            this.linkArmor.Text = "Grab Armor";
            this.linkArmor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkArmor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // linkWeapon
            // 
            this.linkWeapon.AutoSize = true;
            this.linkWeapon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkWeapon.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkWeapon.Location = new System.Drawing.Point(232, 0);
            this.linkWeapon.Name = "linkWeapon";
            this.linkWeapon.Size = new System.Drawing.Size(73, 14);
            this.linkWeapon.TabIndex = 8;
            this.linkWeapon.TabStop = true;
            this.linkWeapon.Text = "Grab Wep";
            this.linkWeapon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkWeapon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // linkPet
            // 
            this.linkPet.AutoSize = true;
            this.linkPet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkPet.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkPet.Location = new System.Drawing.Point(311, 0);
            this.linkPet.Name = "linkPet";
            this.linkPet.Size = new System.Drawing.Size(70, 14);
            this.linkPet.TabIndex = 8;
            this.linkPet.TabStop = true;
            this.linkPet.Text = "Grab Pet";
            this.linkPet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkPet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // linkCape
            // 
            this.linkCape.AutoSize = true;
            this.linkCape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkCape.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkCape.Location = new System.Drawing.Point(387, 0);
            this.linkCape.Name = "linkCape";
            this.linkCape.Size = new System.Drawing.Size(72, 14);
            this.linkCape.TabIndex = 8;
            this.linkCape.TabStop = true;
            this.linkCape.Text = "Grab Cape";
            this.linkCape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkCape.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "⟳";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // linkClass
            // 
            this.linkClass.AutoSize = true;
            this.linkClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkClass.LinkColor = System.Drawing.SystemColors.ControlText;
            this.linkClass.Location = new System.Drawing.Point(156, 0);
            this.linkClass.Name = "linkClass";
            this.linkClass.Size = new System.Drawing.Size(70, 14);
            this.linkClass.TabIndex = 8;
            this.linkClass.TabStop = true;
            this.linkClass.Text = "Grab Class";
            this.linkClass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkItems_LinkClicked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.50471F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83479F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5047F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.1464F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5047F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5047F));
            this.tableLayoutPanel2.Controls.Add(this.linkHelm, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkArmor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkCape, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkClass, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkPet, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkWeapon, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(462, 14);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "Helm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Armor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Class";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Weapon";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Pet";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cape";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtArmor1
            // 
            this.txtArmor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArmor1.Location = new System.Drawing.Point(60, 26);
            this.txtArmor1.Margin = new System.Windows.Forms.Padding(2);
            this.txtArmor1.Name = "txtArmor1";
            this.txtArmor1.Size = new System.Drawing.Size(185, 20);
            this.txtArmor1.TabIndex = 12;
            // 
            // txtHelm1
            // 
            this.txtHelm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelm1.Location = new System.Drawing.Point(60, 2);
            this.txtHelm1.Margin = new System.Windows.Forms.Padding(2);
            this.txtHelm1.Name = "txtHelm1";
            this.txtHelm1.Size = new System.Drawing.Size(185, 20);
            this.txtHelm1.TabIndex = 12;
            // 
            // txtWeapon1
            // 
            this.txtWeapon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWeapon1.Location = new System.Drawing.Point(60, 74);
            this.txtWeapon1.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeapon1.Name = "txtWeapon1";
            this.txtWeapon1.Size = new System.Drawing.Size(185, 20);
            this.txtWeapon1.TabIndex = 12;
            // 
            // txtClass1
            // 
            this.txtClass1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClass1.Location = new System.Drawing.Point(60, 50);
            this.txtClass1.Margin = new System.Windows.Forms.Padding(2);
            this.txtClass1.Name = "txtClass1";
            this.txtClass1.Size = new System.Drawing.Size(185, 20);
            this.txtClass1.TabIndex = 12;
            // 
            // txtCape1
            // 
            this.txtCape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCape1.Location = new System.Drawing.Point(60, 146);
            this.txtCape1.Margin = new System.Windows.Forms.Padding(2);
            this.txtCape1.Name = "txtCape1";
            this.txtCape1.Size = new System.Drawing.Size(185, 20);
            this.txtCape1.TabIndex = 12;
            // 
            // txtPet1
            // 
            this.txtPet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPet1.Location = new System.Drawing.Point(60, 122);
            this.txtPet1.Margin = new System.Windows.Forms.Padding(2);
            this.txtPet1.Name = "txtPet1";
            this.txtPet1.Size = new System.Drawing.Size(185, 20);
            this.txtPet1.TabIndex = 12;
            // 
            // btnHelmSet
            // 
            this.btnHelmSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelmSet.Location = new System.Drawing.Point(364, 1);
            this.btnHelmSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnHelmSet.Name = "btnHelmSet";
            this.btnHelmSet.Size = new System.Drawing.Size(101, 22);
            this.btnHelmSet.TabIndex = 1;
            this.btnHelmSet.Text = "Set";
            this.btnHelmSet.UseVisualStyleBackColor = true;
            this.btnHelmSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnArmorSet
            // 
            this.btnArmorSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArmorSet.Location = new System.Drawing.Point(364, 25);
            this.btnArmorSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnArmorSet.Name = "btnArmorSet";
            this.btnArmorSet.Size = new System.Drawing.Size(101, 22);
            this.btnArmorSet.TabIndex = 1;
            this.btnArmorSet.Text = "Set";
            this.btnArmorSet.UseVisualStyleBackColor = true;
            this.btnArmorSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClassSet
            // 
            this.btnClassSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClassSet.Location = new System.Drawing.Point(364, 49);
            this.btnClassSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnClassSet.Name = "btnClassSet";
            this.btnClassSet.Size = new System.Drawing.Size(101, 22);
            this.btnClassSet.TabIndex = 1;
            this.btnClassSet.Text = "Set";
            this.btnClassSet.UseVisualStyleBackColor = true;
            this.btnClassSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnWeaponSet
            // 
            this.btnWeaponSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWeaponSet.Location = new System.Drawing.Point(364, 73);
            this.btnWeaponSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnWeaponSet.Name = "btnWeaponSet";
            this.btnWeaponSet.Size = new System.Drawing.Size(101, 22);
            this.btnWeaponSet.TabIndex = 1;
            this.btnWeaponSet.Text = "Set";
            this.btnWeaponSet.UseVisualStyleBackColor = true;
            this.btnWeaponSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnPetSet
            // 
            this.btnPetSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPetSet.Location = new System.Drawing.Point(364, 121);
            this.btnPetSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnPetSet.Name = "btnPetSet";
            this.btnPetSet.Size = new System.Drawing.Size(101, 22);
            this.btnPetSet.TabIndex = 1;
            this.btnPetSet.Text = "Set";
            this.btnPetSet.UseVisualStyleBackColor = true;
            this.btnPetSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnCapeSet
            // 
            this.btnCapeSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapeSet.Location = new System.Drawing.Point(364, 145);
            this.btnCapeSet.Margin = new System.Windows.Forms.Padding(1);
            this.btnCapeSet.Name = "btnCapeSet";
            this.btnCapeSet.Size = new System.Drawing.Size(101, 22);
            this.btnCapeSet.TabIndex = 1;
            this.btnCapeSet.Text = "Set";
            this.btnCapeSet.UseVisualStyleBackColor = true;
            this.btnCapeSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtHelm2
            // 
            this.txtHelm2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelm2.Location = new System.Drawing.Point(249, 2);
            this.txtHelm2.Margin = new System.Windows.Forms.Padding(2);
            this.txtHelm2.Name = "txtHelm2";
            this.txtHelm2.Size = new System.Drawing.Size(112, 20);
            this.txtHelm2.TabIndex = 13;
            // 
            // txtArmor2
            // 
            this.txtArmor2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArmor2.Location = new System.Drawing.Point(249, 26);
            this.txtArmor2.Margin = new System.Windows.Forms.Padding(2);
            this.txtArmor2.Name = "txtArmor2";
            this.txtArmor2.Size = new System.Drawing.Size(112, 20);
            this.txtArmor2.TabIndex = 13;
            // 
            // txtClass2
            // 
            this.txtClass2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClass2.Location = new System.Drawing.Point(249, 50);
            this.txtClass2.Margin = new System.Windows.Forms.Padding(2);
            this.txtClass2.Name = "txtClass2";
            this.txtClass2.Size = new System.Drawing.Size(112, 20);
            this.txtClass2.TabIndex = 13;
            // 
            // txtWeapon2
            // 
            this.txtWeapon2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWeapon2.Location = new System.Drawing.Point(249, 74);
            this.txtWeapon2.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeapon2.Name = "txtWeapon2";
            this.txtWeapon2.Size = new System.Drawing.Size(112, 20);
            this.txtWeapon2.TabIndex = 13;
            // 
            // txtPet2
            // 
            this.txtPet2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPet2.Location = new System.Drawing.Point(249, 122);
            this.txtPet2.Margin = new System.Windows.Forms.Padding(2);
            this.txtPet2.Name = "txtPet2";
            this.txtPet2.Size = new System.Drawing.Size(112, 20);
            this.txtPet2.TabIndex = 13;
            // 
            // txtCape2
            // 
            this.txtCape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCape2.Location = new System.Drawing.Point(249, 146);
            this.txtCape2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCape2.Name = "txtCape2";
            this.txtCape2.Size = new System.Drawing.Size(112, 20);
            this.txtCape2.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.06897F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.93103F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel3.Controls.Add(this.btnCapeSet, 3, 6);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtCape1, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtPet1, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtCape2, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtClass1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnPetSet, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtPet2, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtClass2, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtArmor1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtHelm1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnClassSet, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtArmor2, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnArmorSet, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnHelmSet, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtHelm2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtWeapon1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtWeapon2, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnWeaponSet, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtOff2, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtOff1, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnSetOffhand, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 67);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(466, 168);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // txtOff2
            // 
            this.txtOff2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOff2.Location = new System.Drawing.Point(249, 98);
            this.txtOff2.Margin = new System.Windows.Forms.Padding(2);
            this.txtOff2.Name = "txtOff2";
            this.txtOff2.Size = new System.Drawing.Size(112, 20);
            this.txtOff2.TabIndex = 13;
            // 
            // txtOff1
            // 
            this.txtOff1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOff1.Location = new System.Drawing.Point(60, 98);
            this.txtOff1.Margin = new System.Windows.Forms.Padding(2);
            this.txtOff1.Name = "txtOff1";
            this.txtOff1.Size = new System.Drawing.Size(185, 20);
            this.txtOff1.TabIndex = 12;
            // 
            // btnSetOffhand
            // 
            this.btnSetOffhand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetOffhand.Location = new System.Drawing.Point(364, 97);
            this.btnSetOffhand.Margin = new System.Windows.Forms.Padding(1);
            this.btnSetOffhand.Name = "btnSetOffhand";
            this.btnSetOffhand.Size = new System.Drawing.Size(101, 22);
            this.btnSetOffhand.TabIndex = 1;
            this.btnSetOffhand.Text = "Set";
            this.btnSetOffhand.UseVisualStyleBackColor = true;
            this.btnSetOffhand.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Off.H";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveSet
            // 
            this.btnSaveSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSet.Location = new System.Drawing.Point(359, 13);
            this.btnSaveSet.Name = "btnSaveSet";
            this.btnSaveSet.Size = new System.Drawing.Size(59, 23);
            this.btnSaveSet.TabIndex = 15;
            this.btnSaveSet.Text = "Save";
            this.btnSaveSet.UseVisualStyleBackColor = true;
            this.btnSaveSet.Click += new System.EventHandler(this.btnSaveSet_Click);
            // 
            // btnLoadSet
            // 
            this.btnLoadSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSet.Location = new System.Drawing.Point(419, 13);
            this.btnLoadSet.Name = "btnLoadSet";
            this.btnLoadSet.Size = new System.Drawing.Size(59, 23);
            this.btnLoadSet.TabIndex = 15;
            this.btnLoadSet.Text = "Load";
            this.btnLoadSet.UseVisualStyleBackColor = true;
            this.btnLoadSet.Click += new System.EventHandler(this.btnLoadSet_Click);
            // 
            // CosmeticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 484);
            this.Controls.Add(this.btnLoadSet);
            this.Controls.Add(this.btnSaveSet);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.btnGrabCosm);
            this.Controls.Add(this.cbPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CosmeticForm";
            this.Text = "SWF Cosmetics";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CosmeticForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPlayer;
        private System.Windows.Forms.Button btnGrabCosm;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnCopyAll;
        private System.Windows.Forms.Button btnEquipSelected;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.LinkLabel linkHelm;
        private System.Windows.Forms.LinkLabel linkArmor;
        private System.Windows.Forms.LinkLabel linkWeapon;
        private System.Windows.Forms.LinkLabel linkPet;
        private System.Windows.Forms.LinkLabel linkCape;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.LinkLabel linkClass;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArmor1;
        private System.Windows.Forms.TextBox txtHelm1;
        private System.Windows.Forms.TextBox txtWeapon1;
        private System.Windows.Forms.TextBox txtClass1;
        private System.Windows.Forms.TextBox txtCape1;
        private System.Windows.Forms.TextBox txtPet1;
        private System.Windows.Forms.Button btnHelmSet;
        private System.Windows.Forms.Button btnArmorSet;
        private System.Windows.Forms.Button btnClassSet;
        private System.Windows.Forms.Button btnWeaponSet;
        private System.Windows.Forms.Button btnPetSet;
        private System.Windows.Forms.Button btnCapeSet;
        private System.Windows.Forms.TextBox txtHelm2;
        private System.Windows.Forms.TextBox txtArmor2;
        private System.Windows.Forms.TextBox txtClass2;
        private System.Windows.Forms.TextBox txtWeapon2;
        private System.Windows.Forms.TextBox txtPet2;
        private System.Windows.Forms.TextBox txtCape2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSaveSet;
        private System.Windows.Forms.Button btnLoadSet;
        private System.Windows.Forms.TextBox txtOff2;
        private System.Windows.Forms.TextBox txtOff1;
        private System.Windows.Forms.Button btnSetOffhand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemove;
    }
}