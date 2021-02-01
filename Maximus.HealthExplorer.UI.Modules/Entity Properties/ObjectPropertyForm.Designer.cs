
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
      this.pCommands = new System.Windows.Forms.Panel();
      this.btClose = new System.Windows.Forms.Button();
      this.btGetGroups = new System.Windows.Forms.Button();
      this.btGetClasses = new System.Windows.Forms.Button();
      this.btGetMAP = new System.Windows.Forms.Button();
      this.btGetMonitors = new System.Windows.Forms.Button();
      this.btGetRules = new System.Windows.Forms.Button();
      this.pCommands.SuspendLayout();
      this.SuspendLayout();
      // 
      // pgManagedObject
      // 
      this.pgManagedObject.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgManagedObject.Location = new System.Drawing.Point(0, 0);
      this.pgManagedObject.Name = "pgManagedObject";
      this.pgManagedObject.Size = new System.Drawing.Size(515, 676);
      this.pgManagedObject.TabIndex = 0;
      // 
      // pCommands
      // 
      this.pCommands.Controls.Add(this.btGetRules);
      this.pCommands.Controls.Add(this.btGetMonitors);
      this.pCommands.Controls.Add(this.btGetMAP);
      this.pCommands.Controls.Add(this.btGetClasses);
      this.pCommands.Controls.Add(this.btGetGroups);
      this.pCommands.Controls.Add(this.btClose);
      this.pCommands.Dock = System.Windows.Forms.DockStyle.Right;
      this.pCommands.Location = new System.Drawing.Point(515, 0);
      this.pCommands.Name = "pCommands";
      this.pCommands.Size = new System.Drawing.Size(200, 676);
      this.pCommands.TabIndex = 1;
      // 
      // btClose
      // 
      this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btClose.Location = new System.Drawing.Point(6, 641);
      this.btClose.Name = "btClose";
      this.btClose.Size = new System.Drawing.Size(182, 23);
      this.btClose.TabIndex = 0;
      this.btClose.Text = "Close";
      this.btClose.UseVisualStyleBackColor = true;
      // 
      // btGetGroups
      // 
      this.btGetGroups.Location = new System.Drawing.Point(6, 12);
      this.btGetGroups.Name = "btGetGroups";
      this.btGetGroups.Size = new System.Drawing.Size(182, 23);
      this.btGetGroups.TabIndex = 1;
      this.btGetGroups.Text = "Get Groups";
      this.btGetGroups.UseVisualStyleBackColor = true;
      // 
      // btGetClasses
      // 
      this.btGetClasses.Location = new System.Drawing.Point(6, 41);
      this.btGetClasses.Name = "btGetClasses";
      this.btGetClasses.Size = new System.Drawing.Size(182, 23);
      this.btGetClasses.TabIndex = 2;
      this.btGetClasses.Text = "Get Classes";
      this.btGetClasses.UseVisualStyleBackColor = true;
      // 
      // btGetMAP
      // 
      this.btGetMAP.Location = new System.Drawing.Point(6, 70);
      this.btGetMAP.Name = "btGetMAP";
      this.btGetMAP.Size = new System.Drawing.Size(182, 23);
      this.btGetMAP.TabIndex = 3;
      this.btGetMAP.Text = "Get MAP";
      this.btGetMAP.UseVisualStyleBackColor = true;
      // 
      // btGetMonitors
      // 
      this.btGetMonitors.Location = new System.Drawing.Point(6, 99);
      this.btGetMonitors.Name = "btGetMonitors";
      this.btGetMonitors.Size = new System.Drawing.Size(182, 23);
      this.btGetMonitors.TabIndex = 4;
      this.btGetMonitors.Text = "Get Monitors";
      this.btGetMonitors.UseVisualStyleBackColor = true;
      // 
      // btGetRules
      // 
      this.btGetRules.Location = new System.Drawing.Point(6, 128);
      this.btGetRules.Name = "btGetRules";
      this.btGetRules.Size = new System.Drawing.Size(182, 23);
      this.btGetRules.TabIndex = 5;
      this.btGetRules.Text = "Get Rules";
      this.btGetRules.UseVisualStyleBackColor = true;
      this.btGetRules.Click += new System.EventHandler(this.btGetRules_Click);
      // 
      // ObjectPropertyForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btClose;
      this.ClientSize = new System.Drawing.Size(715, 676);
      this.Controls.Add(this.pgManagedObject);
      this.Controls.Add(this.pCommands);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ObjectPropertyForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Extended Entity Properties";
      this.pCommands.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PropertyGrid pgManagedObject;
    private System.Windows.Forms.Panel pCommands;
    private System.Windows.Forms.Button btGetMAP;
    private System.Windows.Forms.Button btGetClasses;
    private System.Windows.Forms.Button btGetGroups;
    private System.Windows.Forms.Button btClose;
    private System.Windows.Forms.Button btGetRules;
    private System.Windows.Forms.Button btGetMonitors;
  }
}