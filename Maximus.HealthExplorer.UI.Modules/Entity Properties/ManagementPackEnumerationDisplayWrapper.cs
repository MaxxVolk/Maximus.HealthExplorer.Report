using Microsoft.EnterpriseManagement.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.HealthExplorer.UI.Modules
{
  public class ManagementPackEnumerationDisplayWrapper
  {
    public ManagementPackEnumeration ManagementPackEnumeration;

    public ManagementPackEnumerationDisplayWrapper(ManagementPackEnumeration mpEnum)
    {
      ManagementPackEnumeration = mpEnum;
    }

    public override string ToString()
    {
      return ManagementPackEnumeration.DisplayName ?? ManagementPackEnumeration.Name;
    }

    public string FullDisplayName => $"{ManagementPackEnumeration.DisplayName ?? ManagementPackEnumeration.Name} ({ManagementPackEnumeration.Description ?? ""})";

    public Guid Id => ManagementPackEnumeration.Id;
  }
}
