using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.ConsoleFramework;
using Microsoft.EnterpriseManagement.Monitoring;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.HealthExplorer.UI.Modules
{
  public class HealthExplorerReportStartupContext : IStartupContext
  {
    public MonitoringObject Entiry { get; }
    public ConnectionStartupAction Startup { get; private set; }

    public HealthExplorerReportStartupContext(MonitoringObject mo)
    {
      Entiry = mo;
    }

    #region IStartupContext implementation
    public ISettingsStore Settings => null;

    public object AddAction(Type actionType)
    {
      if (actionType != typeof(ConnectionStartupAction))
        return null;
      Startup = new ConnectionStartupAction();
      return Startup;
    }

    public object GetAction(Type actionType) => null;
    #endregion
  }
}
