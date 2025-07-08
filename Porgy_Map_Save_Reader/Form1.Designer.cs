namespace Porgy_Map_Save_Reader
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BtnOpen = new Button();
            VariableHeader = new ColumnHeader();
            ValueHeader = new ColumnHeader();
            label1 = new Label();
            labelFuel = new Label();
            labelTorpedo = new Label();
            labelEgg = new Label();
            labelEquipment = new Label();
            labelItemsFound = new Label();
            SuspendLayout();
            // 
            // BtnOpen
            // 
            BtnOpen.Location = new Point(21, 20);
            BtnOpen.Margin = new Padding(2);
            BtnOpen.Name = "BtnOpen";
            BtnOpen.Size = new Size(111, 37);
            BtnOpen.TabIndex = 1;
            BtnOpen.Text = "Open Save";
            BtnOpen.UseVisualStyleBackColor = true;
            BtnOpen.Click += BtnOpen_Click;
            // 
            // VariableHeader
            // 
            VariableHeader.Text = "Variable";
            VariableHeader.Width = 200;
            // 
            // ValueHeader
            // 
            ValueHeader.Text = "Value";
            ValueHeader.Width = 150;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(152, 26);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 25);
            label1.TabIndex = 6;
            label1.Text = "No save file currently open";
            // 
            // labelFuel
            // 
            labelFuel.AutoSize = true;
            labelFuel.Font = new Font("Segoe UI", 9F);
            labelFuel.Location = new Point(53, 127);
            labelFuel.Margin = new Padding(2, 0, 2, 0);
            labelFuel.Name = "labelFuel";
            labelFuel.Size = new Size(164, 25);
            labelFuel.TabIndex = 7;
            labelFuel.Text = "Fuel Tanks Found: 0 / 20";
            // 
            // labelTorpedo
            // 
            labelTorpedo.AutoSize = true;
            labelTorpedo.Font = new Font("Segoe UI", 9F);
            labelTorpedo.Location = new Point(53, 164);
            labelTorpedo.Margin = new Padding(2, 0, 2, 0);
            labelTorpedo.Name = "labelTorpedo";
            labelTorpedo.Size = new Size(198, 25);
            labelTorpedo.TabIndex = 8;
            labelTorpedo.Text = "Torpedos Found: 0 / 20";
            // 
            // labelEgg
            // 
            labelEgg.AutoSize = true;
            labelEgg.Font = new Font("Segoe UI", 9F);
            labelEgg.Location = new Point(53, 200);
            labelEgg.Margin = new Padding(2, 0, 2, 0);
            labelEgg.Name = "labelEgg";
            labelEgg.Size = new Size(163, 25);
            labelEgg.TabIndex = 9;
            labelEgg.Text = "Eggs Found: 0 / 20";
            // 
            // labelEquipment
            // 
            labelEquipment.AutoSize = true;
            labelEquipment.Font = new Font("Segoe UI", 9F);
            labelEquipment.Location = new Point(53, 236);
            labelEquipment.Margin = new Padding(2, 0, 2, 0);
            labelEquipment.Name = "labelEquipment";
            labelEquipment.Size = new Size(218, 25);
            labelEquipment.TabIndex = 10;
            labelEquipment.Text = "Equipment Found: 0 / 20";
            // 
            // labelItemsFound
            // 
            labelItemsFound.AutoSize = true;
            labelItemsFound.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelItemsFound.Location = new Point(31, 80);
            labelItemsFound.Margin = new Padding(2, 0, 2, 0);
            labelItemsFound.Name = "labelItemsFound";
            labelItemsFound.Size = new Size(205, 32);
            labelItemsFound.TabIndex = 10;
            labelItemsFound.Text = "Items Found: 0%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1016, 283);
            Controls.Add(labelItemsFound);
            Controls.Add(labelFuel);
            Controls.Add(labelTorpedo);
            Controls.Add(labelEgg);
            Controls.Add(labelEquipment);
            Controls.Add(label1);
            Controls.Add(BtnOpen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Porgy Map Save Reader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOpen;
        private ColumnHeader VariableHeader;
        private ColumnHeader ValueHeader;
        private Label label1;
        private Label labelFuel;
        private Label labelTorpedo;
        private Label labelEgg;
        private Label labelEquipment;
        private Label labelItemsFound;
    }
}
