using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Monitoring;

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
  public partial class ObjectPropertyForm : Form
  {
    private MonitoringObject entity;

    public ObjectPropertyForm()
    {
      InitializeComponent();
    }

    public MonitoringObject Entity
    {
      get
      {
        return entity;
      }
      set
      {
        entity = value;
        pgManagedObject.SelectedObject = new MonitoringObjectTypeDescriptor(value);
      }
    }

    private ManagementGroup _ManagementGroup = null;
    protected ManagementGroup ManagementGroup => _ManagementGroup ?? (_ManagementGroup = Entity?.ManagementGroup);

    private void btGetRules_Click(object sender, EventArgs e)
    {
      if (ManagementGroup == null) // also checks Entity != null
        return;
      IList<ManagementPackRule> allRules = ManagementGroup.Monitoring.GetRules(Entity, QueryCriteria<ManagementPackRuleCriteria>.Empty);
      using (GridDisplayForm gridDisplayForm = new GridDisplayForm())
      {
        gridDisplayForm.DataGridView.DataSource = new BindingSource { DataSource = allRules };
        gridDisplayForm.ShowDialog();
      }
    }
  }
}
