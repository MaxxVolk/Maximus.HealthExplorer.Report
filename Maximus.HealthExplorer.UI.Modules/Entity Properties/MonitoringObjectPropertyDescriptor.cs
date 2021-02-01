using Microsoft.EnterpriseManagement.Configuration;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maximus.HealthExplorer.UI.Modules
{
  public class MonitoringObjectPropertyDescriptor : PropertyDescriptor
  {
    public ManagementPackProperty ManagementPackProperty { get; } = null;
    public PropertyInfo PropertyInfo { get; } = null;
    public object DataMember { get; } = null;

    public MonitoringObjectPropertyDescriptor(ManagementPackProperty managementPackProperty, Attribute[] attributes) :base(managementPackProperty.DisplayName ?? managementPackProperty.Name, attributes)
    {
      ManagementPackProperty = managementPackProperty;
    }

    public MonitoringObjectPropertyDescriptor(PropertyInfo propertyInfo, Attribute[] attributes):base (propertyInfo.Name, attributes)
    {
      PropertyInfo = propertyInfo;
    }

    public MonitoringObjectPropertyDescriptor(string name, object dataMember, Attribute[] attributes) : base(name, attributes)
    {
      DataMember = dataMember;
    }

    public override Type ComponentType => typeof(MonitoringObjectTypeDescriptor);

    public override bool IsReadOnly => true;

    public override Type PropertyType
    {
      get
      {
        if (ManagementPackProperty != null )
        {
          if (ManagementPackProperty.SystemType == typeof(Enum))
            return typeof(ManagementPackEnumerationDisplayWrapper);
          else
            return ManagementPackProperty.SystemType;
        }
        if (PropertyInfo != null)
        {
          return PropertyInfo.PropertyType;
        }
        if (DataMember != null)
        {
          return DataMember.GetType();
        }
        return typeof(object);
      }
    }

    public override bool CanResetValue(object component) => false;

    public override object GetValue(object component)
    {
      if (ManagementPackProperty != null && component is MonitoringObjectTypeDescriptor moDescriptor1)
      {
        if (ManagementPackProperty.SystemType == typeof(Enum))
        {
          if (moDescriptor1[ManagementPackProperty].Value == null)
            return null;
          return new ManagementPackEnumerationDisplayWrapper((ManagementPackEnumeration)moDescriptor1[ManagementPackProperty].Value);
        }
        return moDescriptor1[ManagementPackProperty].Value;
      }
      if (PropertyInfo != null && component is MonitoringObjectTypeDescriptor moDescriptor2)
      {
        return PropertyInfo.GetValue(moDescriptor2.MonitoringObject);
      }
      return DataMember;
    }

    public override void ResetValue(object component) { }

    public override void SetValue(object component, object value) { }

    public override bool ShouldSerializeValue(object component) => false;
  }
}
