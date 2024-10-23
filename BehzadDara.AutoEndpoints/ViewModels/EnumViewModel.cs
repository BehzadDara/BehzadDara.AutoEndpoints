using BehzadDara.AutoEndpoints.Attributes;
using Humanizer;

namespace BehzadDara.AutoEndpoints.ViewModels;

public record EnumViewModel(
    int Key,
    string Value,
    string Description,
    IDictionary<string, object> Information
    )
{
    public EnumViewModel(Enum enumValue) : this((int)(object)enumValue, enumValue.ToString(), enumValue.Humanize(), GetEnumAttributes(enumValue))
    {
    }

    private static Dictionary<string, object> GetEnumAttributes(Enum enumValue)
    {
        var attributes = new Dictionary<string, object>();

        var enumType = enumValue.GetType();
        var enumField = enumType.GetField(enumValue.ToString());

        if (enumField is null)
            return attributes;

        var infoAttributes = enumField.GetCustomAttributes(false).Where(attr => attr is InfoAttribute);

        foreach (var infoAttribute in infoAttributes.Cast<InfoAttribute>())
        {
            attributes[infoAttribute!.Name] = infoAttribute!.Value;
        }

        return attributes;
    }

}

