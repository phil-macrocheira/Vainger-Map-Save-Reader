namespace Vainger_Map_Save_Reader
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
            labelShield = new Label();
            labelStabilizer = new Label();
            labelClone = new Label();
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
            // labelShield
            // 
            labelShield.AutoSize = true;
            labelShield.Font = new Font("Segoe UI", 9F);
            labelShield.Location = new Point(53, 127);
            labelShield.Margin = new Padding(2, 0, 2, 0);
            labelShield.Name = "labelShield";
            labelShield.Size = new Size(180, 25);
            labelShield.TabIndex = 7;
            labelShield.Text = "Shields Found: 0 / 25";
            // 
            // labelStabilizer
            // 
            labelStabilizer.AutoSize = true;
            labelStabilizer.Font = new Font("Segoe UI", 9F);
            labelStabilizer.Location = new Point(53, 164);
            labelStabilizer.Margin = new Padding(2, 0, 2, 0);
            labelStabilizer.Name = "labelStabilizer";
            labelStabilizer.Size = new Size(192, 25);
            labelStabilizer.TabIndex = 8;
            labelStabilizer.Text = "Stabilizers Found: 0 / 2";
            // 
            // labelClone
            // 
            labelClone.AutoSize = true;
            labelClone.Font = new Font("Segoe UI", 9F);
            labelClone.Location = new Point(53, 200);
            labelClone.Margin = new Padding(2, 0, 2, 0);
            labelClone.Name = "labelClone";
            labelClone.Size = new Size(167, 25);
            labelClone.TabIndex = 9;
            labelClone.Text = "Clones Found: 0 / 3";
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
            ClientSize = new Size(1016, 264);
            Controls.Add(labelItemsFound);
            Controls.Add(labelClone);
            Controls.Add(labelStabilizer);
            Controls.Add(labelShield);
            Controls.Add(label1);
            Controls.Add(BtnOpen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Vainger Map Save Reader";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOpen;
        private ColumnHeader VariableHeader;
        private ColumnHeader ValueHeader;
        private Label label1;
        private Label labelShield;
        private Label labelStabilizer;
        private Label labelClone;
        private Label labelItemsFound;
    }
}
