using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Converters;

namespace ChangeControl.Models;

[TypeConverter(typeof(EnumDescriptionTypeConverter))]
public enum ChangeComponentEnum
{
    [Description("製造方法")]
    Method,
    [Description("人")]
    Man,
    [Description("機械")]
    Machine,
    [Description("材料")]
    Material,
    [Description("測定/検査")]
    Measurement,
}

public class EnumForCheckBox<T> where T : Enum
{
    public T Value
    {
        get; set;
    }
    public string Description => GetEnumDescription(Value);
    public bool IsSelected
    {
        get; set;
    }

    private string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
}
