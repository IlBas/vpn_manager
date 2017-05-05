namespace VpnManager
{
    partial class AssemblyInfo
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
            this.components = new System.ComponentModel.Container();
            this.dtAssembli = new System.Windows.Forms.DataGridView();
            this.infoDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtAssembli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtAssembli
            // 
            this.dtAssembli.AllowUserToAddRows = false;
            this.dtAssembli.AllowUserToDeleteRows = false;
            this.dtAssembli.AutoGenerateColumns = false;
            this.dtAssembli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAssembli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.infoDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dtAssembli.DataSource = this.infoDtoBindingSource;
            this.dtAssembli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtAssembli.Location = new System.Drawing.Point(0, 0);
            this.dtAssembli.Name = "dtAssembli";
            this.dtAssembli.ReadOnly = true;
            this.dtAssembli.Size = new System.Drawing.Size(787, 179);
            this.dtAssembli.TabIndex = 0;
            // 
            // infoDtoBindingSource
            // 
            this.infoDtoBindingSource.DataSource = typeof(Core.DTO.InfoDto);
            // 
            // infoDataGridViewTextBoxColumn
            // 
            this.infoDataGridViewTextBoxColumn.DataPropertyName = "Info";
            this.infoDataGridViewTextBoxColumn.HeaderText = "Assembly Name";
            this.infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            this.infoDataGridViewTextBoxColumn.ReadOnly = true;
            this.infoDataGridViewTextBoxColumn.Width = 300;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Version";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 300;
            // 
            // AssemblyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 179);
            this.Controls.Add(this.dtAssembli);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AssemblyInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssembliInfo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AssemblyInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtAssembli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtAssembli;
        private System.Windows.Forms.BindingSource infoDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn infoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}