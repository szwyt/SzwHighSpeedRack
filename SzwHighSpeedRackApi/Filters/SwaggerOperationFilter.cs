using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SzwHighSpeedRackApi
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters = operation.Parameters ?? new List<OpenApiParameter>();
            var info = context.MethodInfo;
            context.ApiDescription.TryGetMethodInfo(out info);
            try
            {
                Attribute attribute = info.GetCustomAttribute(typeof(AuthorizeAttribute));
                if (attribute != null)
                {
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Description = "access_token",
                        Required = true
                    });
                }
            }
            catch
            { }
        }
    }
}