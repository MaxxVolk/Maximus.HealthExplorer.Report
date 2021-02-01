
namespace Maximus.HealthExplorer.UI.Modules
{
  partial class GridDisplayForm
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
      this.pControl = new System.Windows.Forms.Panel();
      this.btClose = new System.Windows.Forms.Button();
      this.dataGridView = new System.Windows.Forms.DataGridView();
      this.pControl.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // pControl
      // 
      this.pControl.Controls.Add(this.btClose);
      this.pControl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pControl.Location = new System.Drawing.Point(0, 495);
      this.pControl.Name = "pControl";
      this.pControl.Size = new System.Drawing.Size(929, 48);
      this.pControl.TabIndex = 0;
      // 
      // btClose
      // 
      this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btClose.Location = new System.Drawing.Point(842, 13);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(75, 23);
      this.btClose.TabIndex = 0;
      this.btClose.Text = "Close";
      this.btClose.UseVisualStyleBackColor = true;
      // 
      // dataGridView
      // 
      this.dataGridView.AllowUserToAddRows = false;
      this.dataGridView.AllowUserToDeleteRows = false;
      this.dataGridView.AllowUserToOrderColumns = true;
      this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView.Location = new System.Drawing.Point(0, 0);
      this.dataGridView.Name = "dataGridView";
      this.dataGridView.ReadOnly = true;
      this.dataGridView.Size = new System.Drawing.Size(929, 495);
      this.dataGridView.TabIndex = 1;
      // 
      // GridDisplayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btClose;
      this.ClientSize = new System.Drawing.Size(929, 543);
      this.Controls.Add(this.dataGridView);
      this.Controls.Add(this.pControl);
      this.Name = "GridDisplayForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.pControl.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pControl;
    private System.Windows.Forms.Button btClose;
    private System.Windows.Forms.DataGridView dataGridView;
  }
}