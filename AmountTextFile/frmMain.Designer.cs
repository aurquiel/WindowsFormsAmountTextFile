namespace AmountTextFile
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openDGV = new System.Windows.Forms.DataGridView();
            this.formatedDGV = new System.Windows.Forms.DataGridView();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openTextButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderSavingTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectFolderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatedDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDGV
            // 
            this.openDGV.AllowUserToAddRows = false;
            this.openDGV.AllowUserToDeleteRows = false;
            this.openDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.openDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openDGV.Location = new System.Drawing.Point(3, 43);
            this.openDGV.Name = "openDGV";
            this.openDGV.ReadOnly = true;
            this.openDGV.Size = new System.Drawing.Size(501, 540);
            this.openDGV.TabIndex = 1;
            // 
            // formatedDGV
            // 
            this.formatedDGV.AllowUserToAddRows = false;
            this.formatedDGV.AllowUserToDeleteRows = false;
            this.formatedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.formatedDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatedDGV.Location = new System.Drawing.Point(570, 43);
            this.formatedDGV.Name = "formatedDGV";
            this.formatedDGV.ReadOnly = true;
            this.formatedDGV.Size = new System.Drawing.Size(502, 540);
            this.formatedDGV.TabIndex = 2;
            // 
            // storeComboBox
            // 
            this.storeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "1000",
            "2000"});
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Items.AddRange(new object[] {
            "1000",
            "2000"});
            this.storeComboBox.Location = new System.Drawing.Point(197, 9);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(208, 21);
            this.storeComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione Almacen:";
            // 
            // openTextButton
            // 
            this.openTextButton.Image = global::AmountTextFile.Properties.Resources.open;
            this.openTextButton.Location = new System.Drawing.Point(510, 43);
            this.openTextButton.Name = "openTextButton";
            this.openTextButton.Size = new System.Drawing.Size(54, 46);
            this.openTextButton.TabIndex = 0;
            this.openTextButton.UseVisualStyleBackColor = true;
            this.openTextButton.Click += new System.EventHandler(this.openTextButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectFolderButton);
            this.panel1.Controls.Add(this.folderSavingTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.storeComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 74);
            this.panel1.TabIndex = 5;
            // 
            // folderSavingTextBox
            // 
            this.folderSavingTextBox.Location = new System.Drawing.Point(411, 43);
            this.folderSavingTextBox.Name = "folderSavingTextBox";
            this.folderSavingTextBox.ReadOnly = true;
            this.folderSavingTextBox.Size = new System.Drawing.Size(327, 20);
            this.folderSavingTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Carpeta de Guardado:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 586);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.openDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.openTextButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.formatedDGV, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 586);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Archivo de Texto Original";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(570, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(502, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "Archivos de Texto Cortados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolderButton.Location = new System.Drawing.Point(197, 41);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(208, 23);
            this.selectFolderButton.TabIndex = 7;
            this.selectFolderButton.Text = "Seleccionar...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 660);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texto Articulos SAP";
            ((System.ComponentModel.ISupportInitialize)(this.openDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formatedDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openTextButton;
        private System.Windows.Forms.DataGridView openDGV;
        private System.Windows.Forms.DataGridView formatedDGV;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox folderSavingTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectFolderButton;
    }
}

