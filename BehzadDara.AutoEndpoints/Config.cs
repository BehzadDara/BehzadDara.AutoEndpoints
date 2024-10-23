using BehzadDara.AutoEndpoints.Attributes;
using BehzadDara.AutoEndpoints.ViewModels;
using BehzadDara.BaseResult;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;

namespace BehzadDara.AutoEndpoints;

public static class Config
{
    public static void UsingEnumEndpoints(this WebApplication app, Assembly assembly)
    {
        var enumTypes = assembly.GetTypes()
            .Where(t => t.IsEnum && t.GetCustomAttributes(typeof(EnumEndpointAttribute), false).Length != 0)
            .ToList();

        foreach (var enumType in enumTypes)
        {
            var attribute = (enumType.GetCustomAttribute(typeof(EnumEndpointAttribute)) as EnumEndpointAttribute)!;
            var route = attribute.Route;

            app.MapGet(route, () =>
            {
                var enumValues = Enum.GetValues(enumType)
                                     .Cast<Enum>()
                                     .Select(e => new EnumViewModel(e))
                                     .ToList();

                return Result.Success(enumValues);
            })
            .WithMetadata(new SwaggerOperationAttribute($"Get {enumType.Name} values"))
            .WithTags("Enum Endpoints")
            .WithMetadata(new SwaggerResponseAttribute(StatusCodes.Status200OK, "Retrieved", typeof(List<EnumViewModel>)));
        }
    }
}
