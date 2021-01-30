using Microsoft.EnterpriseManagement.ConsoleFramework;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maximus.HealthExplorer.UI.Modules
{
  public partial class HealthExplorerReportForm : ConsoleForm
  {
    private HealthExplorerReportControl reportControl;
    public HealthExplorerReportForm(IContainer parentContainer) : base(parentContainer)
    {
      parentContainer?.Add(this);
      //System.IServiceProvider serviceProvider = (System.IServiceProvider)parentContainer;
      
      InitializeComponent();
      if (!DesignMode)
      {
        IsConsoleMaximized = false;
        reportControl = (HealthExplorerReportControl)SetDisplayPanelType(typeof(HealthExplorerReportControl));
      }
    }
  }
}
