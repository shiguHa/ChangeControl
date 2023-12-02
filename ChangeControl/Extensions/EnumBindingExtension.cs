using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;

namespace ChangeControl.Extensions;

//[MarkupExtensionReturnType(ReturnType = typeof(List<string>))]
public class EnumBindingExtension : MarkupExtension
{
    public   Type EnumType;

    public EnumBindingExtension(Type enumType)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException($"{enumType} is not enum.");
        }

        EnumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
    }

    protected override object ProvideValue(IXamlServiceProvider serviceProvider)
    {
        if (EnumType == null)
            throw new InvalidOperationException("The EnumType must be specified.");

        return Enum.GetValues(EnumType);
    }
}
