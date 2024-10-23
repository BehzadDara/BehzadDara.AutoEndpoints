namespace BehzadDara.AutoEndpoints.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
public sealed class InfoAttribute(string name, object value) : Attribute
{
    public string Name { get; } = name;
    public object Value { get; } = value;
}
