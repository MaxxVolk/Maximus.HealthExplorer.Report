﻿
namespace Maximus.HealthExplorer.UI.Modules
{
  partial class ObjectPropertyForm
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
      this.pgManagedObject = new System.Windows.Forms.PropertyGrid();
      this.SuspendLayout();
      // 
      // pgManagedObject
      // 
      this.pgManagedObject.Location = new System.Drawing.Point(71, 45);
      this.pgManagedObject.Name = "pgManagedObject";
      this.pgManagedObject.Size = new System.Drawing.Size(395, 458);
      this.pgManagedObject.TabIndex = 0;
      // 
      // ObjectPropertyForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(715, 676);
      this.Controls.Add(this.pgManagedObject);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ObjectPropertyForm";
      this.Text = "ObjectPropertyForm";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PropertyGrid pgManagedObject;
  }
}