using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.ConsoleFramework;
using Microsoft.EnterpriseManagement.Instrumentation.ErrorHandling;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.ConsoleFramework;
using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;
using Microsoft.EnterpriseManagement.Tracing;
using Microsoft.Internal.ManagedWPP;
using Microsoft.Practices.Unity;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Maximus.HealthExplorer.UI.Modules
{
  [Export]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  [ComponentBuildUpRequired]
  public class ObjectPropertyTask : INotifyPropertyChanged, INotifyInitialized
  {
    private string connectionSessionTicket;
    private IDataObject entity;
    private bool notified;

    [Dependency]
    public IDataGateway Gateway { get; set; }

    [Dependency]
    public IDisplayErrorService ErrorService { get; set; }

    [Dependency]
    public ISite Site { get; set; }

    /*
    <Property Name="ConnectionSessionTicket" Direction="In">
      <Reference>$Service/ConnectionSessionTicket$</Reference>
    </Property>
    */
    public string ConnectionSessionTicket
    {
      get => connectionSessionTicket;
      set
      {
        try
        {
          connectionSessionTicket = value;
          RunTask();
          OnPropertyChanged(nameof(ConnectionSessionTicket));
        }
        catch { }
      }
    }

    public IDataObject Entity
    {
      get => entity;
      set
      {
        try
        {
          entity = value;
          RunTask();
          OnPropertyChanged(nameof(Entity));
        }
        catch { }
      }
    }

    private void OnPropertyChanged(string propertyName)
    {
      try
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      catch { }
    }

    private void RunTask()
    {
      if (!notified || ConnectionSessionTicket == null || Entity == null)
        return;
      if (Site.GetService(typeof(IManagementGroupServerSession)) is IManagementGroupServerSession mgSession)
      {
        Guid mgId = Guid.Empty;
        Dictionary<Guid, ManagementGroup> mgDictionary = new Dictionary<Guid, ManagementGroup>
        {
          { Guid.Empty, mgSession.ManagementGroup },
          { mgSession.ManagementGroup.Id, mgSession.ManagementGroup }
        };
        Guid? monitoringObjectId = new Guid?();
        if (Entity["Id"] != null)
        {
          monitoringObjectId = new Guid?(new Guid(Entity["Id"].ToString()));
          if (Entity["ManagementGroupId"] != null && Guid.TryParse(Entity["ManagementGroupId"].ToString(), out mgId))
          {
            if (!mgDictionary.ContainsKey(mgId))
            {
              if (Site.GetService(typeof(ICredentialManager)) is ICredentialManager credentialManager)
              {
                if (Site.GetService(typeof(IDashboardGateway)) is IDashboardGateway dashboardGateway)
                {
                  IList<ManagementGroup> managementGroups = dashboardGateway.GetTieredManagementGroups(mgSession.ManagementGroup, credentialManager);
                  if (managementGroups != null)
                  {
                    foreach (ManagementGroup managementGroup in managementGroups)
                      mgDictionary.Add(managementGroup.Id, managementGroup);
                  }
                }
              }
            }
          }
          else
            mgId = Guid.Empty;
        }
        if (!monitoringObjectId.HasValue)
          return;
        MonitoringObject mo = null;
        if (!ConsoleJobs.RunJob(Site.Component, delegate
        {
          ManagementGroup managementGroup = mgDictionary[mgId];
          if (managementGroup == null)
            return;
          mo = managementGroup.EntityObjects.GetObject<MonitoringObject>(monitoringObjectId.Value, ObjectQueryOptions.Default);
        }).JobSucceeded || mo == null)
          return;
        using (ObjectPropertyForm pf = new ObjectPropertyForm())
        {
          Site.Container.Add(pf);
          pf.Entity = mo;
          pf.ShowDialog();
        }
      }
    }

    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region INotifyInitialized implementation
    public void Notify()
    {
      try
      {
        notified = true;
        RunTask();
      }
      catch { }
    }
    #endregion

  }
}
