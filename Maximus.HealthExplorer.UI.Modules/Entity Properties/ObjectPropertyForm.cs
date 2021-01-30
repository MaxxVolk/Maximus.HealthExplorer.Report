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
        pgManagedObject.SelectedObject = entity;
      }
    }
  }
}
