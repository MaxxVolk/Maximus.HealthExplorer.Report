using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Monitoring;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.HealthExplorer.UI.Modules
{
  public class MonitoringObjectTypeDescriptor : ICustomTypeDescriptor
  {
    public MonitoringObject MonitoringObject { get; }
    public MonitoringObjectTypeDescriptor(MonitoringObject monitoringObject)
    {
      MonitoringObject = monitoringObject;
    }
    public EnterpriseManagementSimpleObject this[ManagementPackProperty managementPackProperty] => MonitoringObject[managementPackProperty];

    #region ICustomTypeDescriptor implementation
    public AttributeCollection GetAttributes()=> new AttributeCollection(new Attribute[0]);

    public string GetClassName() => MonitoringObject.GetMostDerivedClasses().FirstOrDefault()?.DisplayName ?? MonitoringObject.GetMostDerivedClasses().FirstOrDefault()?.Name ?? "Unknown";

    public string GetComponentName() => MonitoringObject.DisplayName;

    public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);

    public EventDescriptor GetDefaultEvent() => null;

    public PropertyDescriptor GetDefaultProperty() => null;

    public object GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);

    public EventDescriptorCollection GetEvents() => new EventDescriptorCollection(new EventDescriptor[0]);

    public EventDescriptorCollection GetEvents(Attribute[] attributes) => new EventDescriptorCollection(new EventDescriptor[0]);

    public PropertyDescriptorCollection GetProperties()
    {
      PropertyDescriptorCollection result = new PropertyDescriptorCollection(new PropertyDescriptor[0]);
      ManagementGroup mg = MonitoringObject.ManagementGroup;

      // Synthetic properties
      result.Add(new MonitoringObjectPropertyDescriptor("LeastDerivedNonAbstractManagementPackClass",
        mg.EntityTypes.GetClass(MonitoringObject.LeastDerivedNonAbstractManagementPackClassId),
        new Attribute[] { new BrowsableAttribute(true), new ReadOnlyAttribute(true), new CategoryAttribute("Synthetic Properties"), new DisplayNameAttribute("Least Derived Non Abstract Management Pack Class") }));

      // SCOM Properties
      foreach (ManagementPackProperty mpProperty in MonitoringObject.GetProperties())
      {
        List<Attribute> attributes = new List<Attribute>() { new BrowsableAttribute(true), new ReadOnlyAttribute(true) };
        if (!string.IsNullOrWhiteSpace(mpProperty.Description))
          attributes.Add(new DescriptionAttribute(mpProperty.Description));
        if (mpProperty.ParentElement is ManagementPackClass parentClass)
        {
          attributes.Add(new CategoryAttribute($"SCOM Properties inherited from {parentClass.DisplayName ?? parentClass.Name}"));
        }
        result.Add(new MonitoringObjectPropertyDescriptor(mpProperty, attributes.ToArray()));
      }

      // .Net Properties
      foreach (PropertyInfo netProperty in MonitoringObject.GetType().GetProperties())
      {
        if (netProperty.Name == "Values") // not required -- will be listed as SCOM properties
          continue;
        if (netProperty.Name == "MonitoringClassIds") // obsolete, replaced by ManagementPackClassIds
          continue;
        if (netProperty.Name == "LeastDerivedNonAbstractMonitoringClassId") // obsolete, replaced by LeastDerivedNonAbstractManagementPackClassId
          continue;
        if (netProperty.Name == "Item") // Indexer [] property
          continue;
        List<Attribute> attributes = new List<Attribute>() { new BrowsableAttribute(true), new ReadOnlyAttribute(true), new CategoryAttribute(".Net Property") };
        if (netProperty.Name == "ManagementPackClassIds") // PropertyGrid cannot display IListm, but can display Collection
        {
          ReadOnlyCollection<Guid> data = new ReadOnlyCollection<Guid>(MonitoringObject.ManagementPackClassIds);
          result.Add(new MonitoringObjectPropertyDescriptor("ManagementPackClassIds", data, attributes.ToArray()));
          continue;
        }
        result.Add(new MonitoringObjectPropertyDescriptor(netProperty, attributes.ToArray()));
      }

      return result;
    }

    // no filtering
    public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => GetProperties();

    public object GetPropertyOwner(PropertyDescriptor pd) => this;
    #endregion
  }
}
