using BehzadDara.AutoEndpoints.Attributes;
using System.ComponentModel;

namespace SampleUsage.Enums;

[EnumEndpoint("/StatusTypes")]
public enum StatusEnum
{
    [Description("This is an Active option")]
    [Info("backgroundColor", "#EDF7F4")]
    [Info("borderColor", "#E1F4EE")]
    [Info("textColor", "#1F8361")]
    Active = 1,

    [Description("This is a Deactive option")]
    [Info("backgroundColor", "#F5F5F7")]
    [Info("borderColor", "#E6EAF0")]
    [Info("textColor", "#636873")]
    Diactive = 2,
}
